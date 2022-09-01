
using System.ComponentModel;
using System.Windows.Forms;

namespace VKR.PL.NET5
{
    partial class MainMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvBirthDays = new System.Windows.Forms.DataGridView();
            this.TeamColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_StartMatchFromSchedule = new System.Windows.Forms.Button();
            this.btnStandings = new System.Windows.Forms.Button();
            this.btnPlayerStats = new System.Windows.Forms.Button();
            this.btnLineups = new System.Windows.Forms.Button();
            this.btnResults = new System.Windows.Forms.Button();
            this.btnNewMatch = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAdminMenu = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBirthDays)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panel1.Controls.Add(this.dgvBirthDays);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1204, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 450);
            this.panel1.TabIndex = 0;
            // 
            // dgvBirthDays
            // 
            this.dgvBirthDays.AllowUserToAddRows = false;
            this.dgvBirthDays.AllowUserToDeleteRows = false;
            this.dgvBirthDays.AllowUserToResizeColumns = false;
            this.dgvBirthDays.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvBirthDays.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBirthDays.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBirthDays.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvBirthDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBirthDays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBirthDays.ColumnHeadersVisible = false;
            this.dgvBirthDays.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TeamColor,
            this.TeamName,
            this.PlayerName,
            this.Age});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBirthDays.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBirthDays.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvBirthDays.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvBirthDays.Location = new System.Drawing.Point(0, 33);
            this.dgvBirthDays.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvBirthDays.Name = "dgvBirthDays";
            this.dgvBirthDays.ReadOnly = true;
            this.dgvBirthDays.RowHeadersVisible = false;
            this.dgvBirthDays.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBirthDays.Size = new System.Drawing.Size(350, 417);
            this.dgvBirthDays.TabIndex = 1;
            // 
            // TeamColor
            // 
            this.TeamColor.FillWeight = 20.95935F;
            this.TeamColor.HeaderText = "";
            this.TeamColor.Name = "TeamColor";
            this.TeamColor.ReadOnly = true;
            this.TeamColor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // TeamName
            // 
            this.TeamName.FillWeight = 82.46645F;
            this.TeamName.HeaderText = "Team";
            this.TeamName.Name = "TeamName";
            this.TeamName.ReadOnly = true;
            this.TeamName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // PlayerName
            // 
            this.PlayerName.FillWeight = 324.5579F;
            this.PlayerName.HeaderText = "Name";
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.ReadOnly = true;
            // 
            // Age
            // 
            this.Age.FillWeight = 59.6706F;
            this.Age.HeaderText = "Age";
            this.Age.Name = "Age";
            this.Age.ReadOnly = true;
            this.Age.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Happy Birthday";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_StartMatchFromSchedule
            // 
            this.btn_StartMatchFromSchedule.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_StartMatchFromSchedule.FlatAppearance.BorderSize = 0;
            this.btn_StartMatchFromSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_StartMatchFromSchedule.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_StartMatchFromSchedule.Location = new System.Drawing.Point(418, 96);
            this.btn_StartMatchFromSchedule.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.btn_StartMatchFromSchedule.Name = "btn_StartMatchFromSchedule";
            this.btn_StartMatchFromSchedule.Size = new System.Drawing.Size(250, 76);
            this.btn_StartMatchFromSchedule.TabIndex = 1;
            this.btn_StartMatchFromSchedule.Text = "REAL MLB SEASON";
            this.btn_StartMatchFromSchedule.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_StartMatchFromSchedule.UseVisualStyleBackColor = false;
            this.btn_StartMatchFromSchedule.Click += new System.EventHandler(this.btn_StartNewMatch_Click);
            // 
            // btnStandings
            // 
            this.btnStandings.BackColor = System.Drawing.Color.Gainsboro;
            this.btnStandings.FlatAppearance.BorderSize = 0;
            this.btnStandings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStandings.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStandings.Location = new System.Drawing.Point(680, 14);
            this.btnStandings.Margin = new System.Windows.Forms.Padding(6);
            this.btnStandings.Name = "btnStandings";
            this.btnStandings.Size = new System.Drawing.Size(250, 158);
            this.btnStandings.TabIndex = 2;
            this.btnStandings.Text = "STANDINGS";
            this.btnStandings.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnStandings.UseVisualStyleBackColor = false;
            this.btnStandings.Click += new System.EventHandler(this.btnStandings_Click);
            // 
            // btnPlayerStats
            // 
            this.btnPlayerStats.BackColor = System.Drawing.Color.Gainsboro;
            this.btnPlayerStats.FlatAppearance.BorderSize = 0;
            this.btnPlayerStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayerStats.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPlayerStats.Location = new System.Drawing.Point(942, 14);
            this.btnPlayerStats.Margin = new System.Windows.Forms.Padding(6, 6, 6, 3);
            this.btnPlayerStats.Name = "btnPlayerStats";
            this.btnPlayerStats.Size = new System.Drawing.Size(250, 158);
            this.btnPlayerStats.TabIndex = 3;
            this.btnPlayerStats.Text = "STATISTICS";
            this.btnPlayerStats.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPlayerStats.UseVisualStyleBackColor = false;
            this.btnPlayerStats.Click += new System.EventHandler(this.btnPlayerStats_Click);
            // 
            // btnLineups
            // 
            this.btnLineups.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLineups.FlatAppearance.BorderSize = 0;
            this.btnLineups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLineups.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLineups.Location = new System.Drawing.Point(418, 184);
            this.btnLineups.Margin = new System.Windows.Forms.Padding(6);
            this.btnLineups.Name = "btnLineups";
            this.btnLineups.Size = new System.Drawing.Size(250, 158);
            this.btnLineups.TabIndex = 4;
            this.btnLineups.Text = "ROSTERS";
            this.btnLineups.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnLineups.UseVisualStyleBackColor = false;
            this.btnLineups.Click += new System.EventHandler(this.btnLineups_Click);
            // 
            // btnResults
            // 
            this.btnResults.BackColor = System.Drawing.Color.Gainsboro;
            this.btnResults.FlatAppearance.BorderSize = 0;
            this.btnResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResults.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnResults.Location = new System.Drawing.Point(680, 184);
            this.btnResults.Margin = new System.Windows.Forms.Padding(6);
            this.btnResults.Name = "btnResults";
            this.btnResults.Size = new System.Drawing.Size(250, 158);
            this.btnResults.TabIndex = 5;
            this.btnResults.Text = "SCHEDULE AND MATCH RESULTS";
            this.btnResults.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnResults.UseVisualStyleBackColor = false;
            this.btnResults.Click += new System.EventHandler(this.btnResults_Click);
            // 
            // btnNewMatch
            // 
            this.btnNewMatch.BackColor = System.Drawing.Color.Gainsboro;
            this.btnNewMatch.FlatAppearance.BorderSize = 0;
            this.btnNewMatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewMatch.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNewMatch.Location = new System.Drawing.Point(418, 14);
            this.btnNewMatch.Margin = new System.Windows.Forms.Padding(6, 6, 6, 3);
            this.btnNewMatch.Name = "btnNewMatch";
            this.btnNewMatch.Size = new System.Drawing.Size(250, 76);
            this.btnNewMatch.TabIndex = 6;
            this.btnNewMatch.Text = "START NEW MATCH";
            this.btnNewMatch.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNewMatch.UseVisualStyleBackColor = false;
            this.btnNewMatch.Click += new System.EventHandler(this.btnNewMatch_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnClose.Location = new System.Drawing.Point(1034, 381);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 10, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(154, 57);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::VKR.PL.NET5.Properties.Resources.MainMenu;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(406, 450);
            this.panel2.TabIndex = 9;
            // 
            // btnAdminMenu
            // 
            this.btnAdminMenu.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAdminMenu.FlatAppearance.BorderSize = 0;
            this.btnAdminMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdminMenu.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAdminMenu.Location = new System.Drawing.Point(942, 184);
            this.btnAdminMenu.Margin = new System.Windows.Forms.Padding(6);
            this.btnAdminMenu.Name = "btnAdminMenu";
            this.btnAdminMenu.Size = new System.Drawing.Size(250, 158);
            this.btnAdminMenu.TabIndex = 15;
            this.btnAdminMenu.Text = "ADMINISTRATIVE TOOLS";
            this.btnAdminMenu.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAdminMenu.UseVisualStyleBackColor = false;
            this.btnAdminMenu.Click += new System.EventHandler(this.btnAdminMenu_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1554, 450);
            this.Controls.Add(this.btnAdminMenu);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnNewMatch);
            this.Controls.Add(this.btnResults);
            this.Controls.Add(this.btnLineups);
            this.Controls.Add(this.btnPlayerStats);
            this.Controls.Add(this.btnStandings);
            this.Controls.Add(this.btn_StartMatchFromSchedule);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main menu";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.VisibleChanged += new System.EventHandler(this.MainMenuForm_VisibleChanged);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBirthDays)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private DataGridView dgvBirthDays;
        private Label label1;
        private DataGridViewTextBoxColumn TeamColor;
        private DataGridViewTextBoxColumn TeamName;
        private DataGridViewTextBoxColumn PlayerName;
        private DataGridViewTextBoxColumn Age;
        private Button btn_StartMatchFromSchedule;
        private Button btnStandings;
        private Button btnPlayerStats;
        private Button btnLineups;
        private Button btnResults;
        private Button btnNewMatch;
        private Panel panel2;
        private Button btnClose;
        private Button btnAdminMenu;
    }
}