using LogisticsCenter.Model.DbModels;
using LogisticsCenter.Repository;
using LogisticsCenter.Views.Main.Info;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LogisticsCenter.Presenters.Main.Info
{
    public class InfoPresenter : IInfoPresenter
    {
        IDatesAndWarehouseChooseForm DatesAndWarehouseChooseForm { get; set; }

        IShowingForm ShowingForm { get; set; }

        DatabaseContext Context { get; set; }

        string WarehouseID { get; set; }

        DateTime StartDate { get; set; }

        DateTime EndDate { get; set; }

        public InfoPresenter(IDatesAndWarehouseChooseForm datesAndWarehouseChooseForm, IShowingForm showingForm,
            DatabaseContext databaseContext)
        {
            DatesAndWarehouseChooseForm = datesAndWarehouseChooseForm;
            DatesAndWarehouseChooseForm.RequestWarehousesIDs += () => databaseContext.StationaryWarehouses.AsNoTracking()
                .Select(sw => sw.WarehouseID).ToList();
            DatesAndWarehouseChooseForm.SendConfirmedData += (warehouseID, startDate, endDate) =>
            {
                WarehouseID = warehouseID;
                StartDate = startDate;
                EndDate = endDate;
            };

            ShowingForm = showingForm;
            Context = databaseContext;
        }

        public void Run(InfoType runType)
        {
            switch (runType)
            {
                case InfoType.AwaitingReceivings:
                    DatesAndWarehouseChooseForm.Show();
                    if (DatesAndWarehouseChooseForm.DataReceived)
                        SetAwaitingReceivings();
                    break;
                case InfoType.AwaitingSendings:
                    DatesAndWarehouseChooseForm.Show();
                    if (DatesAndWarehouseChooseForm.DataReceived)
                        SetAwatingSendings();
                    break;
                case InfoType.ResourcesInTransit:
                    SetResourcesInTransit();
                    break;
                case InfoType.StationaryStocks:
                    SetStationaryStocks();
                    break;
            }
        }

        private void SetAwaitingReceivings()
        {
            var DataSource = (from ws in Context.StationaryWarehouses
                              join tr in Context.TransferRoutes on ws.WarehouseID equals tr.FinalWarehouseID
                              join to in Context.TransferOrders on tr.RouteID equals to.TransferRouteID
                              join oc in Context.TransferOrderContents on to.OrderID equals oc.TransferOrderID
                              where StartDate <= to.ReceivingDate && to.ReceivingDate <= EndDate && (to.Status == OrderStatuses.InTransit
                               || to.Status == OrderStatuses.AwaitingToBeReceived) && ws.WarehouseID == WarehouseID
                              orderby ws.WarehouseID
                              select new
                              {
                                  ws.WarehouseID,
                                  oc.ResourceID,
                                  oc.ResourceAmount,
                                  to.OrderID,
                                  to.Status
                              }).AsNoTracking().ToList();
            ShowingForm.Show(DataSource, $"Ожидаемые поступления на склад ID {WarehouseID}");
            ShowingForm.DataGridView.Columns[0].HeaderText = "ID стационарного склада";
            ShowingForm.DataGridView.Columns[1].HeaderText = "ID ресурса";
            ShowingForm.DataGridView.Columns[2].HeaderText = "Количество ресурса";
            ShowingForm.DataGridView.Columns[3].HeaderText = "ID заказа перемещения";
            ShowingForm.DataGridView.Columns[4].HeaderText = "Статус заказа перемещения";

        }

        private void SetAwatingSendings()
        {
            var DataSource = (from ws in Context.StationaryWarehouses
                              join tr in Context.TransferRoutes on ws.WarehouseID equals tr.InitialWarehouseID
                              join to in Context.TransferOrders on tr.RouteID equals to.TransferRouteID
                              join oc in Context.TransferOrderContents on to.OrderID equals oc.TransferOrderID
                              where StartDate <= to.SendingDate && to.SendingDate <= EndDate && (to.Status == OrderStatuses.AwaitingToBeSent
                              || to.Status == OrderStatuses.AwaitingSendingDate) && ws.WarehouseID == WarehouseID
                              orderby ws.WarehouseID
                              select new
                              {
                                  ws.WarehouseID,
                                  oc.ResourceID,
                                  oc.ResourceAmount,
                                  to.OrderID,
                                  to.Status
                              }).AsNoTracking().ToList();
            ShowingForm.Show(DataSource, $"Ожидаемые отгрузки со склада ID {WarehouseID}");
            ShowingForm.DataGridView.Columns[0].HeaderText = "ID стационарного склада";
            ShowingForm.DataGridView.Columns[1].HeaderText = "ID ресурса";
            ShowingForm.DataGridView.Columns[2].HeaderText = "Количество ресурса";
            ShowingForm.DataGridView.Columns[3].HeaderText = "ID заказа перемещения";
            ShowingForm.DataGridView.Columns[4].HeaderText = "Статус заказа перемещения";
        }

        private void SetResourcesInTransit()
        {
            var DataSource = (from tw in Context.TransitWarehouses
                              join tr in Context.TransferRoutes on tw.WarehouseID equals tr.TransitWarehouseID
                              join to in Context.TransferOrders on tr.RouteID equals to.TransferRouteID
                              join oc in Context.TransferOrderContents on to.OrderID equals oc.TransferOrderID
                              where tw.Status == TransitWarehouseStatuses.Busy
                              orderby tw.WarehouseID
                              select new
                              {
                                  tw.WarehouseID,
                                  oc.ResourceID,
                                  oc.ResourceAmount
                              }).AsNoTracking().ToList();
            ShowingForm.Show(DataSource, "Запасы в пути");
            ShowingForm.DataGridView.Columns[0].HeaderText = "ID транзитного склада";
            ShowingForm.DataGridView.Columns[1].HeaderText = "ID ресурса";
            ShowingForm.DataGridView.Columns[2].HeaderText = "Количество ресурса";
        }

        private void SetStationaryStocks()
        {
            var DataSource = (from sw in Context.StationaryWarehouses
                              join ss in Context.StationaryStocks on sw.WarehouseID equals ss.WarehouseID
                              orderby sw.WarehouseID
                              select new
                              {
                                  sw.WarehouseID,
                                  ss.ResourceID,
                                  ss.ResourceAmount
                              }).AsNoTracking().ToList();
            ShowingForm.Show(DataSource, "Запасы на основных складах");
            ShowingForm.DataGridView.Columns[0].HeaderText = "ID стационарного склада";
            ShowingForm.DataGridView.Columns[1].HeaderText = "ID ресурса";
            ShowingForm.DataGridView.Columns[2].HeaderText = "Количество ресурса";
        }
    }

    public enum InfoType
    {
        AwaitingReceivings,
        AwaitingSendings,
        ResourcesInTransit,
        StationaryStocks,
    }
}