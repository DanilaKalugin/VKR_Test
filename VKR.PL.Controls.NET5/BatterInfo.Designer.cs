
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
            panelCurrentSituationBatter = new System.Windows.Forms.Panel();
            BatterStats = new System.Windows.Forms.Label();
            lbBatterSecondName = new System.Windows.Forms.Label();
            BatterNumber = new System.Windows.Forms.Label();
            panelCurrentSituationBatter.SuspendLayout();
            SuspendLayout();
            // 
            // panelCurrentSituationBatter
            // 
            panelCurrentSituationBatter.BackColor = System.Drawing.Color.FromArgb(48, 48, 48);
            panelCurrentSituationBatter.Controls.Add(BatterStats);
            panelCurrentSituationBatter.Controls.Add(lbBatterSecondName);
            panelCurrentSituationBatter.Controls.Add(BatterNumber);
            panelCurrentSituationBatter.Location = new System.Drawing.Point(0, 0);
            panelCurrentSituationBatter.Name = "panelCurrentSituationBatter";
            panelCurrentSituationBatter.Size = new System.Drawing.Size(250, 30);
            panelCurrentSituationBatter.TabIndex = 45;
            // 
            // BatterStats
            // 
            BatterStats.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            BatterStats.ForeColor = System.Drawing.Color.White;
            BatterStats.Location = new System.Drawing.Point(163, 5);
            BatterStats.Margin = new System.Windows.Forms.Padding(3, 5, 1, 5);
            BatterStats.Name = "BatterStats";
            BatterStats.Size = new System.Drawing.Size(86, 20);
            BatterStats.TabIndex = 4;
            BatterStats.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbBatterSecondName
            // 
            lbBatterSecondName.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lbBatterSecondName.ForeColor = System.Drawing.Color.White;
            lbBatterSecondName.Location = new System.Drawing.Point(28, 5);
            lbBatterSecondName.Margin = new System.Windows.Forms.Padding(3, 5, 1, 5);
            lbBatterSecondName.Name = "lbBatterSecondName";
            lbBatterSecondName.Size = new System.Drawing.Size(149, 20);
            lbBatterSecondName.TabIndex = 3;
            lbBatterSecondName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BatterNumber
            // 
            BatterNumber.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            BatterNumber.ForeColor = System.Drawing.Color.FromArgb(160, 160, 160);
            BatterNumber.Location = new System.Drawing.Point(3, 5);
            BatterNumber.Margin = new System.Windows.Forms.Padding(3, 5, 1, 5);
            BatterNumber.Name = "BatterNumber";
            BatterNumber.Size = new System.Drawing.Size(25, 20);
            BatterNumber.TabIndex = 1;
            BatterNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BatterInfo
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panelCurrentSituationBatter);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Name = "BatterInfo";
            Size = new System.Drawing.Size(250, 30);
            panelCurrentSituationBatter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCurrentSituationBatter;
        private System.Windows.Forms.Label BatterStats;
        private System.Windows.Forms.Label lbBatterSecondName;
        private System.Windows.Forms.Label BatterNumber;
    }
}
