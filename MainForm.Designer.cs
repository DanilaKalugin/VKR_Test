namespace VKR_Test
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.AwayTeam_Abbreviation = new System.Windows.Forms.Label();
            this.HomeTeam_Abbreviation = new System.Windows.Forms.Label();
            this.AwayTeam_RunsScored = new System.Windows.Forms.Label();
            this.HomeTeam_RunsScored = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(450, 1047);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(428, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "New Pitch";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(1162, 823);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 78);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(1162, 902);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 30);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label1.Location = new System.Drawing.Point(15, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(15, 5, 1, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "▲";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(37, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 1, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(83, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 1, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label4.Location = new System.Drawing.Point(105, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 5, 1, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Out";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(189, 6);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "0-0";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.BackgroundImage = global::VKR_Test.Properties.Resources._000;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(160, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(90, 78);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(163)))), ((int)(((byte)(224)))));
            this.panel4.Controls.Add(this.AwayTeam_RunsScored);
            this.panel4.Controls.Add(this.AwayTeam_Abbreviation);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(160, 39);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(184)))), ((int)(((byte)(39)))));
            this.panel5.Controls.Add(this.HomeTeam_Abbreviation);
            this.panel5.Controls.Add(this.HomeTeam_RunsScored);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 39);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(160, 39);
            this.panel5.TabIndex = 4;
            // 
            // AwayTeam_Abbreviation
            // 
            this.AwayTeam_Abbreviation.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold);
            this.AwayTeam_Abbreviation.ForeColor = System.Drawing.Color.White;
            this.AwayTeam_Abbreviation.Location = new System.Drawing.Point(6, 5);
            this.AwayTeam_Abbreviation.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.AwayTeam_Abbreviation.Name = "AwayTeam_Abbreviation";
            this.AwayTeam_Abbreviation.Size = new System.Drawing.Size(84, 26);
            this.AwayTeam_Abbreviation.TabIndex = 0;
            this.AwayTeam_Abbreviation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HomeTeam_Abbreviation
            // 
            this.HomeTeam_Abbreviation.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold);
            this.HomeTeam_Abbreviation.ForeColor = System.Drawing.Color.White;
            this.HomeTeam_Abbreviation.Location = new System.Drawing.Point(6, 5);
            this.HomeTeam_Abbreviation.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.HomeTeam_Abbreviation.Name = "HomeTeam_Abbreviation";
            this.HomeTeam_Abbreviation.Size = new System.Drawing.Size(84, 28);
            this.HomeTeam_Abbreviation.TabIndex = 1;
            this.HomeTeam_Abbreviation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AwayTeam_RunsScored
            // 
            this.AwayTeam_RunsScored.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold);
            this.AwayTeam_RunsScored.ForeColor = System.Drawing.Color.White;
            this.AwayTeam_RunsScored.Location = new System.Drawing.Point(70, 5);
            this.AwayTeam_RunsScored.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.AwayTeam_RunsScored.Name = "AwayTeam_RunsScored";
            this.AwayTeam_RunsScored.Size = new System.Drawing.Size(84, 26);
            this.AwayTeam_RunsScored.TabIndex = 2;
            this.AwayTeam_RunsScored.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // HomeTeam_RunsScored
            // 
            this.HomeTeam_RunsScored.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold);
            this.HomeTeam_RunsScored.ForeColor = System.Drawing.Color.White;
            this.HomeTeam_RunsScored.Location = new System.Drawing.Point(70, 5);
            this.HomeTeam_RunsScored.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.HomeTeam_RunsScored.Name = "HomeTeam_RunsScored";
            this.HomeTeam_RunsScored.Size = new System.Drawing.Size(84, 28);
            this.HomeTeam_RunsScored.TabIndex = 3;
            this.HomeTeam_RunsScored.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1423, 1082);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label HomeTeam_Abbreviation;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label AwayTeam_Abbreviation;
        private System.Windows.Forms.Label HomeTeam_RunsScored;
        private System.Windows.Forms.Label AwayTeam_RunsScored;
    }
}

