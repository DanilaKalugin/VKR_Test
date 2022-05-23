using System.ComponentModel;
using System.Windows.Forms;

namespace VKR.PL.NET5
{
    partial class StadiumSelectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StadiumSelectionForm));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDecreaseStadiumNumberBy1 = new System.Windows.Forms.Button();
            this.btnIncreaseStadiumNumberBy1 = new System.Windows.Forms.Button();
            this.lbDistanceToCenterField = new System.Windows.Forms.Label();
            this.lbStadiumCapacity = new System.Windows.Forms.Label();
            this.lbStadiumLocation = new System.Windows.Forms.Label();
            this.lbStadiumName = new System.Windows.Forms.Label();
            this.pbHomeTeamLogo = new System.Windows.Forms.Panel();
            this.pbAwayTeamLogo = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pbStadiumPhoto = new System.Windows.Forms.Panel();
            this.btnAcceptSelectedStadium = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.label2.Location = new System.Drawing.Point(12, 577);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Location";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.label3.Location = new System.Drawing.Point(12, 600);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(255, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Capacity";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.label4.Location = new System.Drawing.Point(12, 623);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(261, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Distance to center field";
            // 
            // btnDecreaseStadiumNumberBy1
            // 
            this.btnDecreaseStadiumNumberBy1.FlatAppearance.BorderSize = 0;
            this.btnDecreaseStadiumNumberBy1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecreaseStadiumNumberBy1.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDecreaseStadiumNumberBy1.ForeColor = System.Drawing.Color.White;
            this.btnDecreaseStadiumNumberBy1.Location = new System.Drawing.Point(9, 95);
            this.btnDecreaseStadiumNumberBy1.Name = "btnDecreaseStadiumNumberBy1";
            this.btnDecreaseStadiumNumberBy1.Size = new System.Drawing.Size(45, 23);
            this.btnDecreaseStadiumNumberBy1.TabIndex = 4;
            this.btnDecreaseStadiumNumberBy1.Text = "<";
            this.btnDecreaseStadiumNumberBy1.UseVisualStyleBackColor = true;
            this.btnDecreaseStadiumNumberBy1.Click += new System.EventHandler(this.btnDecreaseStadiumNumberBy1_Click);
            // 
            // btnIncreaseStadiumNumberBy1
            // 
            this.btnIncreaseStadiumNumberBy1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIncreaseStadiumNumberBy1.FlatAppearance.BorderSize = 0;
            this.btnIncreaseStadiumNumberBy1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncreaseStadiumNumberBy1.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIncreaseStadiumNumberBy1.ForeColor = System.Drawing.Color.White;
            this.btnIncreaseStadiumNumberBy1.Location = new System.Drawing.Point(558, 95);
            this.btnIncreaseStadiumNumberBy1.Name = "btnIncreaseStadiumNumberBy1";
            this.btnIncreaseStadiumNumberBy1.Size = new System.Drawing.Size(45, 23);
            this.btnIncreaseStadiumNumberBy1.TabIndex = 5;
            this.btnIncreaseStadiumNumberBy1.Text = ">";
            this.btnIncreaseStadiumNumberBy1.UseVisualStyleBackColor = true;
            this.btnIncreaseStadiumNumberBy1.Click += new System.EventHandler(this.btnIncreaseStadiumNumberBy1_Click);
            // 
            // lbDistanceToCenterField
            // 
            this.lbDistanceToCenterField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDistanceToCenterField.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbDistanceToCenterField.ForeColor = System.Drawing.Color.White;
            this.lbDistanceToCenterField.Location = new System.Drawing.Point(275, 623);
            this.lbDistanceToCenterField.Name = "lbDistanceToCenterField";
            this.lbDistanceToCenterField.Size = new System.Drawing.Size(331, 23);
            this.lbDistanceToCenterField.TabIndex = 9;
            this.lbDistanceToCenterField.Text = "label5";
            this.lbDistanceToCenterField.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbStadiumCapacity
            // 
            this.lbStadiumCapacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStadiumCapacity.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbStadiumCapacity.ForeColor = System.Drawing.Color.White;
            this.lbStadiumCapacity.Location = new System.Drawing.Point(275, 600);
            this.lbStadiumCapacity.Name = "lbStadiumCapacity";
            this.lbStadiumCapacity.Size = new System.Drawing.Size(331, 23);
            this.lbStadiumCapacity.TabIndex = 8;
            this.lbStadiumCapacity.Text = "label6";
            this.lbStadiumCapacity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbStadiumLocation
            // 
            this.lbStadiumLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStadiumLocation.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbStadiumLocation.ForeColor = System.Drawing.Color.White;
            this.lbStadiumLocation.Location = new System.Drawing.Point(275, 577);
            this.lbStadiumLocation.Name = "lbStadiumLocation";
            this.lbStadiumLocation.Size = new System.Drawing.Size(331, 23);
            this.lbStadiumLocation.TabIndex = 7;
            this.lbStadiumLocation.Text = "label7";
            this.lbStadiumLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbStadiumName
            // 
            this.lbStadiumName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStadiumName.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbStadiumName.ForeColor = System.Drawing.Color.White;
            this.lbStadiumName.Location = new System.Drawing.Point(60, 95);
            this.lbStadiumName.Name = "lbStadiumName";
            this.lbStadiumName.Size = new System.Drawing.Size(492, 23);
            this.lbStadiumName.TabIndex = 10;
            this.lbStadiumName.Text = "label1";
            this.lbStadiumName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbHomeTeamLogo
            // 
            this.pbHomeTeamLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbHomeTeamLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbHomeTeamLogo.Location = new System.Drawing.Point(345, 3);
            this.pbHomeTeamLogo.Name = "pbHomeTeamLogo";
            this.pbHomeTeamLogo.Size = new System.Drawing.Size(80, 80);
            this.pbHomeTeamLogo.TabIndex = 12;
            // 
            // pbAwayTeamLogo
            // 
            this.pbAwayTeamLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbAwayTeamLogo.Location = new System.Drawing.Point(193, 3);
            this.pbAwayTeamLogo.Name = "pbAwayTeamLogo";
            this.pbAwayTeamLogo.Size = new System.Drawing.Size(80, 80);
            this.pbAwayTeamLogo.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(279, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 80);
            this.label8.TabIndex = 13;
            this.label8.Text = "vs";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Controls.Add(this.pbHomeTeamLogo);
            this.panel3.Controls.Add(this.pbAwayTeamLogo);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(618, 86);
            this.panel3.TabIndex = 14;
            // 
            // pbStadiumPhoto
            // 
            this.pbStadiumPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbStadiumPhoto.Location = new System.Drawing.Point(6, 124);
            this.pbStadiumPhoto.Name = "pbStadiumPhoto";
            this.pbStadiumPhoto.Size = new System.Drawing.Size(600, 450);
            this.pbStadiumPhoto.TabIndex = 15;
            // 
            // btnAcceptSelectedStadium
            // 
            this.btnAcceptSelectedStadium.FlatAppearance.BorderSize = 0;
            this.btnAcceptSelectedStadium.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceptSelectedStadium.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAcceptSelectedStadium.ForeColor = System.Drawing.Color.White;
            this.btnAcceptSelectedStadium.Location = new System.Drawing.Point(12, 649);
            this.btnAcceptSelectedStadium.Name = "btnAcceptSelectedStadium";
            this.btnAcceptSelectedStadium.Size = new System.Drawing.Size(594, 28);
            this.btnAcceptSelectedStadium.TabIndex = 16;
            this.btnAcceptSelectedStadium.Text = "CONFIRM";
            this.btnAcceptSelectedStadium.UseVisualStyleBackColor = true;
            this.btnAcceptSelectedStadium.Click += new System.EventHandler(this.btnAcceptSelectedStadium_Click);
            // 
            // StadiumSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(618, 689);
            this.Controls.Add(this.btnAcceptSelectedStadium);
            this.Controls.Add(this.pbStadiumPhoto);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lbStadiumName);
            this.Controls.Add(this.lbDistanceToCenterField);
            this.Controls.Add(this.lbStadiumCapacity);
            this.Controls.Add(this.lbStadiumLocation);
            this.Controls.Add(this.btnIncreaseStadiumNumberBy1);
            this.Controls.Add(this.btnDecreaseStadiumNumberBy1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StadiumSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stadium selection";
            this.Load += new System.EventHandler(this.StadiumSelectionForm_Load);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnDecreaseStadiumNumberBy1;
        private Button btnIncreaseStadiumNumberBy1;
        private Label lbDistanceToCenterField;
        private Label lbStadiumCapacity;
        private Label lbStadiumLocation;
        private Label lbStadiumName;
        private Panel pbHomeTeamLogo;
        private Panel pbAwayTeamLogo;
        private Label label8;
        private Panel panel3;
        private Panel pbStadiumPhoto;
        private Button btnAcceptSelectedStadium;
    }
}