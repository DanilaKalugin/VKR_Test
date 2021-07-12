
namespace VKR_Test
{
    partial class StatsMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatsMenuForm));
            this.btnCloseResultsMenu = new System.Windows.Forms.Button();
            this.btnTeamsStats = new System.Windows.Forms.Button();
            this.btnPlayersStats = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnCloseResultsMenu
            // 
            this.btnCloseResultsMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnCloseResultsMenu.FlatAppearance.BorderSize = 0;
            this.btnCloseResultsMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseResultsMenu.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseResultsMenu.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCloseResultsMenu.Location = new System.Drawing.Point(853, 286);
            this.btnCloseResultsMenu.Margin = new System.Windows.Forms.Padding(6);
            this.btnCloseResultsMenu.Name = "btnCloseResultsMenu";
            this.btnCloseResultsMenu.Size = new System.Drawing.Size(132, 49);
            this.btnCloseResultsMenu.TabIndex = 16;
            this.btnCloseResultsMenu.Text = "CLOSE";
            this.btnCloseResultsMenu.UseVisualStyleBackColor = false;
            this.btnCloseResultsMenu.Click += new System.EventHandler(this.btnCloseResultsMenu_Click);
            // 
            // btnTeamsStats
            // 
            this.btnTeamsStats.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTeamsStats.FlatAppearance.BorderSize = 0;
            this.btnTeamsStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTeamsStats.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeamsStats.Location = new System.Drawing.Point(502, 102);
            this.btnTeamsStats.Margin = new System.Windows.Forms.Padding(6);
            this.btnTeamsStats.Name = "btnTeamsStats";
            this.btnTeamsStats.Size = new System.Drawing.Size(250, 75);
            this.btnTeamsStats.TabIndex = 15;
            this.btnTeamsStats.Text = "TEAMS\' STATS";
            this.btnTeamsStats.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnTeamsStats.UseVisualStyleBackColor = false;
            this.btnTeamsStats.Click += new System.EventHandler(this.btnTeamsStats_Click);
            // 
            // btnPlayersStats
            // 
            this.btnPlayersStats.BackColor = System.Drawing.Color.Gainsboro;
            this.btnPlayersStats.FlatAppearance.BorderSize = 0;
            this.btnPlayersStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayersStats.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayersStats.Location = new System.Drawing.Point(502, 15);
            this.btnPlayersStats.Margin = new System.Windows.Forms.Padding(6);
            this.btnPlayersStats.Name = "btnPlayersStats";
            this.btnPlayersStats.Size = new System.Drawing.Size(250, 75);
            this.btnPlayersStats.TabIndex = 14;
            this.btnPlayersStats.Text = "PLAYERS\' STATS";
            this.btnPlayersStats.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPlayersStats.UseVisualStyleBackColor = false;
            this.btnPlayersStats.Click += new System.EventHandler(this.btnPlayersStats_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::VKR_Test.Properties.Resources.Stats;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(490, 350);
            this.panel2.TabIndex = 11;
            // 
            // StatsMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1000, 350);
            this.Controls.Add(this.btnCloseResultsMenu);
            this.Controls.Add(this.btnTeamsStats);
            this.Controls.Add(this.btnPlayersStats);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StatsMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StatsMenuForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCloseResultsMenu;
        private System.Windows.Forms.Button btnTeamsStats;
        private System.Windows.Forms.Button btnPlayersStats;
    }
}