using LogisticsCenter.Model.DbModels;
using LogisticsCenter.Views.MessageService;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LogisticsCenter.Views.Table
{
    public partial class TransferOrdersTableForm : TableForm<TransferOrder>, ITransferOrdersTableForm
    {
        public TransferOrdersTableForm(IMessageService messageService) : base(messageService)
        {
            InitializeComponent();
        }

        public event Action<List<TransferOrder>> ConfirmOrdersButtClick;
        public event Action FilterButtClick;

        public string FileExportPath { get; private set; }
        public bool FilterButtEnabled { get => filterButt.Enabled; set => filterButt.Enabled = value; }
        public bool ConfirmButtEnabled { get => confirmButt.Enabled; set => confirmButt.Enabled = value; }

        protected override void SetEvents()
        {
            base.SetEvents();
            confirmButt.Click += (sender, e) => Invoke(ConfirmOrdersButtClick);

            filterButt.Click += (sender, e) => Invoke(FilterButtClick);
        }

        private Button confirmButt;
        private Button filterButt;
        private System.ComponentModel.IContainer components;

        private void InitializeComponent()
        {
            this.confirmButt = new System.Windows.Forms.Button();
            this.filterButt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // confirmButt
            // 
            this.confirmButt.BackgroundImage = global::LogisticsCenter.Properties.Resources.confirmOrderPicture;
            this.confirmButt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.confirmButt.Location = new System.Drawing.Point(1032, 8);
            this.confirmButt.Name = "confirmButt";
            this.confirmButt.Size = new System.Drawing.Size(131, 103);
            this.confirmButt.TabIndex = 3;
            this.toolTip.SetToolTip(this.confirmButt, "Подтверить отправку/получение");
            this.confirmButt.UseVisualStyleBackColor = true;
            // 
            // filterButt
            // 
            this.filterButt.BackgroundImage = global::LogisticsCenter.Properties.Resources.filterPicture;
            this.filterButt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.filterButt.Location = new System.Drawing.Point(895, 8);
            this.filterButt.Name = "filterButt";
            this.filterButt.Size = new System.Drawing.Size(131, 103);
            this.filterButt.TabIndex = 4;
            this.toolTip.SetToolTip(this.filterButt, "Отфильтровать по вашему складу. " +
                "Для возврата к полному списку воспользуйтесь кнопкой \"Отменить поиск\".");
            this.filterButt.UseVisualStyleBackColor = true;
            // 
            // TableFormWithOrderConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.ClientSize = new System.Drawing.Size(1351, 632);
            this.Controls.Add(this.filterButt);
            this.Controls.Add(this.confirmButt);
            this.Name = "TableFormWithOrderConfirm";
            this.Controls.SetChildIndex(this.confirmButt, 0);
            this.Controls.SetChildIndex(this.filterButt, 0);
            this.ResumeLayout(false);
        }
    }
}