namespace VKR.PL.NET5
{
    partial class ExitForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExitForm));
            this.btnExit = new System.Windows.Forms.Button();
            this.btnExitCanceled = new System.Windows.Forms.Button();
            this.lbHeader = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Gainsboro;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnExit.Location = new System.Drawing.Point(321, 140);
            this.btnExit.Margin = new System.Windows.Forms.Padding(6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(132, 49);
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "YES";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnExitCanceled
            // 
            this.btnExitCanceled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExitCanceled.BackColor = System.Drawing.Color.Gainsboro;
            this.btnExitCanceled.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExitCanceled.FlatAppearance.BorderSize = 0;
            this.btnExitCanceled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExitCanceled.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExitCanceled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnExitCanceled.Location = new System.Drawing.Point(554, 140);
            this.btnExitCanceled.Margin = new System.Windows.Forms.Padding(6);
            this.btnExitCanceled.Name = "btnExitCanceled";
            this.btnExitCanceled.Size = new System.Drawing.Size(132, 49);
            this.btnExitCanceled.TabIndex = 19;
            this.btnExitCanceled.Text = "NO";
            this.btnExitCanceled.UseVisualStyleBackColor = false;
            // 
            // lbHeader
            // 
            this.lbHeader.Font = new System.Drawing.Font("MicroFLF", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbHeader.ForeColor = System.Drawing.Color.DimGray;
            this.lbHeader.Location = new System.Drawing.Point(321, 12);
            this.lbHeader.Margin = new System.Windows.Forms.Padding(6);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(354, 95);
            this.lbHeader.TabIndex = 20;
            this.lbHeader.Text = "Are you sure you want to quit the program?";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::VKR.PL.NET5.Properties.Resources.Exit;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 180);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // ExitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(701, 204);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbHeader);
            this.Controls.Add(this.btnExitCanceled);
            this.Controls.Add(this.btnExit);
            this.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ExitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExitForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnExitCanceled;
        private System.Windows.Forms.Label lbHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}