using LogisticsCenter.Model.DbModels;
using LogisticsCenter.Repository;
using LogisticsCenter.Views.MessageService;
using LogisticsCenter.Views.Table;
using System.Collections.Generic;
using System.Linq;

namespace LogisticsCenter.Presenters.Table
{
    public class TransferOrdersContentTablePresenter : TablePresenter<TransferOrderContent>
    {
        public TransferOrdersContentTablePresenter(IMessageService messageService, DatabaseContext context,
            ITableForm<TransferOrderContent> tableForm) : base(messageService, context, tableForm) { }

        protected override void DeleteRecords(List<TransferOrderContent> cntntsToDelete)
        {
            var failed = new List<TransferOrderContent>();
            foreach (var cntnt in cntntsToDelete)
            {
                if (cntnt.ResourceAmount > double.Epsilon)
                {
                    failed.Add(cntnt);
                }
            }

            failed.ForEach(el => cntntsToDelete.Remove(el));

            if (failed.Any())
            {
                string failureString = "Следующие содержимые не были удалены из-за активных статусов заказов " +
                    "перемещения:";
                foreach (var cntnt in failed)
                    failureString += NL + $"ID заказа: {cntnt.TransferOrderID} ID ресурса: {cntnt.ResourceID} " +
                        $"Количество ресурса: {cntnt.ResourceAmount}";
                MessageService.ShowExclamation(failureString);
            }
            base.DeleteRecords(cntntsToDelete);
        }
    }
}