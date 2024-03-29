﻿namespace VKR.PL.NET5
{
    partial class SetStadiumForMatchTypeAndTeamForm
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
            System.Windows.Forms.Label cbStadium;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetStadiumForMatchTypeAndTeamForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.cbStadiums = new System.Windows.Forms.ComboBox();
            this.txtTeam = new VKR.PL.Controls.NET5.TextBoxWithHeader();
            this.txtMatchType = new VKR.PL.Controls.NET5.TextBoxWithHeader();
            this.btnClose = new System.Windows.Forms.Button();
            cbStadium = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbStadium
            // 
            cbStadium.AutoSize = true;
            cbStadium.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cbStadium.Location = new System.Drawing.Point(118, 79);
            cbStadium.Name = "cbStadium";
            cbStadium.Size = new System.Drawing.Size(74, 17);
            cbStadium.TabIndex = 96;
            cbStadium.Text = "Stadium:";
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(12, 9);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 100);
            this.panel1.TabIndex = 102;
            // 
            // btnConfirm
            // 
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConfirm.Location = new System.Drawing.Point(420, 107);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(107, 33);
            this.btnConfirm.TabIndex = 101;
            this.btnConfirm.Text = "CONFIRM";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbStadiums
            // 
            this.cbStadiums.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbStadiums.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStadiums.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbStadiums.FormattingEnabled = true;
            this.cbStadiums.Location = new System.Drawing.Point(247, 76);
            this.cbStadiums.Name = "cbStadiums";
            this.cbStadiums.Size = new System.Drawing.Size(280, 25);
            this.cbStadiums.TabIndex = 95;
            this.cbStadiums.SelectionChangeCommitted += new System.EventHandler(this.cbStadiums_SelectionChangeCommitted);
            // 
            // txtTeam
            // 
            this.txtTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTeam.Header = "Team";
            this.txtTeam.Location = new System.Drawing.Point(118, 12);
            this.txtTeam.MaxLength = ((ushort)(100));
            this.txtTeam.MayIncludeNumbers = false;
            this.txtTeam.Name = "txtTeam";
            this.txtTeam.ReadOnlyControl = true;
            this.txtTeam.Size = new System.Drawing.Size(409, 26);
            this.txtTeam.TabIndex = 103;
            this.txtTeam.Value = null;
            this.txtTeam.ValuePosition = ((ushort)(129));
            // 
            // txtMatchType
            // 
            this.txtMatchType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMatchType.Header = "Type of match";
            this.txtMatchType.Location = new System.Drawing.Point(118, 44);
            this.txtMatchType.MaxLength = ((ushort)(40));
            this.txtMatchType.MayIncludeNumbers = false;
            this.txtMatchType.Name = "txtMatchType";
            this.txtMatchType.ReadOnlyControl = true;
            this.txtMatchType.Size = new System.Drawing.Size(409, 26);
            this.txtMatchType.TabIndex = 104;
            this.txtMatchType.Value = null;
            this.txtMatchType.ValuePosition = ((ushort)(129));
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClose.Location = new System.Drawing.Point(247, 107);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 33);
            this.btnClose.TabIndex = 105;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // SetStadiumForMatchTypeAndTeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(539, 152);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtMatchType);
            this.Controls.Add(this.txtTeam);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(cbStadium);
            this.Controls.Add(this.cbStadiums);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SetStadiumForMatchTypeAndTeamForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetStadiumForMatchTypeAndTeam";
            this.Load += new System.EventHandler(this.SetStadiumForMatchTypeAndTeam_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label cbStadium;
        private System.Windows.Forms.ComboBox cbStadiums;
        private Controls.NET5.TextBoxWithHeader txtTeam;
        private Controls.NET5.TextBoxWithHeader txtMatchType;
        private System.Windows.Forms.Button btnClose;
    }
}