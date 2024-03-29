﻿
using System.ComponentModel;
using System.Windows.Forms;

namespace VKR.PL.NET5
{
    partial class StandingsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StandingsForm));
            this.dgvStandings = new System.Windows.Forms.DataGridView();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStandingsDate = new System.Windows.Forms.DateTimePicker();
            this.cbSeasons = new System.Windows.Forms.ComboBox();
            this.TeamColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamWins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamLosses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamGB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamPCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamStreak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStandings)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStandings
            // 
            this.dgvStandings.AllowDrop = true;
            this.dgvStandings.AllowUserToAddRows = false;
            this.dgvStandings.AllowUserToDeleteRows = false;
            this.dgvStandings.AllowUserToResizeColumns = false;
            this.dgvStandings.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dgvStandings.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStandings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStandings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStandings.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvStandings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStandings.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStandings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStandings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStandings.ColumnHeadersVisible = false;
            this.dgvStandings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TeamColor,
            this.TeamName,
            this.TeamWins,
            this.TeamLosses,
            this.TeamGB,
            this.TeamPCT,
            this.TeamStreak,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("MicroFLF", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStandings.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvStandings.EnableHeadersVisualStyles = false;
            this.dgvStandings.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvStandings.Location = new System.Drawing.Point(12, 45);
            this.dgvStandings.Name = "dgvStandings";
            this.dgvStandings.ReadOnly = true;
            this.dgvStandings.RowHeadersVisible = false;
            this.dgvStandings.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvStandings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStandings.Size = new System.Drawing.Size(776, 1004);
            this.dgvStandings.TabIndex = 0;
            // 
            // cbFilter
            // 
            this.cbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbFilter.Items.AddRange(new object[] {
            "MLB",
            "League",
            "Division",
            "Wild card"});
            this.cbFilter.Location = new System.Drawing.Point(300, 9);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(121, 27);
            this.cbFilter.TabIndex = 1;
            this.cbFilter.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(282, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "CURRENT STANDINGS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpStandingsDate
            // 
            this.dtpStandingsDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpStandingsDate.CalendarForeColor = System.Drawing.Color.WhiteSmoke;
            this.dtpStandingsDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dtpStandingsDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dtpStandingsDate.CalendarTitleForeColor = System.Drawing.Color.WhiteSmoke;
            this.dtpStandingsDate.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtpStandingsDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStandingsDate.Location = new System.Drawing.Point(427, 9);
            this.dtpStandingsDate.MaxDate = new System.DateTime(2021, 10, 3, 0, 0, 0, 0);
            this.dtpStandingsDate.MinDate = new System.DateTime(2021, 4, 1, 0, 0, 0, 0);
            this.dtpStandingsDate.Name = "dtpStandingsDate";
            this.dtpStandingsDate.Size = new System.Drawing.Size(208, 27);
            this.dtpStandingsDate.TabIndex = 5;
            this.dtpStandingsDate.Value = new System.DateTime(2021, 4, 12, 0, 0, 0, 0);
            this.dtpStandingsDate.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // cbSeasons
            // 
            this.cbSeasons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSeasons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSeasons.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbSeasons.Items.AddRange(new object[] {
            "MLB",
            "League",
            "Division",
            "Wild card"});
            this.cbSeasons.Location = new System.Drawing.Point(667, 9);
            this.cbSeasons.Name = "cbSeasons";
            this.cbSeasons.Size = new System.Drawing.Size(121, 27);
            this.cbSeasons.TabIndex = 6;
            this.cbSeasons.SelectedIndexChanged += new System.EventHandler(this.cbSeasons_SelectedIndexChanged);
            // 
            // TeamColor
            // 
            this.TeamColor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TeamColor.FillWeight = 10F;
            this.TeamColor.HeaderText = "";
            this.TeamColor.Name = "TeamColor";
            this.TeamColor.ReadOnly = true;
            this.TeamColor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TeamColor.Width = 22;
            // 
            // TeamName
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.TeamName.DefaultCellStyle = dataGridViewCellStyle3;
            this.TeamName.FillWeight = 250F;
            this.TeamName.HeaderText = "Team";
            this.TeamName.Name = "TeamName";
            this.TeamName.ReadOnly = true;
            this.TeamName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TeamWins
            // 
            this.TeamWins.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TeamWins.DefaultCellStyle = dataGridViewCellStyle4;
            this.TeamWins.FillWeight = 30F;
            this.TeamWins.HeaderText = "W";
            this.TeamWins.Name = "TeamWins";
            this.TeamWins.ReadOnly = true;
            this.TeamWins.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TeamWins.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TeamWins.ToolTipText = "Wins";
            this.TeamWins.Width = 49;
            // 
            // TeamLosses
            // 
            this.TeamLosses.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TeamLosses.DefaultCellStyle = dataGridViewCellStyle5;
            this.TeamLosses.FillWeight = 30F;
            this.TeamLosses.HeaderText = "L";
            this.TeamLosses.Name = "TeamLosses";
            this.TeamLosses.ReadOnly = true;
            this.TeamLosses.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TeamLosses.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TeamLosses.ToolTipText = "Losses";
            this.TeamLosses.Width = 49;
            // 
            // TeamGB
            // 
            this.TeamGB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TeamGB.DefaultCellStyle = dataGridViewCellStyle6;
            this.TeamGB.FillWeight = 30F;
            this.TeamGB.HeaderText = "GB";
            this.TeamGB.Name = "TeamGB";
            this.TeamGB.ReadOnly = true;
            this.TeamGB.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TeamGB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TeamGB.ToolTipText = "Games Behind";
            this.TeamGB.Width = 49;
            // 
            // TeamPCT
            // 
            this.TeamPCT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TeamPCT.DefaultCellStyle = dataGridViewCellStyle7;
            this.TeamPCT.FillWeight = 35F;
            this.TeamPCT.HeaderText = "PCT";
            this.TeamPCT.Name = "TeamPCT";
            this.TeamPCT.ReadOnly = true;
            this.TeamPCT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TeamPCT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TeamPCT.ToolTipText = "Winning Percentage";
            this.TeamPCT.Width = 57;
            // 
            // TeamStreak
            // 
            this.TeamStreak.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TeamStreak.DefaultCellStyle = dataGridViewCellStyle8;
            this.TeamStreak.FillWeight = 30F;
            this.TeamStreak.HeaderText = "STREAK";
            this.TeamStreak.Name = "TeamStreak";
            this.TeamStreak.ReadOnly = true;
            this.TeamStreak.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TeamStreak.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TeamStreak.ToolTipText = "Current streak";
            this.TeamStreak.Width = 75;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column1.FillWeight = 30F;
            this.Column1.HeaderText = "RS";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.ToolTipText = "Runs scored";
            this.Column1.Width = 49;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle10;
            this.Column2.FillWeight = 30F;
            this.Column2.HeaderText = "RA";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.ToolTipText = "Runs allowed";
            this.Column2.Width = 49;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle11;
            this.Column3.FillWeight = 30F;
            this.Column3.HeaderText = "DIFF";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.ToolTipText = "Run differential";
            this.Column3.Width = 49;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle12;
            this.Column4.FillWeight = 65F;
            this.Column4.HeaderText = "HOME";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 69;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle13;
            this.Column5.FillWeight = 65F;
            this.Column5.HeaderText = "AWAY";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 68;
            // 
            // StandingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(800, 1061);
            this.Controls.Add(this.cbSeasons);
            this.Controls.Add(this.dtpStandingsDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.dgvStandings);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "StandingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Standings";
            this.Load += new System.EventHandler(this.StandingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStandings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvStandings;
        private ComboBox cbFilter;
        private Label label2;
        private DateTimePicker dtpStandingsDate;
        private ComboBox cbSeasons;
        private DataGridViewTextBoxColumn TeamColor;
        private DataGridViewTextBoxColumn TeamName;
        private DataGridViewTextBoxColumn TeamWins;
        private DataGridViewTextBoxColumn TeamLosses;
        private DataGridViewTextBoxColumn TeamGB;
        private DataGridViewTextBoxColumn TeamPCT;
        private DataGridViewTextBoxColumn TeamStreak;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
    }
}