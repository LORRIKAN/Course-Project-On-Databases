using LogisticsCenter.Model.DbModels;
using LogisticsCenter.Repository;
using LogisticsCenter.Views.Filling;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LogisticsCenter.Presenters.Filling
{
    public class FillingTransferOrderContentPresenter : FillingPresenter<TransferOrderContent>
    {
        public FillingTransferOrderContentPresenter(DatabaseContext context, IFillingForm fillingForm) :
            base(context, fillingForm)
        {

        }

        protected override string FillingForm_CheckProperty(string propertyName, object propertyValue)
        {
            Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var orderContent = ModelClone as TransferOrderContent;
            if (propertyName == nameof(orderContent.TransferOrderID))
            {
                var transferOrder = Context.TransferOrders.Find(propertyValue);
                if (transferOrder == null)
                    return "Такого заказа перемещения не существует";
                else
                    if (transferOrder.Status != OrderStatuses.AwaitingSendingDate)
                    return "Невозможно добавить ресурсы к заказу, не имеющему статус \"Ждёт дату отгрузки\".";
            }

            if (propertyName == nameof(orderContent.TransferOrderID) || propertyName == nameof(orderContent.ResourceID)
                || propertyName == nameof(orderContent.ResourceAmount))
            {
                if (orderContent.TransferOrderID != default && orderContent.ResourceID != default)
                {
                    var transferOrder = Context.TransferOrders.Find(orderContent.TransferOrderID);
                    var transferRoute = Context.TransferRoutes.Find(transferOrder.TransferRouteID);
                    var initialWarehouse = Context.StationaryWarehouses.Find(transferRoute.InitialWarehouseID);

                    if (!initialWarehouse.WarehouseID.StartsWith("С"))
                    {
                        return base.FillingForm_CheckProperty(propertyName, propertyValue);
                    }

                    try
                    {
                        var statStock = Context.StationaryStocks.Single(ss => ss.WarehouseID == initialWarehouse.WarehouseID);
                        if (orderContent.ResourceAmount != default)
                        {
                            var stockResAmount = statStock.ResourceAmount;
                            var sendingDate = Context.TransferOrders.Find(orderContent.TransferOrderID).SendingDate;

                            var transferOrdersWithThisInitialWarehouse = Context.TransferOrders
                                .Where(to => (to.Status == OrderStatuses.AwaitingSendingDate
                                || to.Status == OrderStatuses.AwaitingToBeSent)
                                && to.TransferRoute.InitialWarehouseID == initialWarehouse.WarehouseID
                                && to.OrderContent.Any(oc => oc.ResourceID == orderContent.ResourceID))
                                .AsNoTracking().ToList();

                            var transferOrdersWithThisFinalWarehouse = Context.TransferOrders
                                .Where(to => (to.Status == OrderStatuses.InTransit
                                || to.Status == OrderStatuses.AwaitingToBeReceived)
                                && to.ReceivingDate <= sendingDate
                                && to.TransferRoute.FinalWarehouseID == initialWarehouse.WarehouseID
                                && to.OrderContent.Any(oc => oc.ResourceID == orderContent.ResourceID))
                                .AsNoTracking().ToList();

                            foreach (var order in transferOrdersWithThisInitialWarehouse)
                                stockResAmount -= order.OrderContent
                                    .Single(oc => oc.ResourceID == orderContent.ResourceID).ResourceAmount;

                            foreach (var order in transferOrdersWithThisFinalWarehouse)
                                stockResAmount += order.OrderContent
                                    .Single(oc => oc.ResourceID == orderContent.ResourceID).ResourceAmount;

                            if (stockResAmount < 0)
                                return "На складе не хватает этого ресурса.";
                        }
                    }
                    catch { return "Такого ресурса на складе не зарегистрировано."; }
                }
            }
            return base.FillingForm_CheckProperty(propertyName, propertyValue);
        }
    }
}