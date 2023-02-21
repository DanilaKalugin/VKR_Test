namespace VKR.PL.Controls.NET5
{
    partial class RunnerData
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1Base = new System.Windows.Forms.Panel();
            this.lbRunnerName = new System.Windows.Forms.Label();
            this.panel33 = new System.Windows.Forms.Panel();
            this.lbHeader = new System.Windows.Forms.Label();
            this.RunnerPhoto = new System.Windows.Forms.Panel();
            this.panel1Base.SuspendLayout();
            this.panel33.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1Base
            // 
            this.panel1Base.Controls.Add(this.lbRunnerName);
            this.panel1Base.Controls.Add(this.panel33);
            this.panel1Base.Location = new System.Drawing.Point(67, 0);
            this.panel1Base.Margin = new System.Windows.Forms.Padding(0);
            this.panel1Base.Name = "panel1Base";
            this.panel1Base.Size = new System.Drawing.Size(197, 100);
            this.panel1Base.TabIndex = 52;
            // 
            // lbRunnerName
            // 
            this.lbRunnerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lbRunnerName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbRunnerName.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbRunnerName.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbRunnerName.Location = new System.Drawing.Point(0, 23);
            this.lbRunnerName.Name = "lbRunnerName";
            this.lbRunnerName.Padding = new System.Windows.Forms.Padding(4, 4, 0, 0);
            this.lbRunnerName.Size = new System.Drawing.Size(197, 77);
            this.lbRunnerName.TabIndex = 2;
            this.lbRunnerName.Click += new System.EventHandler(this.RunnerData_Click);
            // 
            // panel33
            // 
            this.panel33.Controls.Add(this.lbHeader);
            this.panel33.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel33.Location = new System.Drawing.Point(0, 0);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(197, 23);
            this.panel33.TabIndex = 1;
            // 
            // lbHeader
            // 
            this.lbHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbHeader.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbHeader.ForeColor = System.Drawing.Color.White;
            this.lbHeader.Location = new System.Drawing.Point(0, 0);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(197, 23);
            this.lbHeader.TabIndex = 1;
            this.lbHeader.Text = "1ST BASE";
            this.lbHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbHeader.BackColorChanged += new System.EventHandler(this.lbHeader_BackColorChanged);
            this.lbHeader.Click += new System.EventHandler(this.RunnerData_Click);
            // 
            // RunnerPhoto
            // 
            this.RunnerPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RunnerPhoto.Location = new System.Drawing.Point(0, 0);
            this.RunnerPhoto.Name = "RunnerPhoto";
            this.RunnerPhoto.Size = new System.Drawing.Size(67, 100);
            this.RunnerPhoto.TabIndex = 53;
            this.RunnerPhoto.Click += new System.EventHandler(this.RunnerData_Click);
            // 
            // RunnerData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RunnerPhoto);
            this.Controls.Add(this.panel1Base);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "RunnerData";
            this.Size = new System.Drawing.Size(264, 100);
            this.Click += new System.EventHandler(this.RunnerData_Click);
            this.panel1Base.ResumeLayout(false);
            this.panel33.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1Base;
        private System.Windows.Forms.Label lbRunnerName;
        private System.Windows.Forms.Panel panel33;
        private System.Windows.Forms.Label lbHeader;
        private System.Windows.Forms.Panel RunnerPhoto;
    }
}
