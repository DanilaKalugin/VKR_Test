using System.ComponentModel;
using System.Windows.Forms;

namespace VKR.PL.NET5
{
    partial class StatsMenuForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatsMenuForm));
            this.btnCloseResultsMenu = new System.Windows.Forms.Button();
            this.btnTeamsStats = new System.Windows.Forms.Button();
            this.btnPlayersStats = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvBattingLeaders = new System.Windows.Forms.DataGridView();
            this.Parameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvPitchingLeaders = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBattingLeaders)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPitchingLeaders)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCloseResultsMenu
            // 
            this.btnCloseResultsMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnCloseResultsMenu.FlatAppearance.BorderSize = 0;
            this.btnCloseResultsMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseResultsMenu.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCloseResultsMenu.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCloseResultsMenu.Location = new System.Drawing.Point(906, 286);
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
            this.btnTeamsStats.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            this.btnPlayersStats.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            this.panel2.BackgroundImage = global::VKR.PL.NET5.Properties.Resources.Stats;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(490, 350);
            this.panel2.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panel1.Controls.Add(this.dgvBattingLeaders);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1050, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 150);
            this.panel1.TabIndex = 17;
            // 
            // dgvBattingLeaders
            // 
            this.dgvBattingLeaders.AllowUserToAddRows = false;
            this.dgvBattingLeaders.AllowUserToDeleteRows = false;
            this.dgvBattingLeaders.AllowUserToResizeColumns = false;
            this.dgvBattingLeaders.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvBattingLeaders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBattingLeaders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBattingLeaders.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvBattingLeaders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBattingLeaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBattingLeaders.ColumnHeadersVisible = false;
            this.dgvBattingLeaders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Parameter,
            this.TeamColor,
            this.PlayerName,
            this.Value});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBattingLeaders.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBattingLeaders.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvBattingLeaders.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvBattingLeaders.Location = new System.Drawing.Point(0, 26);
            this.dgvBattingLeaders.Name = "dgvBattingLeaders";
            this.dgvBattingLeaders.ReadOnly = true;
            this.dgvBattingLeaders.RowHeadersVisible = false;
            this.dgvBattingLeaders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBattingLeaders.Size = new System.Drawing.Size(350, 124);
            this.dgvBattingLeaders.TabIndex = 1;
            // 
            // Parameter
            // 
            this.Parameter.FillWeight = 82.46645F;
            this.Parameter.HeaderText = "Team";
            this.Parameter.Name = "Parameter";
            this.Parameter.ReadOnly = true;
            this.Parameter.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // TeamColor
            // 
            this.TeamColor.FillWeight = 20.95935F;
            this.TeamColor.HeaderText = "";
            this.TeamColor.Name = "TeamColor";
            this.TeamColor.ReadOnly = true;
            this.TeamColor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // PlayerName
            // 
            this.PlayerName.FillWeight = 324.5579F;
            this.PlayerName.HeaderText = "Name";
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.ReadOnly = true;
            // 
            // Value
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Value.DefaultCellStyle = dataGridViewCellStyle2;
            this.Value.FillWeight = 75F;
            this.Value.HeaderText = "Age";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Batting leaders";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panel3.Controls.Add(this.dgvPitchingLeaders);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(1050, 211);
            this.panel3.Margin = new System.Windows.Forms.Padding(6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(350, 139);
            this.panel3.TabIndex = 18;
            // 
            // dgvPitchingLeaders
            // 
            this.dgvPitchingLeaders.AllowUserToAddRows = false;
            this.dgvPitchingLeaders.AllowUserToDeleteRows = false;
            this.dgvPitchingLeaders.AllowUserToResizeColumns = false;
            this.dgvPitchingLeaders.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvPitchingLeaders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPitchingLeaders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPitchingLeaders.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPitchingLeaders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPitchingLeaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPitchingLeaders.ColumnHeadersVisible = false;
            this.dgvPitchingLeaders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPitchingLeaders.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPitchingLeaders.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvPitchingLeaders.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPitchingLeaders.Location = new System.Drawing.Point(0, 26);
            this.dgvPitchingLeaders.Name = "dgvPitchingLeaders";
            this.dgvPitchingLeaders.ReadOnly = true;
            this.dgvPitchingLeaders.RowHeadersVisible = false;
            this.dgvPitchingLeaders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPitchingLeaders.Size = new System.Drawing.Size(350, 113);
            this.dgvPitchingLeaders.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 82.46645F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Team";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 20.95935F;
            this.dataGridViewTextBoxColumn2.HeaderText = "";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.FillWeight = 324.5579F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn4.FillWeight = 75F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Age";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(350, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Pitching leaders";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatsMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1400, 350);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCloseResultsMenu);
            this.Controls.Add(this.btnTeamsStats);
            this.Controls.Add(this.btnPlayersStats);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StatsMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistics";
            this.Load += new System.EventHandler(this.StatsMenuForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBattingLeaders)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPitchingLeaders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel2;
        private Button btnCloseResultsMenu;
        private Button btnTeamsStats;
        private Button btnPlayersStats;
        private Panel panel1;
        private DataGridView dgvBattingLeaders;
        private Label label1;
        private DataGridViewTextBoxColumn Parameter;
        private DataGridViewTextBoxColumn TeamColor;
        private DataGridViewTextBoxColumn PlayerName;
        private DataGridViewTextBoxColumn Value;
        private Panel panel3;
        private DataGridView dgvPitchingLeaders;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private Label label2;
    }
}