
namespace VKR_Test
{
    partial class MainMenuForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(780, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 450);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TeamColor,
            this.TeamName,
            this.PlayerName,
            this.Age});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(350, 424);
            this.dataGridView1.TabIndex = 1;
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Happy Birthday";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_StartMatchFromSchedule
            // 
            this.btn_StartMatchFromSchedule.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_StartMatchFromSchedule.FlatAppearance.BorderSize = 0;
            this.btn_StartMatchFromSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_StartMatchFromSchedule.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_StartMatchFromSchedule.Location = new System.Drawing.Point(12, 89);
            this.btn_StartMatchFromSchedule.Name = "btn_StartMatchFromSchedule";
            this.btn_StartMatchFromSchedule.Size = new System.Drawing.Size(250, 73);
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
            this.btnStandings.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStandings.Location = new System.Drawing.Point(268, 12);
            this.btnStandings.Name = "btnStandings";
            this.btnStandings.Size = new System.Drawing.Size(250, 150);
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
            this.btnPlayerStats.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayerStats.Location = new System.Drawing.Point(524, 12);
            this.btnPlayerStats.Name = "btnPlayerStats";
            this.btnPlayerStats.Size = new System.Drawing.Size(250, 150);
            this.btnPlayerStats.TabIndex = 3;
            this.btnPlayerStats.Text = "PLAYER STATISTICS";
            this.btnPlayerStats.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPlayerStats.UseVisualStyleBackColor = false;
            this.btnPlayerStats.Click += new System.EventHandler(this.btnPlayerStats_Click);
            // 
            // btnLineups
            // 
            this.btnLineups.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLineups.FlatAppearance.BorderSize = 0;
            this.btnLineups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLineups.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLineups.Location = new System.Drawing.Point(12, 168);
            this.btnLineups.Name = "btnLineups";
            this.btnLineups.Size = new System.Drawing.Size(250, 150);
            this.btnLineups.TabIndex = 4;
            this.btnLineups.Text = "STARTING LINEUPS";
            this.btnLineups.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnLineups.UseVisualStyleBackColor = false;
            this.btnLineups.Click += new System.EventHandler(this.btnLineups_Click);
            // 
            // btnResults
            // 
            this.btnResults.BackColor = System.Drawing.Color.Gainsboro;
            this.btnResults.FlatAppearance.BorderSize = 0;
            this.btnResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResults.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResults.Location = new System.Drawing.Point(268, 168);
            this.btnResults.Name = "btnResults";
            this.btnResults.Size = new System.Drawing.Size(250, 150);
            this.btnResults.TabIndex = 5;
            this.btnResults.Text = "MATCH RESULTS";
            this.btnResults.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnResults.UseVisualStyleBackColor = false;
            this.btnResults.Click += new System.EventHandler(this.btnResults_Click);
            // 
            // btnNewMatch
            // 
            this.btnNewMatch.BackColor = System.Drawing.Color.Gainsboro;
            this.btnNewMatch.FlatAppearance.BorderSize = 0;
            this.btnNewMatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewMatch.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewMatch.Location = new System.Drawing.Point(12, 12);
            this.btnNewMatch.Name = "btnNewMatch";
            this.btnNewMatch.Size = new System.Drawing.Size(250, 73);
            this.btnNewMatch.TabIndex = 6;
            this.btnNewMatch.Text = "START NEW MATCH";
            this.btnNewMatch.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNewMatch.UseVisualStyleBackColor = false;
            this.btnNewMatch.Click += new System.EventHandler(this.btnNewMatch_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1130, 450);
            this.Controls.Add(this.btnNewMatch);
            this.Controls.Add(this.btnResults);
            this.Controls.Add(this.btnLineups);
            this.Controls.Add(this.btnPlayerStats);
            this.Controls.Add(this.btnStandings);
            this.Controls.Add(this.btn_StartMatchFromSchedule);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main menu";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.Button btn_StartMatchFromSchedule;
        private System.Windows.Forms.Button btnStandings;
        private System.Windows.Forms.Button btnPlayerStats;
        private System.Windows.Forms.Button btnLineups;
        private System.Windows.Forms.Button btnResults;
        private System.Windows.Forms.Button btnNewMatch;
    }
}