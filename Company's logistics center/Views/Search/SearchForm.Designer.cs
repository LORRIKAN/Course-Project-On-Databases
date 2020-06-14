namespace LogisticsCenter.Views.Search
{
    partial class SearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.okButt = new System.Windows.Forms.Button();
            this.abortButt = new System.Windows.Forms.Button();
            this.textBox = new LogisticsCenter.Views.TextBoxWithPlaceholder();
            this.SuspendLayout();
            // 
            // comboBox
            // 
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(12, 21);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(219, 28);
            this.comboBox.TabIndex = 0;
            // 
            // okButt
            // 
            this.okButt.AutoSize = true;
            this.okButt.Location = new System.Drawing.Point(359, 75);
            this.okButt.Name = "okButt";
            this.okButt.Size = new System.Drawing.Size(81, 38);
            this.okButt.TabIndex = 2;
            this.okButt.Text = "Ок";
            this.okButt.UseVisualStyleBackColor = true;
            // 
            // abortButt
            // 
            this.abortButt.AutoSize = true;
            this.abortButt.Location = new System.Drawing.Point(446, 75);
            this.abortButt.Name = "abortButt";
            this.abortButt.Size = new System.Drawing.Size(89, 38);
            this.abortButt.TabIndex = 3;
            this.abortButt.Text = "Отмена";
            this.abortButt.UseVisualStyleBackColor = true;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(237, 23);
            this.textBox.Name = "textBox";
            this.textBox.Placeholder = "Введите поисковой запрос";
            this.textBox.Size = new System.Drawing.Size(298, 26);
            this.textBox.TabIndex = 4;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 125);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.abortButt);
            this.Controls.Add(this.okButt);
            this.Controls.Add(this.comboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SearchForm";
            this.Text = "Поиск";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Button okButt;
        private System.Windows.Forms.Button abortButt;
        private TextBoxWithPlaceholder textBox;
    }
}