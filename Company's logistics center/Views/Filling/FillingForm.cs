using LogisticsCenter.Model;
using LogisticsCenter.Views.MessageService;
using System;
using System.Windows.Forms;

namespace LogisticsCenter.Views.Filling
{
    public partial class FillingForm : Form, IFillingForm
    {
        public FillingForm(IMessageService messageService)
        {
            MessageService = messageService;
            InitializeComponent();
            propertyGrid.PropertyValueChanged += PropertyGrid_PropertyValueChanged;
            abortButt.Click += (sender, e) => Close();
            okButt.Click += OkButt_Click;
            FormClosed += (sender, e) => FormClosure.Invoke();
        }

        protected IMessageService MessageService { get; set; }

        IModel Model { get; set; }

        private void OkButt_Click(object sender, EventArgs e)
        {
            var result = CheckModel.Invoke(Model);
            if (result != null)
                MessageService.ShowError(result);
            else
            {
                Close();
                SuccessfullyFilled.Invoke(Model);
            }
        }

        private void PropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            var result = CheckProperty.Invoke(e.ChangedItem.PropertyDescriptor.Name, e.ChangedItem.Value);
            if (result != null)
            {
                MessageService.ShowExclamation(result);
                e.ChangedItem.PropertyDescriptor.SetValue(propertyGrid.SelectedObject, e.OldValue);
                propertyGrid.SelectedObject = propertyGrid.SelectedObject;
            }
        }

        public event CheckProperty CheckProperty;

        public event CheckObject CheckModel;

        public event Action<IModel> SuccessfullyFilled;
        public event Action FormClosure;

        public void Show(IModel model)
        {
            Model = model;
            propertyGrid.SelectedObject = Model;
            base.Show();
        }
    }
}