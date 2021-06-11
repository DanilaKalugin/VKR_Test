﻿
namespace VKR_Test
{
    partial class LineupsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LineupsForm));
            this.dgvLineup = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDecreaseTeamNumberBy1 = new System.Windows.Forms.Button();
            this.btnIncreaseTeamNumberBy1 = new System.Windows.Forms.Button();
            this.lbTeamtitle = new System.Windows.Forms.Label();
            this.btnDecLineupTypeNumberBy1 = new System.Windows.Forms.Button();
            this.btnIncLineupTypeNumberBy1 = new System.Windows.Forms.Button();
            this.lbLineUpType = new System.Windows.Forms.Label();
            this.lbl_LineupHeader = new System.Windows.Forms.Label();
            this.lbPlayerNumber = new System.Windows.Forms.Label();
            this.lbPlayerName = new System.Windows.Forms.Label();
            this.lbPlayerPlace_and_DateOfBirth = new System.Windows.Forms.Label();
            this.dgvBench = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pbPlayerPhoto = new System.Windows.Forms.Panel();
            this.panelTeamLogo = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBench)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLineup
            // 
            this.dgvLineup.AllowUserToAddRows = false;
            this.dgvLineup.AllowUserToDeleteRows = false;
            this.dgvLineup.AllowUserToResizeColumns = false;
            this.dgvLineup.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dgvLineup.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLineup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLineup.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvLineup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLineup.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvLineup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineup.ColumnHeadersVisible = false;
            this.dgvLineup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLineup.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLineup.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvLineup.Location = new System.Drawing.Point(13, 181);
            this.dgvLineup.MultiSelect = false;
            this.dgvLineup.Name = "dgvLineup";
            this.dgvLineup.ReadOnly = true;
            this.dgvLineup.RowHeadersVisible = false;
            this.dgvLineup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLineup.Size = new System.Drawing.Size(580, 199);
            this.dgvLineup.TabIndex = 0;
            this.dgvLineup.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dgvLineup.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 6F;
            this.Column1.HeaderText = "Number";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 6F;
            this.Column2.HeaderText = "Position";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 88F;
            this.Column3.HeaderText = "Name";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // btnDecreaseTeamNumberBy1
            // 
            this.btnDecreaseTeamNumberBy1.FlatAppearance.BorderSize = 0;
            this.btnDecreaseTeamNumberBy1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecreaseTeamNumberBy1.ForeColor = System.Drawing.Color.Black;
            this.btnDecreaseTeamNumberBy1.Location = new System.Drawing.Point(488, 12);
            this.btnDecreaseTeamNumberBy1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnDecreaseTeamNumberBy1.Name = "btnDecreaseTeamNumberBy1";
            this.btnDecreaseTeamNumberBy1.Size = new System.Drawing.Size(17, 22);
            this.btnDecreaseTeamNumberBy1.TabIndex = 19;
            this.btnDecreaseTeamNumberBy1.Text = "<";
            this.btnDecreaseTeamNumberBy1.UseVisualStyleBackColor = true;
            this.btnDecreaseTeamNumberBy1.Click += new System.EventHandler(this.btnDecreaseTeamNumberBy1_Click);
            // 
            // btnIncreaseTeamNumberBy1
            // 
            this.btnIncreaseTeamNumberBy1.FlatAppearance.BorderSize = 0;
            this.btnIncreaseTeamNumberBy1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncreaseTeamNumberBy1.ForeColor = System.Drawing.Color.Black;
            this.btnIncreaseTeamNumberBy1.Location = new System.Drawing.Point(771, 12);
            this.btnIncreaseTeamNumberBy1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnIncreaseTeamNumberBy1.Name = "btnIncreaseTeamNumberBy1";
            this.btnIncreaseTeamNumberBy1.Size = new System.Drawing.Size(17, 22);
            this.btnIncreaseTeamNumberBy1.TabIndex = 18;
            this.btnIncreaseTeamNumberBy1.Text = ">";
            this.btnIncreaseTeamNumberBy1.UseVisualStyleBackColor = true;
            this.btnIncreaseTeamNumberBy1.Click += new System.EventHandler(this.btnIncreaseTeamNumberBy1_Click);
            // 
            // lbTeamtitle
            // 
            this.lbTeamtitle.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTeamtitle.ForeColor = System.Drawing.Color.Black;
            this.lbTeamtitle.Location = new System.Drawing.Point(505, 12);
            this.lbTeamtitle.Margin = new System.Windows.Forms.Padding(0);
            this.lbTeamtitle.Name = "lbTeamtitle";
            this.lbTeamtitle.Size = new System.Drawing.Size(266, 22);
            this.lbTeamtitle.TabIndex = 17;
            this.lbTeamtitle.Text = "label7";
            this.lbTeamtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDecLineupTypeNumberBy1
            // 
            this.btnDecLineupTypeNumberBy1.FlatAppearance.BorderSize = 0;
            this.btnDecLineupTypeNumberBy1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecLineupTypeNumberBy1.ForeColor = System.Drawing.Color.Black;
            this.btnDecLineupTypeNumberBy1.Location = new System.Drawing.Point(292, 383);
            this.btnDecLineupTypeNumberBy1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnDecLineupTypeNumberBy1.Name = "btnDecLineupTypeNumberBy1";
            this.btnDecLineupTypeNumberBy1.Size = new System.Drawing.Size(17, 22);
            this.btnDecLineupTypeNumberBy1.TabIndex = 22;
            this.btnDecLineupTypeNumberBy1.Text = "<";
            this.btnDecLineupTypeNumberBy1.UseVisualStyleBackColor = true;
            this.btnDecLineupTypeNumberBy1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnIncLineupTypeNumberBy1
            // 
            this.btnIncLineupTypeNumberBy1.FlatAppearance.BorderSize = 0;
            this.btnIncLineupTypeNumberBy1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncLineupTypeNumberBy1.ForeColor = System.Drawing.Color.Black;
            this.btnIncLineupTypeNumberBy1.Location = new System.Drawing.Point(575, 383);
            this.btnIncLineupTypeNumberBy1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnIncLineupTypeNumberBy1.Name = "btnIncLineupTypeNumberBy1";
            this.btnIncLineupTypeNumberBy1.Size = new System.Drawing.Size(17, 22);
            this.btnIncLineupTypeNumberBy1.TabIndex = 21;
            this.btnIncLineupTypeNumberBy1.Text = ">";
            this.btnIncLineupTypeNumberBy1.UseVisualStyleBackColor = true;
            this.btnIncLineupTypeNumberBy1.Click += new System.EventHandler(this.btnIncLineupTypeNumberBy1_Click);
            // 
            // lbLineUpType
            // 
            this.lbLineUpType.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLineUpType.ForeColor = System.Drawing.Color.Black;
            this.lbLineUpType.Location = new System.Drawing.Point(309, 383);
            this.lbLineUpType.Margin = new System.Windows.Forms.Padding(0);
            this.lbLineUpType.Name = "lbLineUpType";
            this.lbLineUpType.Size = new System.Drawing.Size(266, 22);
            this.lbLineUpType.TabIndex = 20;
            this.lbLineUpType.Text = "label1";
            this.lbLineUpType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_LineupHeader
            // 
            this.lbl_LineupHeader.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_LineupHeader.ForeColor = System.Drawing.Color.Black;
            this.lbl_LineupHeader.Location = new System.Drawing.Point(9, 383);
            this.lbl_LineupHeader.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_LineupHeader.Name = "lbl_LineupHeader";
            this.lbl_LineupHeader.Size = new System.Drawing.Size(158, 22);
            this.lbl_LineupHeader.TabIndex = 23;
            this.lbl_LineupHeader.Text = "LINEUP";
            this.lbl_LineupHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbPlayerNumber
            // 
            this.lbPlayerNumber.Font = new System.Drawing.Font("MicroFLF", 42F, System.Drawing.FontStyle.Bold);
            this.lbPlayerNumber.ForeColor = System.Drawing.Color.DimGray;
            this.lbPlayerNumber.Location = new System.Drawing.Point(6, 98);
            this.lbPlayerNumber.Name = "lbPlayerNumber";
            this.lbPlayerNumber.Size = new System.Drawing.Size(155, 74);
            this.lbPlayerNumber.TabIndex = 26;
            this.lbPlayerNumber.Text = "#99";
            this.lbPlayerNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbPlayerName
            // 
            this.lbPlayerName.Font = new System.Drawing.Font("MicroFLF", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlayerName.ForeColor = System.Drawing.Color.Black;
            this.lbPlayerName.Location = new System.Drawing.Point(273, 37);
            this.lbPlayerName.Margin = new System.Windows.Forms.Padding(0);
            this.lbPlayerName.Name = "lbPlayerName";
            this.lbPlayerName.Size = new System.Drawing.Size(515, 42);
            this.lbPlayerName.TabIndex = 27;
            this.lbPlayerName.Text = "label3";
            this.lbPlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbPlayerPlace_and_DateOfBirth
            // 
            this.lbPlayerPlace_and_DateOfBirth.AutoSize = true;
            this.lbPlayerPlace_and_DateOfBirth.Font = new System.Drawing.Font("MicroFLF", 14F);
            this.lbPlayerPlace_and_DateOfBirth.ForeColor = System.Drawing.Color.Black;
            this.lbPlayerPlace_and_DateOfBirth.Location = new System.Drawing.Point(276, 79);
            this.lbPlayerPlace_and_DateOfBirth.Margin = new System.Windows.Forms.Padding(0);
            this.lbPlayerPlace_and_DateOfBirth.Name = "lbPlayerPlace_and_DateOfBirth";
            this.lbPlayerPlace_and_DateOfBirth.Size = new System.Drawing.Size(61, 21);
            this.lbPlayerPlace_and_DateOfBirth.TabIndex = 28;
            this.lbPlayerPlace_and_DateOfBirth.Text = "label4";
            this.lbPlayerPlace_and_DateOfBirth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvBench
            // 
            this.dgvBench.AllowUserToAddRows = false;
            this.dgvBench.AllowUserToDeleteRows = false;
            this.dgvBench.AllowUserToResizeColumns = false;
            this.dgvBench.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            this.dgvBench.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBench.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBench.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvBench.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBench.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvBench.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBench.ColumnHeadersVisible = false;
            this.dgvBench.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBench.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBench.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvBench.Location = new System.Drawing.Point(624, 181);
            this.dgvBench.MultiSelect = false;
            this.dgvBench.Name = "dgvBench";
            this.dgvBench.ReadOnly = true;
            this.dgvBench.RowHeadersVisible = false;
            this.dgvBench.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBench.Size = new System.Drawing.Size(580, 199);
            this.dgvBench.TabIndex = 30;
            this.dgvBench.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dgvBench.SelectionChanged += new System.EventHandler(this.dataGridView2_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.FillWeight = 88F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // pbPlayerPhoto
            // 
            this.pbPlayerPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPlayerPhoto.Location = new System.Drawing.Point(167, 12);
            this.pbPlayerPhoto.Name = "pbPlayerPhoto";
            this.pbPlayerPhoto.Size = new System.Drawing.Size(106, 160);
            this.pbPlayerPhoto.TabIndex = 25;
            // 
            // panelTeamLogo
            // 
            this.panelTeamLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTeamLogo.Location = new System.Drawing.Point(1044, 12);
            this.panelTeamLogo.Name = "panelTeamLogo";
            this.panelTeamLogo.Size = new System.Drawing.Size(160, 160);
            this.panelTeamLogo.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("MicroFLF", 14F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(624, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 25);
            this.label6.TabIndex = 32;
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // LineupsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 414);
            this.Controls.Add(this.pbPlayerPhoto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panelTeamLogo);
            this.Controls.Add(this.dgvBench);
            this.Controls.Add(this.lbPlayerPlace_and_DateOfBirth);
            this.Controls.Add(this.lbPlayerName);
            this.Controls.Add(this.lbPlayerNumber);
            this.Controls.Add(this.lbl_LineupHeader);
            this.Controls.Add(this.btnDecLineupTypeNumberBy1);
            this.Controls.Add(this.btnIncLineupTypeNumberBy1);
            this.Controls.Add(this.lbLineUpType);
            this.Controls.Add(this.btnDecreaseTeamNumberBy1);
            this.Controls.Add(this.btnIncreaseTeamNumberBy1);
            this.Controls.Add(this.lbTeamtitle);
            this.Controls.Add(this.dgvLineup);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LineupsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Starting lineups";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBench)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLineup;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button btnDecreaseTeamNumberBy1;
        private System.Windows.Forms.Button btnIncreaseTeamNumberBy1;
        private System.Windows.Forms.Label lbTeamtitle;
        private System.Windows.Forms.Button btnDecLineupTypeNumberBy1;
        private System.Windows.Forms.Button btnIncLineupTypeNumberBy1;
        private System.Windows.Forms.Label lbLineUpType;
        private System.Windows.Forms.Label lbl_LineupHeader;
        private System.Windows.Forms.Panel pbPlayerPhoto;
        private System.Windows.Forms.Label lbPlayerNumber;
        private System.Windows.Forms.Label lbPlayerName;
        private System.Windows.Forms.Label lbPlayerPlace_and_DateOfBirth;
        private System.Windows.Forms.DataGridView dgvBench;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Panel panelTeamLogo;
        private System.Windows.Forms.Label label6;
    }
}