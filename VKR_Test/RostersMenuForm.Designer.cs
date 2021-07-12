
namespace VKR_Test
{
    partial class RostersMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RostersMenuForm));
            this.btnLineups = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCloseRostersMenu = new System.Windows.Forms.Button();
            this.btnReserves = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLineups
            // 
            this.btnLineups.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLineups.FlatAppearance.BorderSize = 0;
            this.btnLineups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLineups.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLineups.Location = new System.Drawing.Point(15, 15);
            this.btnLineups.Margin = new System.Windows.Forms.Padding(6);
            this.btnLineups.Name = "btnLineups";
            this.btnLineups.Size = new System.Drawing.Size(250, 150);
            this.btnLineups.TabIndex = 18;
            this.btnLineups.Text = "STARTING LINEUPS";
            this.btnLineups.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnLineups.UseVisualStyleBackColor = false;
            this.btnLineups.Click += new System.EventHandler(this.btnLineups_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::VKR_Test.Properties.Resources.Roster;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Controls.Add(this.btnCloseRostersMenu);
            this.panel2.Location = new System.Drawing.Point(660, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(490, 350);
            this.panel2.TabIndex = 17;
            // 
            // btnCloseRostersMenu
            // 
            this.btnCloseRostersMenu.FlatAppearance.BorderSize = 0;
            this.btnCloseRostersMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseRostersMenu.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseRostersMenu.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCloseRostersMenu.Location = new System.Drawing.Point(193, 15);
            this.btnCloseRostersMenu.Margin = new System.Windows.Forms.Padding(6);
            this.btnCloseRostersMenu.Name = "btnCloseRostersMenu";
            this.btnCloseRostersMenu.Size = new System.Drawing.Size(132, 49);
            this.btnCloseRostersMenu.TabIndex = 20;
            this.btnCloseRostersMenu.Text = "CLOSE";
            this.btnCloseRostersMenu.UseVisualStyleBackColor = false;
            this.btnCloseRostersMenu.Click += new System.EventHandler(this.btnCloseResultsMenu_Click);
            // 
            // btnReserves
            // 
            this.btnReserves.BackColor = System.Drawing.Color.Gainsboro;
            this.btnReserves.FlatAppearance.BorderSize = 0;
            this.btnReserves.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReserves.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReserves.Location = new System.Drawing.Point(15, 177);
            this.btnReserves.Margin = new System.Windows.Forms.Padding(6);
            this.btnReserves.Name = "btnReserves";
            this.btnReserves.Size = new System.Drawing.Size(250, 150);
            this.btnReserves.TabIndex = 19;
            this.btnReserves.Text = "RESERVES";
            this.btnReserves.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnReserves.UseVisualStyleBackColor = false;
            this.btnReserves.Click += new System.EventHandler(this.btnReserves_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("MicroFLF", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(277, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 150);
            this.button1.TabIndex = 20;
            this.button1.Text = "FREE AGENTS";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RostersMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1000, 350);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnReserves);
            this.Controls.Add(this.btnLineups);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RostersMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RostersMenuForm";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCloseRostersMenu;
        private System.Windows.Forms.Button btnLineups;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnReserves;
        private System.Windows.Forms.Button button1;
    }
}