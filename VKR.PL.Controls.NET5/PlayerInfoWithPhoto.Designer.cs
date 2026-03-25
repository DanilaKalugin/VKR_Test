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
            PlayerSecondName = new Label();
            PlayerPosition = new Label();
            PlayerNumber = new Label();
            PlayerFirstName = new Label();
            PlayerPhoto = new Panel();
            PlayerPhoto.SuspendLayout();
            SuspendLayout();
            // 
            // PlayerSecondName
            // 
            PlayerSecondName.BackColor = System.Drawing.Color.Black;
            PlayerSecondName.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            PlayerSecondName.Location = new System.Drawing.Point(0, 206);
            PlayerSecondName.Margin = new Padding(0);
            PlayerSecondName.Name = "PlayerSecondName";
            PlayerSecondName.Size = new System.Drawing.Size(120, 23);
            PlayerSecondName.TabIndex = 28;
            PlayerSecondName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerPosition
            // 
            PlayerPosition.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            PlayerPosition.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            PlayerPosition.Location = new System.Drawing.Point(79, 156);
            PlayerPosition.Margin = new Padding(0);
            PlayerPosition.Name = "PlayerPosition";
            PlayerPosition.Size = new System.Drawing.Size(40, 23);
            PlayerPosition.TabIndex = 35;
            PlayerPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerNumber
            // 
            PlayerNumber.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            PlayerNumber.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            PlayerNumber.Location = new System.Drawing.Point(79, 130);
            PlayerNumber.Margin = new Padding(0);
            PlayerNumber.Name = "PlayerNumber";
            PlayerNumber.Size = new System.Drawing.Size(40, 23);
            PlayerNumber.TabIndex = 34;
            PlayerNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerFirstName
            // 
            PlayerFirstName.BackColor = System.Drawing.Color.Black;
            PlayerFirstName.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            PlayerFirstName.Location = new System.Drawing.Point(0, 183);
            PlayerFirstName.Margin = new Padding(0);
            PlayerFirstName.Name = "PlayerFirstName";
            PlayerFirstName.Size = new System.Drawing.Size(120, 23);
            PlayerFirstName.TabIndex = 27;
            PlayerFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerPhoto
            // 
            PlayerPhoto.BackgroundImageLayout = ImageLayout.Zoom;
            PlayerPhoto.Controls.Add(PlayerPosition);
            PlayerPhoto.Controls.Add(PlayerNumber);
            PlayerPhoto.Location = new System.Drawing.Point(0, 0);
            PlayerPhoto.Margin = new Padding(0, 3, 0, 3);
            PlayerPhoto.Name = "PlayerPhoto";
            PlayerPhoto.Size = new System.Drawing.Size(120, 180);
            PlayerPhoto.TabIndex = 26;
            // 
            // PlayerInfoWithPhoto
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PlayerPhoto);
            Controls.Add(PlayerSecondName);
            Controls.Add(PlayerFirstName);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Name = "PlayerInfoWithPhoto";
            Size = new System.Drawing.Size(120, 229);
            PlayerPhoto.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label PlayerSecondName;
        private Label PlayerPosition;
        private Label PlayerNumber;
        private Label PlayerFirstName;
        private Panel PlayerPhoto;
    }
}
