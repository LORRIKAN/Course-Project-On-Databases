using LogisticsCenter.Model.DbModels;

namespace LogisticsCenter.Views.Main
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.RelogButt = new System.Windows.Forms.ToolStripMenuItem();
            this.stationaryStocksInfoButt = new System.Windows.Forms.ToolStripMenuItem();
            this.resourcesInTransitButt = new System.Windows.Forms.ToolStripMenuItem();
            this.resourcesAwaitingToBeSentButt = new System.Windows.Forms.ToolStripMenuItem();
            this.resourcesAwaitingToBeReceivedButt = new System.Windows.Forms.ToolStripMenuItem();
            this.employeesButt = ButtonFactory.GetButtonFromPresenter<Employee>();
            this.specialitiesButt = ButtonFactory.GetButtonFromPresenter<Speciality>();
            this.specificationsButt = ButtonFactory.GetButtonFromPresenter<Specification>();
            this.transferOrdersButt = ButtonFactory.GetButtonFromPresenter<TransferOrder>();
            this.productsAndMaterialsButt = ButtonFactory.GetButtonFromPresenter<ProductOrMaterial>();
            this.productionsStepsButt = ButtonFactory.GetButtonFromPresenter<ProductionStep>();
            this.stationaryWarehousesButt = ButtonFactory.GetButtonFromPresenter<StationaryWarehouse>();
            this.stationaryStocksButt = ButtonFactory.GetButtonFromPresenter<StationaryStock>();
            this.transferRoutesButt = ButtonFactory.GetButtonFromPresenter<TransferRoute>();
            this.transitWarehousesButt = ButtonFactory.GetButtonFromPresenter<TransitWarehouse>();
            this.transferOrdersContentsButt = ButtonFactory.GetButtonFromPresenter<TransferOrderContent>();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.productionsStepsButt, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.productsAndMaterialsButt, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.transferOrdersButt, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.specificationsButt, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.specialitiesButt, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.employeesButt, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 31);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1128, 70);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.transferOrdersContentsButt, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.transitWarehousesButt, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.transferRoutesButt, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.stationaryStocksButt, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.stationaryWarehousesButt, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 101);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1128, 70);
            this.tableLayoutPanel2.TabIndex = 1;
            //
            // menuStrip
            // 
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RelogButt,
            this.stationaryStocksInfoButt,
            this.resourcesInTransitButt,
            this.resourcesAwaitingToBeSentButt,
            this.resourcesAwaitingToBeReceivedButt});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1128, 33);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // RelogButt
            // 
            this.RelogButt.Name = "RelogButt";
            this.RelogButt.Size = new System.Drawing.Size(232, 29);
            this.RelogButt.Text = "Выйти из учётной записи";
            // 
            // stationaryStocksInfoButt
            // 
            this.stationaryStocksInfoButt.Name = "stationaryStocksInfoButt";
            this.stationaryStocksInfoButt.Size = new System.Drawing.Size(264, 29);
            this.stationaryStocksInfoButt.Text = "Запасы на основных складах";
            // 
            // resourcesInTransitButt
            // 
            this.resourcesInTransitButt.Name = "resourcesInTransitButt";
            this.resourcesInTransitButt.Size = new System.Drawing.Size(143, 29);
            this.resourcesInTransitButt.Text = "Запасы в пути";
            // 
            // resourcesAwaitingToBeSentButt
            // 
            this.resourcesAwaitingToBeSentButt.Name = "resourcesAwaitingToBeSentButt";
            this.resourcesAwaitingToBeSentButt.Size = new System.Drawing.Size(205, 29);
            this.resourcesAwaitingToBeSentButt.Text = "Ожидаемые отгрузки";
            // 
            // resourcesAwaitingToBeReceivedButt
            // 
            this.resourcesAwaitingToBeReceivedButt.Name = "resourcesAwaitingToBeReceivedButt";
            this.resourcesAwaitingToBeReceivedButt.Size = new System.Drawing.Size(235, 29);
            this.resourcesAwaitingToBeReceivedButt.Text = "Ожидаемые поступления";

            this.employeesButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeesButt.Location = new System.Drawing.Point(8, 8);
            this.employeesButt.Margin = new System.Windows.Forms.Padding(8);
            this.employeesButt.Name = "employeesButt";
            this.employeesButt.Size = new System.Drawing.Size(171, 54);
            this.employeesButt.TabIndex = 0;
            this.employeesButt.Text = "Сотрудники";
            this.employeesButt.UseVisualStyleBackColor = true;

            this.specialitiesButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.specialitiesButt.Location = new System.Drawing.Point(195, 8);
            this.specialitiesButt.Margin = new System.Windows.Forms.Padding(8);
            this.specialitiesButt.Name = "specialitiesButt";
            this.specialitiesButt.Size = new System.Drawing.Size(171, 54);
            this.specialitiesButt.TabIndex = 1;
            this.specialitiesButt.Text = "Специальности";
            this.specialitiesButt.UseVisualStyleBackColor = true;

            this.specificationsButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.specificationsButt.Location = new System.Drawing.Point(382, 8);
            this.specificationsButt.Margin = new System.Windows.Forms.Padding(8);
            this.specificationsButt.Name = "specificationsButt";
            this.specificationsButt.Size = new System.Drawing.Size(171, 54);
            this.specificationsButt.TabIndex = 2;
            this.specificationsButt.Text = "Спецификации";
            this.specificationsButt.UseVisualStyleBackColor = true;

            this.transferOrdersButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transferOrdersButt.Location = new System.Drawing.Point(569, 8);
            this.transferOrdersButt.Margin = new System.Windows.Forms.Padding(8);
            this.transferOrdersButt.Name = "transferOrdersButt";
            this.transferOrdersButt.Size = new System.Drawing.Size(171, 54);
            this.transferOrdersButt.TabIndex = 3;
            this.transferOrdersButt.Text = "Заказы перемещения";
            this.transferOrdersButt.UseVisualStyleBackColor = true;

            this.productsAndMaterialsButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productsAndMaterialsButt.Location = new System.Drawing.Point(756, 8);
            this.productsAndMaterialsButt.Margin = new System.Windows.Forms.Padding(8);
            this.productsAndMaterialsButt.Name = "productsAndMaterialsButt";
            this.productsAndMaterialsButt.Size = new System.Drawing.Size(171, 54);
            this.productsAndMaterialsButt.TabIndex = 4;
            this.productsAndMaterialsButt.Text = "Товары и материалы";
            this.productsAndMaterialsButt.UseVisualStyleBackColor = true;

            this.productionsStepsButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productionsStepsButt.Location = new System.Drawing.Point(943, 8);
            this.productionsStepsButt.Margin = new System.Windows.Forms.Padding(8);
            this.productionsStepsButt.Name = "productionsStepsButt";
            this.productionsStepsButt.Size = new System.Drawing.Size(177, 54);
            this.productionsStepsButt.TabIndex = 5;
            this.productionsStepsButt.Text = "Этапы производства";
            this.productionsStepsButt.UseVisualStyleBackColor = true;

            this.stationaryWarehousesButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stationaryWarehousesButt.Location = new System.Drawing.Point(233, 8);
            this.stationaryWarehousesButt.Margin = new System.Windows.Forms.Padding(8);
            this.stationaryWarehousesButt.Name = "stationaryWarehousesButt";
            this.stationaryWarehousesButt.Size = new System.Drawing.Size(209, 54);
            this.stationaryWarehousesButt.TabIndex = 1;
            this.stationaryWarehousesButt.Text = "Стационарные склады";
            this.stationaryWarehousesButt.UseVisualStyleBackColor = true;

            this.stationaryStocksButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stationaryStocksButt.Location = new System.Drawing.Point(8, 8);
            this.stationaryStocksButt.Margin = new System.Windows.Forms.Padding(8);
            this.stationaryStocksButt.Name = "stationaryStocksButt";
            this.stationaryStocksButt.Size = new System.Drawing.Size(209, 54);
            this.stationaryStocksButt.TabIndex = 2;
            this.stationaryStocksButt.Text = "Стационарные запасы";
            this.stationaryStocksButt.UseVisualStyleBackColor = true;

            this.transferRoutesButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transferRoutesButt.Location = new System.Drawing.Point(458, 8);
            this.transferRoutesButt.Margin = new System.Windows.Forms.Padding(8);
            this.transferRoutesButt.Name = "transferRoutesButt";
            this.transferRoutesButt.Size = new System.Drawing.Size(209, 54);
            this.transferRoutesButt.TabIndex = 3;
            this.transferRoutesButt.Text = "Маршруты перемещения";
            this.transferRoutesButt.UseVisualStyleBackColor = true;

            this.transitWarehousesButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transitWarehousesButt.Location = new System.Drawing.Point(908, 8);
            this.transitWarehousesButt.Margin = new System.Windows.Forms.Padding(8);
            this.transitWarehousesButt.Name = "transitWarehousesButt";
            this.transitWarehousesButt.Size = new System.Drawing.Size(212, 54);
            this.transitWarehousesButt.TabIndex = 4;
            this.transitWarehousesButt.Text = "Транзитные склады";
            this.transitWarehousesButt.UseVisualStyleBackColor = true;

            this.transferOrdersContentsButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transferOrdersContentsButt.Location = new System.Drawing.Point(683, 8);
            this.transferOrdersContentsButt.Margin = new System.Windows.Forms.Padding(8);
            this.transferOrdersContentsButt.Name = "transferOrdersContentsButt";
            this.transferOrdersContentsButt.Size = new System.Drawing.Size(209, 54);
            this.transferOrdersContentsButt.TabIndex = 5;
            this.transferOrdersContentsButt.Text = "Составы заказов перемещения";
            this.transferOrdersContentsButt.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 171);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem RelogButt;
        private System.Windows.Forms.Button employeesButt;
        private System.Windows.Forms.Button specialitiesButt;
        private System.Windows.Forms.Button specificationsButt;
        private System.Windows.Forms.Button transferOrdersButt;
        private System.Windows.Forms.Button productsAndMaterialsButt;
        private System.Windows.Forms.Button productionsStepsButt;
        private System.Windows.Forms.Button stationaryWarehousesButt;
        private System.Windows.Forms.Button stationaryStocksButt;
        private System.Windows.Forms.Button transferRoutesButt;
        private System.Windows.Forms.Button transitWarehousesButt;
        private System.Windows.Forms.Button transferOrdersContentsButt;
        private System.Windows.Forms.ToolStripMenuItem stationaryStocksInfoButt;
        private System.Windows.Forms.ToolStripMenuItem resourcesInTransitButt;
        private System.Windows.Forms.ToolStripMenuItem resourcesAwaitingToBeSentButt;
        private System.Windows.Forms.ToolStripMenuItem resourcesAwaitingToBeReceivedButt;
    }
}