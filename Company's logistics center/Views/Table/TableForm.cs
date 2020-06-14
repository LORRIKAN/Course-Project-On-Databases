using LogisticsCenter.Model;
using LogisticsCenter.Views.MessageService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LogisticsCenter.Views.Table
{
    public partial class TableForm<TEntity> : Form, ITableForm<TEntity> where TEntity : class, IModel
    {
        public TableForm(IMessageService messageService)
        {
            InitializeComponent();
            MessageService = messageService;
        }

        public bool AddButtEnabled { get => addButt.Enabled; set => addButt.Enabled = value; }
        public bool UpdateButtEnabled { get => updateButt.Enabled; set => updateButt.Enabled = value; }
        public bool DeleteButtEnabled { get => deleteButt.Enabled; set => deleteButt.Enabled = value; }
        public bool SaveButtEnabled { get => saveButt.Enabled; set => saveButt.Enabled = value; }
        public string Header { get => Text; set => Text = value; }

        public List<TEntity> DataSource
        {
            get => (List<TEntity>)((BindingSource)dataGridView.DataSource).DataSource;
            set => dataGridView.DataSource = new BindingSource { DataSource = value };
        }

        public event Action RequestButtsRights;
        public event Action GetSource;
        public event Action MakeSearch;
        public event Action GetNonSearch;
        public event Action AddNewRecord;
        public event Action<List<TEntity>> UpdateRecords;
        public event Action Save;
        public event Action<List<TEntity>> DeleteRecords;
        public new event Action<FormClosingEventArgs> FormClosing;

        protected IMessageService MessageService { get; set; }

        protected virtual void SetEvents()
        {
            RequestButtsRights.Invoke();

            refreshButt.Click += (sender, e) => Invoke(GetSource);

            searchButt.Click += (sender, e) => Invoke(MakeSearch);

            noSearchButt.Click += (sender, e) => Invoke(GetNonSearch);

            addButt.Click += (sender, e) => Invoke(AddNewRecord);

            updateButt.Click += (sender, e) => Invoke(UpdateRecords);

            saveButt.Click += (sender, e) => Invoke(Save);

            deleteButt.Click += (sender, e) => Invoke(DeleteRecords);

            base.FormClosing += (sender, e) => FormClosing.Invoke(e);
        }

        public new void Show()
        {
            SetEvents();
            base.Show();
            Invoke(GetSource);
        }

        protected List<TEntity> GetSelectedItems()
        {
            var selectedItems = new List<TEntity>();
            if (dataGridView.SelectedRows != null)
                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                    selectedItems.Add(row.DataBoundItem as TEntity);
            return selectedItems;
        }

        protected void Invoke(Action<List<TEntity>> action)
        {
            var items = GetSelectedItems();
            if (items.Any())
            {
                DisableAllButts();
                action.Invoke(items);
            }
        }

        protected void Invoke(Action action)
        {
            DisableAllButts();

            action.Invoke();
        }

        Dictionary<Button, bool> buttsEnabled;

        private void DisableAllButts()
        {
            buttsEnabled = new Dictionary<Button, bool>();
            foreach (Control control in Controls)
            {
                if (control is Button button)
                {
                    buttsEnabled.Add(button, button.Enabled);
                    button.Enabled = false;
                }

                if (control is TableLayoutPanel table)
                    foreach (Control control1 in table.Controls)
                        if (control1 is Button button1)
                        {
                            buttsEnabled.Add(button1, button1.Enabled);
                            button1.Enabled = false;
                        }
            }
        }

        public void EnableButts()
        {
            foreach (Control control in Controls)
            {
                if (control is Button button)
                {
                    button.Enabled = buttsEnabled[button];
                }

                if (control is TableLayoutPanel table)
                    foreach (Control control1 in table.Controls)
                        if (control1 is Button button1)
                        {
                            button1.Enabled = buttsEnabled[button1];
                        }
            }
            buttsEnabled = new Dictionary<Button, bool>();
        }
    }
}