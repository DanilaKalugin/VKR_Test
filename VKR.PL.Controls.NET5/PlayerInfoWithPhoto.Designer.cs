using System.ComponentModel;
using System.Windows.Forms;

namespace VKR.PL.Controls.NET5
{
    partial class PlayerInfoWithPhoto
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PlayerSecondName = new System.Windows.Forms.Label();
            this.PlayerPosition = new System.Windows.Forms.Label();
            this.PlayerNumber = new System.Windows.Forms.Label();
            this.PlayerFirstName = new System.Windows.Forms.Label();
            this.PlayerPhoto = new System.Windows.Forms.Panel();
            this.PlayerPhoto.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlayerSecondName
            // 
            this.PlayerSecondName.BackColor = System.Drawing.Color.Black;
            this.PlayerSecondName.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Bold);
            this.PlayerSecondName.Location = new System.Drawing.Point(0, 206);
            this.PlayerSecondName.Margin = new System.Windows.Forms.Padding(0);
            this.PlayerSecondName.Name = "PlayerSecondName";
            this.PlayerSecondName.Size = new System.Drawing.Size(120, 23);
            this.PlayerSecondName.TabIndex = 28;
            this.PlayerSecondName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerPosition
            // 
            this.PlayerPosition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.PlayerPosition.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerPosition.Location = new System.Drawing.Point(79, 156);
            this.PlayerPosition.Margin = new System.Windows.Forms.Padding(0);
            this.PlayerPosition.Name = "PlayerPosition";
            this.PlayerPosition.Size = new System.Drawing.Size(40, 23);
            this.PlayerPosition.TabIndex = 35;
            this.PlayerPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerNumber
            // 
            this.PlayerNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.PlayerNumber.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerNumber.Location = new System.Drawing.Point(79, 130);
            this.PlayerNumber.Margin = new System.Windows.Forms.Padding(0);
            this.PlayerNumber.Name = "PlayerNumber";
            this.PlayerNumber.Size = new System.Drawing.Size(40, 23);
            this.PlayerNumber.TabIndex = 34;
            this.PlayerNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerFirstName
            // 
            this.PlayerFirstName.BackColor = System.Drawing.Color.Black;
            this.PlayerFirstName.Font = new System.Drawing.Font("MicroFLF", 11F);
            this.PlayerFirstName.Location = new System.Drawing.Point(0, 183);
            this.PlayerFirstName.Margin = new System.Windows.Forms.Padding(0);
            this.PlayerFirstName.Name = "PlayerFirstName";
            this.PlayerFirstName.Size = new System.Drawing.Size(120, 23);
            this.PlayerFirstName.TabIndex = 27;
            this.PlayerFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerPhoto
            // 
            this.PlayerPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PlayerPhoto.Controls.Add(this.PlayerPosition);
            this.PlayerPhoto.Controls.Add(this.PlayerNumber);
            this.PlayerPhoto.Location = new System.Drawing.Point(0, 0);
            this.PlayerPhoto.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.PlayerPhoto.Name = "PlayerPhoto";
            this.PlayerPhoto.Size = new System.Drawing.Size(120, 180);
            this.PlayerPhoto.TabIndex = 26;
            // 
            // PlayerInfoWithPhoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PlayerPhoto);
            this.Controls.Add(this.PlayerSecondName);
            this.Controls.Add(this.PlayerFirstName);
            this.Name = "PlayerInfoWithPhoto";
            this.Size = new System.Drawing.Size(120, 229);
            this.PlayerPhoto.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Label PlayerSecondName;
        private Label PlayerPosition;
        private Label PlayerNumber;
        private Label PlayerFirstName;
        private Panel PlayerPhoto;
    }
}
