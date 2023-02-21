
using System.ComponentModel;
using System.Windows.Forms;

namespace VKR.PL.NET5
{
    partial class DefenseForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefenseForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.teamLogo = new System.Windows.Forms.Panel();
            this.lbTeamTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel19 = new System.Windows.Forms.Panel();
            this.panel20 = new System.Windows.Forms.Panel();
            this.lf_SecondName = new System.Windows.Forms.Label();
            this.lf_FirstName = new System.Windows.Forms.Label();
            this.lf = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.cf_SecondName = new System.Windows.Forms.Label();
            this.cf_FirstName = new System.Windows.Forms.Label();
            this.cf = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rf_SecondName = new System.Windows.Forms.Label();
            this.rf_FirstName = new System.Windows.Forms.Label();
            this.rf = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.ss_SecondName = new System.Windows.Forms.Label();
            this.ss_FirstName = new System.Windows.Forms.Label();
            this.ss = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this._2b_SecondName = new System.Windows.Forms.Label();
            this._2b_FirstName = new System.Windows.Forms.Label();
            this._2b = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.c_FirstName = new System.Windows.Forms.Label();
            this.c_SecondName = new System.Windows.Forms.Label();
            this.c = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this._3b_FirstName = new System.Windows.Forms.Label();
            this._3b_SecondName = new System.Windows.Forms.Label();
            this._3b = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this._1b_SecondName = new System.Windows.Forms.Label();
            this._1b_FirstName = new System.Windows.Forms.Label();
            this._1b = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.p_FirstName = new System.Windows.Forms.Label();
            this.p_SecondName = new System.Windows.Forms.Label();
            this.p = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer_Defense = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel14.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.panel1.Controls.Add(this.teamLogo);
            this.panel1.Controls.Add(this.lbTeamTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1120, 66);
            this.panel1.TabIndex = 55;
            // 
            // teamLogo
            // 
            this.teamLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.teamLogo.Location = new System.Drawing.Point(3, 3);
            this.teamLogo.Name = "teamLogo";
            this.teamLogo.Size = new System.Drawing.Size(60, 60);
            this.teamLogo.TabIndex = 52;
            // 
            // lbTeamTitle
            // 
            this.lbTeamTitle.Font = new System.Drawing.Font("MicroFLF", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbTeamTitle.ForeColor = System.Drawing.Color.Black;
            this.lbTeamTitle.Location = new System.Drawing.Point(83, 3);
            this.lbTeamTitle.Name = "lbTeamTitle";
            this.lbTeamTitle.Size = new System.Drawing.Size(1041, 60);
            this.lbTeamTitle.TabIndex = 53;
            this.lbTeamTitle.Text = "label37";
            this.lbTeamTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Gainsboro;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.Controls.Add(this.panel19, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel8, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel9, 3, 10);
            this.tableLayoutPanel1.Controls.Add(this.panel10, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.panel11, 6, 7);
            this.tableLayoutPanel1.Controls.Add(this.panel12, 3, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 66);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1120, 561);
            this.tableLayoutPanel1.TabIndex = 57;
            this.tableLayoutPanel1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel1_MouseDoubleClick);
            // 
            // panel19
            // 
            this.panel19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel19.Controls.Add(this.panel20);
            this.panel19.Controls.Add(this.lf);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel19.Location = new System.Drawing.Point(0, 51);
            this.panel19.Margin = new System.Windows.Forms.Padding(0);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(160, 51);
            this.panel19.TabIndex = 13;
            // 
            // panel20
            // 
            this.panel20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel20.Controls.Add(this.lf_SecondName);
            this.panel20.Controls.Add(this.lf_FirstName);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel20.Location = new System.Drawing.Point(33, 0);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(125, 49);
            this.panel20.TabIndex = 0;
            // 
            // lf_SecondName
            // 
            this.lf_SecondName.BackColor = System.Drawing.Color.Gainsboro;
            this.lf_SecondName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lf_SecondName.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lf_SecondName.Location = new System.Drawing.Point(0, 22);
            this.lf_SecondName.Margin = new System.Windows.Forms.Padding(0);
            this.lf_SecondName.Name = "lf_SecondName";
            this.lf_SecondName.Size = new System.Drawing.Size(123, 25);
            this.lf_SecondName.TabIndex = 33;
            this.lf_SecondName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lf_FirstName
            // 
            this.lf_FirstName.BackColor = System.Drawing.Color.Gainsboro;
            this.lf_FirstName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lf_FirstName.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lf_FirstName.ForeColor = System.Drawing.Color.Black;
            this.lf_FirstName.Location = new System.Drawing.Point(0, 0);
            this.lf_FirstName.Margin = new System.Windows.Forms.Padding(0);
            this.lf_FirstName.Name = "lf_FirstName";
            this.lf_FirstName.Size = new System.Drawing.Size(123, 25);
            this.lf_FirstName.TabIndex = 32;
            this.lf_FirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lf
            // 
            this.lf.Dock = System.Windows.Forms.DockStyle.Left;
            this.lf.Font = new System.Drawing.Font("MicroFLF", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lf.Location = new System.Drawing.Point(0, 0);
            this.lf.Name = "lf";
            this.lf.Size = new System.Drawing.Size(33, 49);
            this.lf.TabIndex = 34;
            this.lf.Text = "LF";
            this.lf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.panel18);
            this.panel6.Controls.Add(this.cf);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(480, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(160, 51);
            this.panel6.TabIndex = 12;
            // 
            // panel18
            // 
            this.panel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel18.Controls.Add(this.cf_SecondName);
            this.panel18.Controls.Add(this.cf_FirstName);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel18.Location = new System.Drawing.Point(33, 0);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(125, 49);
            this.panel18.TabIndex = 0;
            // 
            // cf_SecondName
            // 
            this.cf_SecondName.BackColor = System.Drawing.Color.Gainsboro;
            this.cf_SecondName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cf_SecondName.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cf_SecondName.Location = new System.Drawing.Point(0, 22);
            this.cf_SecondName.Margin = new System.Windows.Forms.Padding(0);
            this.cf_SecondName.Name = "cf_SecondName";
            this.cf_SecondName.Size = new System.Drawing.Size(123, 25);
            this.cf_SecondName.TabIndex = 33;
            this.cf_SecondName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cf_FirstName
            // 
            this.cf_FirstName.BackColor = System.Drawing.Color.Gainsboro;
            this.cf_FirstName.Dock = System.Windows.Forms.DockStyle.Top;
            this.cf_FirstName.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cf_FirstName.ForeColor = System.Drawing.Color.Black;
            this.cf_FirstName.Location = new System.Drawing.Point(0, 0);
            this.cf_FirstName.Margin = new System.Windows.Forms.Padding(0);
            this.cf_FirstName.Name = "cf_FirstName";
            this.cf_FirstName.Size = new System.Drawing.Size(123, 25);
            this.cf_FirstName.TabIndex = 32;
            this.cf_FirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cf
            // 
            this.cf.Dock = System.Windows.Forms.DockStyle.Left;
            this.cf.Font = new System.Drawing.Font("MicroFLF", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cf.Location = new System.Drawing.Point(0, 0);
            this.cf.Name = "cf";
            this.cf.Size = new System.Drawing.Size(33, 49);
            this.cf.TabIndex = 34;
            this.cf.Text = "CF";
            this.cf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.rf);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(960, 51);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(160, 51);
            this.panel3.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.rf_SecondName);
            this.panel4.Controls.Add(this.rf_FirstName);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(33, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(125, 49);
            this.panel4.TabIndex = 0;
            // 
            // rf_SecondName
            // 
            this.rf_SecondName.BackColor = System.Drawing.Color.Gainsboro;
            this.rf_SecondName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rf_SecondName.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rf_SecondName.Location = new System.Drawing.Point(0, 22);
            this.rf_SecondName.Margin = new System.Windows.Forms.Padding(0);
            this.rf_SecondName.Name = "rf_SecondName";
            this.rf_SecondName.Size = new System.Drawing.Size(123, 25);
            this.rf_SecondName.TabIndex = 33;
            this.rf_SecondName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rf_FirstName
            // 
            this.rf_FirstName.BackColor = System.Drawing.Color.Gainsboro;
            this.rf_FirstName.Dock = System.Windows.Forms.DockStyle.Top;
            this.rf_FirstName.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rf_FirstName.ForeColor = System.Drawing.Color.Black;
            this.rf_FirstName.Location = new System.Drawing.Point(0, 0);
            this.rf_FirstName.Margin = new System.Windows.Forms.Padding(0);
            this.rf_FirstName.Name = "rf_FirstName";
            this.rf_FirstName.Size = new System.Drawing.Size(123, 25);
            this.rf_FirstName.TabIndex = 32;
            this.rf_FirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rf
            // 
            this.rf.Dock = System.Windows.Forms.DockStyle.Left;
            this.rf.Font = new System.Drawing.Font("MicroFLF", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rf.Location = new System.Drawing.Point(0, 0);
            this.rf.Name = "rf";
            this.rf.Size = new System.Drawing.Size(33, 49);
            this.rf.TabIndex = 34;
            this.rf.Text = "RF";
            this.rf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.panel17);
            this.panel7.Controls.Add(this.ss);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(160, 204);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(160, 51);
            this.panel7.TabIndex = 10;
            // 
            // panel17
            // 
            this.panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel17.Controls.Add(this.ss_SecondName);
            this.panel17.Controls.Add(this.ss_FirstName);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel17.Location = new System.Drawing.Point(33, 0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(125, 49);
            this.panel17.TabIndex = 0;
            // 
            // ss_SecondName
            // 
            this.ss_SecondName.BackColor = System.Drawing.Color.Gainsboro;
            this.ss_SecondName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ss_SecondName.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ss_SecondName.Location = new System.Drawing.Point(0, 22);
            this.ss_SecondName.Margin = new System.Windows.Forms.Padding(0);
            this.ss_SecondName.Name = "ss_SecondName";
            this.ss_SecondName.Size = new System.Drawing.Size(123, 25);
            this.ss_SecondName.TabIndex = 33;
            this.ss_SecondName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ss_FirstName
            // 
            this.ss_FirstName.BackColor = System.Drawing.Color.Gainsboro;
            this.ss_FirstName.Dock = System.Windows.Forms.DockStyle.Top;
            this.ss_FirstName.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ss_FirstName.ForeColor = System.Drawing.Color.Black;
            this.ss_FirstName.Location = new System.Drawing.Point(0, 0);
            this.ss_FirstName.Margin = new System.Windows.Forms.Padding(0);
            this.ss_FirstName.Name = "ss_FirstName";
            this.ss_FirstName.Size = new System.Drawing.Size(123, 25);
            this.ss_FirstName.TabIndex = 32;
            this.ss_FirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ss
            // 
            this.ss.Dock = System.Windows.Forms.DockStyle.Left;
            this.ss.Font = new System.Drawing.Font("MicroFLF", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ss.Location = new System.Drawing.Point(0, 0);
            this.ss.Name = "ss";
            this.ss.Size = new System.Drawing.Size(33, 49);
            this.ss.TabIndex = 34;
            this.ss.Text = "SS";
            this.ss.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.panel16);
            this.panel8.Controls.Add(this._2b);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(800, 204);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(160, 51);
            this.panel8.TabIndex = 9;
            // 
            // panel16
            // 
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Controls.Add(this._2b_SecondName);
            this.panel16.Controls.Add(this._2b_FirstName);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel16.Location = new System.Drawing.Point(33, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(125, 49);
            this.panel16.TabIndex = 0;
            // 
            // _2b_SecondName
            // 
            this._2b_SecondName.BackColor = System.Drawing.Color.Gainsboro;
            this._2b_SecondName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._2b_SecondName.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._2b_SecondName.Location = new System.Drawing.Point(0, 22);
            this._2b_SecondName.Margin = new System.Windows.Forms.Padding(0);
            this._2b_SecondName.Name = "_2b_SecondName";
            this._2b_SecondName.Size = new System.Drawing.Size(123, 25);
            this._2b_SecondName.TabIndex = 33;
            this._2b_SecondName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _2b_FirstName
            // 
            this._2b_FirstName.BackColor = System.Drawing.Color.Gainsboro;
            this._2b_FirstName.Dock = System.Windows.Forms.DockStyle.Top;
            this._2b_FirstName.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._2b_FirstName.ForeColor = System.Drawing.Color.Black;
            this._2b_FirstName.Location = new System.Drawing.Point(0, 0);
            this._2b_FirstName.Margin = new System.Windows.Forms.Padding(0);
            this._2b_FirstName.Name = "_2b_FirstName";
            this._2b_FirstName.Size = new System.Drawing.Size(123, 25);
            this._2b_FirstName.TabIndex = 32;
            this._2b_FirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _2b
            // 
            this._2b.Dock = System.Windows.Forms.DockStyle.Left;
            this._2b.Font = new System.Drawing.Font("MicroFLF", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._2b.Location = new System.Drawing.Point(0, 0);
            this._2b.Name = "_2b";
            this._2b.Size = new System.Drawing.Size(33, 49);
            this._2b.TabIndex = 34;
            this._2b.Text = "2B";
            this._2b.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.panel13);
            this.panel9.Controls.Add(this.c);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(480, 510);
            this.panel9.Margin = new System.Windows.Forms.Padding(0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(160, 51);
            this.panel9.TabIndex = 5;
            // 
            // panel13
            // 
            this.panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel13.Controls.Add(this.c_FirstName);
            this.panel13.Controls.Add(this.c_SecondName);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(33, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(125, 49);
            this.panel13.TabIndex = 0;
            // 
            // c_FirstName
            // 
            this.c_FirstName.BackColor = System.Drawing.Color.Gainsboro;
            this.c_FirstName.Dock = System.Windows.Forms.DockStyle.Top;
            this.c_FirstName.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.c_FirstName.ForeColor = System.Drawing.Color.Black;
            this.c_FirstName.Location = new System.Drawing.Point(0, 0);
            this.c_FirstName.Margin = new System.Windows.Forms.Padding(0);
            this.c_FirstName.Name = "c_FirstName";
            this.c_FirstName.Size = new System.Drawing.Size(123, 25);
            this.c_FirstName.TabIndex = 29;
            this.c_FirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c_SecondName
            // 
            this.c_SecondName.BackColor = System.Drawing.Color.Gainsboro;
            this.c_SecondName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.c_SecondName.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.c_SecondName.Location = new System.Drawing.Point(0, 22);
            this.c_SecondName.Margin = new System.Windows.Forms.Padding(0);
            this.c_SecondName.Name = "c_SecondName";
            this.c_SecondName.Size = new System.Drawing.Size(123, 25);
            this.c_SecondName.TabIndex = 30;
            this.c_SecondName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c
            // 
            this.c.Dock = System.Windows.Forms.DockStyle.Left;
            this.c.Font = new System.Drawing.Font("MicroFLF", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.c.Location = new System.Drawing.Point(0, 0);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(33, 49);
            this.c.TabIndex = 31;
            this.c.Text = "C";
            this.c.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.panel15);
            this.panel10.Controls.Add(this._3b);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 357);
            this.panel10.Margin = new System.Windows.Forms.Padding(0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(160, 51);
            this.panel10.TabIndex = 6;
            // 
            // panel15
            // 
            this.panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel15.Controls.Add(this._3b_FirstName);
            this.panel15.Controls.Add(this._3b_SecondName);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(33, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(125, 49);
            this.panel15.TabIndex = 35;
            // 
            // _3b_FirstName
            // 
            this._3b_FirstName.BackColor = System.Drawing.Color.Gainsboro;
            this._3b_FirstName.Dock = System.Windows.Forms.DockStyle.Top;
            this._3b_FirstName.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._3b_FirstName.ForeColor = System.Drawing.Color.Black;
            this._3b_FirstName.Location = new System.Drawing.Point(0, 0);
            this._3b_FirstName.Margin = new System.Windows.Forms.Padding(0);
            this._3b_FirstName.Name = "_3b_FirstName";
            this._3b_FirstName.Size = new System.Drawing.Size(123, 25);
            this._3b_FirstName.TabIndex = 32;
            this._3b_FirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _3b_SecondName
            // 
            this._3b_SecondName.BackColor = System.Drawing.Color.Gainsboro;
            this._3b_SecondName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._3b_SecondName.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._3b_SecondName.Location = new System.Drawing.Point(0, 22);
            this._3b_SecondName.Margin = new System.Windows.Forms.Padding(0);
            this._3b_SecondName.Name = "_3b_SecondName";
            this._3b_SecondName.Size = new System.Drawing.Size(123, 25);
            this._3b_SecondName.TabIndex = 33;
            this._3b_SecondName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _3b
            // 
            this._3b.Dock = System.Windows.Forms.DockStyle.Left;
            this._3b.Font = new System.Drawing.Font("MicroFLF", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._3b.Location = new System.Drawing.Point(0, 0);
            this._3b.Name = "_3b";
            this._3b.Size = new System.Drawing.Size(33, 49);
            this._3b.TabIndex = 34;
            this._3b.Text = "3B";
            this._3b.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.panel5);
            this.panel11.Controls.Add(this._1b);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(960, 357);
            this.panel11.Margin = new System.Windows.Forms.Padding(0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(160, 51);
            this.panel11.TabIndex = 7;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this._1b_SecondName);
            this.panel5.Controls.Add(this._1b_FirstName);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(33, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(125, 49);
            this.panel5.TabIndex = 0;
            // 
            // _1b_SecondName
            // 
            this._1b_SecondName.BackColor = System.Drawing.Color.Gainsboro;
            this._1b_SecondName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._1b_SecondName.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._1b_SecondName.Location = new System.Drawing.Point(0, 22);
            this._1b_SecondName.Margin = new System.Windows.Forms.Padding(0);
            this._1b_SecondName.Name = "_1b_SecondName";
            this._1b_SecondName.Size = new System.Drawing.Size(123, 25);
            this._1b_SecondName.TabIndex = 33;
            this._1b_SecondName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _1b_FirstName
            // 
            this._1b_FirstName.BackColor = System.Drawing.Color.Gainsboro;
            this._1b_FirstName.Dock = System.Windows.Forms.DockStyle.Top;
            this._1b_FirstName.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._1b_FirstName.ForeColor = System.Drawing.Color.Black;
            this._1b_FirstName.Location = new System.Drawing.Point(0, 0);
            this._1b_FirstName.Margin = new System.Windows.Forms.Padding(0);
            this._1b_FirstName.Name = "_1b_FirstName";
            this._1b_FirstName.Size = new System.Drawing.Size(123, 25);
            this._1b_FirstName.TabIndex = 32;
            this._1b_FirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _1b
            // 
            this._1b.Dock = System.Windows.Forms.DockStyle.Left;
            this._1b.Font = new System.Drawing.Font("MicroFLF", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._1b.Location = new System.Drawing.Point(0, 0);
            this._1b.Name = "_1b";
            this._1b.Size = new System.Drawing.Size(33, 49);
            this._1b.TabIndex = 34;
            this._1b.Text = "1B";
            this._1b.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel12
            // 
            this.panel12.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel12.BackgroundImage")));
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.panel14);
            this.panel12.Controls.Add(this.p);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(480, 357);
            this.panel12.Margin = new System.Windows.Forms.Padding(0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(160, 51);
            this.panel12.TabIndex = 8;
            // 
            // panel14
            // 
            this.panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel14.Controls.Add(this.p_FirstName);
            this.panel14.Controls.Add(this.p_SecondName);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel14.Location = new System.Drawing.Point(32, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(126, 49);
            this.panel14.TabIndex = 35;
            // 
            // p_FirstName
            // 
            this.p_FirstName.BackColor = System.Drawing.Color.Gainsboro;
            this.p_FirstName.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_FirstName.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.p_FirstName.ForeColor = System.Drawing.Color.Black;
            this.p_FirstName.Location = new System.Drawing.Point(0, 0);
            this.p_FirstName.Margin = new System.Windows.Forms.Padding(0);
            this.p_FirstName.Name = "p_FirstName";
            this.p_FirstName.Size = new System.Drawing.Size(124, 25);
            this.p_FirstName.TabIndex = 32;
            this.p_FirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // p_SecondName
            // 
            this.p_SecondName.BackColor = System.Drawing.Color.Gainsboro;
            this.p_SecondName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p_SecondName.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.p_SecondName.Location = new System.Drawing.Point(0, 22);
            this.p_SecondName.Margin = new System.Windows.Forms.Padding(0);
            this.p_SecondName.Name = "p_SecondName";
            this.p_SecondName.Size = new System.Drawing.Size(124, 25);
            this.p_SecondName.TabIndex = 33;
            this.p_SecondName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // p
            // 
            this.p.Dock = System.Windows.Forms.DockStyle.Left;
            this.p.Font = new System.Drawing.Font("MicroFLF", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.p.Location = new System.Drawing.Point(0, 0);
            this.p.Name = "p";
            this.p.Size = new System.Drawing.Size(33, 49);
            this.p.TabIndex = 34;
            this.p.Text = "P";
            this.p.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Interval = 5;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer_Defense
            // 
            this.timer_Defense.Enabled = true;
            this.timer_Defense.Interval = 4000;
            this.timer_Defense.Tick += new System.EventHandler(this.timer_Defense_Tick);
            // 
            // DefenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1120, 627);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "DefenseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DefenseForm";
            this.Load += new System.EventHandler(this.DefenseForm_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel teamLogo;
        private Label lbTeamTitle;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel9;
        private Panel panel10;
        private Panel panel11;
        private Panel panel12;
        private Label c;
        private Label c_SecondName;
        private Label c_FirstName;
        private Label _3b;
        private Label _3b_SecondName;
        private Label _3b_FirstName;
        private Label _1b;
        private Label _1b_SecondName;
        private Label _1b_FirstName;
        private Label p;
        private Label p_SecondName;
        private Label p_FirstName;
        private Panel panel13;
        private Panel panel5;
        private Panel panel15;
        private Panel panel14;
        private Panel panel8;
        private Panel panel16;
        private Label _2b_SecondName;
        private Label _2b_FirstName;
        private Label _2b;
        private Panel panel7;
        private Panel panel17;
        private Label ss_SecondName;
        private Label ss_FirstName;
        private Label ss;
        private Panel panel3;
        private Panel panel4;
        private Label rf_SecondName;
        private Label rf_FirstName;
        private Label rf;
        private Panel panel19;
        private Panel panel20;
        private Label lf_SecondName;
        private Label lf_FirstName;
        private Label lf;
        private Panel panel6;
        private Panel panel18;
        private Label cf_SecondName;
        private Label cf_FirstName;
        private Label cf;
        private Timer timer_Defense;
        private Timer timer1;
    }
}