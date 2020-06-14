using System.Windows.Forms;

namespace LogisticsCenter.Views.Main.Info
{
    public interface IShowingForm
    {
        void Show(object DataSource, string TableName);

        DataGridView DataGridView { get; }
    }
}