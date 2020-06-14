using LogisticsCenter.Model.DbModels;
using System;
using System.Collections.Generic;

namespace LogisticsCenter.Views.Table
{
    public interface ITransferOrdersTableForm : ITableForm<TransferOrder>
    {
        bool ConfirmButtEnabled { get; set; }

        bool FilterButtEnabled { get; set; }

        string FileExportPath { get; }

        event Action<List<TransferOrder>> ConfirmOrdersButtClick;

        event Action FilterButtClick;
    }
}