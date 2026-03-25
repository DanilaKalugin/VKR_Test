namespace VKR.PL.NET5
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
            panel1 = new System.Windows.Forms.Panel();
            btnConfirm = new System.Windows.Forms.Button();
            cbStadiums = new System.Windows.Forms.ComboBox();
            txtTeam = new Controls.NET5.TextBoxWithHeader();
            txtMatchType = new Controls.NET5.TextBoxWithHeader();
            btnClose = new System.Windows.Forms.Button();
            cbStadium = new System.Windows.Forms.Label();
            SuspendLayout();
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
            panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panel1.Location = new System.Drawing.Point(12, 9);
            panel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(100, 100);
            panel1.TabIndex = 102;
            // 
            // btnConfirm
            // 
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnConfirm.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnConfirm.Location = new System.Drawing.Point(420, 107);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new System.Drawing.Size(107, 33);
            btnConfirm.TabIndex = 101;
            btnConfirm.Text = "CONFIRM";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnClose_Click;
            // 
            // cbStadiums
            // 
            cbStadiums.BackColor = System.Drawing.Color.WhiteSmoke;
            cbStadiums.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbStadiums.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cbStadiums.FormattingEnabled = true;
            cbStadiums.Location = new System.Drawing.Point(247, 76);
            cbStadiums.Name = "cbStadiums";
            cbStadiums.Size = new System.Drawing.Size(280, 25);
            cbStadiums.TabIndex = 95;
            cbStadiums.SelectionChangeCommitted += cbStadiums_SelectionChangeCommitted;
            // 
            // txtTeam
            // 
            txtTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtTeam.Header = "Team";
            txtTeam.Location = new System.Drawing.Point(118, 12);
            txtTeam.MaxLength = (ushort)100;
            txtTeam.MayIncludeNumbers = false;
            txtTeam.Name = "txtTeam";
            txtTeam.ReadOnlyControl = true;
            txtTeam.Size = new System.Drawing.Size(409, 26);
            txtTeam.TabIndex = 103;
            txtTeam.Value = null;
            txtTeam.ValuePosition = (ushort)129;
            // 
            // txtMatchType
            // 
            txtMatchType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtMatchType.Header = "Type of match";
            txtMatchType.Location = new System.Drawing.Point(118, 44);
            txtMatchType.MaxLength = (ushort)40;
            txtMatchType.MayIncludeNumbers = false;
            txtMatchType.Name = "txtMatchType";
            txtMatchType.ReadOnlyControl = true;
            txtMatchType.Size = new System.Drawing.Size(409, 26);
            txtMatchType.TabIndex = 104;
            txtMatchType.Value = null;
            txtMatchType.ValuePosition = (ushort)129;
            // 
            // btnClose
            // 
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClose.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnClose.Location = new System.Drawing.Point(247, 107);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(107, 33);
            btnClose.TabIndex = 105;
            btnClose.Text = "CLOSE";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // SetStadiumForMatchTypeAndTeamForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.WhiteSmoke;
            ClientSize = new System.Drawing.Size(539, 152);
            ControlBox = false;
            Controls.Add(btnClose);
            Controls.Add(txtMatchType);
            Controls.Add(txtTeam);
            Controls.Add(panel1);
            Controls.Add(btnConfirm);
            Controls.Add(cbStadium);
            Controls.Add(cbStadiums);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "SetStadiumForMatchTypeAndTeamForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SetStadiumForMatchTypeAndTeam";
            Load += SetStadiumForMatchTypeAndTeam_Load;
            ResumeLayout(false);
            PerformLayout();
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