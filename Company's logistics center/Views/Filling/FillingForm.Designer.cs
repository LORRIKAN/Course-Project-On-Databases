namespace LogisticsCenter.Views.Filling
{
    partial class FillingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FillingForm));
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.okButt = new System.Windows.Forms.Button();
            this.abortButt = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.propertyGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.propertyGrid.HelpVisible = false;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(714, 544);
            this.propertyGrid.TabIndex = 0;
            this.propertyGrid.ToolbarVisible = false;
            // 
            // okButt
            // 
            this.okButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.okButt.Location = new System.Drawing.Point(501, 3);
            this.okButt.Name = "okButt";
            this.okButt.Size = new System.Drawing.Size(102, 47);
            this.okButt.TabIndex = 1;
            this.okButt.Text = "Ок";
            this.okButt.UseVisualStyleBackColor = true;
            // 
            // abortButt
            // 
            this.abortButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.abortButt.Location = new System.Drawing.Point(609, 3);
            this.abortButt.Name = "abortButt";
            this.abortButt.Size = new System.Drawing.Size(102, 47);
            this.abortButt.TabIndex = 2;
            this.abortButt.Text = "Отмена";
            this.abortButt.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.19895F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.80105F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel.Controls.Add(this.abortButt, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.okButt, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 571);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(714, 53);
            this.tableLayoutPanel.TabIndex = 3;
            // 
            // FillingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 624);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.propertyGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FillingForm";
            this.Text = "Форма заполнения";
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.PropertyGrid propertyGrid;
        protected System.Windows.Forms.Button okButt;
        protected System.Windows.Forms.Button abortButt;
        protected System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    }
}