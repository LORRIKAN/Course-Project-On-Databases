using System;
using System.Collections.Generic;

namespace LogisticsCenter.Views.Main.Info
{
    public delegate void SendData(string warehouseID, DateTime startDate, DateTime endDate);
    public interface IDatesAndWarehouseChooseForm
    {
        event Func<List<string>> RequestWarehousesIDs;

        event SendData SendConfirmedData;

        bool DataReceived { get; set; }

        void Show();
    }
}