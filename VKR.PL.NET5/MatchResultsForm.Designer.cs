
using System.ComponentModel;
using System.Windows.Forms;

namespace VKR.PL.NET5
{
    partial class MatchResultsForm
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MatchResultsForm));
            dgvMatches = new DataGridView();
            Column3 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewImageColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewImageColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            lbHeader = new Label();
            panel1 = new Panel();
            cbTeam = new ComboBox();
            label2 = new Label();
            panel2 = new Panel();
            dtpMatchDate = new DateTimePicker();
            label3 = new Label();
            panel3 = new Panel();
            cbSeasons = new ComboBox();
            label1 = new Label();
            ((ISupportInitialize)dgvMatches).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // dgvMatches
            // 
            dgvMatches.AllowUserToAddRows = false;
            dgvMatches.AllowUserToDeleteRows = false;
            dgvMatches.AllowUserToResizeColumns = false;
            dgvMatches.AllowUserToResizeRows = false;
            dgvMatches.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMatches.BackgroundColor = System.Drawing.Color.FromArgb(48, 48, 48);
            dgvMatches.BorderStyle = BorderStyle.None;
            dgvMatches.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMatches.ColumnHeadersVisible = false;
            dgvMatches.Columns.AddRange(new DataGridViewColumn[] { Column3, Column8, Column1, Column2, Column4, Column5, Column9, Column6, Column7 });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvMatches.DefaultCellStyle = dataGridViewCellStyle4;
            dgvMatches.Dock = DockStyle.Bottom;
            dgvMatches.GridColor = System.Drawing.Color.FromArgb(48, 48, 48);
            dgvMatches.Location = new System.Drawing.Point(0, 118);
            dgvMatches.Margin = new Padding(4, 3, 4, 3);
            dgvMatches.Name = "dgvMatches";
            dgvMatches.ReadOnly = true;
            dgvMatches.RowHeadersVisible = false;
            dgvMatches.RowTemplate.Height = 50;
            dgvMatches.Size = new System.Drawing.Size(994, 503);
            dgvMatches.TabIndex = 0;
            // 
            // Column3
            // 
            Column3.FillWeight = 80F;
            Column3.HeaderText = "Date";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column8
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(48, 48, 48);
            Column8.DefaultCellStyle = dataGridViewCellStyle1;
            Column8.FillWeight = 50F;
            Column8.HeaderText = "Column8";
            Column8.ImageLayout = DataGridViewImageCellLayout.Stretch;
            Column8.Name = "Column8";
            Column8.ReadOnly = true;
            // 
            // Column1
            // 
            Column1.FillWeight = 60F;
            Column1.HeaderText = "AwayTeam";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            Column2.DefaultCellStyle = dataGridViewCellStyle2;
            Column2.FillWeight = 40F;
            Column2.HeaderText = "AwayTeamRuns";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column4
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle3.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            Column4.DefaultCellStyle = dataGridViewCellStyle3;
            Column4.FillWeight = 40F;
            Column4.HeaderText = "HomeTeamRuns";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Column5
            // 
            Column5.FillWeight = 60F;
            Column5.HeaderText = "HomeTeam";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // Column9
            // 
            Column9.FillWeight = 50F;
            Column9.HeaderText = "Column9";
            Column9.ImageLayout = DataGridViewImageCellLayout.Stretch;
            Column9.Name = "Column9";
            Column9.ReadOnly = true;
            // 
            // Column6
            // 
            Column6.FillWeight = 90F;
            Column6.HeaderText = "MatchStatus";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            // 
            // Column7
            // 
            Column7.FillWeight = 500F;
            Column7.HeaderText = "Stadium";
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            // 
            // lbHeader
            // 
            lbHeader.Dock = DockStyle.Left;
            lbHeader.Font = new System.Drawing.Font("MicroFLF", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbHeader.ForeColor = System.Drawing.Color.WhiteSmoke;
            lbHeader.Location = new System.Drawing.Point(0, 0);
            lbHeader.Margin = new Padding(4, 0, 4, 0);
            lbHeader.Name = "lbHeader";
            lbHeader.Size = new System.Drawing.Size(674, 118);
            lbHeader.TabIndex = 1;
            lbHeader.Text = "PREVIOUS MATCH RESULTS";
            lbHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(cbTeam);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new System.Drawing.Point(674, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(320, 36);
            panel1.TabIndex = 2;
            // 
            // cbTeam
            // 
            cbTeam.Dock = DockStyle.Right;
            cbTeam.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTeam.FlatStyle = FlatStyle.Flat;
            cbTeam.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            cbTeam.FormattingEnabled = true;
            cbTeam.Location = new System.Drawing.Point(91, 0);
            cbTeam.Margin = new Padding(4, 3, 4, 3);
            cbTeam.MaxDropDownItems = 5;
            cbTeam.Name = "cbTeam";
            cbTeam.Size = new System.Drawing.Size(229, 29);
            cbTeam.TabIndex = 1;
            cbTeam.SelectedValueChanged += cbTeam_SelectedValueChanged;
            // 
            // label2
            // 
            label2.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            label2.Location = new System.Drawing.Point(0, 0);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(83, 33);
            label2.TabIndex = 0;
            label2.Text = "Team:";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.Controls.Add(dtpMatchDate);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new System.Drawing.Point(674, 36);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(320, 36);
            panel2.TabIndex = 3;
            // 
            // dtpMatchDate
            // 
            dtpMatchDate.CalendarForeColor = System.Drawing.Color.WhiteSmoke;
            dtpMatchDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(48, 48, 48);
            dtpMatchDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(48, 48, 48);
            dtpMatchDate.CalendarTitleForeColor = System.Drawing.Color.WhiteSmoke;
            dtpMatchDate.Dock = DockStyle.Right;
            dtpMatchDate.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dtpMatchDate.Format = DateTimePickerFormat.Short;
            dtpMatchDate.Location = new System.Drawing.Point(91, 0);
            dtpMatchDate.Margin = new Padding(4, 3, 4, 3);
            dtpMatchDate.MaxDate = new System.DateTime(2031, 1, 5, 0, 0, 0, 0);
            dtpMatchDate.MinDate = new System.DateTime(2018, 12, 31, 0, 0, 0, 0);
            dtpMatchDate.Name = "dtpMatchDate";
            dtpMatchDate.Size = new System.Drawing.Size(229, 27);
            dtpMatchDate.TabIndex = 5;
            dtpMatchDate.Value = new System.DateTime(2021, 4, 12, 0, 0, 0, 0);
            dtpMatchDate.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label3
            // 
            label3.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            label3.Location = new System.Drawing.Point(0, 0);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(83, 33);
            label3.TabIndex = 0;
            label3.Text = "Date:";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            panel3.Controls.Add(cbSeasons);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new System.Drawing.Point(674, 72);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(320, 36);
            panel3.TabIndex = 4;
            // 
            // cbSeasons
            // 
            cbSeasons.Dock = DockStyle.Right;
            cbSeasons.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSeasons.FlatStyle = FlatStyle.Flat;
            cbSeasons.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            cbSeasons.FormattingEnabled = true;
            cbSeasons.Location = new System.Drawing.Point(91, 0);
            cbSeasons.Margin = new Padding(4, 3, 4, 3);
            cbSeasons.MaxDropDownItems = 5;
            cbSeasons.Name = "cbSeasons";
            cbSeasons.Size = new System.Drawing.Size(229, 29);
            cbSeasons.TabIndex = 1;
            cbSeasons.SelectedIndexChanged += cbSeasons_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(91, 33);
            label1.TabIndex = 0;
            label1.Text = "Season:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MatchResultsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(48, 48, 48);
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new System.Drawing.Size(994, 621);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(lbHeader);
            Controls.Add(dgvMatches);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "MatchResultsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Previous match results";
            Load += MatchResultsForm_Load;
            ((ISupportInitialize)dgvMatches).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvMatches;
        private Label lbHeader;
        private Panel panel1;
        private ComboBox cbTeam;
        private Label label2;
        private Panel panel2;
        private Label label3;
        private DateTimePicker dtpMatchDate;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewImageColumn Column8;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewImageColumn Column9;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private Panel panel3;
        private ComboBox cbSeasons;
        private Label label1;
    }
}