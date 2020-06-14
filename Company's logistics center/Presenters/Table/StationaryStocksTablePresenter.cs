using LogisticsCenter.Model.DbModels;
using LogisticsCenter.Repository;
using LogisticsCenter.Views.MessageService;
using LogisticsCenter.Views.Table;
using System.Collections.Generic;
using System.Linq;

namespace LogisticsCenter.Presenters.Table
{
    public class StationaryStocksTablePresenter : TablePresenter<StationaryStock>
    {
        public StationaryStocksTablePresenter(IMessageService messageService, DatabaseContext context,
            ITableForm<StationaryStock> tableForm) : base(messageService, context, tableForm) { }

        protected override void DeleteRecords(List<StationaryStock> stocksToDelete)
        {
            var failed = new List<StationaryStock>();
            foreach (var stock in stocksToDelete)
            {
                if (stock.ResourceAmount > double.Epsilon)
                {
                    failed.Add(stock);
                    stocksToDelete.Remove(stock);
                }
            }
            if (failed.Any())
            {
                string failureString = "Следующие запасы не были удалены из-за наличия в них ресурсов:";
                foreach (var stock in failed)
                    failureString += NL + $"ID склада: {stock.WarehouseID} ID ресурса: {stock.ResourceID} " +
                        $"Количество ресурса: {stock.ResourceAmount}";
                MessageService.ShowExclamation(failureString);
            }
            base.DeleteRecords(stocksToDelete);
        }
    }
}