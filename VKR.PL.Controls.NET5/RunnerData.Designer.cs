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
            this.lb_Runner1_Name = new System.Windows.Forms.Label();
            this.panel33 = new System.Windows.Forms.Panel();
            this.lb1stBase = new System.Windows.Forms.Label();
            this.RunnerOn1Photo = new System.Windows.Forms.Panel();
            this.panel1Base.SuspendLayout();
            this.panel33.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1Base
            // 
            this.panel1Base.Controls.Add(this.lb_Runner1_Name);
            this.panel1Base.Controls.Add(this.panel33);
            this.panel1Base.Location = new System.Drawing.Point(67, 0);
            this.panel1Base.Margin = new System.Windows.Forms.Padding(0);
            this.panel1Base.Name = "panel1Base";
            this.panel1Base.Size = new System.Drawing.Size(197, 100);
            this.panel1Base.TabIndex = 52;
            // 
            // lb_Runner1_Name
            // 
            this.lb_Runner1_Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lb_Runner1_Name.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lb_Runner1_Name.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_Runner1_Name.ForeColor = System.Drawing.Color.Gainsboro;
            this.lb_Runner1_Name.Location = new System.Drawing.Point(0, 23);
            this.lb_Runner1_Name.Name = "lb_Runner1_Name";
            this.lb_Runner1_Name.Padding = new System.Windows.Forms.Padding(4, 4, 0, 0);
            this.lb_Runner1_Name.Size = new System.Drawing.Size(197, 77);
            this.lb_Runner1_Name.TabIndex = 2;
            this.lb_Runner1_Name.Click += new System.EventHandler(this.RunnerData_Click);
            // 
            // panel33
            // 
            this.panel33.Controls.Add(this.lb1stBase);
            this.panel33.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel33.Location = new System.Drawing.Point(0, 0);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(197, 23);
            this.panel33.TabIndex = 1;
            // 
            // lb1stBase
            // 
            this.lb1stBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb1stBase.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb1stBase.ForeColor = System.Drawing.Color.White;
            this.lb1stBase.Location = new System.Drawing.Point(0, 0);
            this.lb1stBase.Name = "lb1stBase";
            this.lb1stBase.Size = new System.Drawing.Size(197, 23);
            this.lb1stBase.TabIndex = 1;
            this.lb1stBase.Text = "1ST BASE";
            this.lb1stBase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb1stBase.Click += new System.EventHandler(this.RunnerData_Click);
            // 
            // RunnerOn1Photo
            // 
            this.RunnerOn1Photo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RunnerOn1Photo.Location = new System.Drawing.Point(0, 0);
            this.RunnerOn1Photo.Name = "RunnerOn1Photo";
            this.RunnerOn1Photo.Size = new System.Drawing.Size(67, 100);
            this.RunnerOn1Photo.TabIndex = 53;
            this.RunnerOn1Photo.Click += new System.EventHandler(this.RunnerData_Click);
            // 
            // RunnerData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RunnerOn1Photo);
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
        private System.Windows.Forms.Label lb_Runner1_Name;
        private System.Windows.Forms.Panel panel33;
        private System.Windows.Forms.Label lb1stBase;
        private System.Windows.Forms.Panel RunnerOn1Photo;
    }
}
