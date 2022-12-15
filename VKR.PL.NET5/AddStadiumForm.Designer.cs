namespace VKR.PL.NET5
{
    partial class AddStadiumForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddStadiumForm));
            this.txtId = new VKR.PL.Controls.NET5.TextBoxWithHeader();
            this.txtStadiumName = new VKR.PL.Controls.NET5.TextBoxWithHeader();
            this.label3 = new System.Windows.Forms.Label();
            this.numPlayerNumber = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numMaxWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddCity = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.cbStadiumLocation = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayerNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtId.Header = "Id";
            this.txtId.Location = new System.Drawing.Point(12, 12);
            this.txtId.MaxLength = ((ushort)(65535));
            this.txtId.MayIncludeNumbers = true;
            this.txtId.Name = "txtId";
            this.txtId.ReadOnlyControl = true;
            this.txtId.Size = new System.Drawing.Size(425, 26);
            this.txtId.TabIndex = 0;
            this.txtId.Value = null;
            this.txtId.ValuePosition = ((ushort)(175));
            // 
            // txtStadiumName
            // 
            this.txtStadiumName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtStadiumName.Header = "Stadium title";
            this.txtStadiumName.Location = new System.Drawing.Point(12, 44);
            this.txtStadiumName.MaxLength = ((ushort)(75));
            this.txtStadiumName.MayIncludeNumbers = true;
            this.txtStadiumName.Name = "txtStadiumName";
            this.txtStadiumName.ReadOnlyControl = false;
            this.txtStadiumName.Size = new System.Drawing.Size(425, 46);
            this.txtStadiumName.TabIndex = 1;
            this.txtStadiumName.Value = null;
            this.txtStadiumName.ValuePosition = ((ushort)(175));
            this.txtStadiumName.Validated += new System.EventHandler(this.txtStadiumName_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 73;
            this.label3.Text = "Capacity:";
            // 
            // numPlayerNumber
            // 
            this.numPlayerNumber.BackColor = System.Drawing.Color.WhiteSmoke;
            this.numPlayerNumber.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numPlayerNumber.Location = new System.Drawing.Point(187, 96);
            this.numPlayerNumber.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numPlayerNumber.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPlayerNumber.Name = "numPlayerNumber";
            this.numPlayerNumber.Size = new System.Drawing.Size(250, 26);
            this.numPlayerNumber.TabIndex = 72;
            this.numPlayerNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPlayerNumber.ThousandsSeparator = true;
            this.numPlayerNumber.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPlayerNumber.ValueChanged += new System.EventHandler(this.numPlayerNumber_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 17);
            this.label1.TabIndex = 75;
            this.label1.Text = "Maximum field width:";
            // 
            // numMaxWidth
            // 
            this.numMaxWidth.BackColor = System.Drawing.Color.WhiteSmoke;
            this.numMaxWidth.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numMaxWidth.Location = new System.Drawing.Point(187, 128);
            this.numMaxWidth.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numMaxWidth.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numMaxWidth.Name = "numMaxWidth";
            this.numMaxWidth.Size = new System.Drawing.Size(250, 26);
            this.numMaxWidth.TabIndex = 74;
            this.numMaxWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numMaxWidth.ThousandsSeparator = true;
            this.numMaxWidth.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numMaxWidth.ValueChanged += new System.EventHandler(this.numMaxWidth_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(443, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 17);
            this.label2.TabIndex = 76;
            this.label2.Text = "ft";
            // 
            // btnAddCity
            // 
            this.btnAddCity.FlatAppearance.BorderSize = 0;
            this.btnAddCity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCity.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddCity.Location = new System.Drawing.Point(443, 160);
            this.btnAddCity.Name = "btnAddCity";
            this.btnAddCity.Size = new System.Drawing.Size(97, 25);
            this.btnAddCity.TabIndex = 87;
            this.btnAddCity.Text = "ADD CITY";
            this.btnAddCity.UseVisualStyleBackColor = true;
            this.btnAddCity.Click += new System.EventHandler(this.btnAddCity_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 86;
            this.label4.Text = "Location:";
            // 
            // cbStadiumLocation
            // 
            this.cbStadiumLocation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbStadiumLocation.DropDownHeight = 172;
            this.cbStadiumLocation.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbStadiumLocation.FormattingEnabled = true;
            this.cbStadiumLocation.IntegralHeight = false;
            this.cbStadiumLocation.Location = new System.Drawing.Point(187, 160);
            this.cbStadiumLocation.MaxLength = 60;
            this.cbStadiumLocation.Name = "cbStadiumLocation";
            this.cbStadiumLocation.Size = new System.Drawing.Size(250, 25);
            this.cbStadiumLocation.TabIndex = 85;
            this.cbStadiumLocation.SelectionChangeCommitted += new System.EventHandler(this.cbStadiumLocation_SelectionChangeCommitted);
            this.cbStadiumLocation.Validating += new System.ComponentModel.CancelEventHandler(this.cbStadiumLocation_Validating);
            // 
            // btnCheck
            // 
            this.btnCheck.FlatAppearance.BorderSize = 0;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCheck.Location = new System.Drawing.Point(330, 191);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(107, 33);
            this.btnCheck.TabIndex = 110;
            this.btnCheck.Text = "UPDATE";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClose.Location = new System.Drawing.Point(187, 191);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 33);
            this.btnClose.TabIndex = 111;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // AddStadiumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(552, 236);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnAddCity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbStadiumLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numMaxWidth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numPlayerNumber);
            this.Controls.Add(this.txtStadiumName);
            this.Controls.Add(this.txtId);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddStadiumForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adding new stadium";
            this.Load += new System.EventHandler(this.AddStadiumForm_Load);
            this.VisibleChanged += new System.EventHandler(this.AddStadiumForm_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.numPlayerNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.NET5.TextBoxWithHeader txtId;
        private Controls.NET5.TextBoxWithHeader txtStadiumName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numPlayerNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numMaxWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddCity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.ComboBox cbStadiumLocation;
        private System.Windows.Forms.Button btnClose;
    }
}