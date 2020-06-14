using LogisticsCenter.Model.DbModels;
using LogisticsCenter.Model.ProgramModels;
using LogisticsCenter.Repository;
using LogisticsCenter.Views.MessageService;
using LogisticsCenter.Views.Table;
using System.Collections.Generic;
using System.Linq;
using System;

namespace LogisticsCenter.Presenters.Table
{
    public class TransferOrdersTablePresenter : TablePresenter<TransferOrder>
    {
        public TransferOrdersTablePresenter(IMessageService messageService, DatabaseContext context,
            ITransferOrdersTableForm tableForm) : base(messageService, context, tableForm)
        {
            TableForm = tableForm;
            base.TableForm = TableForm;
        }

        new ITransferOrdersTableForm TableForm { get; set; }

        protected override void SetEvents()
        {
            base.SetEvents();
            TableForm.ConfirmOrdersButtClick += (orders) => 
            {
                TableForm_ConfirmOrdersButtClick(orders);
                EnableFormsButts();
            };

            TableForm.FilterButtClick += () =>
            {
                FilterOrdersByWarehousemanID();
                EnableFormsButts();
            };
        }

        private void FilterOrdersByWarehousemanID()
        {
            TableForm.DataSource = (from to in ListOfEntities
                                    where (to.TransferRoute.InitialWarehouse.WarehousemanID == User.Login)
                                    || (to.TransferRoute.FinalWarehouse.WarehousemanID == User.Login)
                                    orderby to.Status
                                    select to).ToList();
        }

        private void TableForm_ConfirmOrdersButtClick(List<TransferOrder> orders)
        {
            var failed = new List<string>();
            foreach (var order in orders)
            {
                if (order.Status == OrderStatuses.AwaitingToBeSent
                    && User.Login == order.TransferRoute.InitialWarehouse.WarehousemanID)
                    ConfirmSending(order, failed);

                else if (order.Status == OrderStatuses.AwaitingToBeReceived
                    && User.Login == order.TransferRoute.FinalWarehouse.WarehousemanID)
                    ConfirmReceiving(order);

                else if (order.Status != OrderStatuses.AwaitingToBeSent && order.Status != OrderStatuses.AwaitingToBeReceived)
                    failed.Add($"ID: {order.OrderID} не имеет соответствующего статуса");

                else if (order.Status == OrderStatuses.AwaitingToBeSent
                    && User.Login != order.TransferRoute.InitialWarehouse.WarehousemanID)
                    failed.Add($"ID: {order.OrderID}. Вы не заведуете складом-отправителем этого заказа.");

                else if (order.Status == OrderStatuses.AwaitingToBeReceived
                    && User.Login != order.TransferRoute.FinalWarehouse.WarehousemanID)
                    failed.Add($"ID: {order.OrderID}. Вы не заведуете складом-получателем этого заказа.");
            }

            if (failed.Any())
            {
                var failureString = "Следующие заказы не были подтверждены:";
                foreach (var failure in failed)
                    failureString += NL + failure;

                MessageService.ShowExclamation(failureString);
            }

            TableForm.DataSource = ListOfEntities;
        }

        private void ConfirmSending(TransferOrder order, List<string> failedOrders)
        {
            if (!order.TransferRoute.InitialWarehouse.WarehouseID.StartsWith("С"))
            {
                order.Status = OrderStatuses.InTransit;
                order.TransferRoute.TransitWarehouse.Status = TransitWarehouseStatuses.Busy;
                return;
            }

            foreach (var resource in order.OrderContent)
            {
                try
                {
                    var stock = order.TransferRoute.InitialWarehouse.StationaryStocks
                        .Single(s => s.ResourceID == resource.ResourceID);

                    if (stock.ResourceAmount - resource.ResourceAmount > 0)
                    {
                        order.Status = OrderStatuses.InTransit;
                        order.TransferRoute.TransitWarehouse.Status = TransitWarehouseStatuses.Busy;
                        stock.ResourceAmount -= resource.ResourceAmount;
                    }
                    else failedOrders.Add($"ID: {order.OrderID}, ID ресурса: {resource.ResourceID} " +
                        $"требуется: {resource.ResourceAmount}, ресурса на складе: {stock.ResourceAmount}.");
                }
                catch { MessageService.ShowError("Такого ресурса на складе не зарегестрировано."); }
            }
        }

        private void ConfirmReceiving(TransferOrder order)
        {
            order.Status = OrderStatuses.Closed;
            if (!order.TransferRoute.FinalWarehouse.WarehouseID.StartsWith("С"))
                return;

            foreach (var resource in order.OrderContent)
            {
                try
                {
                    var stock = order.TransferRoute.FinalWarehouse.StationaryStocks
                        .Single(s => s.ResourceID == resource.ResourceID);
                    stock.ResourceAmount += resource.ResourceAmount;
                }
                catch
                {
                    var finalWarehouseID = order.TransferRoute.FinalWarehouse.WarehouseID;
                    var resourceID = resource.ResourceID;
                    var amount = resource.ResourceAmount;
                    order.TransferRoute.FinalWarehouse.StationaryStocks.Add(new StationaryStock
                    {
                        ResourceID = resourceID,
                        WarehouseID = finalWarehouseID,
                        ResourceAmount = amount
                    });
                }
            }
        }

        protected override void RetrieveButtsRights()
        {
            base.RetrieveButtsRights();
            TableForm.ConfirmButtEnabled = User.RightsForEntitiesAndFields.Any(e => e.EntityType == typeof(TransferOrder)
            && e.ConfirmOrders);
            TableForm.FilterButtEnabled = TableForm.ConfirmButtEnabled;

            if (TableForm.ConfirmButtEnabled)
                TableForm.SaveButtEnabled = true;
        }

        protected override void DeleteRecords(List<TransferOrder> ordersToDelete)
        {
            var failedToDelete = new List<TransferOrder>();
            foreach (var order in ordersToDelete)
                if (order.Status != OrderStatuses.Closed && order.Status != OrderStatuses.Outdated)
                {
                    failedToDelete.Add(order);
                }

            failedToDelete.ForEach(el => ordersToDelete.Remove(el));

            if (failedToDelete.Any())
            {
                string failureString = "Следующие заказы не были удалены из-за своего статуса:";
                foreach (var order in failedToDelete)
                    failureString += NL + $"ID: {order.OrderID} Статус: {order.Status}";
                MessageService.ShowExclamation(failureString);
            }
            base.DeleteRecords(ordersToDelete);
        }
    }
}