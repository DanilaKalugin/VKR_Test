
using System.ComponentModel;
using System.Windows.Forms;

namespace VKR.PL.NET5
{
    partial class LineupsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.lbFirstValue = new System.Windows.Forms.Label();
            this.lbSecondValue = new System.Windows.Forms.Label();
            this.lbThirdValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.playerHands = new System.Windows.Forms.Label();
            this.btnMoveToLowerRoster = new System.Windows.Forms.Button();
            this.btnMoveToUpperRoster = new System.Windows.Forms.Button();
            this.btnUpdatePlayer = new System.Windows.Forms.Button();
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
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightGray;
            this.dgvLineup.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLineup.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvLineup.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvLineup.Location = new System.Drawing.Point(13, 179);
            this.dgvLineup.MultiSelect = false;
            this.dgvLineup.Name = "dgvLineup";
            this.dgvLineup.ReadOnly = true;
            this.dgvLineup.RowHeadersVisible = false;
            this.dgvLineup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLineup.Size = new System.Drawing.Size(580, 201);
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
            this.lbTeamtitle.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
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
            this.btnDecLineupTypeNumberBy1.Click += new System.EventHandler(this.btnDecLineupTypeNumberBy1_Click);
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
            this.lbLineUpType.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
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
            this.lbl_LineupHeader.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
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
            this.lbPlayerNumber.Font = new System.Drawing.Font("MicroFLF", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
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
            this.lbPlayerName.Font = new System.Drawing.Font("MicroFLF", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
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
            this.lbPlayerPlace_and_DateOfBirth.Font = new System.Drawing.Font("MicroFLF", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dgvBench.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvBench.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBench.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBench.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvBench.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBench.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBench.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvBench.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBench.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBench.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvBench.EnableHeadersVisualStyles = false;
            this.dgvBench.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvBench.Location = new System.Drawing.Point(724, 181);
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
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.panelTeamLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTeamLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTeamLogo.Location = new System.Drawing.Point(1144, 12);
            this.panelTeamLogo.Name = "panelTeamLogo";
            this.panelTeamLogo.Size = new System.Drawing.Size(160, 160);
            this.panelTeamLogo.TabIndex = 31;
            // 
            // lbFirstValue
            // 
            this.lbFirstValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFirstValue.Font = new System.Drawing.Font("MicroFLF", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbFirstValue.ForeColor = System.Drawing.Color.DimGray;
            this.lbFirstValue.Location = new System.Drawing.Point(716, 124);
            this.lbFirstValue.Name = "lbFirstValue";
            this.lbFirstValue.Size = new System.Drawing.Size(125, 43);
            this.lbFirstValue.TabIndex = 33;
            this.lbFirstValue.Text = "#99";
            this.lbFirstValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbSecondValue
            // 
            this.lbSecondValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSecondValue.Font = new System.Drawing.Font("MicroFLF", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbSecondValue.ForeColor = System.Drawing.Color.DimGray;
            this.lbSecondValue.Location = new System.Drawing.Point(847, 124);
            this.lbSecondValue.Name = "lbSecondValue";
            this.lbSecondValue.Size = new System.Drawing.Size(125, 43);
            this.lbSecondValue.TabIndex = 34;
            this.lbSecondValue.Text = "#99";
            this.lbSecondValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbThirdValue
            // 
            this.lbThirdValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbThirdValue.Font = new System.Drawing.Font("MicroFLF", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbThirdValue.ForeColor = System.Drawing.Color.DimGray;
            this.lbThirdValue.Location = new System.Drawing.Point(978, 124);
            this.lbThirdValue.Name = "lbThirdValue";
            this.lbThirdValue.Size = new System.Drawing.Size(125, 43);
            this.lbThirdValue.TabIndex = 35;
            this.lbThirdValue.Text = "#99";
            this.lbThirdValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MicroFLF", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(720, 103);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 21);
            this.label4.TabIndex = 36;
            this.label4.Text = "label4";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MicroFLF", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(851, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 21);
            this.label5.TabIndex = 37;
            this.label5.Text = "label5";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MicroFLF", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(982, 100);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 21);
            this.label6.TabIndex = 38;
            this.label6.Text = "label6";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MicroFLF", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(276, 100);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 21);
            this.label7.TabIndex = 39;
            this.label7.Text = "label4";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // playerHands
            // 
            this.playerHands.Font = new System.Drawing.Font("MicroFLF", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playerHands.ForeColor = System.Drawing.Color.Black;
            this.playerHands.Location = new System.Drawing.Point(276, 121);
            this.playerHands.Margin = new System.Windows.Forms.Padding(0);
            this.playerHands.Name = "playerHands";
            this.playerHands.Size = new System.Drawing.Size(125, 21);
            this.playerHands.TabIndex = 40;
            this.playerHands.Text = "#99";
            this.playerHands.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnMoveToLowerRoster
            // 
            this.btnMoveToLowerRoster.FlatAppearance.BorderSize = 0;
            this.btnMoveToLowerRoster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveToLowerRoster.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMoveToLowerRoster.Location = new System.Drawing.Point(599, 181);
            this.btnMoveToLowerRoster.Name = "btnMoveToLowerRoster";
            this.btnMoveToLowerRoster.Size = new System.Drawing.Size(119, 82);
            this.btnMoveToLowerRoster.TabIndex = 64;
            this.btnMoveToLowerRoster.Text = ">>";
            this.btnMoveToLowerRoster.UseVisualStyleBackColor = true;
            this.btnMoveToLowerRoster.Click += new System.EventHandler(this.btnAssignTo_Click);
            // 
            // btnMoveToUpperRoster
            // 
            this.btnMoveToUpperRoster.FlatAppearance.BorderSize = 0;
            this.btnMoveToUpperRoster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveToUpperRoster.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMoveToUpperRoster.Location = new System.Drawing.Point(599, 298);
            this.btnMoveToUpperRoster.Name = "btnMoveToUpperRoster";
            this.btnMoveToUpperRoster.Size = new System.Drawing.Size(119, 82);
            this.btnMoveToUpperRoster.TabIndex = 65;
            this.btnMoveToUpperRoster.Text = "<<";
            this.btnMoveToUpperRoster.UseVisualStyleBackColor = true;
            this.btnMoveToUpperRoster.Click += new System.EventHandler(this.MoveToActiveRoster_Click);
            // 
            // btnUpdatePlayer
            // 
            this.btnUpdatePlayer.FlatAppearance.BorderSize = 0;
            this.btnUpdatePlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePlayer.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUpdatePlayer.Location = new System.Drawing.Point(404, 139);
            this.btnUpdatePlayer.Name = "btnUpdatePlayer";
            this.btnUpdatePlayer.Size = new System.Drawing.Size(189, 33);
            this.btnUpdatePlayer.TabIndex = 67;
            this.btnUpdatePlayer.Text = "Edit";
            this.btnUpdatePlayer.UseVisualStyleBackColor = true;
            this.btnUpdatePlayer.Click += new System.EventHandler(this.btnUpdatePlayer_Click);
            // 
            // LineupsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1316, 414);
            this.Controls.Add(this.btnUpdatePlayer);
            this.Controls.Add(this.btnMoveToUpperRoster);
            this.Controls.Add(this.btnMoveToLowerRoster);
            this.Controls.Add(this.playerHands);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbThirdValue);
            this.Controls.Add(this.lbSecondValue);
            this.Controls.Add(this.lbFirstValue);
            this.Controls.Add(this.pbPlayerPhoto);
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
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LineupsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Starting lineups";
            this.Load += new System.EventHandler(this.LineupsForm_Load);
            this.VisibleChanged += new System.EventHandler(this.LineupsForm_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBench)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvLineup;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private Button btnDecreaseTeamNumberBy1;
        private Button btnIncreaseTeamNumberBy1;
        private Label lbTeamtitle;
        private Button btnDecLineupTypeNumberBy1;
        private Button btnIncLineupTypeNumberBy1;
        private Label lbLineUpType;
        private Label lbl_LineupHeader;
        private Panel pbPlayerPhoto;
        private Label lbPlayerNumber;
        private Label lbPlayerName;
        private Label lbPlayerPlace_and_DateOfBirth;
        private DataGridView dgvBench;
        private Panel panelTeamLogo;
        private Label lbFirstValue;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private Label lbSecondValue;
        private Label lbThirdValue;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label playerHands;
        private Button btnMoveToLowerRoster;
        private Button btnMoveToUpperRoster;
        private Button btnUpdatePlayer;
    }
}