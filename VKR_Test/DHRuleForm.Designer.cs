
namespace VKR_Test
{
    partial class DHRuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DHRuleForm));
            this.rbPlayWithDH = new System.Windows.Forms.RadioButton();
            this.rbPlayWithoutDH = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAcceptDHRule = new System.Windows.Forms.Button();
            this.dtpMatchDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rbPlayWithDH
            // 
            this.rbPlayWithDH.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPlayWithDH.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.rbPlayWithDH.Location = new System.Drawing.Point(12, 46);
            this.rbPlayWithDH.Name = "rbPlayWithDH";
            this.rbPlayWithDH.Size = new System.Drawing.Size(150, 24);
            this.rbPlayWithDH.TabIndex = 0;
            this.rbPlayWithDH.TabStop = true;
            this.rbPlayWithDH.Text = "PLAY WITH DH";
            this.rbPlayWithDH.UseVisualStyleBackColor = true;
            this.rbPlayWithDH.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbPlayWithoutDH
            // 
            this.rbPlayWithoutDH.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPlayWithoutDH.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.rbPlayWithoutDH.Location = new System.Drawing.Point(13, 76);
            this.rbPlayWithoutDH.Name = "rbPlayWithoutDH";
            this.rbPlayWithoutDH.Size = new System.Drawing.Size(173, 24);
            this.rbPlayWithoutDH.TabIndex = 1;
            this.rbPlayWithoutDH.TabStop = true;
            this.rbPlayWithoutDH.Text = "PLAY WITHOUT DH";
            this.rbPlayWithoutDH.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(399, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Designated hitter rule:";
            // 
            // btnAcceptDHRule
            // 
            this.btnAcceptDHRule.FlatAppearance.BorderSize = 0;
            this.btnAcceptDHRule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceptDHRule.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcceptDHRule.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAcceptDHRule.Location = new System.Drawing.Point(334, 210);
            this.btnAcceptDHRule.Name = "btnAcceptDHRule";
            this.btnAcceptDHRule.Size = new System.Drawing.Size(75, 23);
            this.btnAcceptDHRule.TabIndex = 3;
            this.btnAcceptDHRule.Text = "PLAY";
            this.btnAcceptDHRule.UseVisualStyleBackColor = true;
            this.btnAcceptDHRule.Click += new System.EventHandler(this.btnAcceptDHRule_Click);
            // 
            // dtpMatchDate
            // 
            this.dtpMatchDate.CalendarForeColor = System.Drawing.Color.WhiteSmoke;
            this.dtpMatchDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dtpMatchDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dtpMatchDate.CalendarTitleForeColor = System.Drawing.Color.WhiteSmoke;
            this.dtpMatchDate.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMatchDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMatchDate.Location = new System.Drawing.Point(12, 137);
            this.dtpMatchDate.MaxDate = new System.DateTime(2021, 10, 3, 0, 0, 0, 0);
            this.dtpMatchDate.MinDate = new System.DateTime(2021, 4, 1, 0, 0, 0, 0);
            this.dtpMatchDate.Name = "dtpMatchDate";
            this.dtpMatchDate.Size = new System.Drawing.Size(397, 27);
            this.dtpMatchDate.TabIndex = 4;
            this.dtpMatchDate.Value = new System.DateTime(2021, 4, 12, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(10, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(399, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Match date:";
            // 
            // DHRuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(421, 245);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpMatchDate);
            this.Controls.Add(this.btnAcceptDHRule);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbPlayWithoutDH);
            this.Controls.Add(this.rbPlayWithDH);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DHRuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Designated hitter rule";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbPlayWithDH;
        private System.Windows.Forms.RadioButton rbPlayWithoutDH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAcceptDHRule;
        private System.Windows.Forms.DateTimePicker dtpMatchDate;
        private System.Windows.Forms.Label label2;
    }
}