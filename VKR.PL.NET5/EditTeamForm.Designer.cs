﻿namespace VKR.PL.NET5
{
    partial class EditTeamForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditTeamForm));
            this.txtId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnUpdateTeam = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbLeague = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbManager = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTeamName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDivision = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numFoundationYear = new System.Windows.Forms.NumericUpDown();
            this.btnFireManager = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFoundationYear)).BeginInit();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtId.Enabled = false;
            this.txtId.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtId.Location = new System.Drawing.Point(141, 6);
            this.txtId.MaxLength = 35;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(250, 26);
            this.txtId.TabIndex = 106;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(12, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 17);
            this.label9.TabIndex = 105;
            this.label9.Text = "Abbreviation:";
            // 
            // btnUpdateTeam
            // 
            this.btnUpdateTeam.FlatAppearance.BorderSize = 0;
            this.btnUpdateTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateTeam.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUpdateTeam.Location = new System.Drawing.Point(284, 266);
            this.btnUpdateTeam.Name = "btnUpdateTeam";
            this.btnUpdateTeam.Size = new System.Drawing.Size(107, 33);
            this.btnUpdateTeam.TabIndex = 103;
            this.btnUpdateTeam.Text = "UPDATE";
            this.btnUpdateTeam.UseVisualStyleBackColor = true;
            this.btnUpdateTeam.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbLeague);
            this.panel1.Location = new System.Drawing.Point(141, 198);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 27);
            this.panel1.TabIndex = 96;
            // 
            // lbLeague
            // 
            this.lbLeague.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLeague.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbLeague.Location = new System.Drawing.Point(0, 0);
            this.lbLeague.Name = "lbLeague";
            this.lbLeague.Size = new System.Drawing.Size(250, 27);
            this.lbLeague.TabIndex = 0;
            this.lbLeague.Text = "label7";
            this.lbLeague.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(12, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 17);
            this.label5.TabIndex = 95;
            this.label5.Text = "League:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 94;
            this.label4.Text = "Manager:";
            // 
            // cbManager
            // 
            this.cbManager.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbManager.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbManager.FormattingEnabled = true;
            this.cbManager.Location = new System.Drawing.Point(141, 134);
            this.cbManager.Name = "cbManager";
            this.cbManager.Size = new System.Drawing.Size(250, 25);
            this.cbManager.TabIndex = 93;
            this.cbManager.SelectedIndexChanged += new System.EventHandler(this.cbManager_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 92;
            this.label3.Text = "Division:";
            // 
            // txtTeamName
            // 
            this.txtTeamName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTeamName.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTeamName.Location = new System.Drawing.Point(141, 70);
            this.txtTeamName.MaxLength = 35;
            this.txtTeamName.Name = "txtTeamName";
            this.txtTeamName.Size = new System.Drawing.Size(250, 26);
            this.txtTeamName.TabIndex = 90;
            this.txtTeamName.Validating += new System.ComponentModel.CancelEventHandler(this.txtTeamName_Validating);
            this.txtTeamName.Validated += new System.EventHandler(this.txtTeamName_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 89;
            this.label1.Text = "Team name:";
            // 
            // txtRegion
            // 
            this.txtRegion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtRegion.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRegion.Location = new System.Drawing.Point(141, 38);
            this.txtRegion.MaxLength = 35;
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(250, 26);
            this.txtRegion.TabIndex = 88;
            this.txtRegion.Validating += new System.ComponentModel.CancelEventHandler(this.txtRegion_Validating);
            this.txtRegion.Validated += new System.EventHandler(this.txtRegion_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 87;
            this.label2.Text = "Region:";
            // 
            // cbDivision
            // 
            this.cbDivision.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDivision.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbDivision.FormattingEnabled = true;
            this.cbDivision.Location = new System.Drawing.Point(141, 102);
            this.cbDivision.Name = "cbDivision";
            this.cbDivision.Size = new System.Drawing.Size(250, 25);
            this.cbDivision.TabIndex = 93;
            this.cbDivision.SelectedIndexChanged += new System.EventHandler(this.cbDivision_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(12, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 17);
            this.label6.TabIndex = 108;
            this.label6.Text = "Founded:";
            // 
            // numFoundationYear
            // 
            this.numFoundationYear.BackColor = System.Drawing.Color.WhiteSmoke;
            this.numFoundationYear.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numFoundationYear.Location = new System.Drawing.Point(141, 234);
            this.numFoundationYear.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numFoundationYear.Minimum = new decimal(new int[] {
            1850,
            0,
            0,
            0});
            this.numFoundationYear.Name = "numFoundationYear";
            this.numFoundationYear.Size = new System.Drawing.Size(250, 26);
            this.numFoundationYear.TabIndex = 107;
            this.numFoundationYear.Value = new decimal(new int[] {
            1850,
            0,
            0,
            0});
            this.numFoundationYear.ValueChanged += new System.EventHandler(this.numFoundationYear_ValueChanged);
            // 
            // btnFireManager
            // 
            this.btnFireManager.FlatAppearance.BorderSize = 0;
            this.btnFireManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFireManager.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFireManager.Location = new System.Drawing.Point(141, 165);
            this.btnFireManager.Name = "btnFireManager";
            this.btnFireManager.Size = new System.Drawing.Size(250, 27);
            this.btnFireManager.TabIndex = 109;
            this.btnFireManager.Text = "FIRE MANAGER";
            this.btnFireManager.UseVisualStyleBackColor = true;
            this.btnFireManager.Click += new System.EventHandler(this.btnFireManager_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClose.Location = new System.Drawing.Point(284, 266);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 33);
            this.btnClose.TabIndex = 110;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // EditTeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(403, 311);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnFireManager);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numFoundationYear);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnUpdateTeam);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbDivision);
            this.Controls.Add(this.cbManager);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTeamName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRegion);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EditTeamForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditTeamForm";
            this.Load += new System.EventHandler(this.EditTeamForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numFoundationYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnUpdateTeam;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbManager;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTeamName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbDivision;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numFoundationYear;
        private System.Windows.Forms.Label lbLeague;
        private System.Windows.Forms.Button btnFireManager;
        private System.Windows.Forms.Button btnClose;
    }
}