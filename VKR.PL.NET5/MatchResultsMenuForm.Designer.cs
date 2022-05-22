
using System.ComponentModel;
using System.Windows.Forms;

namespace VKR.PL.NET5
{
    partial class MatchResultsMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchResultsMenuForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnResults = new System.Windows.Forms.Button();
            this.btnResultsByDate = new System.Windows.Forms.Button();
            this.btnCloseResultsMenu = new System.Windows.Forms.Button();
            this.btnScheduleByTeam = new System.Windows.Forms.Button();
            this.btnScheduleByDate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::VKR.PL.NET5.Properties.Resources.MatchResults;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(632, 450);
            this.panel2.TabIndex = 10;
            // 
            // btnResults
            // 
            this.btnResults.BackColor = System.Drawing.Color.Gainsboro;
            this.btnResults.FlatAppearance.BorderSize = 0;
            this.btnResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResults.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnResults.Location = new System.Drawing.Point(432, 15);
            this.btnResults.Margin = new System.Windows.Forms.Padding(6);
            this.btnResults.Name = "btnResults";
            this.btnResults.Size = new System.Drawing.Size(250, 150);
            this.btnResults.TabIndex = 11;
            this.btnResults.Text = "MATCH RESULTS BY TEAM";
            this.btnResults.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnResults.UseVisualStyleBackColor = false;
            this.btnResults.Click += new System.EventHandler(this.btnResults_Click);
            // 
            // btnResultsByDate
            // 
            this.btnResultsByDate.BackColor = System.Drawing.Color.Gainsboro;
            this.btnResultsByDate.FlatAppearance.BorderSize = 0;
            this.btnResultsByDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResultsByDate.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnResultsByDate.Location = new System.Drawing.Point(432, 177);
            this.btnResultsByDate.Margin = new System.Windows.Forms.Padding(6);
            this.btnResultsByDate.Name = "btnResultsByDate";
            this.btnResultsByDate.Size = new System.Drawing.Size(250, 150);
            this.btnResultsByDate.TabIndex = 12;
            this.btnResultsByDate.Text = "MATCH RESULTS BY DATE";
            this.btnResultsByDate.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnResultsByDate.UseVisualStyleBackColor = false;
            this.btnResultsByDate.Click += new System.EventHandler(this.btnResultsByDate_Click);
            // 
            // btnCloseResultsMenu
            // 
            this.btnCloseResultsMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseResultsMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnCloseResultsMenu.FlatAppearance.BorderSize = 0;
            this.btnCloseResultsMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseResultsMenu.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCloseResultsMenu.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCloseResultsMenu.Location = new System.Drawing.Point(787, 380);
            this.btnCloseResultsMenu.Name = "btnCloseResultsMenu";
            this.btnCloseResultsMenu.Size = new System.Drawing.Size(154, 57);
            this.btnCloseResultsMenu.TabIndex = 13;
            this.btnCloseResultsMenu.Text = "CLOSE";
            this.btnCloseResultsMenu.UseVisualStyleBackColor = false;
            this.btnCloseResultsMenu.Click += new System.EventHandler(this.btnCloseResultsMenu_Click);
            // 
            // btnScheduleByTeam
            // 
            this.btnScheduleByTeam.BackColor = System.Drawing.Color.Gainsboro;
            this.btnScheduleByTeam.FlatAppearance.BorderSize = 0;
            this.btnScheduleByTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScheduleByTeam.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnScheduleByTeam.Location = new System.Drawing.Point(694, 15);
            this.btnScheduleByTeam.Margin = new System.Windows.Forms.Padding(6);
            this.btnScheduleByTeam.Name = "btnScheduleByTeam";
            this.btnScheduleByTeam.Size = new System.Drawing.Size(250, 150);
            this.btnScheduleByTeam.TabIndex = 14;
            this.btnScheduleByTeam.Text = "SCHEDULE BY TEAM";
            this.btnScheduleByTeam.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnScheduleByTeam.UseVisualStyleBackColor = false;
            this.btnScheduleByTeam.Click += new System.EventHandler(this.btnScheduleByTeam_Click);
            // 
            // btnScheduleByDate
            // 
            this.btnScheduleByDate.BackColor = System.Drawing.Color.Gainsboro;
            this.btnScheduleByDate.FlatAppearance.BorderSize = 0;
            this.btnScheduleByDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScheduleByDate.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnScheduleByDate.Location = new System.Drawing.Point(694, 177);
            this.btnScheduleByDate.Margin = new System.Windows.Forms.Padding(6);
            this.btnScheduleByDate.Name = "btnScheduleByDate";
            this.btnScheduleByDate.Size = new System.Drawing.Size(250, 150);
            this.btnScheduleByDate.TabIndex = 15;
            this.btnScheduleByDate.Text = "SCHEDULE BY DATE";
            this.btnScheduleByDate.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnScheduleByDate.UseVisualStyleBackColor = false;
            this.btnScheduleByDate.Click += new System.EventHandler(this.btnScheduleByDate_Click);
            // 
            // MatchResultsMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(959, 450);
            this.Controls.Add(this.btnResults);
            this.Controls.Add(this.btnResultsByDate);
            this.Controls.Add(this.btnScheduleByDate);
            this.Controls.Add(this.btnScheduleByTeam);
            this.Controls.Add(this.btnCloseResultsMenu);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "MatchResultsMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule & match results";
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel2;
        private Button btnResults;
        private Button btnResultsByDate;
        private Button btnCloseResultsMenu;
        private Button btnScheduleByTeam;
        private Button btnScheduleByDate;
    }
}