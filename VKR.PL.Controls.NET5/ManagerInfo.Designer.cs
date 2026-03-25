namespace VKR.PL.Controls.NET5
{
    partial class ManagerInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbManagerPlaceOfBirth = new System.Windows.Forms.Label();
            this.lbManagerDateOfBirth = new System.Windows.Forms.Label();
            this.pbManagerPhoto = new System.Windows.Forms.Panel();
            this.lbManagerName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbManagerPlaceOfBirth
            // 
            this.lbManagerPlaceOfBirth.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbManagerPlaceOfBirth.Location = new System.Drawing.Point(99, 55);
            this.lbManagerPlaceOfBirth.Name = "lbManagerPlaceOfBirth";
            this.lbManagerPlaceOfBirth.Size = new System.Drawing.Size(250, 26);
            this.lbManagerPlaceOfBirth.TabIndex = 110;
            this.lbManagerPlaceOfBirth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbManagerDateOfBirth
            // 
            this.lbManagerDateOfBirth.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbManagerDateOfBirth.Location = new System.Drawing.Point(99, 29);
            this.lbManagerDateOfBirth.Name = "lbManagerDateOfBirth";
            this.lbManagerDateOfBirth.Size = new System.Drawing.Size(250, 26);
            this.lbManagerDateOfBirth.TabIndex = 109;
            this.lbManagerDateOfBirth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbManagerPhoto
            // 
            this.pbManagerPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbManagerPhoto.Location = new System.Drawing.Point(3, 3);
            this.pbManagerPhoto.Name = "pbManagerPhoto";
            this.pbManagerPhoto.Size = new System.Drawing.Size(90, 90);
            this.pbManagerPhoto.TabIndex = 108;
            // 
            // lbManagerName
            // 
            this.lbManagerName.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbManagerName.Location = new System.Drawing.Point(99, 3);
            this.lbManagerName.Name = "lbManagerName";
            this.lbManagerName.Size = new System.Drawing.Size(250, 26);
            this.lbManagerName.TabIndex = 107;
            this.lbManagerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ManagerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbManagerPlaceOfBirth);
            this.Controls.Add(this.lbManagerDateOfBirth);
            this.Controls.Add(this.pbManagerPhoto);
            this.Controls.Add(this.lbManagerName);
            this.Name = "ManagerInfo";
            this.Size = new System.Drawing.Size(381, 100);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbManagerPlaceOfBirth;
        private System.Windows.Forms.Label lbManagerDateOfBirth;
        private System.Windows.Forms.Panel pbManagerPhoto;
        private System.Windows.Forms.Label lbManagerName;
    }
}
