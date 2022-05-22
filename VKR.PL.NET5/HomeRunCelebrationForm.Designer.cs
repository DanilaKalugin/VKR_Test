
using System.ComponentModel;
using System.Windows.Forms;

namespace VKR.PL.NET5
{
    partial class HomeRunCelebrationForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeRunCelebrationForm));
            this.lbHomeRunType = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbPatterPhoto = new System.Windows.Forms.Panel();
            this.lbBatterName = new System.Windows.Forms.Label();
            this.lbBatterHRNumber = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lbBatterHRNumberInThisMatch = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbHomeRunType
            // 
            this.lbHomeRunType.Font = new System.Drawing.Font("MicroFLF", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbHomeRunType.Location = new System.Drawing.Point(200, 50);
            this.lbHomeRunType.Name = "lbHomeRunType";
            this.lbHomeRunType.Size = new System.Drawing.Size(400, 150);
            this.lbHomeRunType.TabIndex = 0;
            this.lbHomeRunType.Text = "Home";
            this.lbHomeRunType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbHomeRunType.BackColorChanged += new System.EventHandler(this.BackColorChanging);
            // 
            // timer1
            // 
            this.timer1.Interval = 3;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(50, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 150);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(600, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 150);
            this.panel2.TabIndex = 2;
            // 
            // pbPatterPhoto
            // 
            this.pbPatterPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPatterPhoto.Location = new System.Drawing.Point(0, 237);
            this.pbPatterPhoto.Name = "pbPatterPhoto";
            this.pbPatterPhoto.Size = new System.Drawing.Size(142, 213);
            this.pbPatterPhoto.TabIndex = 6;
            // 
            // lbBatterName
            // 
            this.lbBatterName.Font = new System.Drawing.Font("MicroFLF", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbBatterName.Location = new System.Drawing.Point(170, 276);
            this.lbBatterName.Name = "lbBatterName";
            this.lbBatterName.Size = new System.Drawing.Size(580, 51);
            this.lbBatterName.TabIndex = 7;
            this.lbBatterName.Text = "Home";
            this.lbBatterName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbBatterName.BackColorChanged += new System.EventHandler(this.BackColorChanging);
            // 
            // lbBatterHRNumber
            // 
            this.lbBatterHRNumber.Font = new System.Drawing.Font("MicroFLF", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbBatterHRNumber.Location = new System.Drawing.Point(171, 327);
            this.lbBatterHRNumber.Name = "lbBatterHRNumber";
            this.lbBatterHRNumber.Size = new System.Drawing.Size(579, 41);
            this.lbBatterHRNumber.TabIndex = 8;
            this.lbBatterHRNumber.Text = "Home";
            this.lbBatterHRNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbBatterHRNumber.BackColorChanged += new System.EventHandler(this.BackColorChanging);
            // 
            // timer2
            // 
            this.timer2.Interval = 3000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // lbBatterHRNumberInThisMatch
            // 
            this.lbBatterHRNumberInThisMatch.Font = new System.Drawing.Font("MicroFLF", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbBatterHRNumberInThisMatch.Location = new System.Drawing.Point(171, 368);
            this.lbBatterHRNumberInThisMatch.Name = "lbBatterHRNumberInThisMatch";
            this.lbBatterHRNumberInThisMatch.Size = new System.Drawing.Size(579, 41);
            this.lbBatterHRNumberInThisMatch.TabIndex = 9;
            this.lbBatterHRNumberInThisMatch.Text = "Home";
            this.lbBatterHRNumberInThisMatch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbBatterHRNumberInThisMatch.BackColorChanged += new System.EventHandler(this.BackColorChanging);
            // 
            // HomeRunCelebrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbBatterHRNumberInThisMatch);
            this.Controls.Add(this.lbBatterHRNumber);
            this.Controls.Add(this.lbBatterName);
            this.Controls.Add(this.pbPatterPhoto);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbHomeRunType);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HomeRunCelebrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomeRunCelebrationForm";
            this.DoubleClick += new System.EventHandler(this.HomeRunCelebrationForm_DoubleClick);
            this.ResumeLayout(false);

        }

        #endregion

        private Label lbHomeRunType;
        private Timer timer1;
        private Panel panel1;
        private Panel panel2;
        private Panel pbPatterPhoto;
        private Label lbBatterName;
        private Label lbBatterHRNumber;
        private Timer timer2;
        private Label lbBatterHRNumberInThisMatch;
    }
}