using LogisticsCenter.Presenters.Main.Info;
using LogisticsCenter.Views.MessageService;
using System;
using System.Windows.Forms;

namespace LogisticsCenter.Views.Main
{
    public partial class MainForm : Form, IMainForm
    {
        public new event Action<bool, FormClosingEventArgs> OnFormClosing;
        public event Action<IButtonFactory> SetButtsRights;
        public event Action<InfoType> InfoButtClicked;

        public string Header { get => Text; set => Text = value; }

        bool reloginAttempt = false;

        IMessageService MessageService { get; set; }

        IButtonFactory ButtonFactory { get; }

        public MainForm(IButtonFactory buttonFactory, IMessageService messageService)
        {
            ButtonFactory = buttonFactory;

            MessageService = messageService;
            FormClosing += (sender, e) => OnFormClosing.Invoke(reloginAttempt, e);

            InitializeComponent();
            RelogButt.Click += (sender, e) =>
            {
                reloginAttempt = true;
                this.Close();
            };
            stationaryStocksInfoButt.Click += (sender, e) => InfoButtClicked.Invoke(InfoType.StationaryStocks);
            resourcesInTransitButt.Click += (sender, e) => InfoButtClicked.Invoke(InfoType.ResourcesInTransit);
            resourcesAwaitingToBeSentButt.Click += (sender, e) => InfoButtClicked.Invoke(InfoType.AwaitingSendings);
            resourcesAwaitingToBeReceivedButt.Click += (sender, e) => InfoButtClicked.Invoke(InfoType.AwaitingReceivings);
        }

        public new void Show()
        {
            SetButtsRights.Invoke(ButtonFactory);
            Application.Run(this);
        }
    }
}