using System.Drawing;

namespace LogisticsCenter.Views.Table
{
    partial class TableForm<TEntity>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableForm<TEntity>));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.saveButt = new System.Windows.Forms.Button();
            this.deleteButt = new System.Windows.Forms.Button();
            this.updateButt = new System.Windows.Forms.Button();
            this.addButt = new System.Windows.Forms.Button();
            this.noSearchButt = new System.Windows.Forms.Button();
            this.searchButt = new System.Windows.Forms.Button();
            this.refreshButt = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 120);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(1327, 500);
            this.dataGridView.TabIndex = 0;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 7;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel.Controls.Add(this.saveButt, 6, 0);
            this.tableLayoutPanel.Controls.Add(this.deleteButt, 5, 0);
            this.tableLayoutPanel.Controls.Add(this.updateButt, 4, 0);
            this.tableLayoutPanel.Controls.Add(this.addButt, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.noSearchButt, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.searchButt, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.refreshButt, 0, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(13, 5);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(879, 109);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // saveButt
            // 
            this.saveButt.BackgroundImage = global::LogisticsCenter.Properties.Resources.savePicture;
            this.saveButt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.saveButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveButt.Location = new System.Drawing.Point(753, 3);
            this.saveButt.Name = "saveButt";
            this.saveButt.Size = new System.Drawing.Size(123, 103);
            this.saveButt.TabIndex = 6;
            this.toolTip.SetToolTip(this.saveButt, "Сохранить всё");
            this.saveButt.UseVisualStyleBackColor = true;
            // 
            // deleteButt
            // 
            this.deleteButt.BackgroundImage = global::LogisticsCenter.Properties.Resources.deletePicture;
            this.deleteButt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deleteButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteButt.Location = new System.Drawing.Point(628, 3);
            this.deleteButt.Name = "deleteButt";
            this.deleteButt.Size = new System.Drawing.Size(119, 103);
            this.deleteButt.TabIndex = 5;
            this.toolTip.SetToolTip(this.deleteButt, "Удалить запись");
            this.deleteButt.UseVisualStyleBackColor = true;
            // 
            // updateButt
            // 
            this.updateButt.BackgroundImage = global::LogisticsCenter.Properties.Resources.updatePicture;
            this.updateButt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.updateButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateButt.Location = new System.Drawing.Point(503, 3);
            this.updateButt.Name = "updateButt";
            this.updateButt.Size = new System.Drawing.Size(119, 103);
            this.updateButt.TabIndex = 4;
            this.toolTip.SetToolTip(this.updateButt, "Изменить запись");
            this.updateButt.UseVisualStyleBackColor = true;
            // 
            // addButt
            // 
            this.addButt.BackgroundImage = global::LogisticsCenter.Properties.Resources.addPicture;
            this.addButt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addButt.Location = new System.Drawing.Point(378, 3);
            this.addButt.Name = "addButt";
            this.addButt.Size = new System.Drawing.Size(119, 103);
            this.addButt.TabIndex = 3;
            this.toolTip.SetToolTip(this.addButt, "Добавить запись");
            this.addButt.UseVisualStyleBackColor = true;
            // 
            // noSearchButt
            // 
            this.noSearchButt.BackgroundImage = global::LogisticsCenter.Properties.Resources.noSearchPicture;
            this.noSearchButt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.noSearchButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noSearchButt.Location = new System.Drawing.Point(253, 3);
            this.noSearchButt.Name = "noSearchButt";
            this.noSearchButt.Size = new System.Drawing.Size(119, 103);
            this.noSearchButt.TabIndex = 2;
            this.toolTip.SetToolTip(this.noSearchButt, "Сброс поиска");
            this.noSearchButt.UseVisualStyleBackColor = true;
            // 
            // searchButt
            // 
            this.searchButt.BackgroundImage = global::LogisticsCenter.Properties.Resources.searchPicture;
            this.searchButt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.searchButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchButt.Location = new System.Drawing.Point(128, 3);
            this.searchButt.Name = "searchButt";
            this.searchButt.Size = new System.Drawing.Size(119, 103);
            this.searchButt.TabIndex = 1;
            this.toolTip.SetToolTip(this.searchButt, "Поиск");
            this.searchButt.UseVisualStyleBackColor = true;
            // 
            // refreshButt
            // 
            this.refreshButt.BackgroundImage = global::LogisticsCenter.Properties.Resources.refreshPicture;
            this.refreshButt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refreshButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.refreshButt.Location = new System.Drawing.Point(3, 3);
            this.refreshButt.Name = "refreshButt";
            this.refreshButt.Size = new System.Drawing.Size(119, 103);
            this.refreshButt.TabIndex = 0;
            this.toolTip.SetToolTip(this.refreshButt, "Сбросить");
            this.refreshButt.UseVisualStyleBackColor = true;
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 632);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.dataGridView);
            this.Icon = new Icon(@"..\..\Resources\tableIco.ico");
            this.Name = "TableForm";
            this.Text = "Название таблицы";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.DataGridView dataGridView;
        protected System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button saveButt;
        private System.Windows.Forms.Button deleteButt;
        private System.Windows.Forms.Button updateButt;
        private System.Windows.Forms.Button addButt;
        private System.Windows.Forms.Button noSearchButt;
        private System.Windows.Forms.Button searchButt;
        private System.Windows.Forms.Button refreshButt;
        protected System.Windows.Forms.ToolTip toolTip;
    }
}