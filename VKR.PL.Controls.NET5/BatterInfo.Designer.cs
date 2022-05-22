
namespace VKR.PL.Controls.NET5
{
    partial class BatterInfo
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
            this.panelCurrentSituationBatter = new System.Windows.Forms.Panel();
            this.BatterStats = new System.Windows.Forms.Label();
            this.lbBatterSecondName = new System.Windows.Forms.Label();
            this.BatterNumber = new System.Windows.Forms.Label();
            this.panelCurrentSituationBatter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCurrentSituationBatter
            // 
            this.panelCurrentSituationBatter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panelCurrentSituationBatter.Controls.Add(this.BatterStats);
            this.panelCurrentSituationBatter.Controls.Add(this.lbBatterSecondName);
            this.panelCurrentSituationBatter.Controls.Add(this.BatterNumber);
            this.panelCurrentSituationBatter.Location = new System.Drawing.Point(0, 0);
            this.panelCurrentSituationBatter.Name = "panelCurrentSituationBatter";
            this.panelCurrentSituationBatter.Size = new System.Drawing.Size(250, 30);
            this.panelCurrentSituationBatter.TabIndex = 45;
            // 
            // BatterStats
            // 
            this.BatterStats.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BatterStats.ForeColor = System.Drawing.Color.White;
            this.BatterStats.Location = new System.Drawing.Point(163, 5);
            this.BatterStats.Margin = new System.Windows.Forms.Padding(3, 5, 1, 5);
            this.BatterStats.Name = "BatterStats";
            this.BatterStats.Size = new System.Drawing.Size(86, 20);
            this.BatterStats.TabIndex = 4;
            this.BatterStats.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbBatterSecondName
            // 
            this.lbBatterSecondName.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBatterSecondName.ForeColor = System.Drawing.Color.White;
            this.lbBatterSecondName.Location = new System.Drawing.Point(28, 5);
            this.lbBatterSecondName.Margin = new System.Windows.Forms.Padding(3, 5, 1, 5);
            this.lbBatterSecondName.Name = "lbBatterSecondName";
            this.lbBatterSecondName.Size = new System.Drawing.Size(149, 20);
            this.lbBatterSecondName.TabIndex = 3;
            this.lbBatterSecondName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BatterNumber
            // 
            this.BatterNumber.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BatterNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.BatterNumber.Location = new System.Drawing.Point(3, 5);
            this.BatterNumber.Margin = new System.Windows.Forms.Padding(3, 5, 1, 5);
            this.BatterNumber.Name = "BatterNumber";
            this.BatterNumber.Size = new System.Drawing.Size(25, 20);
            this.BatterNumber.TabIndex = 1;
            this.BatterNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BatterInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCurrentSituationBatter);
            this.Name = "BatterInfo";
            this.Size = new System.Drawing.Size(250, 30);
            this.panelCurrentSituationBatter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCurrentSituationBatter;
        private System.Windows.Forms.Label BatterStats;
        private System.Windows.Forms.Label lbBatterSecondName;
        private System.Windows.Forms.Label BatterNumber;
    }
}
