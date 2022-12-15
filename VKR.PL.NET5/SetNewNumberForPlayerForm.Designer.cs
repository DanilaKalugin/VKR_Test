namespace VKR.PL.NET5
{
    partial class SetNewNumberForPlayerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetNewNumberForPlayerForm));
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.txtPlayer = new VKR.PL.Controls.NET5.TextBoxWithHeader();
            this.txtTeam = new VKR.PL.Controls.NET5.TextBoxWithHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
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
            cbStadium.TabIndex = 106;
            cbStadium.Text = "Number:";
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.domainUpDown1.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.domainUpDown1.Location = new System.Drawing.Point(208, 77);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(319, 26);
            this.domainUpDown1.TabIndex = 0;
            this.domainUpDown1.Text = "domainUpDown1";
            this.domainUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.domainUpDown1.Validated += new System.EventHandler(this.domainUpDown1_Validated);
            // 
            // txtPlayer
            // 
            this.txtPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPlayer.Header = "Player";
            this.txtPlayer.Location = new System.Drawing.Point(118, 44);
            this.txtPlayer.MaxLength = ((ushort)(40));
            this.txtPlayer.MayIncludeNumbers = false;
            this.txtPlayer.Name = "txtPlayer";
            this.txtPlayer.ReadOnlyControl = true;
            this.txtPlayer.Size = new System.Drawing.Size(409, 26);
            this.txtPlayer.TabIndex = 110;
            this.txtPlayer.Value = null;
            this.txtPlayer.ValuePosition = ((ushort)(90));
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
            this.txtTeam.TabIndex = 109;
            this.txtTeam.Value = null;
            this.txtTeam.ValuePosition = ((ushort)(90));
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(12, 9);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 100);
            this.panel1.TabIndex = 108;
            // 
            // btnConfirm
            // 
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConfirm.Location = new System.Drawing.Point(420, 107);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(107, 33);
            this.btnConfirm.TabIndex = 107;
            this.btnConfirm.Text = "CONFIRM";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClose.Location = new System.Drawing.Point(208, 107);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 33);
            this.btnClose.TabIndex = 111;
            this.btnClose.Text = "CANCEL";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // SetNewNumberForPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(539, 152);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtPlayer);
            this.Controls.Add(this.txtTeam);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(cbStadium);
            this.Controls.Add(this.domainUpDown1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetNewNumberForPlayerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetNewNumberForPlayerForm";
            this.Load += new System.EventHandler(this.SetNewNumberForPlayerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private Controls.NET5.TextBoxWithHeader txtPlayer;
        private Controls.NET5.TextBoxWithHeader txtTeam;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnClose;
    }
}