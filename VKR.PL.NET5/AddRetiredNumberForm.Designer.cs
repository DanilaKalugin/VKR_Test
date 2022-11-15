namespace VKR.PL.NET5
{
    partial class AddRetiredNumberForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRetiredNumberForm));
            this.txtTeam = new VKR.PL.Controls.NET5.TextBoxWithHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textPerson = new VKR.PL.Controls.NET5.TextBoxWithHeader();
            this.numRetiredNumber = new System.Windows.Forms.DomainUpDown();
            this.dtpRetirementDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddRetiredNumber = new System.Windows.Forms.Button();
            cbStadium = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbStadium
            // 
            cbStadium.AutoSize = true;
            cbStadium.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cbStadium.Location = new System.Drawing.Point(118, 98);
            cbStadium.Name = "cbStadium";
            cbStadium.Size = new System.Drawing.Size(74, 17);
            cbStadium.TabIndex = 113;
            cbStadium.Text = "Number:";
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
            this.txtTeam.TabIndex = 111;
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
            this.panel1.TabIndex = 110;
            // 
            // textPerson
            // 
            this.textPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textPerson.Header = "Person";
            this.textPerson.Location = new System.Drawing.Point(118, 44);
            this.textPerson.MaxLength = ((ushort)(75));
            this.textPerson.MayIncludeNumbers = false;
            this.textPerson.Name = "textPerson";
            this.textPerson.ReadOnlyControl = false;
            this.textPerson.Size = new System.Drawing.Size(409, 46);
            this.textPerson.TabIndex = 112;
            this.textPerson.Value = null;
            this.textPerson.ValuePosition = ((ushort)(90));
            this.textPerson.Validated += new System.EventHandler(this.textPerson_Validated);
            // 
            // numRetiredNumber
            // 
            this.numRetiredNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numRetiredNumber.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numRetiredNumber.Location = new System.Drawing.Point(208, 96);
            this.numRetiredNumber.Name = "numRetiredNumber";
            this.numRetiredNumber.Size = new System.Drawing.Size(319, 26);
            this.numRetiredNumber.TabIndex = 114;
            this.numRetiredNumber.Text = "domainUpDown1";
            this.numRetiredNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numRetiredNumber.SelectedItemChanged += new System.EventHandler(this.numRetiredNumber_SelectedItemChanged);
            // 
            // dtpRetirementDate
            // 
            this.dtpRetirementDate.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpRetirementDate.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dtpRetirementDate.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.dtpRetirementDate.CustomFormat = "MM/dd/yyyy";
            this.dtpRetirementDate.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpRetirementDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRetirementDate.Location = new System.Drawing.Point(208, 128);
            this.dtpRetirementDate.MinDate = new System.DateTime(1901, 1, 1, 0, 0, 0, 0);
            this.dtpRetirementDate.Name = "dtpRetirementDate";
            this.dtpRetirementDate.Size = new System.Drawing.Size(319, 26);
            this.dtpRetirementDate.TabIndex = 116;
            this.dtpRetirementDate.Value = new System.DateTime(2022, 8, 19, 13, 15, 23, 0);
            this.dtpRetirementDate.Validated += new System.EventHandler(this.dtpRetirementDate_Validated);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(118, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 17);
            this.label7.TabIndex = 115;
            this.label7.Text = "Date:";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClose.Location = new System.Drawing.Point(208, 160);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 33);
            this.btnClose.TabIndex = 118;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnAddRetiredNumber
            // 
            this.btnAddRetiredNumber.FlatAppearance.BorderSize = 0;
            this.btnAddRetiredNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRetiredNumber.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddRetiredNumber.Location = new System.Drawing.Point(420, 160);
            this.btnAddRetiredNumber.Name = "btnAddRetiredNumber";
            this.btnAddRetiredNumber.Size = new System.Drawing.Size(107, 33);
            this.btnAddRetiredNumber.TabIndex = 117;
            this.btnAddRetiredNumber.Text = "ADD";
            this.btnAddRetiredNumber.UseVisualStyleBackColor = true;
            this.btnAddRetiredNumber.Click += new System.EventHandler(this.btnAddRetiredNumber_Click);
            // 
            // AddRetiredNumberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 205);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddRetiredNumber);
            this.Controls.Add(this.dtpRetirementDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numRetiredNumber);
            this.Controls.Add(cbStadium);
            this.Controls.Add(this.textPerson);
            this.Controls.Add(this.txtTeam);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddRetiredNumberForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add new retired number";
            this.Load += new System.EventHandler(this.AddRetiredNumberForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.NET5.TextBoxWithHeader txtTeam;
        private System.Windows.Forms.Panel panel1;
        private Controls.NET5.TextBoxWithHeader textPerson;
        private System.Windows.Forms.DomainUpDown numRetiredNumber;
        private System.Windows.Forms.DateTimePicker dtpRetirementDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddRetiredNumber;
    }
}