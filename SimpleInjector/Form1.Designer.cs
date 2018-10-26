namespace SimpleInjector
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.ProcId = new System.Windows.Forms.Label();
            this.ProcPicture = new System.Windows.Forms.PictureBox();
            this.ProcName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ProcPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 64);
            this.button1.TabIndex = 0;
            this.button1.Text = "Select Process";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProcId
            // 
            this.ProcId.AutoSize = true;
            this.ProcId.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcId.Location = new System.Drawing.Point(197, 51);
            this.ProcId.Name = "ProcId";
            this.ProcId.Size = new System.Drawing.Size(24, 25);
            this.ProcId.TabIndex = 4;
            this.ProcId.Text = "0";
            // 
            // ProcPicture
            // 
            this.ProcPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProcPicture.Location = new System.Drawing.Point(127, 12);
            this.ProcPicture.Name = "ProcPicture";
            this.ProcPicture.Size = new System.Drawing.Size(64, 64);
            this.ProcPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ProcPicture.TabIndex = 5;
            this.ProcPicture.TabStop = false;
            // 
            // ProcName
            // 
            this.ProcName.AutoSize = true;
            this.ProcName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcName.Location = new System.Drawing.Point(197, 12);
            this.ProcName.Name = "ProcName";
            this.ProcName.Size = new System.Drawing.Size(30, 25);
            this.ProcName.TabIndex = 6;
            this.ProcName.Text = "...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 283);
            this.Controls.Add(this.ProcName);
            this.Controls.Add(this.ProcPicture);
            this.Controls.Add(this.ProcId);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ProcPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label ProcId;
        private System.Windows.Forms.PictureBox ProcPicture;
        private System.Windows.Forms.Label ProcName;
    }
}

