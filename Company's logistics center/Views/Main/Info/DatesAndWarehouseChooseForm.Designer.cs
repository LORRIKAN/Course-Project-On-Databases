namespace LogisticsCenter.Views.Main.Info
{
    partial class DatesAndWarehouseChooseForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatesAndWarehouseChooseForm));
            this.startDateLabel = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.okButt = new System.Windows.Forms.Button();
            this.abortButt = new System.Windows.Forms.Button();
            this.warehouseIDTextBox = new LogisticsCenter.Views.TextBoxWithPlaceholder();
            this.warehouseIDLabel = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // startDateLabel
            // 
            this.startDateLabel.AutoSize = true;
            this.startDateLabel.Location = new System.Drawing.Point(36, 55);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(140, 20);
            this.startDateLabel.TabIndex = 1;
            this.startDateLabel.Text = "Начальная дата:";
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(182, 55);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(200, 26);
            this.startDatePicker.TabIndex = 2;
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(182, 87);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(200, 26);
            this.endDatePicker.TabIndex = 4;
            // 
            // endDateLabel
            // 
            this.endDateLabel.AutoSize = true;
            this.endDateLabel.Location = new System.Drawing.Point(36, 87);
            this.endDateLabel.Name = "endDateLabel";
            this.endDateLabel.Size = new System.Drawing.Size(128, 20);
            this.endDateLabel.TabIndex = 3;
            this.endDateLabel.Text = "Конечная дата:";
            // 
            // okButt
            // 
            this.okButt.AutoSize = true;
            this.okButt.Location = new System.Drawing.Point(226, 136);
            this.okButt.Name = "okButt";
            this.okButt.Size = new System.Drawing.Size(75, 41);
            this.okButt.TabIndex = 5;
            this.okButt.Text = "Ок";
            this.okButt.UseVisualStyleBackColor = true;
            // 
            // abortButt
            // 
            this.abortButt.AutoSize = true;
            this.abortButt.Location = new System.Drawing.Point(307, 136);
            this.abortButt.Name = "abortButt";
            this.abortButt.Size = new System.Drawing.Size(78, 41);
            this.abortButt.TabIndex = 6;
            this.abortButt.Text = "Отмена";
            this.abortButt.UseVisualStyleBackColor = true;
            // 
            // warehouseIDTextBox
            // 
            this.warehouseIDTextBox.Location = new System.Drawing.Point(182, 23);
            this.warehouseIDTextBox.Name = "warehouseIDTextBox";
            this.warehouseIDTextBox.Placeholder = "Введите ID склада";
            this.warehouseIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.warehouseIDTextBox.TabIndex = 7;
            // 
            // warehouseIDLabel
            // 
            this.warehouseIDLabel.AutoSize = true;
            this.warehouseIDLabel.Location = new System.Drawing.Point(36, 26);
            this.warehouseIDLabel.Name = "warehouseIDLabel";
            this.warehouseIDLabel.Size = new System.Drawing.Size(85, 20);
            this.warehouseIDLabel.TabIndex = 8;
            this.warehouseIDLabel.Text = "ID склада";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // DatesAndWarehouseChooseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 189);
            this.Controls.Add(this.warehouseIDLabel);
            this.Controls.Add(this.warehouseIDTextBox);
            this.Controls.Add(this.abortButt);
            this.Controls.Add(this.okButt);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.endDateLabel);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.startDateLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DatesAndWarehouseChooseForm";
            this.Text = "Выбор периода и склада";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.Button okButt;
        private System.Windows.Forms.Button abortButt;
        private TextBoxWithPlaceholder warehouseIDTextBox;
        private System.Windows.Forms.Label warehouseIDLabel;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}