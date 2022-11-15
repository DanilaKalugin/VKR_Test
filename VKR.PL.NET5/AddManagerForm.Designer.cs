namespace VKR.PL.NET5
{
    partial class AddManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddManagerForm));
            this.btnAddCity = new System.Windows.Forms.Button();
            this.btnAddManager = new System.Windows.Forms.Button();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbPlaceOfBirth = new System.Windows.Forms.ComboBox();
            this.txtFirstName = new VKR.PL.Controls.NET5.TextBoxWithHeader();
            this.txtLastName = new VKR.PL.Controls.NET5.TextBoxWithHeader();
            this.txtId = new VKR.PL.Controls.NET5.TextBoxWithHeader();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddCity
            // 
            this.btnAddCity.FlatAppearance.BorderSize = 0;
            this.btnAddCity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCity.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddCity.Location = new System.Drawing.Point(397, 180);
            this.btnAddCity.Name = "btnAddCity";
            this.btnAddCity.Size = new System.Drawing.Size(97, 25);
            this.btnAddCity.TabIndex = 104;
            this.btnAddCity.Text = "ADD CITY";
            this.btnAddCity.UseVisualStyleBackColor = true;
            this.btnAddCity.Click += new System.EventHandler(this.btnAddCity_Click);
            // 
            // btnAddManager
            // 
            this.btnAddManager.FlatAppearance.BorderSize = 0;
            this.btnAddManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddManager.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddManager.Location = new System.Drawing.Point(284, 211);
            this.btnAddManager.Name = "btnAddManager";
            this.btnAddManager.Size = new System.Drawing.Size(107, 33);
            this.btnAddManager.TabIndex = 103;
            this.btnAddManager.Text = "ADD";
            this.btnAddManager.UseVisualStyleBackColor = true;
            this.btnAddManager.Click += new System.EventHandler(this.btnAddManager_Click);
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dtpBirthDate.CustomFormat = "MM/dd/yyyy";
            this.dtpBirthDate.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthDate.Location = new System.Drawing.Point(141, 148);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(250, 26);
            this.dtpBirthDate.TabIndex = 100;
            this.dtpBirthDate.Value = new System.DateTime(2022, 8, 19, 13, 15, 23, 0);
            this.dtpBirthDate.ValueChanged += new System.EventHandler(this.dtpBirthDate_ValueChanged);
            this.dtpBirthDate.Validating += new System.ComponentModel.CancelEventHandler(this.dtpBirthDate_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(12, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 17);
            this.label7.TabIndex = 99;
            this.label7.Text = "Date of birth:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 17);
            this.label4.TabIndex = 94;
            this.label4.Text = "Place of birth:";
            // 
            // cbPlaceOfBirth
            // 
            this.cbPlaceOfBirth.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbPlaceOfBirth.DropDownHeight = 172;
            this.cbPlaceOfBirth.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbPlaceOfBirth.FormattingEnabled = true;
            this.cbPlaceOfBirth.IntegralHeight = false;
            this.cbPlaceOfBirth.Location = new System.Drawing.Point(141, 180);
            this.cbPlaceOfBirth.MaxDropDownItems = 5;
            this.cbPlaceOfBirth.MaxLength = 60;
            this.cbPlaceOfBirth.Name = "cbPlaceOfBirth";
            this.cbPlaceOfBirth.Size = new System.Drawing.Size(250, 25);
            this.cbPlaceOfBirth.TabIndex = 93;
            this.cbPlaceOfBirth.SelectedIndexChanged += new System.EventHandler(this.cbPlaceOfBirth_SelectedIndexChanged);
            this.cbPlaceOfBirth.Validating += new System.ComponentModel.CancelEventHandler(this.cbPlaceOfBirth_Validating);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFirstName.Header = "First name";
            this.txtFirstName.Location = new System.Drawing.Point(12, 44);
            this.txtFirstName.MaxLength = ((ushort)(30));
            this.txtFirstName.MayIncludeNumbers = false;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.ReadOnlyControl = false;
            this.txtFirstName.Size = new System.Drawing.Size(379, 46);
            this.txtFirstName.TabIndex = 108;
            this.txtFirstName.Value = null;
            this.txtFirstName.ValuePosition = ((ushort)(129));
            this.txtFirstName.Validated += new System.EventHandler(this.txtFirstName_Validated);
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLastName.Header = "Last name";
            this.txtLastName.Location = new System.Drawing.Point(12, 96);
            this.txtLastName.MaxLength = ((ushort)(30));
            this.txtLastName.MayIncludeNumbers = false;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.ReadOnlyControl = false;
            this.txtLastName.Size = new System.Drawing.Size(379, 46);
            this.txtLastName.TabIndex = 109;
            this.txtLastName.Value = null;
            this.txtLastName.ValuePosition = ((ushort)(129));
            this.txtLastName.Validated += new System.EventHandler(this.txtLastName_Validated_1);
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtId.Header = "ID";
            this.txtId.Location = new System.Drawing.Point(12, 12);
            this.txtId.MaxLength = ((ushort)(15));
            this.txtId.MayIncludeNumbers = false;
            this.txtId.Name = "txtId";
            this.txtId.ReadOnlyControl = true;
            this.txtId.Size = new System.Drawing.Size(379, 26);
            this.txtId.TabIndex = 110;
            this.txtId.Value = null;
            this.txtId.ValuePosition = ((ushort)(129));
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClose.Location = new System.Drawing.Point(141, 211);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 33);
            this.btnClose.TabIndex = 111;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // AddManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(506, 256);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.btnAddCity);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbPlaceOfBirth);
            this.Controls.Add(this.btnAddManager);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adding new manager";
            this.Load += new System.EventHandler(this.AddManagerForm_Load);
            this.VisibleChanged += new System.EventHandler(this.AddManagerForm_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddCity;
        private System.Windows.Forms.Button btnAddManager;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbPlaceOfBirth;
        private Controls.NET5.TextBoxWithHeader txtFirstName;
        private Controls.NET5.TextBoxWithHeader txtLastName;
        private Controls.NET5.TextBoxWithHeader txtId;
        private System.Windows.Forms.Button btnClose;
    }
}