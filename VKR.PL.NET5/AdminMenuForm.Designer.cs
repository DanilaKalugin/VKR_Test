namespace VKR.PL.NET5
{
    partial class AdminMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminMenuForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btnRostersAdminMenu = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddPlayer = new System.Windows.Forms.Button();
            this.btnAddCity = new System.Windows.Forms.Button();
            this.btnEditTeam = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("MicroFLF", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(984, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "ADMINISTRATIVE TOOLS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRostersAdminMenu
            // 
            this.btnRostersAdminMenu.BackColor = System.Drawing.Color.Gainsboro;
            this.btnRostersAdminMenu.FlatAppearance.BorderSize = 0;
            this.btnRostersAdminMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRostersAdminMenu.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRostersAdminMenu.Location = new System.Drawing.Point(15, 44);
            this.btnRostersAdminMenu.Margin = new System.Windows.Forms.Padding(6);
            this.btnRostersAdminMenu.Name = "btnRostersAdminMenu";
            this.btnRostersAdminMenu.Size = new System.Drawing.Size(250, 150);
            this.btnRostersAdminMenu.TabIndex = 5;
            this.btnRostersAdminMenu.Text = "ROSTERS";
            this.btnRostersAdminMenu.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnRostersAdminMenu.UseVisualStyleBackColor = false;
            this.btnRostersAdminMenu.Click += new System.EventHandler(this.btnRostersAdminMenu_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::VKR.PL.NET5.Properties.Resources.PlayersAdminMenu;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(767, 38);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(217, 333);
            this.panel2.TabIndex = 10;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnClose.Location = new System.Drawing.Point(597, 302);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 10, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(154, 57);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddPlayer
            // 
            this.btnAddPlayer.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAddPlayer.FlatAppearance.BorderSize = 0;
            this.btnAddPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPlayer.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddPlayer.Location = new System.Drawing.Point(15, 206);
            this.btnAddPlayer.Margin = new System.Windows.Forms.Padding(6, 6, 6, 3);
            this.btnAddPlayer.Name = "btnAddPlayer";
            this.btnAddPlayer.Size = new System.Drawing.Size(250, 72);
            this.btnAddPlayer.TabIndex = 16;
            this.btnAddPlayer.Text = "ADD PLAYER";
            this.btnAddPlayer.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAddPlayer.UseVisualStyleBackColor = false;
            this.btnAddPlayer.Click += new System.EventHandler(this.btnAddPlayer_Click);
            // 
            // btnAddCity
            // 
            this.btnAddCity.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAddCity.FlatAppearance.BorderSize = 0;
            this.btnAddCity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCity.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddCity.Location = new System.Drawing.Point(15, 287);
            this.btnAddCity.Margin = new System.Windows.Forms.Padding(6, 6, 6, 3);
            this.btnAddCity.Name = "btnAddCity";
            this.btnAddCity.Size = new System.Drawing.Size(250, 72);
            this.btnAddCity.TabIndex = 17;
            this.btnAddCity.Text = "ADD CITY";
            this.btnAddCity.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAddCity.UseVisualStyleBackColor = false;
            this.btnAddCity.Click += new System.EventHandler(this.btnAddCity_Click);
            // 
            // btnEditTeam
            // 
            this.btnEditTeam.BackColor = System.Drawing.Color.Gainsboro;
            this.btnEditTeam.FlatAppearance.BorderSize = 0;
            this.btnEditTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditTeam.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEditTeam.Location = new System.Drawing.Point(277, 44);
            this.btnEditTeam.Margin = new System.Windows.Forms.Padding(6, 6, 6, 3);
            this.btnEditTeam.Name = "btnEditTeam";
            this.btnEditTeam.Size = new System.Drawing.Size(250, 72);
            this.btnEditTeam.TabIndex = 18;
            this.btnEditTeam.Text = "EDIT TEAM";
            this.btnEditTeam.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnEditTeam.UseVisualStyleBackColor = false;
            this.btnEditTeam.Click += new System.EventHandler(this.btnEditTeam_Click);
            // 
            // AdminMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(984, 371);
            this.Controls.Add(this.btnEditTeam);
            this.Controls.Add(this.btnAddCity);
            this.Controls.Add(this.btnAddPlayer);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnRostersAdminMenu);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AdminMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrative tools";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRostersAdminMenu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddPlayer;
        private System.Windows.Forms.Button btnAddCity;
        private System.Windows.Forms.Button btnEditTeam;
    }
}