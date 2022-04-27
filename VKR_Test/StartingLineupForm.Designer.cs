
using System.ComponentModel;
using System.Windows.Forms;

namespace VKR_Test
{
    partial class StartingLineupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartingLineupForm));
            this.teamLogo = new System.Windows.Forms.Panel();
            this.lbTeamTitle = new System.Windows.Forms.Label();
            this.timer_LineupForm = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.teamManager = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.FirstPlayerInLineup = new VKR_Test.PlayerInfoWithPhoto();
            this.SecondPlayerInLineup = new VKR_Test.PlayerInfoWithPhoto();
            this.ThirdPlayerInLineup = new VKR_Test.PlayerInfoWithPhoto();
            this.ForthPlayerInLineup = new VKR_Test.PlayerInfoWithPhoto();
            this.FifthPlayerInLineup = new VKR_Test.PlayerInfoWithPhoto();
            this.SixthPlayerInLineup = new VKR_Test.PlayerInfoWithPhoto();
            this.SeventhPlayerInLineup = new VKR_Test.PlayerInfoWithPhoto();
            this.EighthPlayerInLineup = new VKR_Test.PlayerInfoWithPhoto();
            this.NinethPlayerInLineup = new VKR_Test.PlayerInfoWithPhoto();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // teamLogo
            // 
            this.teamLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.teamLogo.Location = new System.Drawing.Point(3, 3);
            this.teamLogo.Name = "teamLogo";
            this.teamLogo.Size = new System.Drawing.Size(106, 106);
            this.teamLogo.TabIndex = 52;
            // 
            // lbTeamTitle
            // 
            this.lbTeamTitle.Font = new System.Drawing.Font("MicroFLF", 25F, System.Drawing.FontStyle.Bold);
            this.lbTeamTitle.ForeColor = System.Drawing.Color.Black;
            this.lbTeamTitle.Location = new System.Drawing.Point(114, 3);
            this.lbTeamTitle.Name = "lbTeamTitle";
            this.lbTeamTitle.Size = new System.Drawing.Size(1083, 106);
            this.lbTeamTitle.TabIndex = 53;
            this.lbTeamTitle.Text = "label37";
            this.lbTeamTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer_LineupForm
            // 
            this.timer_LineupForm.Interval = 10;
            this.timer_LineupForm.Tick += new System.EventHandler(this.timer_LineupForm_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))));
            this.panel1.Controls.Add(this.teamLogo);
            this.panel1.Controls.Add(this.lbTeamTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 112);
            this.panel1.TabIndex = 54;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.teamManager);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 350);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1200, 30);
            this.panel2.TabIndex = 55;
            // 
            // teamManager
            // 
            this.teamManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teamManager.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamManager.ForeColor = System.Drawing.Color.Gold;
            this.teamManager.Location = new System.Drawing.Point(0, 0);
            this.teamManager.Name = "teamManager";
            this.teamManager.Size = new System.Drawing.Size(1200, 30);
            this.teamManager.TabIndex = 0;
            this.teamManager.Text = "label38";
            this.teamManager.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 4000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FirstPlayerInLineup
            // 
            this.FirstPlayerInLineup.Location = new System.Drawing.Point(32, 118);
            this.FirstPlayerInLineup.Name = "FirstPlayerInLineup";
            this.FirstPlayerInLineup.Size = new System.Drawing.Size(120, 229);
            this.FirstPlayerInLineup.TabIndex = 56;
            // 
            // SecondPlayerInLineup
            // 
            this.SecondPlayerInLineup.Location = new System.Drawing.Point(159, 118);
            this.SecondPlayerInLineup.Name = "SecondPlayerInLineup";
            this.SecondPlayerInLineup.Size = new System.Drawing.Size(120, 229);
            this.SecondPlayerInLineup.TabIndex = 57;
            // 
            // ThirdPlayerInLineup
            // 
            this.ThirdPlayerInLineup.Location = new System.Drawing.Point(286, 118);
            this.ThirdPlayerInLineup.Name = "ThirdPlayerInLineup";
            this.ThirdPlayerInLineup.Size = new System.Drawing.Size(120, 229);
            this.ThirdPlayerInLineup.TabIndex = 58;
            // 
            // ForthPlayerInLineup
            // 
            this.ForthPlayerInLineup.Location = new System.Drawing.Point(413, 118);
            this.ForthPlayerInLineup.Name = "ForthPlayerInLineup";
            this.ForthPlayerInLineup.Size = new System.Drawing.Size(120, 229);
            this.ForthPlayerInLineup.TabIndex = 59;
            // 
            // FifthPlayerInLineup
            // 
            this.FifthPlayerInLineup.Location = new System.Drawing.Point(540, 118);
            this.FifthPlayerInLineup.Name = "FifthPlayerInLineup";
            this.FifthPlayerInLineup.Size = new System.Drawing.Size(120, 229);
            this.FifthPlayerInLineup.TabIndex = 60;
            // 
            // SixthPlayerInLineup
            // 
            this.SixthPlayerInLineup.Location = new System.Drawing.Point(667, 118);
            this.SixthPlayerInLineup.Name = "SixthPlayerInLineup";
            this.SixthPlayerInLineup.Size = new System.Drawing.Size(120, 229);
            this.SixthPlayerInLineup.TabIndex = 61;
            // 
            // SeventhPlayerInLineup
            // 
            this.SeventhPlayerInLineup.Location = new System.Drawing.Point(794, 118);
            this.SeventhPlayerInLineup.Name = "SeventhPlayerInLineup";
            this.SeventhPlayerInLineup.Size = new System.Drawing.Size(120, 229);
            this.SeventhPlayerInLineup.TabIndex = 62;
            // 
            // EighthPlayerInLineup
            // 
            this.EighthPlayerInLineup.Location = new System.Drawing.Point(921, 118);
            this.EighthPlayerInLineup.Name = "EighthPlayerInLineup";
            this.EighthPlayerInLineup.Size = new System.Drawing.Size(120, 229);
            this.EighthPlayerInLineup.TabIndex = 63;
            // 
            // NinethPlayerInLineup
            // 
            this.NinethPlayerInLineup.Location = new System.Drawing.Point(1048, 118);
            this.NinethPlayerInLineup.Name = "NinethPlayerInLineup";
            this.NinethPlayerInLineup.Size = new System.Drawing.Size(120, 229);
            this.NinethPlayerInLineup.TabIndex = 64;
            // 
            // StartingLineupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1200, 380);
            this.Controls.Add(this.NinethPlayerInLineup);
            this.Controls.Add(this.EighthPlayerInLineup);
            this.Controls.Add(this.SeventhPlayerInLineup);
            this.Controls.Add(this.SixthPlayerInLineup);
            this.Controls.Add(this.FifthPlayerInLineup);
            this.Controls.Add(this.ForthPlayerInLineup);
            this.Controls.Add(this.ThirdPlayerInLineup);
            this.Controls.Add(this.SecondPlayerInLineup);
            this.Controls.Add(this.FirstPlayerInLineup);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartingLineupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartingLineupForm";
            this.BackColorChanged += new System.EventHandler(this.StartingLineupForm_BackColorChanged);
            this.DoubleClick += new System.EventHandler(this.StartingLineupForm_DoubleClick);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panel teamLogo;
        private Label lbTeamTitle;
        private Timer timer_LineupForm;
        private Panel panel1;
        private Panel panel2;
        private Label teamManager;
        private Timer timer1;
        private PlayerInfoWithPhoto FirstPlayerInLineup;
        private PlayerInfoWithPhoto SecondPlayerInLineup;
        private PlayerInfoWithPhoto ThirdPlayerInLineup;
        private PlayerInfoWithPhoto ForthPlayerInLineup;
        private PlayerInfoWithPhoto FifthPlayerInLineup;
        private PlayerInfoWithPhoto SixthPlayerInLineup;
        private PlayerInfoWithPhoto SeventhPlayerInLineup;
        private PlayerInfoWithPhoto EighthPlayerInLineup;
        private PlayerInfoWithPhoto NinethPlayerInLineup;
    }
}