namespace SimpleInjector
{
    partial class SelProcDialog
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
            this.ProcList = new System.Windows.Forms.ListView();
            this.PreviewField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IdField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PathField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SelectButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProcList
            // 
            this.ProcList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PreviewField,
            this.NameField,
            this.IdField,
            this.PathField});
            this.ProcList.FullRowSelect = true;
            this.ProcList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ProcList.HideSelection = false;
            this.ProcList.Location = new System.Drawing.Point(12, 12);
            this.ProcList.MultiSelect = false;
            this.ProcList.Name = "ProcList";
            this.ProcList.Size = new System.Drawing.Size(325, 217);
            this.ProcList.TabIndex = 0;
            this.ProcList.UseCompatibleStateImageBehavior = false;
            this.ProcList.View = System.Windows.Forms.View.Details;
            // 
            // PreviewField
            // 
            this.PreviewField.Text = "";
            this.PreviewField.Width = 23;
            // 
            // NameField
            // 
            this.NameField.Text = "Name";
            this.NameField.Width = 82;
            // 
            // IdField
            // 
            this.IdField.Text = "Id";
            // 
            // PathField
            // 
            this.PathField.Text = "Path";
            this.PathField.Width = 125;
            // 
            // SelectButton
            // 
            this.SelectButton.Location = new System.Drawing.Point(12, 243);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(152, 34);
            this.SelectButton.TabIndex = 1;
            this.SelectButton.Text = "Select";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(170, 243);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(167, 34);
            this.RefreshButton.TabIndex = 2;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // SelProcDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 287);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.ProcList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelProcDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Select Process";
            this.Load += new System.EventHandler(this.SelProcDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ProcList;
        private System.Windows.Forms.ColumnHeader PreviewField;
        private System.Windows.Forms.ColumnHeader NameField;
        private System.Windows.Forms.ColumnHeader IdField;
        private System.Windows.Forms.ColumnHeader PathField;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.Button RefreshButton;
    }
}