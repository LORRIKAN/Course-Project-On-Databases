using LogisticsCenter.Views.MessageService;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LogisticsCenter.Views.Main.Info
{
    public partial class DatesAndWarehouseChooseForm : Form, IDatesAndWarehouseChooseForm
    {
        IMessageService MessageService { get; set; }
        public DatesAndWarehouseChooseForm(IMessageService messageService)
        {
            InitializeComponent();

            warehouseIDTextBox.KeyDown += CheckKey;
            startDatePicker.KeyDown += CheckKey;
            endDatePicker.KeyDown += CheckKey;

            okButt.Click += (sender, e) => CheckAndSendData();
            abortButt.Click += (sender, e) => this.Close();

            MessageService = messageService;
        }

        public new void Show()
        {
            WarehousesIDs = RequestWarehousesIDs.Invoke();
            base.Show();
        }

        private void CheckKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CheckAndSendData();
        }

        private void CheckAndSendData()
        {
            if (warehouseIDTextBox.Text == null)
                return;

            var warehouseID = warehouseIDTextBox.Text;
            if (!WarehousesIDs.Contains(warehouseID))
            {
                MessageService.ShowError("Такого склада нет.");
                return;
            }

            if (startDatePicker.Value == null || endDatePicker.Value == null)
                return;

            var startDate = startDatePicker.Value;
            var endDate = endDatePicker.Value;
            if (startDate >= endDate)
            {
                MessageService.ShowError("Начальная дата не может быть той же или позднее конечной.");
                return;
            }

            SendConfirmedData.Invoke(warehouseID, startDate, endDate);
        }

        List<string> WarehousesIDs { get; set; }

        public event SendData SendConfirmedData;

        public event Func<List<string>> RequestWarehousesIDs;
    }
}