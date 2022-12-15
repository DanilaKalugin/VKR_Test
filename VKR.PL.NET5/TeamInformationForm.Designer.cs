namespace VKR.PL.NET5
{
    partial class TeamInformationForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamInformationForm));
            this.btnDecreaseTeamNumberBy1 = new System.Windows.Forms.Button();
            this.btnIncreaseTeamNumberBy1 = new System.Windows.Forms.Button();
            this.lbTeamTitle = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbRegion = new System.Windows.Forms.Label();
            this.lbTeamName = new System.Windows.Forms.Label();
            this.lbDivision = new System.Windows.Forms.Label();
            this.lbLeague = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEditTeamMainInfo = new System.Windows.Forms.Button();
            this.lbManager = new System.Windows.Forms.Label();
            this.lbManagerHeader = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbSubstitutionLogo = new System.Windows.Forms.Panel();
            this.pbCapLogo = new System.Windows.Forms.Panel();
            this.pbTeamLogo = new System.Windows.Forms.Panel();
            this.lbManagerPlaceOfBirth = new System.Windows.Forms.Label();
            this.lbManagerDateOfBirth = new System.Windows.Forms.Label();
            this.pbManagerPhoto = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnEditTSMT = new System.Windows.Forms.Button();
            this.dgvStadiums = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stadium = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnAddRetiredNumber = new System.Windows.Forms.Button();
            this.dgvRetiredNumbers = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStadiums)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRetiredNumbers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDecreaseTeamNumberBy1
            // 
            this.btnDecreaseTeamNumberBy1.FlatAppearance.BorderSize = 0;
            this.btnDecreaseTeamNumberBy1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecreaseTeamNumberBy1.ForeColor = System.Drawing.Color.Black;
            this.btnDecreaseTeamNumberBy1.Location = new System.Drawing.Point(256, 9);
            this.btnDecreaseTeamNumberBy1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnDecreaseTeamNumberBy1.Name = "btnDecreaseTeamNumberBy1";
            this.btnDecreaseTeamNumberBy1.Size = new System.Drawing.Size(17, 22);
            this.btnDecreaseTeamNumberBy1.TabIndex = 22;
            this.btnDecreaseTeamNumberBy1.Text = "<";
            this.btnDecreaseTeamNumberBy1.UseVisualStyleBackColor = true;
            this.btnDecreaseTeamNumberBy1.Click += new System.EventHandler(this.btnDecreaseTeamNumberBy1_Click);
            // 
            // btnIncreaseTeamNumberBy1
            // 
            this.btnIncreaseTeamNumberBy1.FlatAppearance.BorderSize = 0;
            this.btnIncreaseTeamNumberBy1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncreaseTeamNumberBy1.ForeColor = System.Drawing.Color.Black;
            this.btnIncreaseTeamNumberBy1.Location = new System.Drawing.Point(539, 9);
            this.btnIncreaseTeamNumberBy1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnIncreaseTeamNumberBy1.Name = "btnIncreaseTeamNumberBy1";
            this.btnIncreaseTeamNumberBy1.Size = new System.Drawing.Size(17, 22);
            this.btnIncreaseTeamNumberBy1.TabIndex = 21;
            this.btnIncreaseTeamNumberBy1.Text = ">";
            this.btnIncreaseTeamNumberBy1.UseVisualStyleBackColor = true;
            this.btnIncreaseTeamNumberBy1.Click += new System.EventHandler(this.btnIncreaseTeamNumberBy1_Click);
            // 
            // lbTeamTitle
            // 
            this.lbTeamTitle.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbTeamTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbTeamTitle.Location = new System.Drawing.Point(273, 9);
            this.lbTeamTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lbTeamTitle.Name = "lbTeamTitle";
            this.lbTeamTitle.Size = new System.Drawing.Size(266, 22);
            this.lbTeamTitle.TabIndex = 20;
            this.lbTeamTitle.Text = "label7";
            this.lbTeamTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtId.Enabled = false;
            this.txtId.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtId.Location = new System.Drawing.Point(137, 6);
            this.txtId.MaxLength = 35;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(250, 26);
            this.txtId.TabIndex = 92;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(8, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 17);
            this.label9.TabIndex = 91;
            this.label9.Text = "Abbreviation:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(8, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 89;
            this.label1.Text = "Team name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 87;
            this.label2.Text = "Region:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(8, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 94;
            this.label4.Text = "Division:";
            // 
            // lbRegion
            // 
            this.lbRegion.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbRegion.Location = new System.Drawing.Point(137, 35);
            this.lbRegion.Name = "lbRegion";
            this.lbRegion.Size = new System.Drawing.Size(250, 26);
            this.lbRegion.TabIndex = 95;
            this.lbRegion.Text = "label3";
            this.lbRegion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbTeamName
            // 
            this.lbTeamName.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbTeamName.Location = new System.Drawing.Point(137, 66);
            this.lbTeamName.Name = "lbTeamName";
            this.lbTeamName.Size = new System.Drawing.Size(250, 26);
            this.lbTeamName.TabIndex = 96;
            this.lbTeamName.Text = "label3";
            this.lbTeamName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDivision
            // 
            this.lbDivision.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbDivision.Location = new System.Drawing.Point(137, 97);
            this.lbDivision.Name = "lbDivision";
            this.lbDivision.Size = new System.Drawing.Size(250, 26);
            this.lbDivision.TabIndex = 97;
            this.lbDivision.Text = "label3";
            this.lbDivision.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbLeague
            // 
            this.lbLeague.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbLeague.Location = new System.Drawing.Point(137, 128);
            this.lbLeague.Name = "lbLeague";
            this.lbLeague.Size = new System.Drawing.Size(250, 26);
            this.lbLeague.TabIndex = 99;
            this.lbLeague.Text = "label3";
            this.lbLeague.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(8, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 17);
            this.label5.TabIndex = 98;
            this.label5.Text = "League:";
            // 
            // btnEditTeamMainInfo
            // 
            this.btnEditTeamMainInfo.FlatAppearance.BorderSize = 0;
            this.btnEditTeamMainInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditTeamMainInfo.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEditTeamMainInfo.Location = new System.Drawing.Point(586, 261);
            this.btnEditTeamMainInfo.Name = "btnEditTeamMainInfo";
            this.btnEditTeamMainInfo.Size = new System.Drawing.Size(100, 41);
            this.btnEditTeamMainInfo.TabIndex = 100;
            this.btnEditTeamMainInfo.Text = "EDIT";
            this.btnEditTeamMainInfo.UseVisualStyleBackColor = true;
            this.btnEditTeamMainInfo.Click += new System.EventHandler(this.btnEditTeamMainInfo_Click);
            // 
            // lbManager
            // 
            this.lbManager.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbManager.Location = new System.Drawing.Point(104, 184);
            this.lbManager.Name = "lbManager";
            this.lbManager.Size = new System.Drawing.Size(250, 26);
            this.lbManager.TabIndex = 103;
            this.lbManager.Text = "label3";
            this.lbManager.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbManagerHeader
            // 
            this.lbManagerHeader.AutoSize = true;
            this.lbManagerHeader.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbManagerHeader.Location = new System.Drawing.Point(8, 164);
            this.lbManagerHeader.Name = "lbManagerHeader";
            this.lbManagerHeader.Size = new System.Drawing.Size(79, 17);
            this.lbManagerHeader.TabIndex = 102;
            this.lbManagerHeader.Text = "Manager:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.lbTeamTitle);
            this.panel1.Controls.Add(this.btnIncreaseTeamNumberBy1);
            this.panel1.Controls.Add(this.btnDecreaseTeamNumberBy1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 39);
            this.panel1.TabIndex = 105;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(700, 338);
            this.panel2.TabIndex = 106;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(700, 338);
            this.tabControl1.TabIndex = 101;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.pbSubstitutionLogo);
            this.tabPage1.Controls.Add(this.pbCapLogo);
            this.tabPage1.Controls.Add(this.pbTeamLogo);
            this.tabPage1.Controls.Add(this.lbManagerPlaceOfBirth);
            this.tabPage1.Controls.Add(this.lbManagerDateOfBirth);
            this.tabPage1.Controls.Add(this.pbManagerPhoto);
            this.tabPage1.Controls.Add(this.btnEditTeamMainInfo);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txtId);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.lbLeague);
            this.tabPage1.Controls.Add(this.lbTeamName);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lbManagerHeader);
            this.tabPage1.Controls.Add(this.lbRegion);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.lbManager);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.lbDivision);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(692, 308);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main information";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(596, 123);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 58);
            this.label8.TabIndex = 113;
            this.label8.Text = "Substituion logo";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(495, 123);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 58);
            this.label7.TabIndex = 112;
            this.label7.Text = "Cap logo";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(393, 123);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 58);
            this.label6.TabIndex = 111;
            this.label6.Text = "Main logo";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(393, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(293, 22);
            this.label3.TabIndex = 110;
            this.label3.Text = "Logos";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbSubstitutionLogo
            // 
            this.pbSubstitutionLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbSubstitutionLogo.Location = new System.Drawing.Point(596, 30);
            this.pbSubstitutionLogo.Name = "pbSubstitutionLogo";
            this.pbSubstitutionLogo.Size = new System.Drawing.Size(90, 90);
            this.pbSubstitutionLogo.TabIndex = 109;
            // 
            // pbCapLogo
            // 
            this.pbCapLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCapLogo.Location = new System.Drawing.Point(495, 30);
            this.pbCapLogo.Name = "pbCapLogo";
            this.pbCapLogo.Size = new System.Drawing.Size(90, 90);
            this.pbCapLogo.TabIndex = 108;
            // 
            // pbTeamLogo
            // 
            this.pbTeamLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbTeamLogo.Location = new System.Drawing.Point(393, 30);
            this.pbTeamLogo.Name = "pbTeamLogo";
            this.pbTeamLogo.Size = new System.Drawing.Size(90, 90);
            this.pbTeamLogo.TabIndex = 107;
            // 
            // lbManagerPlaceOfBirth
            // 
            this.lbManagerPlaceOfBirth.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbManagerPlaceOfBirth.Location = new System.Drawing.Point(104, 236);
            this.lbManagerPlaceOfBirth.Name = "lbManagerPlaceOfBirth";
            this.lbManagerPlaceOfBirth.Size = new System.Drawing.Size(250, 26);
            this.lbManagerPlaceOfBirth.TabIndex = 106;
            this.lbManagerPlaceOfBirth.Text = "label3";
            this.lbManagerPlaceOfBirth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbManagerDateOfBirth
            // 
            this.lbManagerDateOfBirth.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbManagerDateOfBirth.Location = new System.Drawing.Point(104, 210);
            this.lbManagerDateOfBirth.Name = "lbManagerDateOfBirth";
            this.lbManagerDateOfBirth.Size = new System.Drawing.Size(250, 26);
            this.lbManagerDateOfBirth.TabIndex = 105;
            this.lbManagerDateOfBirth.Text = "label3";
            this.lbManagerDateOfBirth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbManagerPhoto
            // 
            this.pbManagerPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbManagerPhoto.Location = new System.Drawing.Point(8, 184);
            this.pbManagerPhoto.Name = "pbManagerPhoto";
            this.pbManagerPhoto.Size = new System.Drawing.Size(90, 90);
            this.pbManagerPhoto.TabIndex = 104;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage2.Controls.Add(this.btnEditTSMT);
            this.tabPage2.Controls.Add(this.dgvStadiums);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(692, 308);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Stadiums";
            // 
            // btnEditTSMT
            // 
            this.btnEditTSMT.FlatAppearance.BorderSize = 0;
            this.btnEditTSMT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditTSMT.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEditTSMT.Location = new System.Drawing.Point(586, 261);
            this.btnEditTSMT.Name = "btnEditTSMT";
            this.btnEditTSMT.Size = new System.Drawing.Size(100, 41);
            this.btnEditTSMT.TabIndex = 101;
            this.btnEditTSMT.Text = "EDIT";
            this.btnEditTSMT.UseVisualStyleBackColor = true;
            this.btnEditTSMT.Click += new System.EventHandler(this.btnEditTSMT_Click);
            // 
            // dgvStadiums
            // 
            this.dgvStadiums.AllowUserToAddRows = false;
            this.dgvStadiums.AllowUserToDeleteRows = false;
            this.dgvStadiums.AllowUserToResizeColumns = false;
            this.dgvStadiums.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dgvStadiums.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStadiums.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStadiums.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvStadiums.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStadiums.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStadiums.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStadiums.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Stadium});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStadiums.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStadiums.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvStadiums.EnableHeadersVisualStyles = false;
            this.dgvStadiums.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvStadiums.Location = new System.Drawing.Point(3, 3);
            this.dgvStadiums.Name = "dgvStadiums";
            this.dgvStadiums.ReadOnly = true;
            this.dgvStadiums.RowHeadersVisible = false;
            this.dgvStadiums.RowTemplate.Height = 25;
            this.dgvStadiums.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStadiums.Size = new System.Drawing.Size(686, 150);
            this.dgvStadiums.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Type of match";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Stadium
            // 
            this.Stadium.HeaderText = "Stadium";
            this.Stadium.Name = "Stadium";
            this.Stadium.ReadOnly = true;
            this.Stadium.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage3.Controls.Add(this.btnAddRetiredNumber);
            this.tabPage3.Controls.Add(this.dgvRetiredNumbers);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(692, 308);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Retired numbers";
            // 
            // btnAddRetiredNumber
            // 
            this.btnAddRetiredNumber.FlatAppearance.BorderSize = 0;
            this.btnAddRetiredNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRetiredNumber.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddRetiredNumber.Location = new System.Drawing.Point(586, 261);
            this.btnAddRetiredNumber.Name = "btnAddRetiredNumber";
            this.btnAddRetiredNumber.Size = new System.Drawing.Size(100, 41);
            this.btnAddRetiredNumber.TabIndex = 102;
            this.btnAddRetiredNumber.Text = "ADD";
            this.btnAddRetiredNumber.UseVisualStyleBackColor = true;
            this.btnAddRetiredNumber.Click += new System.EventHandler(this.btnAddRetiredNumber_Click);
            // 
            // dgvRetiredNumbers
            // 
            this.dgvRetiredNumbers.AllowUserToAddRows = false;
            this.dgvRetiredNumbers.AllowUserToDeleteRows = false;
            this.dgvRetiredNumbers.AllowUserToResizeColumns = false;
            this.dgvRetiredNumbers.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgvRetiredNumbers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRetiredNumbers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRetiredNumbers.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvRetiredNumbers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRetiredNumbers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvRetiredNumbers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRetiredNumbers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column2});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRetiredNumbers.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvRetiredNumbers.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvRetiredNumbers.EnableHeadersVisualStyles = false;
            this.dgvRetiredNumbers.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvRetiredNumbers.Location = new System.Drawing.Point(3, 3);
            this.dgvRetiredNumbers.Name = "dgvRetiredNumbers";
            this.dgvRetiredNumbers.ReadOnly = true;
            this.dgvRetiredNumbers.RowHeadersVisible = false;
            this.dgvRetiredNumbers.RowTemplate.Height = 25;
            this.dgvRetiredNumbers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRetiredNumbers.Size = new System.Drawing.Size(686, 247);
            this.dgvRetiredNumbers.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 29.30221F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Number";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 209.7841F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Person";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 60.9137F;
            this.Column2.HeaderText = "Date";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(553, 386);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(132, 49);
            this.btnClose.TabIndex = 107;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // TeamInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TeamInformationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Team information";
            this.VisibleChanged += new System.EventHandler(this.TeamInformationForm_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStadiums)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRetiredNumbers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDecreaseTeamNumberBy1;
        private System.Windows.Forms.Button btnIncreaseTeamNumberBy1;
        private System.Windows.Forms.Label lbTeamTitle;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbRegion;
        private System.Windows.Forms.Label lbTeamName;
        private System.Windows.Forms.Label lbDivision;
        private System.Windows.Forms.Label lbLeague;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEditTeamMainInfo;
        private System.Windows.Forms.Label lbManager;
        private System.Windows.Forms.Label lbManagerHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvStadiums;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stadium;
        private System.Windows.Forms.Panel pbManagerPhoto;
        private System.Windows.Forms.Label lbManagerDateOfBirth;
        private System.Windows.Forms.Label lbManagerPlaceOfBirth;
        private System.Windows.Forms.Panel pbCapLogo;
        private System.Windows.Forms.Panel pbTeamLogo;
        private System.Windows.Forms.Panel pbSubstitutionLogo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEditTSMT;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvRetiredNumbers;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnAddRetiredNumber;
    }
}