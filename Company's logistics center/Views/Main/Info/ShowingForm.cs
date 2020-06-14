using System.Windows.Forms;

namespace LogisticsCenter.Views.Main.Info
{
    public partial class ShowingForm : Form, IShowingForm
    {
        public ShowingForm()
        {
            InitializeComponent();
        }

        public DataGridView DataGridView => dataGridView;

        public void Show(object DataSource, string TableName)
        {
            dataGridView.DataSource = DataSource;
            Text = TableName;
            base.Show();
        }
    }
}