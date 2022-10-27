namespace VKR.PL.NET5
{
    partial class AddPlayerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPlayerForm));
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numPlayerNumber = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPlaceOfBirth = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbThrowRight = new System.Windows.Forms.RadioButton();
            this.cbThrowLeft = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbBattingSwitch = new System.Windows.Forms.RadioButton();
            this.cbBattingRight = new System.Windows.Forms.RadioButton();
            this.cbBattingLeft = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.lbRewards = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnAddCity = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayerNumber)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFirstName.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFirstName.Location = new System.Drawing.Point(141, 44);
            this.txtFirstName.MaxLength = 35;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(250, 26);
            this.txtFirstName.TabIndex = 67;
            this.txtFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.txtFirstName_Validating);
            this.txtFirstName.Validated += new System.EventHandler(this.txtFirstName_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 66;
            this.label2.Text = "First name:";
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLastName.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLastName.Location = new System.Drawing.Point(141, 76);
            this.txtLastName.MaxLength = 35;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(250, 26);
            this.txtLastName.TabIndex = 69;
            this.txtLastName.Validating += new System.ComponentModel.CancelEventHandler(this.txtLastName_Validating);
            this.txtLastName.Validated += new System.EventHandler(this.txtLastName_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 68;
            this.label1.Text = "Last name:";
            // 
            // numPlayerNumber
            // 
            this.numPlayerNumber.BackColor = System.Drawing.Color.WhiteSmoke;
            this.numPlayerNumber.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numPlayerNumber.Location = new System.Drawing.Point(141, 108);
            this.numPlayerNumber.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numPlayerNumber.Name = "numPlayerNumber";
            this.numPlayerNumber.Size = new System.Drawing.Size(250, 26);
            this.numPlayerNumber.TabIndex = 70;
            this.numPlayerNumber.ValueChanged += new System.EventHandler(this.numPlayerNumber_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 71;
            this.label3.Text = "Number:";
            // 
            // cbPlaceOfBirth
            // 
            this.cbPlaceOfBirth.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbPlaceOfBirth.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbPlaceOfBirth.FormattingEnabled = true;
            this.cbPlaceOfBirth.Location = new System.Drawing.Point(141, 140);
            this.cbPlaceOfBirth.Name = "cbPlaceOfBirth";
            this.cbPlaceOfBirth.Size = new System.Drawing.Size(250, 25);
            this.cbPlaceOfBirth.TabIndex = 72;
            this.cbPlaceOfBirth.SelectedIndexChanged += new System.EventHandler(this.cbPlaceOfBirth_SelectedIndexChanged);
            this.cbPlaceOfBirth.Validating += new System.ComponentModel.CancelEventHandler(this.cbPlaceOfBirth_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 17);
            this.label4.TabIndex = 73;
            this.label4.Text = "Place of birth:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(12, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 17);
            this.label5.TabIndex = 74;
            this.label5.Text = "Throwing hand:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbThrowRight);
            this.panel1.Controls.Add(this.cbThrowLeft);
            this.panel1.Location = new System.Drawing.Point(141, 174);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 27);
            this.panel1.TabIndex = 75;
            // 
            // cbThrowRight
            // 
            this.cbThrowRight.AutoSize = true;
            this.cbThrowRight.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbThrowRight.Location = new System.Drawing.Point(67, 3);
            this.cbThrowRight.Name = "cbThrowRight";
            this.cbThrowRight.Size = new System.Drawing.Size(65, 21);
            this.cbThrowRight.TabIndex = 1;
            this.cbThrowRight.TabStop = true;
            this.cbThrowRight.Text = "Right";
            this.cbThrowRight.UseVisualStyleBackColor = true;
            this.cbThrowRight.CheckedChanged += new System.EventHandler(this.cbThrowRight_CheckedChanged);
            // 
            // cbThrowLeft
            // 
            this.cbThrowLeft.AutoSize = true;
            this.cbThrowLeft.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbThrowLeft.Location = new System.Drawing.Point(3, 3);
            this.cbThrowLeft.Name = "cbThrowLeft";
            this.cbThrowLeft.Size = new System.Drawing.Size(58, 21);
            this.cbThrowLeft.TabIndex = 0;
            this.cbThrowLeft.TabStop = true;
            this.cbThrowLeft.Text = "Left";
            this.cbThrowLeft.UseVisualStyleBackColor = true;
            this.cbThrowLeft.CheckedChanged += new System.EventHandler(this.cbThrowLeft_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbBattingSwitch);
            this.panel2.Controls.Add(this.cbBattingRight);
            this.panel2.Controls.Add(this.cbBattingLeft);
            this.panel2.Location = new System.Drawing.Point(141, 207);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 28);
            this.panel2.TabIndex = 77;
            // 
            // cbBattingSwitch
            // 
            this.cbBattingSwitch.AutoSize = true;
            this.cbBattingSwitch.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbBattingSwitch.Location = new System.Drawing.Point(137, 3);
            this.cbBattingSwitch.Name = "cbBattingSwitch";
            this.cbBattingSwitch.Size = new System.Drawing.Size(78, 21);
            this.cbBattingSwitch.TabIndex = 2;
            this.cbBattingSwitch.TabStop = true;
            this.cbBattingSwitch.Text = "Switch";
            this.cbBattingSwitch.UseVisualStyleBackColor = true;
            this.cbBattingSwitch.CheckedChanged += new System.EventHandler(this.cbBattingSwitch_CheckedChanged);
            // 
            // cbBattingRight
            // 
            this.cbBattingRight.AutoSize = true;
            this.cbBattingRight.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbBattingRight.Location = new System.Drawing.Point(66, 3);
            this.cbBattingRight.Name = "cbBattingRight";
            this.cbBattingRight.Size = new System.Drawing.Size(65, 21);
            this.cbBattingRight.TabIndex = 1;
            this.cbBattingRight.TabStop = true;
            this.cbBattingRight.Text = "Right";
            this.cbBattingRight.UseVisualStyleBackColor = true;
            this.cbBattingRight.CheckedChanged += new System.EventHandler(this.cbBattingRight_CheckedChanged);
            // 
            // cbBattingLeft
            // 
            this.cbBattingLeft.AutoSize = true;
            this.cbBattingLeft.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbBattingLeft.Location = new System.Drawing.Point(3, 3);
            this.cbBattingLeft.Name = "cbBattingLeft";
            this.cbBattingLeft.Size = new System.Drawing.Size(58, 21);
            this.cbBattingLeft.TabIndex = 0;
            this.cbBattingLeft.TabStop = true;
            this.cbBattingLeft.Text = "Left";
            this.cbBattingLeft.UseVisualStyleBackColor = true;
            this.cbBattingLeft.CheckedChanged += new System.EventHandler(this.cbBattingLeft_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(12, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 17);
            this.label6.TabIndex = 76;
            this.label6.Text = "Batting:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(12, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 17);
            this.label7.TabIndex = 78;
            this.label7.Text = "Date of birth:";
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dtpBirthDate.CustomFormat = "MM/dd/yyyy";
            this.dtpBirthDate.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthDate.Location = new System.Drawing.Point(141, 244);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(250, 26);
            this.dtpBirthDate.TabIndex = 79;
            this.dtpBirthDate.Value = new System.DateTime(2022, 8, 19, 13, 15, 23, 0);
            this.dtpBirthDate.ValueChanged += new System.EventHandler(this.dtpBirthDate_ValueChanged);
            this.dtpBirthDate.Validating += new System.ComponentModel.CancelEventHandler(this.dtpBirthDate_Validating);
            // 
            // lbRewards
            // 
            this.lbRewards.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbRewards.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbRewards.FormattingEnabled = true;
            this.lbRewards.Location = new System.Drawing.Point(141, 276);
            this.lbRewards.Name = "lbRewards";
            this.lbRewards.Size = new System.Drawing.Size(250, 214);
            this.lbRewards.TabIndex = 81;
            this.lbRewards.Validated += new System.EventHandler(this.lbRewards_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(12, 276);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 17);
            this.label8.TabIndex = 82;
            this.label8.Text = "Positions:";
            // 
            // btnCheck
            // 
            this.btnCheck.FlatAppearance.BorderSize = 0;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCheck.Location = new System.Drawing.Point(284, 496);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(107, 33);
            this.btnCheck.TabIndex = 83;
            this.btnCheck.Text = "UPDATE";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnAddCity
            // 
            this.btnAddCity.FlatAppearance.BorderSize = 0;
            this.btnAddCity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCity.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddCity.Location = new System.Drawing.Point(397, 140);
            this.btnAddCity.Name = "btnAddCity";
            this.btnAddCity.Size = new System.Drawing.Size(97, 25);
            this.btnAddCity.TabIndex = 84;
            this.btnAddCity.Text = "ADD CITY";
            this.btnAddCity.UseVisualStyleBackColor = true;
            this.btnAddCity.Click += new System.EventHandler(this.btnAddCity_Click);
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtId.Enabled = false;
            this.txtId.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtId.Location = new System.Drawing.Point(141, 12);
            this.txtId.MaxLength = 35;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(250, 26);
            this.txtId.TabIndex = 86;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(12, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 17);
            this.label9.TabIndex = 85;
            this.label9.Text = "ID:";
            // 
            // AddPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(506, 541);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnAddCity);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbRewards);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbPlaceOfBirth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numPlayerNumber);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddPlayerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddPlayerForm";
            this.Load += new System.EventHandler(this.AddPlayerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPlayerNumber)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numPlayerNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPlaceOfBirth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton cbThrowRight;
        private System.Windows.Forms.RadioButton cbThrowLeft;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton cbBattingSwitch;
        private System.Windows.Forms.RadioButton cbBattingRight;
        private System.Windows.Forms.RadioButton cbBattingLeft;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.CheckedListBox lbRewards;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnAddCity;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label9;
    }
}