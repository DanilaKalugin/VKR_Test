
using System.ComponentModel;
using System.Windows.Forms;

namespace VKR.PL.NET5
{
    partial class ScheduleAndResultsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleAndResultsForm));
            this.lbHeader = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMatchDayUpcomingMatches = new System.Windows.Forms.Button();
            this.btnMatchDayResults = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTeam1Next10Matches = new System.Windows.Forms.Button();
            this.btnTeam1Last10Matches = new System.Windows.Forms.Button();
            this.team1Header = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSeriesNextMatches = new System.Windows.Forms.Button();
            this.btnSeriesHistory = new System.Windows.Forms.Button();
            this.seriesHeader = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnTeam2Next10Matches = new System.Windows.Forms.Button();
            this.btnTeam2Last10Matches = new System.Windows.Forms.Button();
            this.team2Header = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbHeader
            // 
            this.lbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbHeader.Font = new System.Drawing.Font("MicroFLF", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbHeader.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbHeader.Location = new System.Drawing.Point(0, 0);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(800, 75);
            this.lbHeader.TabIndex = 2;
            this.lbHeader.Text = "SCHEDULE AND RESULTS";
            this.lbHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 75);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 375);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMatchDayUpcomingMatches);
            this.panel1.Controls.Add(this.btnMatchDayResults);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 181);
            this.panel1.TabIndex = 0;
            // 
            // btnMatchDayUpcomingMatches
            // 
            this.btnMatchDayUpcomingMatches.BackColor = System.Drawing.Color.Gainsboro;
            this.btnMatchDayUpcomingMatches.FlatAppearance.BorderSize = 0;
            this.btnMatchDayUpcomingMatches.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMatchDayUpcomingMatches.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMatchDayUpcomingMatches.Location = new System.Drawing.Point(12, 98);
            this.btnMatchDayUpcomingMatches.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnMatchDayUpcomingMatches.Name = "btnMatchDayUpcomingMatches";
            this.btnMatchDayUpcomingMatches.Size = new System.Drawing.Size(370, 35);
            this.btnMatchDayUpcomingMatches.TabIndex = 63;
            this.btnMatchDayUpcomingMatches.Text = "UPCOMING MATCHES";
            this.btnMatchDayUpcomingMatches.UseVisualStyleBackColor = false;
            this.btnMatchDayUpcomingMatches.Click += new System.EventHandler(this.btnMatchDayUpcomingMatches_Click);
            // 
            // btnMatchDayResults
            // 
            this.btnMatchDayResults.BackColor = System.Drawing.Color.Gainsboro;
            this.btnMatchDayResults.FlatAppearance.BorderSize = 0;
            this.btnMatchDayResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMatchDayResults.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMatchDayResults.Location = new System.Drawing.Point(12, 51);
            this.btnMatchDayResults.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnMatchDayResults.Name = "btnMatchDayResults";
            this.btnMatchDayResults.Size = new System.Drawing.Size(370, 35);
            this.btnMatchDayResults.TabIndex = 60;
            this.btnMatchDayResults.Text = "RESULTS";
            this.btnMatchDayResults.UseVisualStyleBackColor = false;
            this.btnMatchDayResults.Click += new System.EventHandler(this.btnMatchDayResults_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("MicroFLF", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(394, 45);
            this.label1.TabIndex = 3;
            this.label1.Text = "MATCHDAY";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnTeam1Next10Matches);
            this.panel2.Controls.Add(this.btnTeam1Last10Matches);
            this.panel2.Controls.Add(this.team1Header);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(403, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(394, 181);
            this.panel2.TabIndex = 1;
            // 
            // btnTeam1Next10Matches
            // 
            this.btnTeam1Next10Matches.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTeam1Next10Matches.FlatAppearance.BorderSize = 0;
            this.btnTeam1Next10Matches.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTeam1Next10Matches.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTeam1Next10Matches.Location = new System.Drawing.Point(12, 98);
            this.btnTeam1Next10Matches.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnTeam1Next10Matches.Name = "btnTeam1Next10Matches";
            this.btnTeam1Next10Matches.Size = new System.Drawing.Size(370, 35);
            this.btnTeam1Next10Matches.TabIndex = 63;
            this.btnTeam1Next10Matches.Text = "NEXT 10 MATCHES";
            this.btnTeam1Next10Matches.UseVisualStyleBackColor = false;
            this.btnTeam1Next10Matches.Click += new System.EventHandler(this.btnTeam1Next10Matches_Click);
            // 
            // btnTeam1Last10Matches
            // 
            this.btnTeam1Last10Matches.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTeam1Last10Matches.FlatAppearance.BorderSize = 0;
            this.btnTeam1Last10Matches.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTeam1Last10Matches.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTeam1Last10Matches.Location = new System.Drawing.Point(12, 51);
            this.btnTeam1Last10Matches.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnTeam1Last10Matches.Name = "btnTeam1Last10Matches";
            this.btnTeam1Last10Matches.Size = new System.Drawing.Size(370, 35);
            this.btnTeam1Last10Matches.TabIndex = 61;
            this.btnTeam1Last10Matches.Text = "LAST 10 MATCHES";
            this.btnTeam1Last10Matches.UseVisualStyleBackColor = false;
            this.btnTeam1Last10Matches.Click += new System.EventHandler(this.btnTeam1Last10Matches_Click);
            // 
            // team1Header
            // 
            this.team1Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.team1Header.Font = new System.Drawing.Font("MicroFLF", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.team1Header.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.team1Header.Location = new System.Drawing.Point(0, 0);
            this.team1Header.Name = "team1Header";
            this.team1Header.Size = new System.Drawing.Size(394, 45);
            this.team1Header.TabIndex = 4;
            this.team1Header.Text = "team1";
            this.team1Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSeriesNextMatches);
            this.panel3.Controls.Add(this.btnSeriesHistory);
            this.panel3.Controls.Add(this.seriesHeader);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 190);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(394, 182);
            this.panel3.TabIndex = 2;
            // 
            // btnSeriesNextMatches
            // 
            this.btnSeriesNextMatches.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSeriesNextMatches.FlatAppearance.BorderSize = 0;
            this.btnSeriesNextMatches.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeriesNextMatches.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSeriesNextMatches.Location = new System.Drawing.Point(12, 98);
            this.btnSeriesNextMatches.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSeriesNextMatches.Name = "btnSeriesNextMatches";
            this.btnSeriesNextMatches.Size = new System.Drawing.Size(370, 35);
            this.btnSeriesNextMatches.TabIndex = 63;
            this.btnSeriesNextMatches.Text = "UPCOMING MATCHES";
            this.btnSeriesNextMatches.UseVisualStyleBackColor = false;
            this.btnSeriesNextMatches.Click += new System.EventHandler(this.btnSeriesNextMatches_Click);
            // 
            // btnSeriesHistory
            // 
            this.btnSeriesHistory.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSeriesHistory.FlatAppearance.BorderSize = 0;
            this.btnSeriesHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeriesHistory.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSeriesHistory.Location = new System.Drawing.Point(12, 51);
            this.btnSeriesHistory.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSeriesHistory.Name = "btnSeriesHistory";
            this.btnSeriesHistory.Size = new System.Drawing.Size(370, 35);
            this.btnSeriesHistory.TabIndex = 62;
            this.btnSeriesHistory.Text = "RESULTS";
            this.btnSeriesHistory.UseVisualStyleBackColor = false;
            this.btnSeriesHistory.Click += new System.EventHandler(this.btnSeriesHistory_Click);
            // 
            // seriesHeader
            // 
            this.seriesHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.seriesHeader.Font = new System.Drawing.Font("MicroFLF", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.seriesHeader.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.seriesHeader.Location = new System.Drawing.Point(0, 0);
            this.seriesHeader.Name = "seriesHeader";
            this.seriesHeader.Size = new System.Drawing.Size(394, 45);
            this.seriesHeader.TabIndex = 4;
            this.seriesHeader.Text = "team1 - team2 Series";
            this.seriesHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnTeam2Next10Matches);
            this.panel4.Controls.Add(this.btnTeam2Last10Matches);
            this.panel4.Controls.Add(this.team2Header);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(403, 190);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(394, 182);
            this.panel4.TabIndex = 3;
            // 
            // btnTeam2Next10Matches
            // 
            this.btnTeam2Next10Matches.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTeam2Next10Matches.FlatAppearance.BorderSize = 0;
            this.btnTeam2Next10Matches.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTeam2Next10Matches.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTeam2Next10Matches.Location = new System.Drawing.Point(12, 98);
            this.btnTeam2Next10Matches.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnTeam2Next10Matches.Name = "btnTeam2Next10Matches";
            this.btnTeam2Next10Matches.Size = new System.Drawing.Size(370, 35);
            this.btnTeam2Next10Matches.TabIndex = 63;
            this.btnTeam2Next10Matches.Text = "NEXT 10 MATCHES";
            this.btnTeam2Next10Matches.UseVisualStyleBackColor = false;
            this.btnTeam2Next10Matches.Click += new System.EventHandler(this.btnTeam2Next10Matches_Click);
            // 
            // btnTeam2Last10Matches
            // 
            this.btnTeam2Last10Matches.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTeam2Last10Matches.FlatAppearance.BorderSize = 0;
            this.btnTeam2Last10Matches.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTeam2Last10Matches.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTeam2Last10Matches.Location = new System.Drawing.Point(12, 51);
            this.btnTeam2Last10Matches.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnTeam2Last10Matches.Name = "btnTeam2Last10Matches";
            this.btnTeam2Last10Matches.Size = new System.Drawing.Size(370, 35);
            this.btnTeam2Last10Matches.TabIndex = 62;
            this.btnTeam2Last10Matches.Text = "LAST 10 MATCHES";
            this.btnTeam2Last10Matches.UseVisualStyleBackColor = false;
            this.btnTeam2Last10Matches.Click += new System.EventHandler(this.btnTeam2Last10Matches_Click);
            // 
            // team2Header
            // 
            this.team2Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.team2Header.Font = new System.Drawing.Font("MicroFLF", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.team2Header.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.team2Header.Location = new System.Drawing.Point(0, 0);
            this.team2Header.Name = "team2Header";
            this.team2Header.Size = new System.Drawing.Size(394, 45);
            this.team2Header.TabIndex = 4;
            this.team2Header.Text = "team2";
            this.team2Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScheduleAndResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lbHeader);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ScheduleAndResultsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule and results";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label lbHeader;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Label team1Header;
        private Panel panel3;
        private Label seriesHeader;
        private Panel panel4;
        private Label team2Header;
        private Button btnMatchDayUpcomingMatches;
        private Button btnMatchDayResults;
        private Button btnTeam1Next10Matches;
        private Button btnTeam1Last10Matches;
        private Button btnSeriesNextMatches;
        private Button btnSeriesHistory;
        private Button btnTeam2Next10Matches;
        private Button btnTeam2Last10Matches;
    }
}