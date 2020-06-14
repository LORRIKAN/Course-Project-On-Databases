using LogisticsCenter.Presenters.Main.Info;
using System;
using System.Windows.Forms;

namespace LogisticsCenter.Views.Main
{
    public interface IMainForm
    {
        event Action<bool, FormClosingEventArgs> OnFormClosing;

        event Action<IButtonFactory> SetButtsRights;

        event Action<InfoType> InfoButtClicked;

        string Header { get; set; }

        void Show();
    }
}