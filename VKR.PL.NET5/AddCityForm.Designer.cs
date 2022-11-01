namespace VKR.PL.NET5
{
    partial class AddCityForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCityForm));
            this.label4 = new System.Windows.Forms.Label();
            this.cbPlaceOfBirth = new System.Windows.Forms.ComboBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtCityName = new VKR.PL.Controls.NET5.TextBoxWithHeader();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 77;
            this.label4.Text = "Region";
            // 
            // cbPlaceOfBirth
            // 
            this.cbPlaceOfBirth.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbPlaceOfBirth.DropDownHeight = 172;
            this.cbPlaceOfBirth.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbPlaceOfBirth.FormattingEnabled = true;
            this.cbPlaceOfBirth.IntegralHeight = false;
            this.cbPlaceOfBirth.Location = new System.Drawing.Point(115, 64);
            this.cbPlaceOfBirth.Name = "cbPlaceOfBirth";
            this.cbPlaceOfBirth.Size = new System.Drawing.Size(351, 25);
            this.cbPlaceOfBirth.TabIndex = 76;
            this.cbPlaceOfBirth.SelectedIndexChanged += new System.EventHandler(this.cbPlaceOfBirth_SelectedIndexChanged);
            this.cbPlaceOfBirth.Validating += new System.ComponentModel.CancelEventHandler(this.cbPlaceOfBirth_Validating);
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.FlatAppearance.BorderSize = 0;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCheck.Location = new System.Drawing.Point(359, 95);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(107, 33);
            this.btnCheck.TabIndex = 84;
            this.btnCheck.Text = "ADD";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtCityName
            // 
            this.txtCityName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCityName.Header = "City name";
            this.txtCityName.Location = new System.Drawing.Point(12, 12);
            this.txtCityName.MaxLength = ((ushort)(50));
            this.txtCityName.MayIncludeNumbers = false;
            this.txtCityName.Name = "txtCityName";
            this.txtCityName.ReadOnlyControl = false;
            this.txtCityName.Size = new System.Drawing.Size(454, 46);
            this.txtCityName.TabIndex = 109;
            this.txtCityName.Value = null;
            this.txtCityName.ValuePosition = ((ushort)(103));
            this.txtCityName.Validated += new System.EventHandler(this.txtCityName_Validated);
            // 
            // AddCityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 140);
            this.Controls.Add(this.txtCityName);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbPlaceOfBirth);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddCityForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adding new city";
            this.Load += new System.EventHandler(this.AddCityForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbPlaceOfBirth;
        private System.Windows.Forms.Button btnCheck;
        private Controls.NET5.TextBoxWithHeader txtCityName;
    }
}