
namespace VKR_Test
{
    partial class ServerNotFoundForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerNotFoundForm));
            this.label1 = new System.Windows.Forms.Label();
            this.lbMessage = new System.Windows.Forms.Label();
            this.btnDeployungAccepted = new System.Windows.Forms.Button();
            this.btnDeployingDenied = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.label1.Location = new System.Drawing.Point(241, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 65);
            this.label1.TabIndex = 14;
            this.label1.Text = "Do you want to deploy a database on your server?";
            // 
            // lbMessage
            // 
            this.lbMessage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbMessage.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.lbMessage.Location = new System.Drawing.Point(241, 9);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(348, 30);
            this.lbMessage.TabIndex = 13;
            this.lbMessage.Text = "Server not found";
            // 
            // btnDeployungAccepted
            // 
            this.btnDeployungAccepted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeployungAccepted.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDeployungAccepted.FlatAppearance.BorderSize = 0;
            this.btnDeployungAccepted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeployungAccepted.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeployungAccepted.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.btnDeployungAccepted.Location = new System.Drawing.Point(241, 207);
            this.btnDeployungAccepted.Name = "btnDeployungAccepted";
            this.btnDeployungAccepted.Size = new System.Drawing.Size(129, 31);
            this.btnDeployungAccepted.TabIndex = 11;
            this.btnDeployungAccepted.Text = "YES";
            this.btnDeployungAccepted.UseVisualStyleBackColor = false;
            this.btnDeployungAccepted.Click += new System.EventHandler(this.btnDeployungAccepted_Click);
            // 
            // btnDeployingDenied
            // 
            this.btnDeployingDenied.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeployingDenied.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDeployingDenied.FlatAppearance.BorderSize = 0;
            this.btnDeployingDenied.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeployingDenied.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeployingDenied.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.btnDeployingDenied.Location = new System.Drawing.Point(460, 207);
            this.btnDeployingDenied.Name = "btnDeployingDenied";
            this.btnDeployingDenied.Size = new System.Drawing.Size(129, 31);
            this.btnDeployingDenied.TabIndex = 12;
            this.btnDeployingDenied.Text = "NO";
            this.btnDeployingDenied.UseVisualStyleBackColor = false;
            this.btnDeployingDenied.Click += new System.EventHandler(this.btnDeployingDenied_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::VKR_Test.Properties.Resources.Error2;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(232, 250);
            this.panel2.TabIndex = 19;
            // 
            // ServerNotFoundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(601, 250);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.btnDeployungAccepted);
            this.Controls.Add(this.btnDeployingDenied);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "ServerNotFoundForm";
            this.Text = "Server not found";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Button btnDeployungAccepted;
        private System.Windows.Forms.Button btnDeployingDenied;
        private System.Windows.Forms.Panel panel2;
    }
}