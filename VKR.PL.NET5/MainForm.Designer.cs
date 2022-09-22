using System.ComponentModel;
using System.Windows.Forms;
using ProgressBar = ExtendedDotNET.Controls.Progress.ProgressBar;
using VKR.PL.Controls.NET5;

namespace VKR.PL.NET5
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label36;
            System.Windows.Forms.Panel panel27;
            System.Windows.Forms.Label label24;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.currentBatter = new VKR.PL.Controls.NET5.BatterInfo();
            this.pb_stamina = new ExtendedDotNET.Controls.Progress.ProgressBar();
            this.panelCurrentSituationPitcher = new System.Windows.Forms.Panel();
            this.lbPitcherSecondName = new System.Windows.Forms.Label();
            this.lbPitchCountForThisPitcher = new System.Windows.Forms.Label();
            this.btnNewPitch = new System.Windows.Forms.Button();
            this.panelSmallScoreBoard = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.HomeTeam_RunsScored = new System.Windows.Forms.Label();
            this.HomeTeam_Abbreviation = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.AwayTeam_RunsScored = new System.Windows.Forms.Label();
            this.AwayTeam_Abbreviation = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelCurrentSituation = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelCurrentBatter = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.batterOPSValue = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnChangeBatter = new System.Windows.Forms.Button();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblPlayerPosition = new System.Windows.Forms.Label();
            this.lblPlayerNumber = new System.Windows.Forms.Label();
            this.lbTodayStats = new System.Windows.Forms.Label();
            this.pbCurrentBatterPhoto = new System.Windows.Forms.Panel();
            this.pbCurrentOffenseLogo = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.away2 = new System.Windows.Forms.Label();
            this.away3 = new System.Windows.Forms.Label();
            this.away4 = new System.Windows.Forms.Label();
            this.away5 = new System.Windows.Forms.Label();
            this.away6 = new System.Windows.Forms.Label();
            this.away7 = new System.Windows.Forms.Label();
            this.away8 = new System.Windows.Forms.Label();
            this.away9 = new System.Windows.Forms.Label();
            this.away10 = new System.Windows.Forms.Label();
            this.home10 = new System.Windows.Forms.Label();
            this.home9 = new System.Windows.Forms.Label();
            this.home8 = new System.Windows.Forms.Label();
            this.home7 = new System.Windows.Forms.Label();
            this.home6 = new System.Windows.Forms.Label();
            this.home5 = new System.Windows.Forms.Label();
            this.home4 = new System.Windows.Forms.Label();
            this.home3 = new System.Windows.Forms.Label();
            this.home2 = new System.Windows.Forms.Label();
            this.awayRuns = new System.Windows.Forms.Label();
            this.homeRuns = new System.Windows.Forms.Label();
            this.awayHits = new System.Windows.Forms.Label();
            this.homeHits = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lb9thInning = new System.Windows.Forms.Label();
            this.lb8thInning = new System.Windows.Forms.Label();
            this.lb7thInning = new System.Windows.Forms.Label();
            this.lb6thInning = new System.Windows.Forms.Label();
            this.lb5thInning = new System.Windows.Forms.Label();
            this.lb4thInning = new System.Windows.Forms.Label();
            this.lb3rdInning = new System.Windows.Forms.Label();
            this.lb2ndInning = new System.Windows.Forms.Label();
            this.lb1stInning = new System.Windows.Forms.Label();
            this.panelScoreBoard = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.panelNextAwayBatters = new System.Windows.Forms.Panel();
            this.awayNextBatter3 = new VKR.PL.Controls.NET5.BatterInfo();
            this.awayNextBatter2 = new VKR.PL.Controls.NET5.BatterInfo();
            this.awayNextBatter1 = new VKR.PL.Controls.NET5.BatterInfo();
            this.AwayTeamNextBatters = new System.Windows.Forms.Panel();
            this.away_DueUP = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panelNextHomeBatters = new System.Windows.Forms.Panel();
            this.homeNextBatter3 = new VKR.PL.Controls.NET5.BatterInfo();
            this.homeNextBatter2 = new VKR.PL.Controls.NET5.BatterInfo();
            this.homeNextBatter1 = new VKR.PL.Controls.NET5.BatterInfo();
            this.homeTeamNextBatters = new System.Windows.Forms.Panel();
            this.home_DueUP = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.awayLOB = new System.Windows.Forms.Label();
            this.homeLOB = new System.Windows.Forms.Label();
            this.panelCurrentPitcher = new System.Windows.Forms.Panel();
            this.PitcherGS = new System.Windows.Forms.Label();
            this.labelGS = new System.Windows.Forms.Label();
            this.PitcherRecord = new System.Windows.Forms.Label();
            this.labelRecord = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.PitcherHomeRunsToday = new System.Windows.Forms.Label();
            this.PitcherStrikeoutsToday = new System.Windows.Forms.Label();
            this.PitcherWalksToday = new System.Windows.Forms.Label();
            this.PitcherIPToday = new System.Windows.Forms.Label();
            this.PitcherBAA = new System.Windows.Forms.Label();
            this.PitcherWHIP = new System.Windows.Forms.Label();
            this.PitcherHomeRuns = new System.Windows.Forms.Label();
            this.PitcherStrikeouts = new System.Windows.Forms.Label();
            this.PitcherWalks = new System.Windows.Forms.Label();
            this.PitcherIP = new System.Windows.Forms.Label();
            this.PitcherERA = new System.Windows.Forms.Label();
            this.PitcherGames = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.labelGames = new System.Windows.Forms.Label();
            this.PitchingTeamColor = new System.Windows.Forms.Panel();
            this.PitcherName = new System.Windows.Forms.Label();
            this.PitchingTeam = new System.Windows.Forms.Panel();
            this.PitcherPhoto = new System.Windows.Forms.Panel();
            this.panel2Base = new System.Windows.Forms.Panel();
            this.lb_Runner2_Name = new System.Windows.Forms.Label();
            this.panel31 = new System.Windows.Forms.Panel();
            this.lb2ndBase = new System.Windows.Forms.Label();
            this.RunnerOn2Photo = new System.Windows.Forms.Panel();
            this.panel1Base = new System.Windows.Forms.Panel();
            this.lb_Runner1_Name = new System.Windows.Forms.Label();
            this.panel33 = new System.Windows.Forms.Panel();
            this.lb1stBase = new System.Windows.Forms.Label();
            this.RunnerOn1Photo = new System.Windows.Forms.Panel();
            this.panel3Base = new System.Windows.Forms.Panel();
            this.lb_Runner3_Name = new System.Windows.Forms.Label();
            this.panel36 = new System.Windows.Forms.Panel();
            this.lb3rdBase = new System.Windows.Forms.Label();
            this.RunnerOn3Photo = new System.Windows.Forms.Panel();
            this.label32 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.btnBuntAttempt = new System.Windows.Forms.Button();
            this.btnStandings = new System.Windows.Forms.Button();
            this.btnShowAvailablePitchers = new System.Windows.Forms.Button();
            this.btnOtherResults = new System.Windows.Forms.Button();
            this.btnPlayerStats = new System.Windows.Forms.Button();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label27 = new System.Windows.Forms.Label();
            this.panelLastAtBat = new System.Windows.Forms.Panel();
            this.btnTeamStats = new System.Windows.Forms.Button();
            this.btnManualMode = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnAutoMode = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            label36 = new System.Windows.Forms.Label();
            panel27 = new System.Windows.Forms.Panel();
            label24 = new System.Windows.Forms.Label();
            panel27.SuspendLayout();
            this.panelCurrentSituationPitcher.SuspendLayout();
            this.panelSmallScoreBoard.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelCurrentSituation.SuspendLayout();
            this.panelCurrentBatter.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panelScoreBoard.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panelNextAwayBatters.SuspendLayout();
            this.AwayTeamNextBatters.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panelNextHomeBatters.SuspendLayout();
            this.homeTeamNextBatters.SuspendLayout();
            this.panelCurrentPitcher.SuspendLayout();
            this.PitchingTeamColor.SuspendLayout();
            this.panel2Base.SuspendLayout();
            this.panel31.SuspendLayout();
            this.panel1Base.SuspendLayout();
            this.panel33.SuspendLayout();
            this.panel3Base.SuspendLayout();
            this.panel36.SuspendLayout();
            this.panelLastAtBat.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label36
            // 
            label36.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            label36.Location = new System.Drawing.Point(179, 6);
            label36.Margin = new System.Windows.Forms.Padding(3, 5, 1, 5);
            label36.Name = "label36";
            label36.Size = new System.Drawing.Size(25, 20);
            label36.TabIndex = 1;
            label36.Text = "P:";
            label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel27
            // 
            panel27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            panel27.BackColor = System.Drawing.Color.Gray;
            panel27.Controls.Add(this.currentBatter);
            panel27.Controls.Add(this.pb_stamina);
            panel27.Controls.Add(this.panelCurrentSituationPitcher);
            panel27.Location = new System.Drawing.Point(1163, 846);
            panel27.Name = "panel27";
            panel27.Size = new System.Drawing.Size(250, 66);
            panel27.TabIndex = 47;
            // 
            // currentBatter
            // 
            this.currentBatter.Location = new System.Drawing.Point(0, 36);
            this.currentBatter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.currentBatter.Name = "currentBatter";
            this.currentBatter.Size = new System.Drawing.Size(250, 30);
            this.currentBatter.TabIndex = 68;
            // 
            // pb_stamina
            // 
            this.pb_stamina.BackColor = System.Drawing.Color.Gray;
            this.pb_stamina.BarOffset = 0;
            this.pb_stamina.Caption = "";
            this.pb_stamina.CaptionColor = System.Drawing.Color.Black;
            this.pb_stamina.CaptionMode = ExtendedDotNET.Controls.Progress.ProgressCaptionMode.None;
            this.pb_stamina.CaptionShadowColor = System.Drawing.Color.White;
            this.pb_stamina.ChangeByMouse = false;
            this.pb_stamina.DashSpace = 0;
            this.pb_stamina.DashWidth = 0;
            this.pb_stamina.Edge = ExtendedDotNET.Controls.Progress.ProgressBarEdge.Rectangle;
            this.pb_stamina.EdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.pb_stamina.EdgeLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.pb_stamina.EdgeWidth = 0;
            this.pb_stamina.FloodPercentage = 0F;
            this.pb_stamina.FloodStyle = ExtendedDotNET.Controls.Progress.ProgressFloodStyle.Standard;
            this.pb_stamina.Invert = false;
            this.pb_stamina.Location = new System.Drawing.Point(0, 28);
            this.pb_stamina.MainColor = System.Drawing.Color.Gainsboro;
            this.pb_stamina.Maximum = 250;
            this.pb_stamina.Minimum = 0;
            this.pb_stamina.Name = "pb_stamina";
            this.pb_stamina.Orientation = ExtendedDotNET.Controls.Progress.ProgressBarDirection.Horizontal;
            this.pb_stamina.ProgressBackColor = System.Drawing.Color.Gray;
            this.pb_stamina.ProgressBarStyle = ExtendedDotNET.Controls.Progress.ProgressStyle.Solid;
            this.pb_stamina.SecondColor = System.Drawing.Color.White;
            this.pb_stamina.Shadow = true;
            this.pb_stamina.ShadowOffset = 0;
            this.pb_stamina.Size = new System.Drawing.Size(250, 8);
            this.pb_stamina.Step = 0;
            this.pb_stamina.TabIndex = 65;
            this.pb_stamina.TabStop = false;
            this.pb_stamina.TextAntialias = true;
            this.pb_stamina.Value = 10;
            // 
            // panelCurrentSituationPitcher
            // 
            this.panelCurrentSituationPitcher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panelCurrentSituationPitcher.Controls.Add(this.lbPitcherSecondName);
            this.panelCurrentSituationPitcher.Controls.Add(label36);
            this.panelCurrentSituationPitcher.Controls.Add(this.lbPitchCountForThisPitcher);
            this.panelCurrentSituationPitcher.Location = new System.Drawing.Point(0, 0);
            this.panelCurrentSituationPitcher.Name = "panelCurrentSituationPitcher";
            this.panelCurrentSituationPitcher.Size = new System.Drawing.Size(250, 30);
            this.panelCurrentSituationPitcher.TabIndex = 46;
            // 
            // lbPitcherSecondName
            // 
            this.lbPitcherSecondName.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbPitcherSecondName.ForeColor = System.Drawing.Color.White;
            this.lbPitcherSecondName.Location = new System.Drawing.Point(28, 5);
            this.lbPitcherSecondName.Margin = new System.Windows.Forms.Padding(3, 5, 1, 5);
            this.lbPitcherSecondName.Name = "lbPitcherSecondName";
            this.lbPitcherSecondName.Size = new System.Drawing.Size(149, 20);
            this.lbPitcherSecondName.TabIndex = 3;
            this.lbPitcherSecondName.Text = "0";
            this.lbPitcherSecondName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbPitchCountForThisPitcher
            // 
            this.lbPitchCountForThisPitcher.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbPitchCountForThisPitcher.ForeColor = System.Drawing.Color.White;
            this.lbPitchCountForThisPitcher.Location = new System.Drawing.Point(178, 5);
            this.lbPitchCountForThisPitcher.Margin = new System.Windows.Forms.Padding(3, 5, 1, 5);
            this.lbPitchCountForThisPitcher.Name = "lbPitchCountForThisPitcher";
            this.lbPitchCountForThisPitcher.Size = new System.Drawing.Size(71, 20);
            this.lbPitchCountForThisPitcher.TabIndex = 4;
            this.lbPitchCountForThisPitcher.Text = "0";
            this.lbPitchCountForThisPitcher.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label24.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label24.Location = new System.Drawing.Point(1179, 144);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(234, 23);
            label24.TabIndex = 58;
            label24.Text = "CURRENT PITCHER";
            label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNewPitch
            // 
            this.btnNewPitch.BackColor = System.Drawing.Color.Gainsboro;
            this.btnNewPitch.FlatAppearance.BorderSize = 0;
            this.btnNewPitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewPitch.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNewPitch.Location = new System.Drawing.Point(82, 10);
            this.btnNewPitch.Name = "btnNewPitch";
            this.btnNewPitch.Size = new System.Drawing.Size(300, 35);
            this.btnNewPitch.TabIndex = 0;
            this.btnNewPitch.TabStop = false;
            this.btnNewPitch.Text = "NEXT PITCH";
            this.btnNewPitch.UseVisualStyleBackColor = false;
            this.btnNewPitch.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelSmallScoreBoard
            // 
            this.panelSmallScoreBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSmallScoreBoard.Controls.Add(this.panel5);
            this.panelSmallScoreBoard.Controls.Add(this.panel4);
            this.panelSmallScoreBoard.Controls.Add(this.panel3);
            this.panelSmallScoreBoard.Location = new System.Drawing.Point(1162, 920);
            this.panelSmallScoreBoard.Name = "panelSmallScoreBoard";
            this.panelSmallScoreBoard.Size = new System.Drawing.Size(250, 78);
            this.panelSmallScoreBoard.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(184)))), ((int)(((byte)(39)))));
            this.panel5.Controls.Add(this.HomeTeam_RunsScored);
            this.panel5.Controls.Add(this.HomeTeam_Abbreviation);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 39);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(160, 39);
            this.panel5.TabIndex = 4;
            // 
            // HomeTeam_RunsScored
            // 
            this.HomeTeam_RunsScored.Dock = System.Windows.Forms.DockStyle.Right;
            this.HomeTeam_RunsScored.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HomeTeam_RunsScored.ForeColor = System.Drawing.Color.White;
            this.HomeTeam_RunsScored.Location = new System.Drawing.Point(120, 0);
            this.HomeTeam_RunsScored.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.HomeTeam_RunsScored.Name = "HomeTeam_RunsScored";
            this.HomeTeam_RunsScored.Size = new System.Drawing.Size(40, 39);
            this.HomeTeam_RunsScored.TabIndex = 3;
            this.HomeTeam_RunsScored.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.HomeTeam_RunsScored.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            // 
            // HomeTeam_Abbreviation
            // 
            this.HomeTeam_Abbreviation.Dock = System.Windows.Forms.DockStyle.Left;
            this.HomeTeam_Abbreviation.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HomeTeam_Abbreviation.ForeColor = System.Drawing.Color.White;
            this.HomeTeam_Abbreviation.Location = new System.Drawing.Point(0, 0);
            this.HomeTeam_Abbreviation.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.HomeTeam_Abbreviation.Name = "HomeTeam_Abbreviation";
            this.HomeTeam_Abbreviation.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.HomeTeam_Abbreviation.Size = new System.Drawing.Size(121, 39);
            this.HomeTeam_Abbreviation.TabIndex = 1;
            this.HomeTeam_Abbreviation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HomeTeam_Abbreviation.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
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
            // AwayTeam_RunsScored
            // 
            this.AwayTeam_RunsScored.Dock = System.Windows.Forms.DockStyle.Right;
            this.AwayTeam_RunsScored.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AwayTeam_RunsScored.ForeColor = System.Drawing.Color.White;
            this.AwayTeam_RunsScored.Location = new System.Drawing.Point(120, 0);
            this.AwayTeam_RunsScored.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.AwayTeam_RunsScored.Name = "AwayTeam_RunsScored";
            this.AwayTeam_RunsScored.Size = new System.Drawing.Size(40, 39);
            this.AwayTeam_RunsScored.TabIndex = 2;
            this.AwayTeam_RunsScored.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AwayTeam_RunsScored.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            // 
            // AwayTeam_Abbreviation
            // 
            this.AwayTeam_Abbreviation.Dock = System.Windows.Forms.DockStyle.Left;
            this.AwayTeam_Abbreviation.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AwayTeam_Abbreviation.ForeColor = System.Drawing.Color.White;
            this.AwayTeam_Abbreviation.Location = new System.Drawing.Point(0, 0);
            this.AwayTeam_Abbreviation.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.AwayTeam_Abbreviation.Name = "AwayTeam_Abbreviation";
            this.AwayTeam_Abbreviation.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.AwayTeam_Abbreviation.Size = new System.Drawing.Size(121, 39);
            this.AwayTeam_Abbreviation.TabIndex = 0;
            this.AwayTeam_Abbreviation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AwayTeam_Abbreviation.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.BackgroundImage = global::VKR.PL.NET5.Properties.Resources._000;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(160, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(90, 78);
            this.panel3.TabIndex = 2;
            // 
            // panelCurrentSituation
            // 
            this.panelCurrentSituation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCurrentSituation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panelCurrentSituation.Controls.Add(this.label5);
            this.panelCurrentSituation.Controls.Add(this.label4);
            this.panelCurrentSituation.Controls.Add(this.label3);
            this.panelCurrentSituation.Controls.Add(this.label2);
            this.panelCurrentSituation.Controls.Add(this.label1);
            this.panelCurrentSituation.Location = new System.Drawing.Point(1161, 999);
            this.panelCurrentSituation.Name = "panelCurrentSituation";
            this.panelCurrentSituation.Size = new System.Drawing.Size(250, 30);
            this.panelCurrentSituation.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(189, 6);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "0-0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label4.Location = new System.Drawing.Point(105, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 5, 1, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Out";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(83, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 1, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(37, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 1, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label1.Location = new System.Drawing.Point(15, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(15, 5, 1, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "▲";
            // 
            // panelCurrentBatter
            // 
            this.panelCurrentBatter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCurrentBatter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panelCurrentBatter.Controls.Add(this.label14);
            this.panelCurrentBatter.Controls.Add(this.label15);
            this.panelCurrentBatter.Controls.Add(this.label12);
            this.panelCurrentBatter.Controls.Add(this.label13);
            this.panelCurrentBatter.Controls.Add(this.label16);
            this.panelCurrentBatter.Controls.Add(this.batterOPSValue);
            this.panelCurrentBatter.Controls.Add(this.label10);
            this.panelCurrentBatter.Controls.Add(this.label11);
            this.panelCurrentBatter.Controls.Add(this.label8);
            this.panelCurrentBatter.Controls.Add(this.label9);
            this.panelCurrentBatter.Controls.Add(this.label7);
            this.panelCurrentBatter.Controls.Add(this.label6);
            this.panelCurrentBatter.Controls.Add(this.panel8);
            this.panelCurrentBatter.Location = new System.Drawing.Point(198, 889);
            this.panelCurrentBatter.Name = "panelCurrentBatter";
            this.panelCurrentBatter.Size = new System.Drawing.Size(903, 110);
            this.panelCurrentBatter.TabIndex = 3;
            this.panelCurrentBatter.VisibleChanged += new System.EventHandler(this.panel6_VisibleChanged);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("MicroFLF", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label14.Location = new System.Drawing.Point(543, 67);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 42);
            this.label14.TabIndex = 21;
            this.label14.Text = "R";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("MicroFLF", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(470, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 57);
            this.label15.TabIndex = 20;
            this.label15.Text = "999";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("MicroFLF", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label12.Location = new System.Drawing.Point(428, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 42);
            this.label12.TabIndex = 19;
            this.label12.Text = "SB";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("MicroFLF", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(374, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 57);
            this.label13.TabIndex = 18;
            this.label13.Text = "99";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("MicroFLF", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label16.Location = new System.Drawing.Point(668, 67);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 42);
            this.label16.TabIndex = 17;
            this.label16.Text = "OPS";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // batterOPSValue
            // 
            this.batterOPSValue.Font = new System.Drawing.Font("MicroFLF", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.batterOPSValue.ForeColor = System.Drawing.Color.White;
            this.batterOPSValue.Location = new System.Drawing.Point(575, 52);
            this.batterOPSValue.Name = "batterOPSValue";
            this.batterOPSValue.Size = new System.Drawing.Size(100, 57);
            this.batterOPSValue.TabIndex = 16;
            this.batterOPSValue.Text = "1.000";
            this.batterOPSValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("MicroFLF", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label10.Location = new System.Drawing.Point(326, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 42);
            this.label10.TabIndex = 11;
            this.label10.Text = "RBI";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("MicroFLF", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(253, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 57);
            this.label11.TabIndex = 10;
            this.label11.Text = "999";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("MicroFLF", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label8.Location = new System.Drawing.Point(211, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 42);
            this.label8.TabIndex = 9;
            this.label8.Text = "HR";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("MicroFLF", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(157, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 57);
            this.label9.TabIndex = 8;
            this.label9.Text = "99";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("MicroFLF", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label7.Location = new System.Drawing.Point(98, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 42);
            this.label7.TabIndex = 7;
            this.label7.Text = "AVG";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("MicroFLF", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(5, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 57);
            this.label6.TabIndex = 6;
            this.label6.Text = "1.000";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnChangeBatter);
            this.panel8.Controls.Add(this.lblPlayerName);
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(903, 36);
            this.panel8.TabIndex = 4;
            // 
            // btnChangeBatter
            // 
            this.btnChangeBatter.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnChangeBatter.FlatAppearance.BorderSize = 0;
            this.btnChangeBatter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeBatter.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnChangeBatter.ForeColor = System.Drawing.Color.White;
            this.btnChangeBatter.Location = new System.Drawing.Point(795, 0);
            this.btnChangeBatter.Name = "btnChangeBatter";
            this.btnChangeBatter.Size = new System.Drawing.Size(108, 36);
            this.btnChangeBatter.TabIndex = 61;
            this.btnChangeBatter.Text = "CHANGE";
            this.btnChangeBatter.UseVisualStyleBackColor = true;
            this.btnChangeBatter.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            this.btnChangeBatter.Click += new System.EventHandler(this.btnChangeBatter_Click);
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.Font = new System.Drawing.Font("MicroFLF", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPlayerName.ForeColor = System.Drawing.Color.White;
            this.lblPlayerName.Location = new System.Drawing.Point(98, 3);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(507, 30);
            this.lblPlayerName.TabIndex = 2;
            this.lblPlayerName.Text = "00";
            this.lblPlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPlayerName.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.lblPlayerPosition);
            this.panel9.Controls.Add(this.lblPlayerNumber);
            this.panel9.ForeColor = System.Drawing.Color.White;
            this.panel9.Location = new System.Drawing.Point(3, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(89, 30);
            this.panel9.TabIndex = 0;
            this.panel9.Paint += new System.Windows.Forms.PaintEventHandler(this.panel9_Paint);
            // 
            // lblPlayerPosition
            // 
            this.lblPlayerPosition.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPlayerPosition.ForeColor = System.Drawing.Color.White;
            this.lblPlayerPosition.Location = new System.Drawing.Point(45, 3);
            this.lblPlayerPosition.Name = "lblPlayerPosition";
            this.lblPlayerPosition.Size = new System.Drawing.Size(36, 24);
            this.lblPlayerPosition.TabIndex = 1;
            this.lblPlayerPosition.Text = "00";
            this.lblPlayerPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPlayerPosition.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            // 
            // lblPlayerNumber
            // 
            this.lblPlayerNumber.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPlayerNumber.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblPlayerNumber.Location = new System.Drawing.Point(3, 3);
            this.lblPlayerNumber.Name = "lblPlayerNumber";
            this.lblPlayerNumber.Size = new System.Drawing.Size(36, 24);
            this.lblPlayerNumber.TabIndex = 0;
            this.lblPlayerNumber.Text = "00";
            this.lblPlayerNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPlayerNumber.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            // 
            // lbTodayStats
            // 
            this.lbTodayStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTodayStats.BackColor = System.Drawing.Color.Black;
            this.lbTodayStats.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbTodayStats.ForeColor = System.Drawing.Color.Gold;
            this.lbTodayStats.Location = new System.Drawing.Point(88, 999);
            this.lbTodayStats.Name = "lbTodayStats";
            this.lbTodayStats.Size = new System.Drawing.Size(1013, 30);
            this.lbTodayStats.TabIndex = 22;
            this.lbTodayStats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbCurrentBatterPhoto
            // 
            this.pbCurrentBatterPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbCurrentBatterPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCurrentBatterPhoto.Location = new System.Drawing.Point(201, 755);
            this.pbCurrentBatterPhoto.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pbCurrentBatterPhoto.Name = "pbCurrentBatterPhoto";
            this.pbCurrentBatterPhoto.Size = new System.Drawing.Size(89, 134);
            this.pbCurrentBatterPhoto.TabIndex = 5;
            // 
            // pbCurrentOffenseLogo
            // 
            this.pbCurrentOffenseLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbCurrentOffenseLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCurrentOffenseLogo.Location = new System.Drawing.Point(88, 889);
            this.pbCurrentOffenseLogo.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.pbCurrentOffenseLogo.Name = "pbCurrentOffenseLogo";
            this.pbCurrentOffenseLogo.Size = new System.Drawing.Size(110, 110);
            this.pbCurrentOffenseLogo.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.BackColor = System.Drawing.Color.Gainsboro;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(103, 53);
            this.label18.Margin = new System.Windows.Forms.Padding(6, 5, 0, 1);
            this.label18.MaximumSize = new System.Drawing.Size(287, 39);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(287, 39);
            this.label18.TabIndex = 4;
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label18.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Gainsboro;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(103, 94);
            this.label19.Margin = new System.Windows.Forms.Padding(6, 1, 6, 5);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(287, 39);
            this.label19.TabIndex = 5;
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label19.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            // 
            // panel11
            // 
            this.panel11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel11.Location = new System.Drawing.Point(64, 53);
            this.panel11.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(39, 39);
            this.panel11.TabIndex = 6;
            // 
            // panel12
            // 
            this.panel12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel12.Location = new System.Drawing.Point(64, 94);
            this.panel12.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(39, 39);
            this.panel12.TabIndex = 7;
            // 
            // away2
            // 
            this.away2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.away2.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.away2.ForeColor = System.Drawing.Color.White;
            this.away2.Location = new System.Drawing.Point(390, 53);
            this.away2.Margin = new System.Windows.Forms.Padding(0);
            this.away2.Name = "away2";
            this.away2.Size = new System.Drawing.Size(45, 39);
            this.away2.TabIndex = 9;
            this.away2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // away3
            // 
            this.away3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.away3.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.away3.ForeColor = System.Drawing.Color.White;
            this.away3.Location = new System.Drawing.Point(435, 53);
            this.away3.Margin = new System.Windows.Forms.Padding(0);
            this.away3.Name = "away3";
            this.away3.Size = new System.Drawing.Size(45, 39);
            this.away3.TabIndex = 10;
            this.away3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // away4
            // 
            this.away4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.away4.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.away4.ForeColor = System.Drawing.Color.White;
            this.away4.Location = new System.Drawing.Point(480, 53);
            this.away4.Margin = new System.Windows.Forms.Padding(0);
            this.away4.Name = "away4";
            this.away4.Size = new System.Drawing.Size(45, 39);
            this.away4.TabIndex = 11;
            this.away4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // away5
            // 
            this.away5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.away5.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.away5.ForeColor = System.Drawing.Color.White;
            this.away5.Location = new System.Drawing.Point(525, 53);
            this.away5.Margin = new System.Windows.Forms.Padding(0);
            this.away5.Name = "away5";
            this.away5.Size = new System.Drawing.Size(45, 39);
            this.away5.TabIndex = 12;
            this.away5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // away6
            // 
            this.away6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.away6.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.away6.ForeColor = System.Drawing.Color.White;
            this.away6.Location = new System.Drawing.Point(570, 53);
            this.away6.Margin = new System.Windows.Forms.Padding(0);
            this.away6.Name = "away6";
            this.away6.Size = new System.Drawing.Size(45, 39);
            this.away6.TabIndex = 13;
            this.away6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // away7
            // 
            this.away7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.away7.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.away7.ForeColor = System.Drawing.Color.White;
            this.away7.Location = new System.Drawing.Point(615, 53);
            this.away7.Margin = new System.Windows.Forms.Padding(0);
            this.away7.Name = "away7";
            this.away7.Size = new System.Drawing.Size(45, 39);
            this.away7.TabIndex = 14;
            this.away7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // away8
            // 
            this.away8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.away8.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.away8.ForeColor = System.Drawing.Color.White;
            this.away8.Location = new System.Drawing.Point(660, 53);
            this.away8.Margin = new System.Windows.Forms.Padding(0);
            this.away8.Name = "away8";
            this.away8.Size = new System.Drawing.Size(45, 39);
            this.away8.TabIndex = 15;
            this.away8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // away9
            // 
            this.away9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.away9.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.away9.ForeColor = System.Drawing.Color.White;
            this.away9.Location = new System.Drawing.Point(705, 53);
            this.away9.Margin = new System.Windows.Forms.Padding(0);
            this.away9.Name = "away9";
            this.away9.Size = new System.Drawing.Size(45, 39);
            this.away9.TabIndex = 16;
            this.away9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // away10
            // 
            this.away10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.away10.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.away10.ForeColor = System.Drawing.Color.White;
            this.away10.Location = new System.Drawing.Point(750, 53);
            this.away10.Margin = new System.Windows.Forms.Padding(0);
            this.away10.Name = "away10";
            this.away10.Size = new System.Drawing.Size(45, 39);
            this.away10.TabIndex = 17;
            this.away10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // home10
            // 
            this.home10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.home10.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.home10.ForeColor = System.Drawing.Color.White;
            this.home10.Location = new System.Drawing.Point(750, 94);
            this.home10.Margin = new System.Windows.Forms.Padding(0);
            this.home10.Name = "home10";
            this.home10.Size = new System.Drawing.Size(45, 39);
            this.home10.TabIndex = 27;
            this.home10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // home9
            // 
            this.home9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.home9.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.home9.ForeColor = System.Drawing.Color.White;
            this.home9.Location = new System.Drawing.Point(705, 94);
            this.home9.Margin = new System.Windows.Forms.Padding(0);
            this.home9.Name = "home9";
            this.home9.Size = new System.Drawing.Size(45, 39);
            this.home9.TabIndex = 26;
            this.home9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // home8
            // 
            this.home8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.home8.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.home8.ForeColor = System.Drawing.Color.White;
            this.home8.Location = new System.Drawing.Point(660, 94);
            this.home8.Margin = new System.Windows.Forms.Padding(0);
            this.home8.Name = "home8";
            this.home8.Size = new System.Drawing.Size(45, 39);
            this.home8.TabIndex = 25;
            this.home8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // home7
            // 
            this.home7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.home7.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.home7.ForeColor = System.Drawing.Color.White;
            this.home7.Location = new System.Drawing.Point(615, 94);
            this.home7.Margin = new System.Windows.Forms.Padding(0);
            this.home7.Name = "home7";
            this.home7.Size = new System.Drawing.Size(45, 39);
            this.home7.TabIndex = 24;
            this.home7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // home6
            // 
            this.home6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.home6.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.home6.ForeColor = System.Drawing.Color.White;
            this.home6.Location = new System.Drawing.Point(570, 94);
            this.home6.Margin = new System.Windows.Forms.Padding(0);
            this.home6.Name = "home6";
            this.home6.Size = new System.Drawing.Size(45, 39);
            this.home6.TabIndex = 23;
            this.home6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // home5
            // 
            this.home5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.home5.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.home5.ForeColor = System.Drawing.Color.White;
            this.home5.Location = new System.Drawing.Point(525, 94);
            this.home5.Margin = new System.Windows.Forms.Padding(0);
            this.home5.Name = "home5";
            this.home5.Size = new System.Drawing.Size(45, 39);
            this.home5.TabIndex = 22;
            this.home5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // home4
            // 
            this.home4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.home4.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.home4.ForeColor = System.Drawing.Color.White;
            this.home4.Location = new System.Drawing.Point(480, 94);
            this.home4.Margin = new System.Windows.Forms.Padding(0);
            this.home4.Name = "home4";
            this.home4.Size = new System.Drawing.Size(45, 39);
            this.home4.TabIndex = 21;
            this.home4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // home3
            // 
            this.home3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.home3.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.home3.ForeColor = System.Drawing.Color.White;
            this.home3.Location = new System.Drawing.Point(435, 94);
            this.home3.Margin = new System.Windows.Forms.Padding(0);
            this.home3.Name = "home3";
            this.home3.Size = new System.Drawing.Size(45, 39);
            this.home3.TabIndex = 20;
            this.home3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // home2
            // 
            this.home2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.home2.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.home2.ForeColor = System.Drawing.Color.White;
            this.home2.Location = new System.Drawing.Point(390, 94);
            this.home2.Margin = new System.Windows.Forms.Padding(0);
            this.home2.Name = "home2";
            this.home2.Size = new System.Drawing.Size(45, 39);
            this.home2.TabIndex = 19;
            this.home2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // awayRuns
            // 
            this.awayRuns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.awayRuns.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.awayRuns.ForeColor = System.Drawing.Color.White;
            this.awayRuns.Location = new System.Drawing.Point(797, 53);
            this.awayRuns.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.awayRuns.Name = "awayRuns";
            this.awayRuns.Size = new System.Drawing.Size(45, 39);
            this.awayRuns.TabIndex = 28;
            this.awayRuns.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // homeRuns
            // 
            this.homeRuns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.homeRuns.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.homeRuns.ForeColor = System.Drawing.Color.White;
            this.homeRuns.Location = new System.Drawing.Point(797, 94);
            this.homeRuns.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.homeRuns.Name = "homeRuns";
            this.homeRuns.Size = new System.Drawing.Size(45, 39);
            this.homeRuns.TabIndex = 29;
            this.homeRuns.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // awayHits
            // 
            this.awayHits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.awayHits.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.awayHits.ForeColor = System.Drawing.Color.White;
            this.awayHits.Location = new System.Drawing.Point(842, 53);
            this.awayHits.Margin = new System.Windows.Forms.Padding(0);
            this.awayHits.Name = "awayHits";
            this.awayHits.Size = new System.Drawing.Size(45, 39);
            this.awayHits.TabIndex = 30;
            this.awayHits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // homeHits
            // 
            this.homeHits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.homeHits.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.homeHits.ForeColor = System.Drawing.Color.White;
            this.homeHits.Location = new System.Drawing.Point(842, 94);
            this.homeHits.Margin = new System.Windows.Forms.Padding(0);
            this.homeHits.Name = "homeHits";
            this.homeHits.Size = new System.Drawing.Size(45, 39);
            this.homeHits.TabIndex = 31;
            this.homeHits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label20.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(842, 9);
            this.label20.Margin = new System.Windows.Forms.Padding(0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(45, 39);
            this.label20.TabIndex = 43;
            this.label20.Text = "H";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label21.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(797, 9);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(45, 39);
            this.label21.TabIndex = 42;
            this.label21.Text = "R";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb9thInning
            // 
            this.lb9thInning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lb9thInning.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb9thInning.ForeColor = System.Drawing.Color.White;
            this.lb9thInning.Location = new System.Drawing.Point(750, 9);
            this.lb9thInning.Margin = new System.Windows.Forms.Padding(0);
            this.lb9thInning.Name = "lb9thInning";
            this.lb9thInning.Size = new System.Drawing.Size(45, 39);
            this.lb9thInning.TabIndex = 41;
            this.lb9thInning.Text = "10";
            this.lb9thInning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb8thInning
            // 
            this.lb8thInning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lb8thInning.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb8thInning.ForeColor = System.Drawing.Color.White;
            this.lb8thInning.Location = new System.Drawing.Point(705, 9);
            this.lb8thInning.Margin = new System.Windows.Forms.Padding(0);
            this.lb8thInning.Name = "lb8thInning";
            this.lb8thInning.Size = new System.Drawing.Size(45, 39);
            this.lb8thInning.TabIndex = 40;
            this.lb8thInning.Text = "9";
            this.lb8thInning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb7thInning
            // 
            this.lb7thInning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lb7thInning.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb7thInning.ForeColor = System.Drawing.Color.White;
            this.lb7thInning.Location = new System.Drawing.Point(660, 9);
            this.lb7thInning.Margin = new System.Windows.Forms.Padding(0);
            this.lb7thInning.Name = "lb7thInning";
            this.lb7thInning.Size = new System.Drawing.Size(45, 39);
            this.lb7thInning.TabIndex = 39;
            this.lb7thInning.Text = "8";
            this.lb7thInning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb6thInning
            // 
            this.lb6thInning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lb6thInning.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb6thInning.ForeColor = System.Drawing.Color.White;
            this.lb6thInning.Location = new System.Drawing.Point(615, 9);
            this.lb6thInning.Margin = new System.Windows.Forms.Padding(0);
            this.lb6thInning.Name = "lb6thInning";
            this.lb6thInning.Size = new System.Drawing.Size(45, 39);
            this.lb6thInning.TabIndex = 38;
            this.lb6thInning.Text = "7";
            this.lb6thInning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb5thInning
            // 
            this.lb5thInning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lb5thInning.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb5thInning.ForeColor = System.Drawing.Color.White;
            this.lb5thInning.Location = new System.Drawing.Point(570, 9);
            this.lb5thInning.Margin = new System.Windows.Forms.Padding(0);
            this.lb5thInning.Name = "lb5thInning";
            this.lb5thInning.Size = new System.Drawing.Size(45, 39);
            this.lb5thInning.TabIndex = 37;
            this.lb5thInning.Text = "6";
            this.lb5thInning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb4thInning
            // 
            this.lb4thInning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lb4thInning.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb4thInning.ForeColor = System.Drawing.Color.White;
            this.lb4thInning.Location = new System.Drawing.Point(525, 9);
            this.lb4thInning.Margin = new System.Windows.Forms.Padding(0);
            this.lb4thInning.Name = "lb4thInning";
            this.lb4thInning.Size = new System.Drawing.Size(45, 39);
            this.lb4thInning.TabIndex = 36;
            this.lb4thInning.Text = "5";
            this.lb4thInning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb3rdInning
            // 
            this.lb3rdInning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lb3rdInning.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb3rdInning.ForeColor = System.Drawing.Color.White;
            this.lb3rdInning.Location = new System.Drawing.Point(480, 9);
            this.lb3rdInning.Margin = new System.Windows.Forms.Padding(0);
            this.lb3rdInning.Name = "lb3rdInning";
            this.lb3rdInning.Size = new System.Drawing.Size(45, 39);
            this.lb3rdInning.TabIndex = 35;
            this.lb3rdInning.Text = "4";
            this.lb3rdInning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb2ndInning
            // 
            this.lb2ndInning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lb2ndInning.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb2ndInning.ForeColor = System.Drawing.Color.White;
            this.lb2ndInning.Location = new System.Drawing.Point(435, 9);
            this.lb2ndInning.Margin = new System.Windows.Forms.Padding(0);
            this.lb2ndInning.Name = "lb2ndInning";
            this.lb2ndInning.Size = new System.Drawing.Size(45, 39);
            this.lb2ndInning.TabIndex = 34;
            this.lb2ndInning.Text = "3";
            this.lb2ndInning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb1stInning
            // 
            this.lb1stInning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lb1stInning.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb1stInning.ForeColor = System.Drawing.Color.White;
            this.lb1stInning.Location = new System.Drawing.Point(390, 9);
            this.lb1stInning.Margin = new System.Windows.Forms.Padding(0);
            this.lb1stInning.Name = "lb1stInning";
            this.lb1stInning.Size = new System.Drawing.Size(45, 39);
            this.lb1stInning.TabIndex = 33;
            this.lb1stInning.Text = "2";
            this.lb1stInning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelScoreBoard
            // 
            this.panelScoreBoard.Controls.Add(this.panel18);
            this.panelScoreBoard.Controls.Add(this.panel16);
            this.panelScoreBoard.Controls.Add(this.label23);
            this.panelScoreBoard.Controls.Add(this.label22);
            this.panelScoreBoard.Controls.Add(this.label18);
            this.panelScoreBoard.Controls.Add(this.label20);
            this.panelScoreBoard.Controls.Add(this.label19);
            this.panelScoreBoard.Controls.Add(this.label21);
            this.panelScoreBoard.Controls.Add(this.panel11);
            this.panelScoreBoard.Controls.Add(this.lb9thInning);
            this.panelScoreBoard.Controls.Add(this.panel12);
            this.panelScoreBoard.Controls.Add(this.lb8thInning);
            this.panelScoreBoard.Controls.Add(this.lb7thInning);
            this.panelScoreBoard.Controls.Add(this.away2);
            this.panelScoreBoard.Controls.Add(this.lb6thInning);
            this.panelScoreBoard.Controls.Add(this.away3);
            this.panelScoreBoard.Controls.Add(this.lb5thInning);
            this.panelScoreBoard.Controls.Add(this.away4);
            this.panelScoreBoard.Controls.Add(this.lb4thInning);
            this.panelScoreBoard.Controls.Add(this.away5);
            this.panelScoreBoard.Controls.Add(this.lb3rdInning);
            this.panelScoreBoard.Controls.Add(this.away6);
            this.panelScoreBoard.Controls.Add(this.lb2ndInning);
            this.panelScoreBoard.Controls.Add(this.away7);
            this.panelScoreBoard.Controls.Add(this.lb1stInning);
            this.panelScoreBoard.Controls.Add(this.away8);
            this.panelScoreBoard.Controls.Add(this.away9);
            this.panelScoreBoard.Controls.Add(this.homeHits);
            this.panelScoreBoard.Controls.Add(this.away10);
            this.panelScoreBoard.Controls.Add(this.awayHits);
            this.panelScoreBoard.Controls.Add(this.homeRuns);
            this.panelScoreBoard.Controls.Add(this.home2);
            this.panelScoreBoard.Controls.Add(this.awayRuns);
            this.panelScoreBoard.Controls.Add(this.home3);
            this.panelScoreBoard.Controls.Add(this.home10);
            this.panelScoreBoard.Controls.Add(this.home4);
            this.panelScoreBoard.Controls.Add(this.home9);
            this.panelScoreBoard.Controls.Add(this.home5);
            this.panelScoreBoard.Controls.Add(this.home8);
            this.panelScoreBoard.Controls.Add(this.home6);
            this.panelScoreBoard.Controls.Add(this.home7);
            this.panelScoreBoard.Controls.Add(this.label28);
            this.panelScoreBoard.Controls.Add(this.awayLOB);
            this.panelScoreBoard.Controls.Add(this.homeLOB);
            this.panelScoreBoard.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelScoreBoard.Location = new System.Drawing.Point(0, 0);
            this.panelScoreBoard.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.panelScoreBoard.Name = "panelScoreBoard";
            this.panelScoreBoard.Size = new System.Drawing.Size(1423, 138);
            this.panelScoreBoard.TabIndex = 45;
            // 
            // panel18
            // 
            this.panel18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel18.Controls.Add(this.panelNextAwayBatters);
            this.panel18.Controls.Add(this.AwayTeamNextBatters);
            this.panel18.Location = new System.Drawing.Point(920, 0);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(250, 138);
            this.panel18.TabIndex = 1;
            // 
            // panelNextAwayBatters
            // 
            this.panelNextAwayBatters.BackColor = System.Drawing.Color.White;
            this.panelNextAwayBatters.Controls.Add(this.awayNextBatter3);
            this.panelNextAwayBatters.Controls.Add(this.awayNextBatter2);
            this.panelNextAwayBatters.Controls.Add(this.awayNextBatter1);
            this.panelNextAwayBatters.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelNextAwayBatters.ForeColor = System.Drawing.Color.White;
            this.panelNextAwayBatters.Location = new System.Drawing.Point(0, 33);
            this.panelNextAwayBatters.Name = "panelNextAwayBatters";
            this.panelNextAwayBatters.Size = new System.Drawing.Size(250, 105);
            this.panelNextAwayBatters.TabIndex = 1;
            // 
            // awayNextBatter3
            // 
            this.awayNextBatter3.Location = new System.Drawing.Point(0, 62);
            this.awayNextBatter3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.awayNextBatter3.Name = "awayNextBatter3";
            this.awayNextBatter3.Size = new System.Drawing.Size(250, 30);
            this.awayNextBatter3.TabIndex = 50;
            // 
            // awayNextBatter2
            // 
            this.awayNextBatter2.Location = new System.Drawing.Point(0, 31);
            this.awayNextBatter2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.awayNextBatter2.Name = "awayNextBatter2";
            this.awayNextBatter2.Size = new System.Drawing.Size(250, 30);
            this.awayNextBatter2.TabIndex = 49;
            // 
            // awayNextBatter1
            // 
            this.awayNextBatter1.Location = new System.Drawing.Point(0, 0);
            this.awayNextBatter1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.awayNextBatter1.Name = "awayNextBatter1";
            this.awayNextBatter1.Size = new System.Drawing.Size(250, 30);
            this.awayNextBatter1.TabIndex = 48;
            // 
            // AwayTeamNextBatters
            // 
            this.AwayTeamNextBatters.Controls.Add(this.away_DueUP);
            this.AwayTeamNextBatters.Dock = System.Windows.Forms.DockStyle.Top;
            this.AwayTeamNextBatters.Location = new System.Drawing.Point(0, 0);
            this.AwayTeamNextBatters.Name = "AwayTeamNextBatters";
            this.AwayTeamNextBatters.Size = new System.Drawing.Size(250, 30);
            this.AwayTeamNextBatters.TabIndex = 0;
            // 
            // away_DueUP
            // 
            this.away_DueUP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.away_DueUP.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.away_DueUP.ForeColor = System.Drawing.Color.White;
            this.away_DueUP.Location = new System.Drawing.Point(0, 0);
            this.away_DueUP.Name = "away_DueUP";
            this.away_DueUP.Size = new System.Drawing.Size(250, 30);
            this.away_DueUP.TabIndex = 0;
            this.away_DueUP.Text = "label32";
            this.away_DueUP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.away_DueUP.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            // 
            // panel16
            // 
            this.panel16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel16.Controls.Add(this.panelNextHomeBatters);
            this.panel16.Controls.Add(this.homeTeamNextBatters);
            this.panel16.Location = new System.Drawing.Point(1173, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(250, 138);
            this.panel16.TabIndex = 0;
            // 
            // panelNextHomeBatters
            // 
            this.panelNextHomeBatters.BackColor = System.Drawing.Color.White;
            this.panelNextHomeBatters.Controls.Add(this.homeNextBatter3);
            this.panelNextHomeBatters.Controls.Add(this.homeNextBatter2);
            this.panelNextHomeBatters.Controls.Add(this.homeNextBatter1);
            this.panelNextHomeBatters.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelNextHomeBatters.ForeColor = System.Drawing.Color.White;
            this.panelNextHomeBatters.Location = new System.Drawing.Point(0, 33);
            this.panelNextHomeBatters.Name = "panelNextHomeBatters";
            this.panelNextHomeBatters.Size = new System.Drawing.Size(250, 105);
            this.panelNextHomeBatters.TabIndex = 2;
            // 
            // homeNextBatter3
            // 
            this.homeNextBatter3.Location = new System.Drawing.Point(0, 62);
            this.homeNextBatter3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.homeNextBatter3.Name = "homeNextBatter3";
            this.homeNextBatter3.Size = new System.Drawing.Size(250, 30);
            this.homeNextBatter3.TabIndex = 51;
            // 
            // homeNextBatter2
            // 
            this.homeNextBatter2.Location = new System.Drawing.Point(0, 31);
            this.homeNextBatter2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.homeNextBatter2.Name = "homeNextBatter2";
            this.homeNextBatter2.Size = new System.Drawing.Size(250, 30);
            this.homeNextBatter2.TabIndex = 50;
            // 
            // homeNextBatter1
            // 
            this.homeNextBatter1.Location = new System.Drawing.Point(0, 0);
            this.homeNextBatter1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.homeNextBatter1.Name = "homeNextBatter1";
            this.homeNextBatter1.Size = new System.Drawing.Size(250, 30);
            this.homeNextBatter1.TabIndex = 49;
            // 
            // homeTeamNextBatters
            // 
            this.homeTeamNextBatters.Controls.Add(this.home_DueUP);
            this.homeTeamNextBatters.Dock = System.Windows.Forms.DockStyle.Top;
            this.homeTeamNextBatters.Location = new System.Drawing.Point(0, 0);
            this.homeTeamNextBatters.Name = "homeTeamNextBatters";
            this.homeTeamNextBatters.Size = new System.Drawing.Size(250, 30);
            this.homeTeamNextBatters.TabIndex = 0;
            // 
            // home_DueUP
            // 
            this.home_DueUP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.home_DueUP.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.home_DueUP.ForeColor = System.Drawing.Color.White;
            this.home_DueUP.Location = new System.Drawing.Point(0, 0);
            this.home_DueUP.Name = "home_DueUP";
            this.home_DueUP.Size = new System.Drawing.Size(250, 30);
            this.home_DueUP.TabIndex = 0;
            this.home_DueUP.Text = "label32";
            this.home_DueUP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.home_DueUP.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label23.ForeColor = System.Drawing.Color.Gainsboro;
            this.label23.Location = new System.Drawing.Point(305, 98);
            this.label23.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(78, 31);
            this.label23.TabIndex = 46;
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label23.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label22.ForeColor = System.Drawing.Color.Gainsboro;
            this.label22.Location = new System.Drawing.Point(305, 57);
            this.label22.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(78, 31);
            this.label22.TabIndex = 45;
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label22.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label28.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(887, 9);
            this.label28.Margin = new System.Windows.Forms.Padding(0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(60, 39);
            this.label28.TabIndex = 107;
            this.label28.Text = "LOB";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label28.Visible = false;
            // 
            // awayLOB
            // 
            this.awayLOB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.awayLOB.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.awayLOB.ForeColor = System.Drawing.Color.White;
            this.awayLOB.Location = new System.Drawing.Point(887, 53);
            this.awayLOB.Margin = new System.Windows.Forms.Padding(0);
            this.awayLOB.Name = "awayLOB";
            this.awayLOB.Size = new System.Drawing.Size(60, 39);
            this.awayLOB.TabIndex = 105;
            this.awayLOB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.awayLOB.Visible = false;
            // 
            // homeLOB
            // 
            this.homeLOB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.homeLOB.Font = new System.Drawing.Font("Segoe UI", 16.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.homeLOB.ForeColor = System.Drawing.Color.White;
            this.homeLOB.Location = new System.Drawing.Point(887, 94);
            this.homeLOB.Margin = new System.Windows.Forms.Padding(0);
            this.homeLOB.Name = "homeLOB";
            this.homeLOB.Size = new System.Drawing.Size(60, 39);
            this.homeLOB.TabIndex = 106;
            this.homeLOB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.homeLOB.Visible = false;
            // 
            // panelCurrentPitcher
            // 
            this.panelCurrentPitcher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCurrentPitcher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panelCurrentPitcher.Controls.Add(this.PitcherGS);
            this.panelCurrentPitcher.Controls.Add(this.labelGS);
            this.panelCurrentPitcher.Controls.Add(this.PitcherRecord);
            this.panelCurrentPitcher.Controls.Add(this.labelRecord);
            this.panelCurrentPitcher.Controls.Add(this.label26);
            this.panelCurrentPitcher.Controls.Add(this.label25);
            this.panelCurrentPitcher.Controls.Add(this.PitcherHomeRunsToday);
            this.panelCurrentPitcher.Controls.Add(this.PitcherStrikeoutsToday);
            this.panelCurrentPitcher.Controls.Add(this.PitcherWalksToday);
            this.panelCurrentPitcher.Controls.Add(this.PitcherIPToday);
            this.panelCurrentPitcher.Controls.Add(this.PitcherBAA);
            this.panelCurrentPitcher.Controls.Add(this.PitcherWHIP);
            this.panelCurrentPitcher.Controls.Add(this.PitcherHomeRuns);
            this.panelCurrentPitcher.Controls.Add(this.PitcherStrikeouts);
            this.panelCurrentPitcher.Controls.Add(this.PitcherWalks);
            this.panelCurrentPitcher.Controls.Add(this.PitcherIP);
            this.panelCurrentPitcher.Controls.Add(this.PitcherERA);
            this.panelCurrentPitcher.Controls.Add(this.PitcherGames);
            this.panelCurrentPitcher.Controls.Add(this.label43);
            this.panelCurrentPitcher.Controls.Add(this.label42);
            this.panelCurrentPitcher.Controls.Add(this.label41);
            this.panelCurrentPitcher.Controls.Add(this.label40);
            this.panelCurrentPitcher.Controls.Add(this.label39);
            this.panelCurrentPitcher.Controls.Add(this.label38);
            this.panelCurrentPitcher.Controls.Add(this.label35);
            this.panelCurrentPitcher.Controls.Add(this.labelGames);
            this.panelCurrentPitcher.Controls.Add(this.PitchingTeamColor);
            this.panelCurrentPitcher.Location = new System.Drawing.Point(1179, 167);
            this.panelCurrentPitcher.Name = "panelCurrentPitcher";
            this.panelCurrentPitcher.Size = new System.Drawing.Size(234, 219);
            this.panelCurrentPitcher.TabIndex = 48;
            // 
            // PitcherGS
            // 
            this.PitcherGS.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PitcherGS.ForeColor = System.Drawing.Color.White;
            this.PitcherGS.Location = new System.Drawing.Point(166, 76);
            this.PitcherGS.Margin = new System.Windows.Forms.Padding(3, 5, 1, 5);
            this.PitcherGS.Name = "PitcherGS";
            this.PitcherGS.Size = new System.Drawing.Size(65, 15);
            this.PitcherGS.TabIndex = 29;
            this.PitcherGS.Text = "0";
            this.PitcherGS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelGS
            // 
            this.labelGS.AutoSize = true;
            this.labelGS.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelGS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.labelGS.Location = new System.Drawing.Point(10, 76);
            this.labelGS.Name = "labelGS";
            this.labelGS.Size = new System.Drawing.Size(116, 15);
            this.labelGS.TabIndex = 28;
            this.labelGS.Text = "GAMES STARTED";
            // 
            // PitcherRecord
            // 
            this.PitcherRecord.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PitcherRecord.ForeColor = System.Drawing.Color.White;
            this.PitcherRecord.Location = new System.Drawing.Point(166, 91);
            this.PitcherRecord.Margin = new System.Windows.Forms.Padding(3, 5, 1, 5);
            this.PitcherRecord.Name = "PitcherRecord";
            this.PitcherRecord.Size = new System.Drawing.Size(65, 15);
            this.PitcherRecord.TabIndex = 27;
            this.PitcherRecord.Text = "0";
            this.PitcherRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelRecord
            // 
            this.labelRecord.AutoSize = true;
            this.labelRecord.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelRecord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.labelRecord.Location = new System.Drawing.Point(10, 91);
            this.labelRecord.Name = "labelRecord";
            this.labelRecord.Size = new System.Drawing.Size(59, 15);
            this.labelRecord.TabIndex = 26;
            this.labelRecord.Text = "RECORD";
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label26.Location = new System.Drawing.Point(109, 46);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(56, 15);
            this.label26.TabIndex = 25;
            this.label26.Text = "MATCH";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label25.Location = new System.Drawing.Point(174, 46);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(57, 15);
            this.label25.TabIndex = 24;
            this.label25.Text = "CAREER";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PitcherHomeRunsToday
            // 
            this.PitcherHomeRunsToday.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PitcherHomeRunsToday.ForeColor = System.Drawing.Color.White;
            this.PitcherHomeRunsToday.Location = new System.Drawing.Point(126, 166);
            this.PitcherHomeRunsToday.Margin = new System.Windows.Forms.Padding(3, 5, 1, 5);
            this.PitcherHomeRunsToday.Name = "PitcherHomeRunsToday";
            this.PitcherHomeRunsToday.Size = new System.Drawing.Size(39, 15);
            this.PitcherHomeRunsToday.TabIndex = 23;
            this.PitcherHomeRunsToday.Text = "0";
            this.PitcherHomeRunsToday.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PitcherStrikeoutsToday
            // 
            this.PitcherStrikeoutsToday.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PitcherStrikeoutsToday.ForeColor = System.Drawing.Color.White;
            this.PitcherStrikeoutsToday.Location = new System.Drawing.Point(126, 151);
            this.PitcherStrikeoutsToday.Margin = new System.Windows.Forms.Padding(3, 5, 1, 5);
            this.PitcherStrikeoutsToday.Name = "PitcherStrikeoutsToday";
            this.PitcherStrikeoutsToday.Size = new System.Drawing.Size(39, 15);
            this.PitcherStrikeoutsToday.TabIndex = 22;
            this.PitcherStrikeoutsToday.Text = "0";
            this.PitcherStrikeoutsToday.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PitcherWalksToday
            // 
            this.PitcherWalksToday.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PitcherWalksToday.ForeColor = System.Drawing.Color.White;
            this.PitcherWalksToday.Location = new System.Drawing.Point(126, 136);
            this.PitcherWalksToday.Margin = new System.Windows.Forms.Padding(3, 5, 1, 5);
            this.PitcherWalksToday.Name = "PitcherWalksToday";
            this.PitcherWalksToday.Size = new System.Drawing.Size(39, 15);
            this.PitcherWalksToday.TabIndex = 21;
            this.PitcherWalksToday.Text = "0";
            this.PitcherWalksToday.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PitcherIPToday
            // 
            this.PitcherIPToday.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PitcherIPToday.ForeColor = System.Drawing.Color.White;
            this.PitcherIPToday.Location = new System.Drawing.Point(126, 121);
            this.PitcherIPToday.Margin = new System.Windows.Forms.Padding(3, 5, 1, 5);
            this.PitcherIPToday.Name = "PitcherIPToday";
            this.PitcherIPToday.Size = new System.Drawing.Size(39, 15);
            this.PitcherIPToday.TabIndex = 20;
            this.PitcherIPToday.Text = "0";
            this.PitcherIPToday.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PitcherBAA
            // 
            this.PitcherBAA.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PitcherBAA.ForeColor = System.Drawing.Color.White;
            this.PitcherBAA.Location = new System.Drawing.Point(166, 196);
            this.PitcherBAA.Margin = new System.Windows.Forms.Padding(3, 5, 1, 5);
            this.PitcherBAA.Name = "PitcherBAA";
            this.PitcherBAA.Size = new System.Drawing.Size(65, 15);
            this.PitcherBAA.TabIndex = 17;
            this.PitcherBAA.Text = "0";
            this.PitcherBAA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PitcherWHIP
            // 
            this.PitcherWHIP.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PitcherWHIP.ForeColor = System.Drawing.Color.White;
            this.PitcherWHIP.Location = new System.Drawing.Point(166, 181);
            this.PitcherWHIP.Margin = new System.Windows.Forms.Padding(3, 5, 1, 5);
            this.PitcherWHIP.Name = "PitcherWHIP";
            this.PitcherWHIP.Size = new System.Drawing.Size(65, 15);
            this.PitcherWHIP.TabIndex = 16;
            this.PitcherWHIP.Text = "0";
            this.PitcherWHIP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PitcherHomeRuns
            // 
            this.PitcherHomeRuns.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PitcherHomeRuns.ForeColor = System.Drawing.Color.White;
            this.PitcherHomeRuns.Location = new System.Drawing.Point(166, 166);
            this.PitcherHomeRuns.Margin = new System.Windows.Forms.Padding(3, 5, 1, 5);
            this.PitcherHomeRuns.Name = "PitcherHomeRuns";
            this.PitcherHomeRuns.Size = new System.Drawing.Size(65, 15);
            this.PitcherHomeRuns.TabIndex = 15;
            this.PitcherHomeRuns.Text = "0";
            this.PitcherHomeRuns.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PitcherStrikeouts
            // 
            this.PitcherStrikeouts.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PitcherStrikeouts.ForeColor = System.Drawing.Color.White;
            this.PitcherStrikeouts.Location = new System.Drawing.Point(166, 151);
            this.PitcherStrikeouts.Margin = new System.Windows.Forms.Padding(3, 5, 1, 5);
            this.PitcherStrikeouts.Name = "PitcherStrikeouts";
            this.PitcherStrikeouts.Size = new System.Drawing.Size(65, 15);
            this.PitcherStrikeouts.TabIndex = 14;
            this.PitcherStrikeouts.Text = "0";
            this.PitcherStrikeouts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PitcherWalks
            // 
            this.PitcherWalks.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PitcherWalks.ForeColor = System.Drawing.Color.White;
            this.PitcherWalks.Location = new System.Drawing.Point(166, 136);
            this.PitcherWalks.Margin = new System.Windows.Forms.Padding(3, 5, 1, 5);
            this.PitcherWalks.Name = "PitcherWalks";
            this.PitcherWalks.Size = new System.Drawing.Size(65, 15);
            this.PitcherWalks.TabIndex = 13;
            this.PitcherWalks.Text = "0";
            this.PitcherWalks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PitcherIP
            // 
            this.PitcherIP.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PitcherIP.ForeColor = System.Drawing.Color.White;
            this.PitcherIP.Location = new System.Drawing.Point(166, 121);
            this.PitcherIP.Margin = new System.Windows.Forms.Padding(3, 5, 1, 5);
            this.PitcherIP.Name = "PitcherIP";
            this.PitcherIP.Size = new System.Drawing.Size(65, 15);
            this.PitcherIP.TabIndex = 12;
            this.PitcherIP.Text = "0";
            this.PitcherIP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PitcherERA
            // 
            this.PitcherERA.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PitcherERA.ForeColor = System.Drawing.Color.White;
            this.PitcherERA.Location = new System.Drawing.Point(166, 106);
            this.PitcherERA.Margin = new System.Windows.Forms.Padding(3, 5, 1, 5);
            this.PitcherERA.Name = "PitcherERA";
            this.PitcherERA.Size = new System.Drawing.Size(65, 15);
            this.PitcherERA.TabIndex = 11;
            this.PitcherERA.Text = "0";
            this.PitcherERA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PitcherGames
            // 
            this.PitcherGames.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PitcherGames.ForeColor = System.Drawing.Color.White;
            this.PitcherGames.Location = new System.Drawing.Point(166, 61);
            this.PitcherGames.Margin = new System.Windows.Forms.Padding(3, 5, 1, 5);
            this.PitcherGames.Name = "PitcherGames";
            this.PitcherGames.Size = new System.Drawing.Size(65, 15);
            this.PitcherGames.TabIndex = 10;
            this.PitcherGames.Text = "0";
            this.PitcherGames.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label43.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label43.Location = new System.Drawing.Point(10, 196);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(111, 15);
            this.label43.TabIndex = 9;
            this.label43.Text = "OPPONENT AVG";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label42.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label42.Location = new System.Drawing.Point(10, 181);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(41, 15);
            this.label42.TabIndex = 8;
            this.label42.Text = "WHIP";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label41.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label41.Location = new System.Drawing.Point(10, 166);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(86, 15);
            this.label41.TabIndex = 7;
            this.label41.Text = "HOME RUNS";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label40.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label40.Location = new System.Drawing.Point(10, 151);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(87, 15);
            this.label40.TabIndex = 6;
            this.label40.Text = "STRIKEOUTS";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label39.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label39.Location = new System.Drawing.Point(10, 136);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(55, 15);
            this.label39.TabIndex = 5;
            this.label39.Text = "WALKS";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label38.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label38.Location = new System.Drawing.Point(10, 121);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(63, 15);
            this.label38.TabIndex = 4;
            this.label38.Text = "INNINGS";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label35.Location = new System.Drawing.Point(10, 106);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(32, 15);
            this.label35.TabIndex = 3;
            this.label35.Text = "ERA";
            // 
            // labelGames
            // 
            this.labelGames.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelGames.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.labelGames.Location = new System.Drawing.Point(10, 61);
            this.labelGames.Name = "labelGames";
            this.labelGames.Size = new System.Drawing.Size(57, 15);
            this.labelGames.TabIndex = 2;
            this.labelGames.Text = "GAMES";
            // 
            // PitchingTeamColor
            // 
            this.PitchingTeamColor.Controls.Add(this.PitcherName);
            this.PitchingTeamColor.Controls.Add(this.PitchingTeam);
            this.PitchingTeamColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.PitchingTeamColor.Location = new System.Drawing.Point(0, 0);
            this.PitchingTeamColor.Name = "PitchingTeamColor";
            this.PitchingTeamColor.Size = new System.Drawing.Size(234, 43);
            this.PitchingTeamColor.TabIndex = 0;
            // 
            // PitcherName
            // 
            this.PitcherName.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PitcherName.ForeColor = System.Drawing.Color.White;
            this.PitcherName.Location = new System.Drawing.Point(46, 3);
            this.PitcherName.Name = "PitcherName";
            this.PitcherName.Size = new System.Drawing.Size(178, 39);
            this.PitcherName.TabIndex = 8;
            this.PitcherName.Text = "Player";
            this.PitcherName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PitcherName.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            // 
            // PitchingTeam
            // 
            this.PitchingTeam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PitchingTeam.Location = new System.Drawing.Point(3, 3);
            this.PitchingTeam.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.PitchingTeam.Name = "PitchingTeam";
            this.PitchingTeam.Size = new System.Drawing.Size(37, 37);
            this.PitchingTeam.TabIndex = 7;
            // 
            // PitcherPhoto
            // 
            this.PitcherPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PitcherPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PitcherPhoto.Location = new System.Drawing.Point(1033, 167);
            this.PitcherPhoto.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.PitcherPhoto.Name = "PitcherPhoto";
            this.PitcherPhoto.Size = new System.Drawing.Size(146, 219);
            this.PitcherPhoto.TabIndex = 49;
            // 
            // panel2Base
            // 
            this.panel2Base.Controls.Add(this.lb_Runner2_Name);
            this.panel2Base.Controls.Add(this.panel31);
            this.panel2Base.Location = new System.Drawing.Point(643, 144);
            this.panel2Base.Name = "panel2Base";
            this.panel2Base.Size = new System.Drawing.Size(197, 100);
            this.panel2Base.TabIndex = 50;
            this.panel2Base.Visible = false;
            // 
            // lb_Runner2_Name
            // 
            this.lb_Runner2_Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lb_Runner2_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Runner2_Name.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_Runner2_Name.ForeColor = System.Drawing.Color.Gainsboro;
            this.lb_Runner2_Name.Location = new System.Drawing.Point(0, 23);
            this.lb_Runner2_Name.Name = "lb_Runner2_Name";
            this.lb_Runner2_Name.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.lb_Runner2_Name.Size = new System.Drawing.Size(197, 77);
            this.lb_Runner2_Name.TabIndex = 2;
            this.lb_Runner2_Name.Text = "label32";
            this.lb_Runner2_Name.Click += new System.EventHandler(this.lb_Runner2_Name_Click);
            // 
            // panel31
            // 
            this.panel31.Controls.Add(this.lb2ndBase);
            this.panel31.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel31.Location = new System.Drawing.Point(0, 0);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(197, 23);
            this.panel31.TabIndex = 1;
            // 
            // lb2ndBase
            // 
            this.lb2ndBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb2ndBase.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb2ndBase.ForeColor = System.Drawing.Color.White;
            this.lb2ndBase.Location = new System.Drawing.Point(0, 0);
            this.lb2ndBase.Name = "lb2ndBase";
            this.lb2ndBase.Size = new System.Drawing.Size(197, 23);
            this.lb2ndBase.TabIndex = 0;
            this.lb2ndBase.Text = "2ND BASE";
            this.lb2ndBase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb2ndBase.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            // 
            // RunnerOn2Photo
            // 
            this.RunnerOn2Photo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RunnerOn2Photo.Location = new System.Drawing.Point(576, 144);
            this.RunnerOn2Photo.Name = "RunnerOn2Photo";
            this.RunnerOn2Photo.Size = new System.Drawing.Size(67, 100);
            this.RunnerOn2Photo.TabIndex = 0;
            // 
            // panel1Base
            // 
            this.panel1Base.Controls.Add(this.lb_Runner1_Name);
            this.panel1Base.Controls.Add(this.panel33);
            this.panel1Base.Location = new System.Drawing.Point(1214, 490);
            this.panel1Base.Margin = new System.Windows.Forms.Padding(0);
            this.panel1Base.Name = "panel1Base";
            this.panel1Base.Size = new System.Drawing.Size(197, 100);
            this.panel1Base.TabIndex = 51;
            this.panel1Base.Visible = false;
            // 
            // lb_Runner1_Name
            // 
            this.lb_Runner1_Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lb_Runner1_Name.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lb_Runner1_Name.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_Runner1_Name.ForeColor = System.Drawing.Color.Gainsboro;
            this.lb_Runner1_Name.Location = new System.Drawing.Point(0, 23);
            this.lb_Runner1_Name.Name = "lb_Runner1_Name";
            this.lb_Runner1_Name.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.lb_Runner1_Name.Size = new System.Drawing.Size(197, 77);
            this.lb_Runner1_Name.TabIndex = 2;
            this.lb_Runner1_Name.Text = "label44";
            this.lb_Runner1_Name.Click += new System.EventHandler(this.lb_Runner1_Name_Click);
            // 
            // panel33
            // 
            this.panel33.Controls.Add(this.lb1stBase);
            this.panel33.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel33.Location = new System.Drawing.Point(0, 0);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(197, 23);
            this.panel33.TabIndex = 1;
            // 
            // lb1stBase
            // 
            this.lb1stBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb1stBase.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb1stBase.ForeColor = System.Drawing.Color.White;
            this.lb1stBase.Location = new System.Drawing.Point(0, 0);
            this.lb1stBase.Name = "lb1stBase";
            this.lb1stBase.Size = new System.Drawing.Size(197, 23);
            this.lb1stBase.TabIndex = 1;
            this.lb1stBase.Text = "1ST BASE";
            this.lb1stBase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb1stBase.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            // 
            // RunnerOn1Photo
            // 
            this.RunnerOn1Photo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RunnerOn1Photo.Location = new System.Drawing.Point(1147, 490);
            this.RunnerOn1Photo.Name = "RunnerOn1Photo";
            this.RunnerOn1Photo.Size = new System.Drawing.Size(67, 100);
            this.RunnerOn1Photo.TabIndex = 0;
            // 
            // panel3Base
            // 
            this.panel3Base.Controls.Add(this.lb_Runner3_Name);
            this.panel3Base.Controls.Add(this.panel36);
            this.panel3Base.Location = new System.Drawing.Point(79, 505);
            this.panel3Base.Name = "panel3Base";
            this.panel3Base.Size = new System.Drawing.Size(197, 100);
            this.panel3Base.TabIndex = 52;
            this.panel3Base.Visible = false;
            // 
            // lb_Runner3_Name
            // 
            this.lb_Runner3_Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lb_Runner3_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Runner3_Name.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_Runner3_Name.ForeColor = System.Drawing.Color.Gainsboro;
            this.lb_Runner3_Name.Location = new System.Drawing.Point(0, 23);
            this.lb_Runner3_Name.Name = "lb_Runner3_Name";
            this.lb_Runner3_Name.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.lb_Runner3_Name.Size = new System.Drawing.Size(197, 77);
            this.lb_Runner3_Name.TabIndex = 2;
            this.lb_Runner3_Name.Text = "label45";
            // 
            // panel36
            // 
            this.panel36.Controls.Add(this.lb3rdBase);
            this.panel36.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel36.Location = new System.Drawing.Point(0, 0);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(197, 23);
            this.panel36.TabIndex = 1;
            // 
            // lb3rdBase
            // 
            this.lb3rdBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb3rdBase.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb3rdBase.ForeColor = System.Drawing.Color.White;
            this.lb3rdBase.Location = new System.Drawing.Point(0, 0);
            this.lb3rdBase.Name = "lb3rdBase";
            this.lb3rdBase.Size = new System.Drawing.Size(197, 23);
            this.lb3rdBase.TabIndex = 1;
            this.lb3rdBase.Text = "3RD BASE";
            this.lb3rdBase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb3rdBase.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            // 
            // RunnerOn3Photo
            // 
            this.RunnerOn3Photo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RunnerOn3Photo.Location = new System.Drawing.Point(12, 505);
            this.RunnerOn3Photo.Name = "RunnerOn3Photo";
            this.RunnerOn3Photo.Size = new System.Drawing.Size(67, 100);
            this.RunnerOn3Photo.TabIndex = 0;
            // 
            // label32
            // 
            this.label32.Dock = System.Windows.Forms.DockStyle.Left;
            this.label32.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label32.Location = new System.Drawing.Point(0, 0);
            this.label32.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label32.MaximumSize = new System.Drawing.Size(140, 31);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(124, 31);
            this.label32.TabIndex = 53;
            this.label32.Text = "Last At-bat:";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label32.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            // 
            // label44
            // 
            this.label44.Dock = System.Windows.Forms.DockStyle.Right;
            this.label44.Font = new System.Drawing.Font("MicroFLF", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label44.ForeColor = System.Drawing.Color.White;
            this.label44.Location = new System.Drawing.Point(520, 0);
            this.label44.MaximumSize = new System.Drawing.Size(400, 31);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(250, 31);
            this.label44.TabIndex = 54;
            this.label44.Text = "00";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBuntAttempt
            // 
            this.btnBuntAttempt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuntAttempt.BackColor = System.Drawing.Color.Gainsboro;
            this.btnBuntAttempt.FlatAppearance.BorderSize = 0;
            this.btnBuntAttempt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuntAttempt.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBuntAttempt.Location = new System.Drawing.Point(388, 10);
            this.btnBuntAttempt.Name = "btnBuntAttempt";
            this.btnBuntAttempt.Size = new System.Drawing.Size(300, 35);
            this.btnBuntAttempt.TabIndex = 55;
            this.btnBuntAttempt.TabStop = false;
            this.btnBuntAttempt.Text = "BUNT ATTEMPT";
            this.btnBuntAttempt.UseVisualStyleBackColor = false;
            this.btnBuntAttempt.Click += new System.EventHandler(this.btnBuntAttempt_Click);
            // 
            // btnStandings
            // 
            this.btnStandings.BackColor = System.Drawing.Color.Gainsboro;
            this.btnStandings.FlatAppearance.BorderSize = 0;
            this.btnStandings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStandings.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStandings.Location = new System.Drawing.Point(12, 144);
            this.btnStandings.Name = "btnStandings";
            this.btnStandings.Size = new System.Drawing.Size(300, 35);
            this.btnStandings.TabIndex = 56;
            this.btnStandings.Text = "CURRENT STANDINGS";
            this.btnStandings.UseVisualStyleBackColor = false;
            this.btnStandings.Click += new System.EventHandler(this.btnStandings_Click);
            // 
            // btnShowAvailablePitchers
            // 
            this.btnShowAvailablePitchers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowAvailablePitchers.FlatAppearance.BorderSize = 0;
            this.btnShowAvailablePitchers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAvailablePitchers.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnShowAvailablePitchers.ForeColor = System.Drawing.Color.White;
            this.btnShowAvailablePitchers.Location = new System.Drawing.Point(1033, 386);
            this.btnShowAvailablePitchers.Name = "btnShowAvailablePitchers";
            this.btnShowAvailablePitchers.Size = new System.Drawing.Size(380, 35);
            this.btnShowAvailablePitchers.TabIndex = 57;
            this.btnShowAvailablePitchers.Text = "CHANGE PITCHER";
            this.btnShowAvailablePitchers.UseVisualStyleBackColor = true;
            this.btnShowAvailablePitchers.Visible = false;
            this.btnShowAvailablePitchers.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            this.btnShowAvailablePitchers.Click += new System.EventHandler(this.btnShowAvailablePitchers_Click);
            // 
            // btnOtherResults
            // 
            this.btnOtherResults.BackColor = System.Drawing.Color.Gainsboro;
            this.btnOtherResults.FlatAppearance.BorderSize = 0;
            this.btnOtherResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOtherResults.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOtherResults.Location = new System.Drawing.Point(12, 185);
            this.btnOtherResults.Name = "btnOtherResults";
            this.btnOtherResults.Size = new System.Drawing.Size(300, 35);
            this.btnOtherResults.TabIndex = 59;
            this.btnOtherResults.Text = "SCHEDULE AND RESULTS";
            this.btnOtherResults.UseVisualStyleBackColor = false;
            this.btnOtherResults.Click += new System.EventHandler(this.btnOtherResults_Click);
            // 
            // btnPlayerStats
            // 
            this.btnPlayerStats.BackColor = System.Drawing.Color.Gainsboro;
            this.btnPlayerStats.FlatAppearance.BorderSize = 0;
            this.btnPlayerStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayerStats.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPlayerStats.Location = new System.Drawing.Point(12, 226);
            this.btnPlayerStats.Name = "btnPlayerStats";
            this.btnPlayerStats.Size = new System.Drawing.Size(300, 35);
            this.btnPlayerStats.TabIndex = 60;
            this.btnPlayerStats.Text = "PLAYER STATS";
            this.btnPlayerStats.UseVisualStyleBackColor = false;
            this.btnPlayerStats.Click += new System.EventHandler(this.btnPlayerStats_Click);
            // 
            // panel15
            // 
            this.panel15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel15.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel15.Location = new System.Drawing.Point(124, 0);
            this.panel15.Margin = new System.Windows.Forms.Padding(0, 3, 3, 1);
            this.panel15.MaximumSize = new System.Drawing.Size(31, 31);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(31, 31);
            this.panel15.TabIndex = 61;
            // 
            // label27
            // 
            this.label27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label27.Font = new System.Drawing.Font("MicroFLF", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(155, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(365, 31);
            this.label27.TabIndex = 62;
            this.label27.Text = "00";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label27.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            // 
            // panelLastAtBat
            // 
            this.panelLastAtBat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLastAtBat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panelLastAtBat.Controls.Add(this.label27);
            this.panelLastAtBat.Controls.Add(this.panel15);
            this.panelLastAtBat.Controls.Add(this.label32);
            this.panelLastAtBat.Controls.Add(this.label44);
            this.panelLastAtBat.Location = new System.Drawing.Point(331, 852);
            this.panelLastAtBat.Name = "panelLastAtBat";
            this.panelLastAtBat.Size = new System.Drawing.Size(770, 31);
            this.panelLastAtBat.TabIndex = 63;
            this.panelLastAtBat.Visible = false;
            // 
            // btnTeamStats
            // 
            this.btnTeamStats.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTeamStats.FlatAppearance.BorderSize = 0;
            this.btnTeamStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTeamStats.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTeamStats.Location = new System.Drawing.Point(12, 267);
            this.btnTeamStats.Name = "btnTeamStats";
            this.btnTeamStats.Size = new System.Drawing.Size(300, 35);
            this.btnTeamStats.TabIndex = 64;
            this.btnTeamStats.Text = "TEAM STATS";
            this.btnTeamStats.UseVisualStyleBackColor = false;
            this.btnTeamStats.Click += new System.EventHandler(this.btnTeamStats_Click);
            // 
            // btnManualMode
            // 
            this.btnManualMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnManualMode.BackColor = System.Drawing.Color.Gainsboro;
            this.btnManualMode.FlatAppearance.BorderSize = 0;
            this.btnManualMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManualMode.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnManualMode.Location = new System.Drawing.Point(413, 750);
            this.btnManualMode.Name = "btnManualMode";
            this.btnManualMode.Size = new System.Drawing.Size(300, 35);
            this.btnManualMode.TabIndex = 65;
            this.btnManualMode.TabStop = false;
            this.btnManualMode.Text = "MANUAL";
            this.btnManualMode.UseVisualStyleBackColor = false;
            this.btnManualMode.Click += new System.EventHandler(this.btnManualMode_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 2500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnAutoMode
            // 
            this.btnAutoMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoMode.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAutoMode.FlatAppearance.BorderSize = 0;
            this.btnAutoMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoMode.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAutoMode.Location = new System.Drawing.Point(719, 750);
            this.btnAutoMode.Name = "btnAutoMode";
            this.btnAutoMode.Size = new System.Drawing.Size(300, 35);
            this.btnAutoMode.TabIndex = 66;
            this.btnAutoMode.TabStop = false;
            this.btnAutoMode.Text = "AUTOMATIC";
            this.btnAutoMode.UseVisualStyleBackColor = false;
            this.btnAutoMode.Click += new System.EventHandler(this.btnAutoMode_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnNewPitch);
            this.panel1.Controls.Add(this.btnBuntAttempt);
            this.panel1.Location = new System.Drawing.Point(331, 791);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 55);
            this.panel1.TabIndex = 67;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1423, 1041);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAutoMode);
            this.Controls.Add(this.btnManualMode);
            this.Controls.Add(this.btnTeamStats);
            this.Controls.Add(this.lbTodayStats);
            this.Controls.Add(this.btnPlayerStats);
            this.Controls.Add(this.btnOtherResults);
            this.Controls.Add(this.RunnerOn3Photo);
            this.Controls.Add(this.RunnerOn2Photo);
            this.Controls.Add(this.RunnerOn1Photo);
            this.Controls.Add(label24);
            this.Controls.Add(this.btnShowAvailablePitchers);
            this.Controls.Add(this.btnStandings);
            this.Controls.Add(this.panel3Base);
            this.Controls.Add(this.panel1Base);
            this.Controls.Add(this.panel2Base);
            this.Controls.Add(this.PitcherPhoto);
            this.Controls.Add(this.pbCurrentBatterPhoto);
            this.Controls.Add(this.pbCurrentOffenseLogo);
            this.Controls.Add(this.panelCurrentPitcher);
            this.Controls.Add(panel27);
            this.Controls.Add(this.panelScoreBoard);
            this.Controls.Add(this.panelCurrentBatter);
            this.Controls.Add(this.panelSmallScoreBoard);
            this.Controls.Add(this.panelCurrentSituation);
            this.Controls.Add(this.panelLastAtBat);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1339, 1000);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ClientSizeChanged += new System.EventHandler(this.MainForm_ClientSizeChanged);
            panel27.ResumeLayout(false);
            this.panelCurrentSituationPitcher.ResumeLayout(false);
            this.panelSmallScoreBoard.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panelCurrentSituation.ResumeLayout(false);
            this.panelCurrentSituation.PerformLayout();
            this.panelCurrentBatter.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panelScoreBoard.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panelNextAwayBatters.ResumeLayout(false);
            this.AwayTeamNextBatters.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panelNextHomeBatters.ResumeLayout(false);
            this.homeTeamNextBatters.ResumeLayout(false);
            this.panelCurrentPitcher.ResumeLayout(false);
            this.panelCurrentPitcher.PerformLayout();
            this.PitchingTeamColor.ResumeLayout(false);
            this.panel2Base.ResumeLayout(false);
            this.panel31.ResumeLayout(false);
            this.panel1Base.ResumeLayout(false);
            this.panel33.ResumeLayout(false);
            this.panel3Base.ResumeLayout(false);
            this.panel36.ResumeLayout(false);
            this.panelLastAtBat.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnNewPitch;
        private Panel panelSmallScoreBoard;
        private Panel panelCurrentSituation;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label5;
        private Panel panel3;
        private Panel panel5;
        private Label HomeTeam_Abbreviation;
        private Panel panel4;
        private Label AwayTeam_Abbreviation;
        private Label HomeTeam_RunsScored;
        private Label AwayTeam_RunsScored;
        private Panel panelCurrentBatter;
        private Panel pbCurrentOffenseLogo;
        private Panel panel8;
        private Panel pbCurrentBatterPhoto;
        private Label lblPlayerName;
        private Panel panel9;
        private Label lblPlayerPosition;
        private Label lblPlayerNumber;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label14;
        private Label label15;
        private Label label12;
        private Label label13;
        private Label label16;
        private Label batterOPSValue;
        private Label label18;
        private Label label19;
        private Panel panel11;
        private Panel panel12;
        private Label away2;
        private Label away3;
        private Label away4;
        private Label away5;
        private Label away6;
        private Label away7;
        private Label away8;
        private Label away9;
        private Label away10;
        private Label home10;
        private Label home9;
        private Label home8;
        private Label home7;
        private Label home6;
        private Label home5;
        private Label home4;
        private Label home3;
        private Label home2;
        private Label awayRuns;
        private Label homeRuns;
        private Label awayHits;
        private Label homeHits;
        private Label label20;
        private Label label21;
        private Label lb9thInning;
        private Label lb8thInning;
        private Label lb7thInning;
        private Label lb6thInning;
        private Label lb5thInning;
        private Label lb4thInning;
        private Label lb3rdInning;
        private Label lb2ndInning;
        private Label lb1stInning;
        private Panel panelScoreBoard;
        private Panel panel18;
        private Panel AwayTeamNextBatters;
        private Panel panel16;
        private Panel homeTeamNextBatters;
        private Label away_DueUP;
        private Label home_DueUP;
        private Panel panelNextAwayBatters;
        private Panel panelNextHomeBatters;
        private Panel panelCurrentSituationPitcher;
        private Label lbPitchCountForThisPitcher;
        private Label lbPitcherSecondName;
        private Panel panelCurrentPitcher;
        private Label PitcherHomeRunsToday;
        private Label PitcherStrikeoutsToday;
        private Label PitcherWalksToday;
        private Label PitcherIPToday;
        private Label PitcherBAA;
        private Label PitcherWHIP;
        private Label PitcherHomeRuns;
        private Label PitcherStrikeouts;
        private Label PitcherWalks;
        private Label PitcherIP;
        private Label PitcherERA;
        private Label PitcherGames;
        private Label label43;
        private Label label42;
        private Label label41;
        private Label label40;
        private Label label39;
        private Label label38;
        private Label label35;
        private Label labelGames;
        private Panel PitchingTeamColor;
        private Label PitcherName;
        private Panel PitchingTeam;
        private Panel PitcherPhoto;
        private Panel panel2Base;
        private Label lb_Runner2_Name;
        private Panel panel31;
        private Panel RunnerOn2Photo;
        private Panel panel1Base;
        private Label lb_Runner1_Name;
        private Panel panel33;
        private Panel RunnerOn1Photo;
        private Panel panel3Base;
        private Label lb_Runner3_Name;
        private Panel panel36;
        private Panel RunnerOn3Photo;
        private Label lb2ndBase;
        private Label lb1stBase;
        private Label lb3rdBase;
        private Label label32;
        private Label label44;
        private Button btnBuntAttempt;
        private Label label23;
        private Label label22;
        private Button btnStandings;
        private Button btnShowAvailablePitchers;
        private Button btnOtherResults;
        private Button btnPlayerStats;
        private Label label26;
        private Label label25;
        private Button btnChangeBatter;
        private Label lbTodayStats;
        private Panel panel15;
        private Label label27;
        private Panel panelLastAtBat;
        private Button btnTeamStats;
        private Label PitcherRecord;
        private Label labelRecord;
        private Label PitcherGS;
        private Label labelGS;
        private ProgressBar pb_stamina;
        private Button btnManualMode;
        private Timer timer1;
        private Button btnAutoMode;
        private Panel panel1;
        private Label label28;
        private Label awayLOB;
        private Label homeLOB;
        private BatterInfo currentBatter;
        private BatterInfo awayNextBatter3;
        private BatterInfo awayNextBatter2;
        private BatterInfo awayNextBatter1;
        private BatterInfo homeNextBatter3;
        private BatterInfo homeNextBatter2;
        private BatterInfo homeNextBatter1;
    }
}

