using System;
using System.Windows.Forms;

namespace LogisticsCenter.Views.Search
{
    public partial class SearchForm : Form, ISearchForm
    {
        public SearchForm()
        {
            InitializeComponent();
            textBox.KeyDown += TextBox_KeyDown;
            okButt.Click += (sender, e) => CheckAndCallSearch();
            abortButt.Click += (sender, e) => Close();
            FormClosed += (sender, e) => FormClosure.Invoke();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CheckAndCallSearch();
        }

        private void CheckAndCallSearch()
        {
            if (!string.IsNullOrEmpty(textBox.Text) && !string.IsNullOrEmpty(comboBox.Text))
            {
                ReturnSearchCriteria.Invoke(comboBox.Text, textBox.Text);
            }
        }

        public event ReturnSearchCriteria ReturnSearchCriteria;

        public event Action FormClosure;

        public void Show(string[] comboBoxItems)
        {
            comboBox.Items.AddRange(comboBoxItems);
            comboBox.SelectedIndex = 0;
            Show();
        }
    }
}