using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ExtendedDotNET.Controls.Progress;
using VKR_Test.Properties;
using ProgressBar = ExtendedDotNET.Controls.Progress.ProgressBar;

namespace VKR_Test
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
            this.components = new Container();
            Label label36;
            Panel panel27;
            Label label24;
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
            this.pb_stamina = new ProgressBar();
            this.panelCurrentSituationPitcher = new Panel();
            this.lbPitcherSecondName = new Label();
            this.lbPitchCountForThisPitcher = new Label();
            this.panelCurrentSituationBatter = new Panel();
            this.BatterStats = new Label();
            this.lbBatterSecondName = new Label();
            this.lbBatterNumber = new Label();
            this.btnNewPitch = new Button();
            this.panelSmallScoreBoard = new Panel();
            this.panel5 = new Panel();
            this.HomeTeam_RunsScored = new Label();
            this.HomeTeam_Abbreviation = new Label();
            this.panel4 = new Panel();
            this.AwayTeam_RunsScored = new Label();
            this.AwayTeam_Abbreviation = new Label();
            this.panel3 = new Panel();
            this.panelCurrentSituation = new Panel();
            this.label5 = new Label();
            this.label4 = new Label();
            this.label3 = new Label();
            this.label2 = new Label();
            this.label1 = new Label();
            this.panelCurrentBatter = new Panel();
            this.label14 = new Label();
            this.label15 = new Label();
            this.label12 = new Label();
            this.label13 = new Label();
            this.label16 = new Label();
            this.batterOPSValue = new Label();
            this.label10 = new Label();
            this.label11 = new Label();
            this.label8 = new Label();
            this.label9 = new Label();
            this.label7 = new Label();
            this.label6 = new Label();
            this.panel8 = new Panel();
            this.btnChangeBatter = new Button();
            this.lblPlayerName = new Label();
            this.panel9 = new Panel();
            this.lblPlayerPosition = new Label();
            this.lblPlayerNumber = new Label();
            this.lbTodayStats = new Label();
            this.pbCurrentBatterPhoto = new Panel();
            this.pbCurrentOffenseLogo = new Panel();
            this.label18 = new Label();
            this.label19 = new Label();
            this.panel11 = new Panel();
            this.panel12 = new Panel();
            this.away2 = new Label();
            this.away3 = new Label();
            this.away4 = new Label();
            this.away5 = new Label();
            this.away6 = new Label();
            this.away7 = new Label();
            this.away8 = new Label();
            this.away9 = new Label();
            this.away10 = new Label();
            this.home10 = new Label();
            this.home9 = new Label();
            this.home8 = new Label();
            this.home7 = new Label();
            this.home6 = new Label();
            this.home5 = new Label();
            this.home4 = new Label();
            this.home3 = new Label();
            this.home2 = new Label();
            this.awayRuns = new Label();
            this.homeRuns = new Label();
            this.awayHits = new Label();
            this.homeHits = new Label();
            this.label20 = new Label();
            this.label21 = new Label();
            this.lb9thInning = new Label();
            this.lb8thInning = new Label();
            this.lb7thInning = new Label();
            this.lb6thInning = new Label();
            this.lb5thInning = new Label();
            this.lb4thInning = new Label();
            this.lb3rdInning = new Label();
            this.lb2ndInning = new Label();
            this.lb1stInning = new Label();
            this.panelScoreBoard = new Panel();
            this.panel18 = new Panel();
            this.panelNextAwayBatters = new Panel();
            this.panel22 = new Panel();
            this.AwayNext3Stats = new Label();
            this.AwayNext3 = new Label();
            this.AwayNextNumber3 = new Label();
            this.panel21 = new Panel();
            this.AwayNext2Stats = new Label();
            this.AwayNext2 = new Label();
            this.AwayNextNumber2 = new Label();
            this.panel20 = new Panel();
            this.AwayNext1Stats = new Label();
            this.AwayNext1 = new Label();
            this.AwayNextNumber1 = new Label();
            this.AwayTeamNextBatters = new Panel();
            this.away_DueUP = new Label();
            this.panel16 = new Panel();
            this.panelNextHomeBatters = new Panel();
            this.panel23 = new Panel();
            this.HomeNext3Stats = new Label();
            this.homeNext3 = new Label();
            this.homeNextNumber3 = new Label();
            this.panel24 = new Panel();
            this.HomeNext2Stats = new Label();
            this.homeNext2 = new Label();
            this.homeNextNumber2 = new Label();
            this.panel25 = new Panel();
            this.HomeNext1Stats = new Label();
            this.label33 = new Label();
            this.label34 = new Label();
            this.homeNext1 = new Label();
            this.homeNextNumber1 = new Label();
            this.homeTeamNextBatters = new Panel();
            this.home_DueUP = new Label();
            this.label23 = new Label();
            this.label22 = new Label();
            this.label28 = new Label();
            this.awayLOB = new Label();
            this.homeLOB = new Label();
            this.panelCurrentPitcher = new Panel();
            this.PitcherGS = new Label();
            this.labelGS = new Label();
            this.PitcherRecord = new Label();
            this.labelRecord = new Label();
            this.label26 = new Label();
            this.label25 = new Label();
            this.PitcherHomeRunsToday = new Label();
            this.PitcherStrikeoutsToday = new Label();
            this.PitcherWalksToday = new Label();
            this.PitcherIPToday = new Label();
            this.PitcherBAA = new Label();
            this.PitcherWHIP = new Label();
            this.PitcherHomeRuns = new Label();
            this.PitcherStrikeouts = new Label();
            this.PitcherWalks = new Label();
            this.PitcherIP = new Label();
            this.PitcherERA = new Label();
            this.PitcherGames = new Label();
            this.label43 = new Label();
            this.label42 = new Label();
            this.label41 = new Label();
            this.label40 = new Label();
            this.label39 = new Label();
            this.label38 = new Label();
            this.label35 = new Label();
            this.labelGames = new Label();
            this.PitchingTeamColor = new Panel();
            this.PitcherName = new Label();
            this.PitchingTeam = new Panel();
            this.PitcherPhoto = new Panel();
            this.panel2Base = new Panel();
            this.lb_Runner2_Name = new Label();
            this.panel31 = new Panel();
            this.lb2ndBase = new Label();
            this.RunnerOn2Photo = new Panel();
            this.panel1Base = new Panel();
            this.lb_Runner1_Name = new Label();
            this.panel33 = new Panel();
            this.lb1stBase = new Label();
            this.RunnerOn1Photo = new Panel();
            this.panel3Base = new Panel();
            this.lb_Runner3_Name = new Label();
            this.panel36 = new Panel();
            this.lb3rdBase = new Label();
            this.RunnerOn3Photo = new Panel();
            this.label32 = new Label();
            this.label44 = new Label();
            this.btnBuntAttempt = new Button();
            this.btnStandings = new Button();
            this.btnShowAvailablePitchers = new Button();
            this.btnOtherResults = new Button();
            this.btnPlayerStats = new Button();
            this.panel15 = new Panel();
            this.label27 = new Label();
            this.panelLastAtBat = new Panel();
            this.btnTeamStats = new Button();
            this.btnManualMode = new Button();
            this.timer1 = new Timer(this.components);
            this.btnAutoMode = new Button();
            this.panel1 = new Panel();
            label36 = new Label();
            panel27 = new Panel();
            label24 = new Label();
            panel27.SuspendLayout();
            this.panelCurrentSituationPitcher.SuspendLayout();
            this.panelCurrentSituationBatter.SuspendLayout();
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
            this.panel22.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel20.SuspendLayout();
            this.AwayTeamNextBatters.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panelNextHomeBatters.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel25.SuspendLayout();
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
            label36.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            label36.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            label36.Location = new Point(179, 6);
            label36.Margin = new Padding(3, 5, 1, 5);
            label36.Name = "label36";
            label36.Size = new Size(25, 20);
            label36.TabIndex = 1;
            label36.Text = "P:";
            label36.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel27
            // 
            panel27.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            panel27.BackColor = Color.Gray;
            panel27.Controls.Add(this.pb_stamina);
            panel27.Controls.Add(this.panelCurrentSituationPitcher);
            panel27.Controls.Add(this.panelCurrentSituationBatter);
            panel27.Location = new Point(1163, 846);
            panel27.Name = "panel27";
            panel27.Size = new Size(250, 66);
            panel27.TabIndex = 47;
            // 
            // pb_stamina
            // 
            this.pb_stamina.BackColor = Color.Gray;
            this.pb_stamina.BarOffset = 0;
            this.pb_stamina.Caption = "";
            this.pb_stamina.CaptionColor = Color.Black;
            this.pb_stamina.CaptionMode = ProgressCaptionMode.None;
            this.pb_stamina.CaptionShadowColor = Color.White;
            this.pb_stamina.ChangeByMouse = false;
            this.pb_stamina.DashSpace = 0;
            this.pb_stamina.DashWidth = 0;
            this.pb_stamina.Edge = ProgressBarEdge.Rectangle;
            this.pb_stamina.EdgeColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.pb_stamina.EdgeLightColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.pb_stamina.EdgeWidth = 0;
            this.pb_stamina.FloodPercentage = 0F;
            this.pb_stamina.FloodStyle = ProgressFloodStyle.Standard;
            this.pb_stamina.Invert = false;
            this.pb_stamina.Location = new Point(0, 28);
            this.pb_stamina.MainColor = Color.Gainsboro;
            this.pb_stamina.Maximum = 250;
            this.pb_stamina.Minimum = 0;
            this.pb_stamina.Name = "pb_stamina";
            this.pb_stamina.Orientation = ProgressBarDirection.Horizontal;
            this.pb_stamina.ProgressBackColor = Color.Gray;
            this.pb_stamina.ProgressBarStyle = ProgressStyle.Solid;
            this.pb_stamina.SecondColor = Color.White;
            this.pb_stamina.Shadow = true;
            this.pb_stamina.ShadowOffset = 0;
            this.pb_stamina.Size = new Size(250, 8);
            this.pb_stamina.Step = 0;
            this.pb_stamina.TabIndex = 65;
            this.pb_stamina.TabStop = false;
            this.pb_stamina.TextAntialias = true;
            this.pb_stamina.Value = 10;
            // 
            // panelCurrentSituationPitcher
            // 
            this.panelCurrentSituationPitcher.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panelCurrentSituationPitcher.Controls.Add(this.lbPitcherSecondName);
            this.panelCurrentSituationPitcher.Controls.Add(label36);
            this.panelCurrentSituationPitcher.Controls.Add(this.lbPitchCountForThisPitcher);
            this.panelCurrentSituationPitcher.Location = new Point(0, 0);
            this.panelCurrentSituationPitcher.Name = "panelCurrentSituationPitcher";
            this.panelCurrentSituationPitcher.Size = new Size(250, 30);
            this.panelCurrentSituationPitcher.TabIndex = 46;
            // 
            // lbPitcherSecondName
            // 
            this.lbPitcherSecondName.Font = new Font("MicroFLF", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.lbPitcherSecondName.ForeColor = Color.White;
            this.lbPitcherSecondName.Location = new Point(28, 5);
            this.lbPitcherSecondName.Margin = new Padding(3, 5, 1, 5);
            this.lbPitcherSecondName.Name = "lbPitcherSecondName";
            this.lbPitcherSecondName.Size = new Size(149, 20);
            this.lbPitcherSecondName.TabIndex = 3;
            this.lbPitcherSecondName.Text = "0";
            this.lbPitcherSecondName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbPitchCountForThisPitcher
            // 
            this.lbPitchCountForThisPitcher.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lbPitchCountForThisPitcher.ForeColor = Color.White;
            this.lbPitchCountForThisPitcher.Location = new Point(178, 5);
            this.lbPitchCountForThisPitcher.Margin = new Padding(3, 5, 1, 5);
            this.lbPitchCountForThisPitcher.Name = "lbPitchCountForThisPitcher";
            this.lbPitchCountForThisPitcher.Size = new Size(71, 20);
            this.lbPitchCountForThisPitcher.TabIndex = 4;
            this.lbPitchCountForThisPitcher.Text = "0";
            this.lbPitchCountForThisPitcher.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelCurrentSituationBatter
            // 
            this.panelCurrentSituationBatter.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panelCurrentSituationBatter.Controls.Add(this.BatterStats);
            this.panelCurrentSituationBatter.Controls.Add(this.lbBatterSecondName);
            this.panelCurrentSituationBatter.Controls.Add(this.lbBatterNumber);
            this.panelCurrentSituationBatter.Location = new Point(0, 36);
            this.panelCurrentSituationBatter.Name = "panelCurrentSituationBatter";
            this.panelCurrentSituationBatter.Size = new Size(250, 30);
            this.panelCurrentSituationBatter.TabIndex = 44;
            // 
            // BatterStats
            // 
            this.BatterStats.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.BatterStats.ForeColor = Color.White;
            this.BatterStats.Location = new Point(163, 5);
            this.BatterStats.Margin = new Padding(3, 5, 1, 5);
            this.BatterStats.Name = "BatterStats";
            this.BatterStats.Size = new Size(86, 20);
            this.BatterStats.TabIndex = 4;
            this.BatterStats.Text = "0";
            this.BatterStats.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbBatterSecondName
            // 
            this.lbBatterSecondName.Font = new Font("MicroFLF", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.lbBatterSecondName.ForeColor = Color.White;
            this.lbBatterSecondName.Location = new Point(28, 5);
            this.lbBatterSecondName.Margin = new Padding(3, 5, 1, 5);
            this.lbBatterSecondName.Name = "lbBatterSecondName";
            this.lbBatterSecondName.Size = new Size(149, 20);
            this.lbBatterSecondName.TabIndex = 3;
            this.lbBatterSecondName.Text = "0";
            this.lbBatterSecondName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbBatterNumber
            // 
            this.lbBatterNumber.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lbBatterNumber.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lbBatterNumber.Location = new Point(3, 5);
            this.lbBatterNumber.Margin = new Padding(3, 5, 1, 5);
            this.lbBatterNumber.Name = "lbBatterNumber";
            this.lbBatterNumber.Size = new Size(25, 20);
            this.lbBatterNumber.TabIndex = 1;
            this.lbBatterNumber.Text = "1.";
            this.lbBatterNumber.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            label24.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            label24.Font = new Font("MicroFLF", 12F);
            label24.Location = new Point(1179, 144);
            label24.Name = "label24";
            label24.Size = new Size(234, 23);
            label24.TabIndex = 58;
            label24.Text = "CURRENT PITCHER";
            label24.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnNewPitch
            // 
            this.btnNewPitch.BackColor = Color.Gainsboro;
            this.btnNewPitch.FlatAppearance.BorderSize = 0;
            this.btnNewPitch.FlatStyle = FlatStyle.Flat;
            this.btnNewPitch.Font = new Font("MicroFLF", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.btnNewPitch.Location = new Point(82, 10);
            this.btnNewPitch.Name = "btnNewPitch";
            this.btnNewPitch.Size = new Size(300, 35);
            this.btnNewPitch.TabIndex = 0;
            this.btnNewPitch.TabStop = false;
            this.btnNewPitch.Text = "NEXT PITCH";
            this.btnNewPitch.UseVisualStyleBackColor = false;
            this.btnNewPitch.Click += new EventHandler(this.button1_Click);
            // 
            // panelSmallScoreBoard
            // 
            this.panelSmallScoreBoard.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            this.panelSmallScoreBoard.Controls.Add(this.panel5);
            this.panelSmallScoreBoard.Controls.Add(this.panel4);
            this.panelSmallScoreBoard.Controls.Add(this.panel3);
            this.panelSmallScoreBoard.Location = new Point(1162, 920);
            this.panelSmallScoreBoard.Name = "panelSmallScoreBoard";
            this.panelSmallScoreBoard.Size = new Size(250, 78);
            this.panelSmallScoreBoard.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(184)))), ((int)(((byte)(39)))));
            this.panel5.Controls.Add(this.HomeTeam_RunsScored);
            this.panel5.Controls.Add(this.HomeTeam_Abbreviation);
            this.panel5.Dock = DockStyle.Bottom;
            this.panel5.Location = new Point(0, 39);
            this.panel5.Name = "panel5";
            this.panel5.Size = new Size(160, 39);
            this.panel5.TabIndex = 4;
            // 
            // HomeTeam_RunsScored
            // 
            this.HomeTeam_RunsScored.Dock = DockStyle.Right;
            this.HomeTeam_RunsScored.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            this.HomeTeam_RunsScored.ForeColor = Color.White;
            this.HomeTeam_RunsScored.Location = new Point(120, 0);
            this.HomeTeam_RunsScored.Margin = new Padding(6, 5, 6, 5);
            this.HomeTeam_RunsScored.Name = "HomeTeam_RunsScored";
            this.HomeTeam_RunsScored.Size = new Size(40, 39);
            this.HomeTeam_RunsScored.TabIndex = 3;
            this.HomeTeam_RunsScored.TextAlign = ContentAlignment.MiddleCenter;
            this.HomeTeam_RunsScored.BackColorChanged += new EventHandler(this.BackColorChanging_label);
            // 
            // HomeTeam_Abbreviation
            // 
            this.HomeTeam_Abbreviation.Dock = DockStyle.Left;
            this.HomeTeam_Abbreviation.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            this.HomeTeam_Abbreviation.ForeColor = Color.White;
            this.HomeTeam_Abbreviation.Location = new Point(0, 0);
            this.HomeTeam_Abbreviation.Margin = new Padding(6, 5, 6, 5);
            this.HomeTeam_Abbreviation.Name = "HomeTeam_Abbreviation";
            this.HomeTeam_Abbreviation.Padding = new Padding(10, 0, 0, 0);
            this.HomeTeam_Abbreviation.Size = new Size(121, 39);
            this.HomeTeam_Abbreviation.TabIndex = 1;
            this.HomeTeam_Abbreviation.TextAlign = ContentAlignment.MiddleLeft;
            this.HomeTeam_Abbreviation.BackColorChanged += new EventHandler(this.BackColorChanging_label);
            // 
            // panel4
            // 
            this.panel4.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(163)))), ((int)(((byte)(224)))));
            this.panel4.Controls.Add(this.AwayTeam_RunsScored);
            this.panel4.Controls.Add(this.AwayTeam_Abbreviation);
            this.panel4.Dock = DockStyle.Top;
            this.panel4.Location = new Point(0, 0);
            this.panel4.Margin = new Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new Size(160, 39);
            this.panel4.TabIndex = 3;
            // 
            // AwayTeam_RunsScored
            // 
            this.AwayTeam_RunsScored.Dock = DockStyle.Right;
            this.AwayTeam_RunsScored.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            this.AwayTeam_RunsScored.ForeColor = Color.White;
            this.AwayTeam_RunsScored.Location = new Point(120, 0);
            this.AwayTeam_RunsScored.Margin = new Padding(6, 5, 6, 5);
            this.AwayTeam_RunsScored.Name = "AwayTeam_RunsScored";
            this.AwayTeam_RunsScored.Size = new Size(40, 39);
            this.AwayTeam_RunsScored.TabIndex = 2;
            this.AwayTeam_RunsScored.TextAlign = ContentAlignment.MiddleCenter;
            this.AwayTeam_RunsScored.BackColorChanged += new EventHandler(this.BackColorChanging_label);
            // 
            // AwayTeam_Abbreviation
            // 
            this.AwayTeam_Abbreviation.Dock = DockStyle.Left;
            this.AwayTeam_Abbreviation.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            this.AwayTeam_Abbreviation.ForeColor = Color.White;
            this.AwayTeam_Abbreviation.Location = new Point(0, 0);
            this.AwayTeam_Abbreviation.Margin = new Padding(6, 5, 6, 5);
            this.AwayTeam_Abbreviation.Name = "AwayTeam_Abbreviation";
            this.AwayTeam_Abbreviation.Padding = new Padding(10, 0, 0, 0);
            this.AwayTeam_Abbreviation.Size = new Size(121, 39);
            this.AwayTeam_Abbreviation.TabIndex = 0;
            this.AwayTeam_Abbreviation.TextAlign = ContentAlignment.MiddleLeft;
            this.AwayTeam_Abbreviation.BackColorChanged += new EventHandler(this.BackColorChanging_label);
            // 
            // panel3
            // 
            this.panel3.BackColor = Color.Gray;
            this.panel3.BackgroundImage = Resources._000;
            this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel3.Dock = DockStyle.Right;
            this.panel3.Location = new Point(160, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(90, 78);
            this.panel3.TabIndex = 2;
            // 
            // panelCurrentSituation
            // 
            this.panelCurrentSituation.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            this.panelCurrentSituation.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panelCurrentSituation.Controls.Add(this.label5);
            this.panelCurrentSituation.Controls.Add(this.label4);
            this.panelCurrentSituation.Controls.Add(this.label3);
            this.panelCurrentSituation.Controls.Add(this.label2);
            this.panelCurrentSituation.Controls.Add(this.label1);
            this.panelCurrentSituation.Location = new Point(1161, 999);
            this.panelCurrentSituation.Name = "panelCurrentSituation";
            this.panelCurrentSituation.Size = new Size(250, 30);
            this.panelCurrentSituation.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new Font("MicroFLF", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = Color.White;
            this.label5.Location = new Point(189, 6);
            this.label5.Margin = new Padding(3, 5, 10, 5);
            this.label5.Name = "label5";
            this.label5.Size = new Size(35, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "0-0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new Font("MicroFLF", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label4.Location = new Point(105, 6);
            this.label4.Margin = new Padding(1, 5, 1, 5);
            this.label4.Name = "label4";
            this.label4.Size = new Size(36, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Out";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = Color.White;
            this.label3.Location = new Point(83, 6);
            this.label3.Margin = new Padding(3, 5, 1, 5);
            this.label3.Name = "label3";
            this.label3.Size = new Size(20, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = Color.White;
            this.label2.Location = new Point(37, 6);
            this.label2.Margin = new Padding(3, 5, 1, 5);
            this.label2.Name = "label2";
            this.label2.Size = new Size(20, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new Font("MicroFLF", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label1.Location = new Point(15, 6);
            this.label1.Margin = new Padding(15, 5, 1, 5);
            this.label1.Name = "label1";
            this.label1.Size = new Size(18, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "▲";
            // 
            // panelCurrentBatter
            // 
            this.panelCurrentBatter.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) 
                                                              | AnchorStyles.Right)));
            this.panelCurrentBatter.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
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
            this.panelCurrentBatter.Location = new Point(198, 889);
            this.panelCurrentBatter.Name = "panelCurrentBatter";
            this.panelCurrentBatter.Size = new Size(903, 110);
            this.panelCurrentBatter.TabIndex = 3;
            this.panelCurrentBatter.VisibleChanged += new EventHandler(this.panel6_VisibleChanged);
            // 
            // label14
            // 
            this.label14.Font = new Font("MicroFLF", 14F);
            this.label14.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label14.Location = new Point(543, 67);
            this.label14.Name = "label14";
            this.label14.Size = new Size(26, 42);
            this.label14.TabIndex = 21;
            this.label14.Text = "R";
            this.label14.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Font = new Font("MicroFLF", 20F, FontStyle.Bold);
            this.label15.ForeColor = Color.White;
            this.label15.Location = new Point(470, 52);
            this.label15.Name = "label15";
            this.label15.Size = new Size(76, 57);
            this.label15.TabIndex = 20;
            this.label15.Text = "999";
            this.label15.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Font = new Font("MicroFLF", 14F);
            this.label12.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label12.Location = new Point(428, 67);
            this.label12.Name = "label12";
            this.label12.Size = new Size(36, 42);
            this.label12.TabIndex = 19;
            this.label12.Text = "SB";
            this.label12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Font = new Font("MicroFLF", 20F, FontStyle.Bold);
            this.label13.ForeColor = Color.White;
            this.label13.Location = new Point(374, 52);
            this.label13.Name = "label13";
            this.label13.Size = new Size(59, 57);
            this.label13.TabIndex = 18;
            this.label13.Text = "99";
            this.label13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Font = new Font("MicroFLF", 14F);
            this.label16.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label16.Location = new Point(668, 67);
            this.label16.Name = "label16";
            this.label16.Size = new Size(53, 42);
            this.label16.TabIndex = 17;
            this.label16.Text = "OPS";
            this.label16.TextAlign = ContentAlignment.MiddleRight;
            // 
            // batterOPSValue
            // 
            this.batterOPSValue.Font = new Font("MicroFLF", 20F, FontStyle.Bold);
            this.batterOPSValue.ForeColor = Color.White;
            this.batterOPSValue.Location = new Point(575, 52);
            this.batterOPSValue.Name = "batterOPSValue";
            this.batterOPSValue.Size = new Size(100, 57);
            this.batterOPSValue.TabIndex = 16;
            this.batterOPSValue.Text = "1.000";
            this.batterOPSValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new Font("MicroFLF", 14F);
            this.label10.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label10.Location = new Point(326, 67);
            this.label10.Name = "label10";
            this.label10.Size = new Size(42, 42);
            this.label10.TabIndex = 11;
            this.label10.Text = "RBI";
            this.label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new Font("MicroFLF", 20F, FontStyle.Bold);
            this.label11.ForeColor = Color.White;
            this.label11.Location = new Point(253, 52);
            this.label11.Name = "label11";
            this.label11.Size = new Size(76, 57);
            this.label11.TabIndex = 10;
            this.label11.Text = "999";
            this.label11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new Font("MicroFLF", 14F);
            this.label8.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label8.Location = new Point(211, 67);
            this.label8.Name = "label8";
            this.label8.Size = new Size(36, 42);
            this.label8.TabIndex = 9;
            this.label8.Text = "HR";
            this.label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new Font("MicroFLF", 20F, FontStyle.Bold);
            this.label9.ForeColor = Color.White;
            this.label9.Location = new Point(157, 52);
            this.label9.Name = "label9";
            this.label9.Size = new Size(59, 57);
            this.label9.TabIndex = 8;
            this.label9.Text = "99";
            this.label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new Font("MicroFLF", 14F);
            this.label7.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label7.Location = new Point(98, 67);
            this.label7.Name = "label7";
            this.label7.Size = new Size(53, 42);
            this.label7.TabIndex = 7;
            this.label7.Text = "AVG";
            this.label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new Font("MicroFLF", 20F, FontStyle.Bold);
            this.label6.ForeColor = Color.White;
            this.label6.Location = new Point(5, 52);
            this.label6.Name = "label6";
            this.label6.Size = new Size(100, 57);
            this.label6.TabIndex = 6;
            this.label6.Text = "1.000";
            this.label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnChangeBatter);
            this.panel8.Controls.Add(this.lblPlayerName);
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Dock = DockStyle.Top;
            this.panel8.Location = new Point(0, 0);
            this.panel8.Margin = new Padding(0, 3, 3, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new Size(903, 36);
            this.panel8.TabIndex = 4;
            // 
            // btnChangeBatter
            // 
            this.btnChangeBatter.Dock = DockStyle.Right;
            this.btnChangeBatter.FlatAppearance.BorderSize = 0;
            this.btnChangeBatter.FlatStyle = FlatStyle.Flat;
            this.btnChangeBatter.Font = new Font("MicroFLF", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeBatter.ForeColor = Color.White;
            this.btnChangeBatter.Location = new Point(795, 0);
            this.btnChangeBatter.Name = "btnChangeBatter";
            this.btnChangeBatter.Size = new Size(108, 36);
            this.btnChangeBatter.TabIndex = 61;
            this.btnChangeBatter.Text = "CHANGE";
            this.btnChangeBatter.UseVisualStyleBackColor = true;
            this.btnChangeBatter.BackColorChanged += new EventHandler(this.BackColorChanging_label);
            this.btnChangeBatter.Click += new EventHandler(this.btnChangeBatter_Click);
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.Font = new Font("MicroFLF", 15F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerName.ForeColor = Color.White;
            this.lblPlayerName.Location = new Point(98, 3);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new Size(507, 30);
            this.lblPlayerName.TabIndex = 2;
            this.lblPlayerName.Text = "00";
            this.lblPlayerName.TextAlign = ContentAlignment.MiddleLeft;
            this.lblPlayerName.BackColorChanged += new EventHandler(this.BackColorChanging_label);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.lblPlayerPosition);
            this.panel9.Controls.Add(this.lblPlayerNumber);
            this.panel9.ForeColor = Color.White;
            this.panel9.Location = new Point(3, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new Size(89, 30);
            this.panel9.TabIndex = 0;
            this.panel9.Paint += new PaintEventHandler(this.panel9_Paint);
            // 
            // lblPlayerPosition
            // 
            this.lblPlayerPosition.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerPosition.ForeColor = Color.White;
            this.lblPlayerPosition.Location = new Point(45, 3);
            this.lblPlayerPosition.Name = "lblPlayerPosition";
            this.lblPlayerPosition.Size = new Size(36, 24);
            this.lblPlayerPosition.TabIndex = 1;
            this.lblPlayerPosition.Text = "00";
            this.lblPlayerPosition.TextAlign = ContentAlignment.MiddleCenter;
            this.lblPlayerPosition.BackColorChanged += new EventHandler(this.BackColorChanging_label);
            // 
            // lblPlayerNumber
            // 
            this.lblPlayerNumber.Font = new Font("MicroFLF", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerNumber.ForeColor = Color.Gainsboro;
            this.lblPlayerNumber.Location = new Point(3, 3);
            this.lblPlayerNumber.Name = "lblPlayerNumber";
            this.lblPlayerNumber.Size = new Size(36, 24);
            this.lblPlayerNumber.TabIndex = 0;
            this.lblPlayerNumber.Text = "00";
            this.lblPlayerNumber.TextAlign = ContentAlignment.MiddleCenter;
            this.lblPlayerNumber.BackColorChanged += new EventHandler(this.BackColorChanging_label);
            // 
            // lbTodayStats
            // 
            this.lbTodayStats.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) 
                                                        | AnchorStyles.Right)));
            this.lbTodayStats.BackColor = Color.Black;
            this.lbTodayStats.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lbTodayStats.ForeColor = Color.Gold;
            this.lbTodayStats.Location = new Point(88, 999);
            this.lbTodayStats.Name = "lbTodayStats";
            this.lbTodayStats.Size = new Size(1013, 30);
            this.lbTodayStats.TabIndex = 22;
            this.lbTodayStats.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pbCurrentBatterPhoto
            // 
            this.pbCurrentBatterPhoto.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            this.pbCurrentBatterPhoto.BackgroundImageLayout = ImageLayout.Stretch;
            this.pbCurrentBatterPhoto.Location = new Point(201, 755);
            this.pbCurrentBatterPhoto.Margin = new Padding(0, 3, 0, 0);
            this.pbCurrentBatterPhoto.Name = "pbCurrentBatterPhoto";
            this.pbCurrentBatterPhoto.Size = new Size(89, 134);
            this.pbCurrentBatterPhoto.TabIndex = 5;
            // 
            // pbCurrentOffenseLogo
            // 
            this.pbCurrentOffenseLogo.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            this.pbCurrentOffenseLogo.BackgroundImageLayout = ImageLayout.Stretch;
            this.pbCurrentOffenseLogo.Location = new Point(88, 889);
            this.pbCurrentOffenseLogo.Margin = new Padding(0, 3, 0, 3);
            this.pbCurrentOffenseLogo.Name = "pbCurrentOffenseLogo";
            this.pbCurrentOffenseLogo.Size = new Size(110, 110);
            this.pbCurrentOffenseLogo.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
                                                   | AnchorStyles.Right)));
            this.label18.BackColor = Color.Gainsboro;
            this.label18.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.label18.ForeColor = Color.White;
            this.label18.Location = new Point(103, 53);
            this.label18.Margin = new Padding(6, 5, 0, 1);
            this.label18.MaximumSize = new Size(287, 39);
            this.label18.Name = "label18";
            this.label18.Size = new Size(287, 39);
            this.label18.TabIndex = 4;
            this.label18.TextAlign = ContentAlignment.MiddleLeft;
            this.label18.BackColorChanged += new EventHandler(this.BackColorChanging_label);
            // 
            // label19
            // 
            this.label19.BackColor = Color.Gainsboro;
            this.label19.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.label19.ForeColor = Color.White;
            this.label19.Location = new Point(103, 94);
            this.label19.Margin = new Padding(6, 1, 6, 5);
            this.label19.Name = "label19";
            this.label19.Size = new Size(287, 39);
            this.label19.TabIndex = 5;
            this.label19.TextAlign = ContentAlignment.MiddleLeft;
            this.label19.BackColorChanged += new EventHandler(this.BackColorChanging_label);
            // 
            // panel11
            // 
            this.panel11.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel11.Location = new Point(64, 53);
            this.panel11.Margin = new Padding(3, 3, 3, 1);
            this.panel11.Name = "panel11";
            this.panel11.Size = new Size(39, 39);
            this.panel11.TabIndex = 6;
            // 
            // panel12
            // 
            this.panel12.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel12.Location = new Point(64, 94);
            this.panel12.Margin = new Padding(3, 1, 3, 3);
            this.panel12.Name = "panel12";
            this.panel12.Size = new Size(39, 39);
            this.panel12.TabIndex = 7;
            // 
            // away2
            // 
            this.away2.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.away2.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.away2.ForeColor = Color.White;
            this.away2.Location = new Point(390, 53);
            this.away2.Margin = new Padding(0);
            this.away2.Name = "away2";
            this.away2.Size = new Size(45, 39);
            this.away2.TabIndex = 9;
            this.away2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // away3
            // 
            this.away3.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.away3.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.away3.ForeColor = Color.White;
            this.away3.Location = new Point(435, 53);
            this.away3.Margin = new Padding(0);
            this.away3.Name = "away3";
            this.away3.Size = new Size(45, 39);
            this.away3.TabIndex = 10;
            this.away3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // away4
            // 
            this.away4.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.away4.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.away4.ForeColor = Color.White;
            this.away4.Location = new Point(480, 53);
            this.away4.Margin = new Padding(0);
            this.away4.Name = "away4";
            this.away4.Size = new Size(45, 39);
            this.away4.TabIndex = 11;
            this.away4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // away5
            // 
            this.away5.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.away5.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.away5.ForeColor = Color.White;
            this.away5.Location = new Point(525, 53);
            this.away5.Margin = new Padding(0);
            this.away5.Name = "away5";
            this.away5.Size = new Size(45, 39);
            this.away5.TabIndex = 12;
            this.away5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // away6
            // 
            this.away6.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.away6.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.away6.ForeColor = Color.White;
            this.away6.Location = new Point(570, 53);
            this.away6.Margin = new Padding(0);
            this.away6.Name = "away6";
            this.away6.Size = new Size(45, 39);
            this.away6.TabIndex = 13;
            this.away6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // away7
            // 
            this.away7.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.away7.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.away7.ForeColor = Color.White;
            this.away7.Location = new Point(615, 53);
            this.away7.Margin = new Padding(0);
            this.away7.Name = "away7";
            this.away7.Size = new Size(45, 39);
            this.away7.TabIndex = 14;
            this.away7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // away8
            // 
            this.away8.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.away8.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.away8.ForeColor = Color.White;
            this.away8.Location = new Point(660, 53);
            this.away8.Margin = new Padding(0);
            this.away8.Name = "away8";
            this.away8.Size = new Size(45, 39);
            this.away8.TabIndex = 15;
            this.away8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // away9
            // 
            this.away9.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.away9.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.away9.ForeColor = Color.White;
            this.away9.Location = new Point(705, 53);
            this.away9.Margin = new Padding(0);
            this.away9.Name = "away9";
            this.away9.Size = new Size(45, 39);
            this.away9.TabIndex = 16;
            this.away9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // away10
            // 
            this.away10.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.away10.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.away10.ForeColor = Color.White;
            this.away10.Location = new Point(750, 53);
            this.away10.Margin = new Padding(0);
            this.away10.Name = "away10";
            this.away10.Size = new Size(45, 39);
            this.away10.TabIndex = 17;
            this.away10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // home10
            // 
            this.home10.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.home10.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.home10.ForeColor = Color.White;
            this.home10.Location = new Point(750, 94);
            this.home10.Margin = new Padding(0);
            this.home10.Name = "home10";
            this.home10.Size = new Size(45, 39);
            this.home10.TabIndex = 27;
            this.home10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // home9
            // 
            this.home9.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.home9.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.home9.ForeColor = Color.White;
            this.home9.Location = new Point(705, 94);
            this.home9.Margin = new Padding(0);
            this.home9.Name = "home9";
            this.home9.Size = new Size(45, 39);
            this.home9.TabIndex = 26;
            this.home9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // home8
            // 
            this.home8.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.home8.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.home8.ForeColor = Color.White;
            this.home8.Location = new Point(660, 94);
            this.home8.Margin = new Padding(0);
            this.home8.Name = "home8";
            this.home8.Size = new Size(45, 39);
            this.home8.TabIndex = 25;
            this.home8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // home7
            // 
            this.home7.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.home7.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.home7.ForeColor = Color.White;
            this.home7.Location = new Point(615, 94);
            this.home7.Margin = new Padding(0);
            this.home7.Name = "home7";
            this.home7.Size = new Size(45, 39);
            this.home7.TabIndex = 24;
            this.home7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // home6
            // 
            this.home6.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.home6.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.home6.ForeColor = Color.White;
            this.home6.Location = new Point(570, 94);
            this.home6.Margin = new Padding(0);
            this.home6.Name = "home6";
            this.home6.Size = new Size(45, 39);
            this.home6.TabIndex = 23;
            this.home6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // home5
            // 
            this.home5.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.home5.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.home5.ForeColor = Color.White;
            this.home5.Location = new Point(525, 94);
            this.home5.Margin = new Padding(0);
            this.home5.Name = "home5";
            this.home5.Size = new Size(45, 39);
            this.home5.TabIndex = 22;
            this.home5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // home4
            // 
            this.home4.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.home4.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.home4.ForeColor = Color.White;
            this.home4.Location = new Point(480, 94);
            this.home4.Margin = new Padding(0);
            this.home4.Name = "home4";
            this.home4.Size = new Size(45, 39);
            this.home4.TabIndex = 21;
            this.home4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // home3
            // 
            this.home3.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.home3.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.home3.ForeColor = Color.White;
            this.home3.Location = new Point(435, 94);
            this.home3.Margin = new Padding(0);
            this.home3.Name = "home3";
            this.home3.Size = new Size(45, 39);
            this.home3.TabIndex = 20;
            this.home3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // home2
            // 
            this.home2.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.home2.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.home2.ForeColor = Color.White;
            this.home2.Location = new Point(390, 94);
            this.home2.Margin = new Padding(0);
            this.home2.Name = "home2";
            this.home2.Size = new Size(45, 39);
            this.home2.TabIndex = 19;
            this.home2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // awayRuns
            // 
            this.awayRuns.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.awayRuns.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.awayRuns.ForeColor = Color.White;
            this.awayRuns.Location = new Point(797, 53);
            this.awayRuns.Margin = new Padding(2, 0, 0, 0);
            this.awayRuns.Name = "awayRuns";
            this.awayRuns.Size = new Size(45, 39);
            this.awayRuns.TabIndex = 28;
            this.awayRuns.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // homeRuns
            // 
            this.homeRuns.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.homeRuns.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.homeRuns.ForeColor = Color.White;
            this.homeRuns.Location = new Point(797, 94);
            this.homeRuns.Margin = new Padding(2, 0, 0, 0);
            this.homeRuns.Name = "homeRuns";
            this.homeRuns.Size = new Size(45, 39);
            this.homeRuns.TabIndex = 29;
            this.homeRuns.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // awayHits
            // 
            this.awayHits.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.awayHits.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.awayHits.ForeColor = Color.White;
            this.awayHits.Location = new Point(842, 53);
            this.awayHits.Margin = new Padding(0);
            this.awayHits.Name = "awayHits";
            this.awayHits.Size = new Size(45, 39);
            this.awayHits.TabIndex = 30;
            this.awayHits.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // homeHits
            // 
            this.homeHits.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.homeHits.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.homeHits.ForeColor = Color.White;
            this.homeHits.Location = new Point(842, 94);
            this.homeHits.Margin = new Padding(0);
            this.homeHits.Name = "homeHits";
            this.homeHits.Size = new Size(45, 39);
            this.homeHits.TabIndex = 31;
            this.homeHits.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label20.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.label20.ForeColor = Color.White;
            this.label20.Location = new Point(842, 9);
            this.label20.Margin = new Padding(0);
            this.label20.Name = "label20";
            this.label20.Size = new Size(45, 39);
            this.label20.TabIndex = 43;
            this.label20.Text = "H";
            this.label20.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label21.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.label21.ForeColor = Color.White;
            this.label21.Location = new Point(797, 9);
            this.label21.Margin = new Padding(2, 0, 0, 0);
            this.label21.Name = "label21";
            this.label21.Size = new Size(45, 39);
            this.label21.TabIndex = 42;
            this.label21.Text = "R";
            this.label21.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lb9thInning
            // 
            this.lb9thInning.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lb9thInning.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.lb9thInning.ForeColor = Color.White;
            this.lb9thInning.Location = new Point(750, 9);
            this.lb9thInning.Margin = new Padding(0);
            this.lb9thInning.Name = "lb9thInning";
            this.lb9thInning.Size = new Size(45, 39);
            this.lb9thInning.TabIndex = 41;
            this.lb9thInning.Text = "10";
            this.lb9thInning.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lb8thInning
            // 
            this.lb8thInning.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lb8thInning.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.lb8thInning.ForeColor = Color.White;
            this.lb8thInning.Location = new Point(705, 9);
            this.lb8thInning.Margin = new Padding(0);
            this.lb8thInning.Name = "lb8thInning";
            this.lb8thInning.Size = new Size(45, 39);
            this.lb8thInning.TabIndex = 40;
            this.lb8thInning.Text = "9";
            this.lb8thInning.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lb7thInning
            // 
            this.lb7thInning.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lb7thInning.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.lb7thInning.ForeColor = Color.White;
            this.lb7thInning.Location = new Point(660, 9);
            this.lb7thInning.Margin = new Padding(0);
            this.lb7thInning.Name = "lb7thInning";
            this.lb7thInning.Size = new Size(45, 39);
            this.lb7thInning.TabIndex = 39;
            this.lb7thInning.Text = "8";
            this.lb7thInning.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lb6thInning
            // 
            this.lb6thInning.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lb6thInning.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.lb6thInning.ForeColor = Color.White;
            this.lb6thInning.Location = new Point(615, 9);
            this.lb6thInning.Margin = new Padding(0);
            this.lb6thInning.Name = "lb6thInning";
            this.lb6thInning.Size = new Size(45, 39);
            this.lb6thInning.TabIndex = 38;
            this.lb6thInning.Text = "7";
            this.lb6thInning.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lb5thInning
            // 
            this.lb5thInning.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lb5thInning.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.lb5thInning.ForeColor = Color.White;
            this.lb5thInning.Location = new Point(570, 9);
            this.lb5thInning.Margin = new Padding(0);
            this.lb5thInning.Name = "lb5thInning";
            this.lb5thInning.Size = new Size(45, 39);
            this.lb5thInning.TabIndex = 37;
            this.lb5thInning.Text = "6";
            this.lb5thInning.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lb4thInning
            // 
            this.lb4thInning.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lb4thInning.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.lb4thInning.ForeColor = Color.White;
            this.lb4thInning.Location = new Point(525, 9);
            this.lb4thInning.Margin = new Padding(0);
            this.lb4thInning.Name = "lb4thInning";
            this.lb4thInning.Size = new Size(45, 39);
            this.lb4thInning.TabIndex = 36;
            this.lb4thInning.Text = "5";
            this.lb4thInning.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lb3rdInning
            // 
            this.lb3rdInning.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lb3rdInning.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.lb3rdInning.ForeColor = Color.White;
            this.lb3rdInning.Location = new Point(480, 9);
            this.lb3rdInning.Margin = new Padding(0);
            this.lb3rdInning.Name = "lb3rdInning";
            this.lb3rdInning.Size = new Size(45, 39);
            this.lb3rdInning.TabIndex = 35;
            this.lb3rdInning.Text = "4";
            this.lb3rdInning.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lb2ndInning
            // 
            this.lb2ndInning.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lb2ndInning.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.lb2ndInning.ForeColor = Color.White;
            this.lb2ndInning.Location = new Point(435, 9);
            this.lb2ndInning.Margin = new Padding(0);
            this.lb2ndInning.Name = "lb2ndInning";
            this.lb2ndInning.Size = new Size(45, 39);
            this.lb2ndInning.TabIndex = 34;
            this.lb2ndInning.Text = "3";
            this.lb2ndInning.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lb1stInning
            // 
            this.lb1stInning.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lb1stInning.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.lb1stInning.ForeColor = Color.White;
            this.lb1stInning.Location = new Point(390, 9);
            this.lb1stInning.Margin = new Padding(0);
            this.lb1stInning.Name = "lb1stInning";
            this.lb1stInning.Size = new Size(45, 39);
            this.lb1stInning.TabIndex = 33;
            this.lb1stInning.Text = "2";
            this.lb1stInning.TextAlign = ContentAlignment.MiddleCenter;
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
            this.panelScoreBoard.Dock = DockStyle.Top;
            this.panelScoreBoard.Location = new Point(0, 0);
            this.panelScoreBoard.Margin = new Padding(3, 1, 3, 3);
            this.panelScoreBoard.Name = "panelScoreBoard";
            this.panelScoreBoard.Size = new Size(1423, 138);
            this.panelScoreBoard.TabIndex = 45;
            // 
            // panel18
            // 
            this.panel18.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.panel18.Controls.Add(this.panelNextAwayBatters);
            this.panel18.Controls.Add(this.AwayTeamNextBatters);
            this.panel18.Location = new Point(900, 0);
            this.panel18.Name = "panel18";
            this.panel18.Size = new Size(260, 138);
            this.panel18.TabIndex = 1;
            // 
            // panelNextAwayBatters
            // 
            this.panelNextAwayBatters.BackColor = Color.White;
            this.panelNextAwayBatters.Controls.Add(this.panel22);
            this.panelNextAwayBatters.Controls.Add(this.panel21);
            this.panelNextAwayBatters.Controls.Add(this.panel20);
            this.panelNextAwayBatters.Dock = DockStyle.Bottom;
            this.panelNextAwayBatters.ForeColor = Color.White;
            this.panelNextAwayBatters.Location = new Point(0, 33);
            this.panelNextAwayBatters.Name = "panelNextAwayBatters";
            this.panelNextAwayBatters.Size = new Size(260, 105);
            this.panelNextAwayBatters.TabIndex = 1;
            // 
            // panel22
            // 
            this.panel22.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panel22.Controls.Add(this.AwayNext3Stats);
            this.panel22.Controls.Add(this.AwayNext3);
            this.panel22.Controls.Add(this.AwayNextNumber3);
            this.panel22.Location = new Point(0, 62);
            this.panel22.Name = "panel22";
            this.panel22.Size = new Size(260, 30);
            this.panel22.TabIndex = 47;
            // 
            // AwayNext3Stats
            // 
            this.AwayNext3Stats.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.AwayNext3Stats.ForeColor = Color.White;
            this.AwayNext3Stats.Location = new Point(170, 5);
            this.AwayNext3Stats.Margin = new Padding(3, 5, 1, 5);
            this.AwayNext3Stats.Name = "AwayNext3Stats";
            this.AwayNext3Stats.Size = new Size(86, 20);
            this.AwayNext3Stats.TabIndex = 6;
            this.AwayNext3Stats.Text = "0";
            this.AwayNext3Stats.TextAlign = ContentAlignment.MiddleRight;
            // 
            // AwayNext3
            // 
            this.AwayNext3.Font = new Font("MicroFLF", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.AwayNext3.ForeColor = Color.White;
            this.AwayNext3.Location = new Point(32, 7);
            this.AwayNext3.Margin = new Padding(3, 5, 1, 5);
            this.AwayNext3.Name = "AwayNext3";
            this.AwayNext3.Size = new Size(149, 20);
            this.AwayNext3.TabIndex = 3;
            this.AwayNext3.Text = "0";
            // 
            // AwayNextNumber3
            // 
            this.AwayNextNumber3.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.AwayNextNumber3.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.AwayNextNumber3.Location = new Point(3, 5);
            this.AwayNextNumber3.Margin = new Padding(3, 5, 1, 5);
            this.AwayNextNumber3.Name = "AwayNextNumber3";
            this.AwayNextNumber3.Size = new Size(30, 20);
            this.AwayNextNumber3.TabIndex = 1;
            this.AwayNextNumber3.Text = "1.";
            this.AwayNextNumber3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel21
            // 
            this.panel21.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panel21.Controls.Add(this.AwayNext2Stats);
            this.panel21.Controls.Add(this.AwayNext2);
            this.panel21.Controls.Add(this.AwayNextNumber2);
            this.panel21.Location = new Point(0, 31);
            this.panel21.Name = "panel21";
            this.panel21.Size = new Size(260, 30);
            this.panel21.TabIndex = 46;
            // 
            // AwayNext2Stats
            // 
            this.AwayNext2Stats.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.AwayNext2Stats.ForeColor = Color.White;
            this.AwayNext2Stats.Location = new Point(170, 5);
            this.AwayNext2Stats.Margin = new Padding(3, 5, 1, 5);
            this.AwayNext2Stats.Name = "AwayNext2Stats";
            this.AwayNext2Stats.Size = new Size(86, 20);
            this.AwayNext2Stats.TabIndex = 6;
            this.AwayNext2Stats.Text = "0";
            this.AwayNext2Stats.TextAlign = ContentAlignment.MiddleRight;
            // 
            // AwayNext2
            // 
            this.AwayNext2.Font = new Font("MicroFLF", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.AwayNext2.ForeColor = Color.White;
            this.AwayNext2.Location = new Point(32, 7);
            this.AwayNext2.Margin = new Padding(3, 5, 1, 5);
            this.AwayNext2.Name = "AwayNext2";
            this.AwayNext2.Size = new Size(149, 20);
            this.AwayNext2.TabIndex = 3;
            this.AwayNext2.Text = "0";
            // 
            // AwayNextNumber2
            // 
            this.AwayNextNumber2.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.AwayNextNumber2.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.AwayNextNumber2.Location = new Point(3, 5);
            this.AwayNextNumber2.Margin = new Padding(3, 5, 1, 5);
            this.AwayNextNumber2.Name = "AwayNextNumber2";
            this.AwayNextNumber2.Size = new Size(30, 20);
            this.AwayNextNumber2.TabIndex = 1;
            this.AwayNextNumber2.Text = "1.";
            this.AwayNextNumber2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel20
            // 
            this.panel20.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panel20.Controls.Add(this.AwayNext1Stats);
            this.panel20.Controls.Add(this.AwayNext1);
            this.panel20.Controls.Add(this.AwayNextNumber1);
            this.panel20.Dock = DockStyle.Top;
            this.panel20.Location = new Point(0, 0);
            this.panel20.Name = "panel20";
            this.panel20.Size = new Size(260, 30);
            this.panel20.TabIndex = 45;
            // 
            // AwayNext1Stats
            // 
            this.AwayNext1Stats.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.AwayNext1Stats.ForeColor = Color.White;
            this.AwayNext1Stats.Location = new Point(170, 5);
            this.AwayNext1Stats.Margin = new Padding(3, 5, 1, 5);
            this.AwayNext1Stats.Name = "AwayNext1Stats";
            this.AwayNext1Stats.Size = new Size(86, 20);
            this.AwayNext1Stats.TabIndex = 5;
            this.AwayNext1Stats.Text = "0";
            this.AwayNext1Stats.TextAlign = ContentAlignment.MiddleRight;
            // 
            // AwayNext1
            // 
            this.AwayNext1.Font = new Font("MicroFLF", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.AwayNext1.ForeColor = Color.White;
            this.AwayNext1.Location = new Point(32, 7);
            this.AwayNext1.Margin = new Padding(3, 5, 1, 5);
            this.AwayNext1.Name = "AwayNext1";
            this.AwayNext1.Size = new Size(149, 20);
            this.AwayNext1.TabIndex = 3;
            this.AwayNext1.Text = "0";
            // 
            // AwayNextNumber1
            // 
            this.AwayNextNumber1.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.AwayNextNumber1.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.AwayNextNumber1.Location = new Point(3, 5);
            this.AwayNextNumber1.Margin = new Padding(3, 5, 1, 5);
            this.AwayNextNumber1.Name = "AwayNextNumber1";
            this.AwayNextNumber1.Size = new Size(30, 20);
            this.AwayNextNumber1.TabIndex = 1;
            this.AwayNextNumber1.Text = "1.";
            this.AwayNextNumber1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AwayTeamNextBatters
            // 
            this.AwayTeamNextBatters.Controls.Add(this.away_DueUP);
            this.AwayTeamNextBatters.Dock = DockStyle.Top;
            this.AwayTeamNextBatters.Location = new Point(0, 0);
            this.AwayTeamNextBatters.Name = "AwayTeamNextBatters";
            this.AwayTeamNextBatters.Size = new Size(260, 30);
            this.AwayTeamNextBatters.TabIndex = 0;
            // 
            // away_DueUP
            // 
            this.away_DueUP.Dock = DockStyle.Fill;
            this.away_DueUP.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.away_DueUP.ForeColor = Color.White;
            this.away_DueUP.Location = new Point(0, 0);
            this.away_DueUP.Name = "away_DueUP";
            this.away_DueUP.Size = new Size(260, 30);
            this.away_DueUP.TabIndex = 0;
            this.away_DueUP.Text = "label32";
            this.away_DueUP.TextAlign = ContentAlignment.MiddleCenter;
            this.away_DueUP.BackColorChanged += new EventHandler(this.BackColorChanging_label);
            // 
            // panel16
            // 
            this.panel16.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.panel16.Controls.Add(this.panelNextHomeBatters);
            this.panel16.Controls.Add(this.homeTeamNextBatters);
            this.panel16.Location = new Point(1163, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new Size(260, 138);
            this.panel16.TabIndex = 0;
            // 
            // panelNextHomeBatters
            // 
            this.panelNextHomeBatters.BackColor = Color.White;
            this.panelNextHomeBatters.Controls.Add(this.panel23);
            this.panelNextHomeBatters.Controls.Add(this.panel24);
            this.panelNextHomeBatters.Controls.Add(this.panel25);
            this.panelNextHomeBatters.Dock = DockStyle.Bottom;
            this.panelNextHomeBatters.ForeColor = Color.White;
            this.panelNextHomeBatters.Location = new Point(0, 33);
            this.panelNextHomeBatters.Name = "panelNextHomeBatters";
            this.panelNextHomeBatters.Size = new Size(260, 105);
            this.panelNextHomeBatters.TabIndex = 2;
            // 
            // panel23
            // 
            this.panel23.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panel23.Controls.Add(this.HomeNext3Stats);
            this.panel23.Controls.Add(this.homeNext3);
            this.panel23.Controls.Add(this.homeNextNumber3);
            this.panel23.Location = new Point(0, 62);
            this.panel23.Name = "panel23";
            this.panel23.Size = new Size(260, 30);
            this.panel23.TabIndex = 50;
            // 
            // HomeNext3Stats
            // 
            this.HomeNext3Stats.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.HomeNext3Stats.ForeColor = Color.White;
            this.HomeNext3Stats.Location = new Point(170, 5);
            this.HomeNext3Stats.Margin = new Padding(3, 5, 1, 5);
            this.HomeNext3Stats.Name = "HomeNext3Stats";
            this.HomeNext3Stats.Size = new Size(86, 20);
            this.HomeNext3Stats.TabIndex = 8;
            this.HomeNext3Stats.Text = "0";
            this.HomeNext3Stats.TextAlign = ContentAlignment.MiddleRight;
            // 
            // homeNext3
            // 
            this.homeNext3.Font = new Font("MicroFLF", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.homeNext3.ForeColor = Color.White;
            this.homeNext3.Location = new Point(32, 7);
            this.homeNext3.Margin = new Padding(3, 5, 1, 5);
            this.homeNext3.Name = "homeNext3";
            this.homeNext3.Size = new Size(149, 20);
            this.homeNext3.TabIndex = 3;
            this.homeNext3.Text = "0";
            // 
            // homeNextNumber3
            // 
            this.homeNextNumber3.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.homeNextNumber3.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.homeNextNumber3.Location = new Point(3, 5);
            this.homeNextNumber3.Margin = new Padding(3, 5, 1, 5);
            this.homeNextNumber3.Name = "homeNextNumber3";
            this.homeNextNumber3.Size = new Size(30, 20);
            this.homeNextNumber3.TabIndex = 1;
            this.homeNextNumber3.Text = "1.";
            this.homeNextNumber3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel24
            // 
            this.panel24.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panel24.Controls.Add(this.HomeNext2Stats);
            this.panel24.Controls.Add(this.homeNext2);
            this.panel24.Controls.Add(this.homeNextNumber2);
            this.panel24.Location = new Point(0, 31);
            this.panel24.Name = "panel24";
            this.panel24.Size = new Size(260, 30);
            this.panel24.TabIndex = 49;
            // 
            // HomeNext2Stats
            // 
            this.HomeNext2Stats.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.HomeNext2Stats.ForeColor = Color.White;
            this.HomeNext2Stats.Location = new Point(170, 5);
            this.HomeNext2Stats.Margin = new Padding(3, 5, 1, 5);
            this.HomeNext2Stats.Name = "HomeNext2Stats";
            this.HomeNext2Stats.Size = new Size(86, 20);
            this.HomeNext2Stats.TabIndex = 8;
            this.HomeNext2Stats.Text = "0";
            this.HomeNext2Stats.TextAlign = ContentAlignment.MiddleRight;
            // 
            // homeNext2
            // 
            this.homeNext2.Font = new Font("MicroFLF", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.homeNext2.ForeColor = Color.White;
            this.homeNext2.Location = new Point(32, 7);
            this.homeNext2.Margin = new Padding(3, 5, 1, 5);
            this.homeNext2.Name = "homeNext2";
            this.homeNext2.Size = new Size(149, 20);
            this.homeNext2.TabIndex = 3;
            this.homeNext2.Text = "0";
            // 
            // homeNextNumber2
            // 
            this.homeNextNumber2.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.homeNextNumber2.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.homeNextNumber2.Location = new Point(3, 5);
            this.homeNextNumber2.Margin = new Padding(3, 5, 1, 5);
            this.homeNextNumber2.Name = "homeNextNumber2";
            this.homeNextNumber2.Size = new Size(30, 20);
            this.homeNextNumber2.TabIndex = 1;
            this.homeNextNumber2.Text = "1.";
            this.homeNextNumber2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel25
            // 
            this.panel25.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panel25.Controls.Add(this.HomeNext1Stats);
            this.panel25.Controls.Add(this.label33);
            this.panel25.Controls.Add(this.label34);
            this.panel25.Controls.Add(this.homeNext1);
            this.panel25.Controls.Add(this.homeNextNumber1);
            this.panel25.Dock = DockStyle.Top;
            this.panel25.Location = new Point(0, 0);
            this.panel25.Name = "panel25";
            this.panel25.Size = new Size(260, 30);
            this.panel25.TabIndex = 48;
            // 
            // HomeNext1Stats
            // 
            this.HomeNext1Stats.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.HomeNext1Stats.ForeColor = Color.White;
            this.HomeNext1Stats.Location = new Point(170, 5);
            this.HomeNext1Stats.Margin = new Padding(3, 5, 1, 5);
            this.HomeNext1Stats.Name = "HomeNext1Stats";
            this.HomeNext1Stats.Size = new Size(86, 20);
            this.HomeNext1Stats.TabIndex = 7;
            this.HomeNext1Stats.Text = "0";
            this.HomeNext1Stats.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label33
            // 
            this.label33.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = Color.White;
            this.label33.Location = new Point(179, 5);
            this.label33.Margin = new Padding(3, 5, 1, 5);
            this.label33.Name = "label33";
            this.label33.Size = new Size(71, 20);
            this.label33.TabIndex = 8;
            this.label33.Text = "0";
            this.label33.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label34
            // 
            this.label34.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = Color.White;
            this.label34.Location = new Point(179, 5);
            this.label34.Margin = new Padding(3, 5, 1, 5);
            this.label34.Name = "label34";
            this.label34.Size = new Size(71, 20);
            this.label34.TabIndex = 9;
            this.label34.Text = "0";
            this.label34.TextAlign = ContentAlignment.MiddleRight;
            // 
            // homeNext1
            // 
            this.homeNext1.Font = new Font("MicroFLF", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.homeNext1.ForeColor = Color.White;
            this.homeNext1.Location = new Point(32, 7);
            this.homeNext1.Margin = new Padding(3, 5, 1, 5);
            this.homeNext1.Name = "homeNext1";
            this.homeNext1.Size = new Size(149, 20);
            this.homeNext1.TabIndex = 3;
            this.homeNext1.Text = "0";
            // 
            // homeNextNumber1
            // 
            this.homeNextNumber1.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.homeNextNumber1.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.homeNextNumber1.Location = new Point(3, 5);
            this.homeNextNumber1.Margin = new Padding(3, 5, 1, 5);
            this.homeNextNumber1.Name = "homeNextNumber1";
            this.homeNextNumber1.Size = new Size(30, 20);
            this.homeNextNumber1.TabIndex = 1;
            this.homeNextNumber1.Text = "1.";
            this.homeNextNumber1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // homeTeamNextBatters
            // 
            this.homeTeamNextBatters.Controls.Add(this.home_DueUP);
            this.homeTeamNextBatters.Dock = DockStyle.Top;
            this.homeTeamNextBatters.Location = new Point(0, 0);
            this.homeTeamNextBatters.Name = "homeTeamNextBatters";
            this.homeTeamNextBatters.Size = new Size(260, 30);
            this.homeTeamNextBatters.TabIndex = 0;
            // 
            // home_DueUP
            // 
            this.home_DueUP.Dock = DockStyle.Fill;
            this.home_DueUP.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.home_DueUP.ForeColor = Color.White;
            this.home_DueUP.Location = new Point(0, 0);
            this.home_DueUP.Name = "home_DueUP";
            this.home_DueUP.Size = new Size(260, 30);
            this.home_DueUP.TabIndex = 0;
            this.home_DueUP.Text = "label32";
            this.home_DueUP.TextAlign = ContentAlignment.MiddleCenter;
            this.home_DueUP.BackColorChanged += new EventHandler(this.BackColorChanging_label);
            // 
            // label23
            // 
            this.label23.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = Color.Gainsboro;
            this.label23.Location = new Point(305, 98);
            this.label23.Margin = new Padding(3, 5, 3, 5);
            this.label23.Name = "label23";
            this.label23.Size = new Size(78, 31);
            this.label23.TabIndex = 46;
            this.label23.TextAlign = ContentAlignment.MiddleRight;
            this.label23.BackColorChanged += new EventHandler(this.BackColorChanging_label);
            // 
            // label22
            // 
            this.label22.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = Color.Gainsboro;
            this.label22.Location = new Point(305, 57);
            this.label22.Margin = new Padding(3, 5, 3, 5);
            this.label22.Name = "label22";
            this.label22.Size = new Size(78, 31);
            this.label22.TabIndex = 45;
            this.label22.TextAlign = ContentAlignment.MiddleRight;
            this.label22.BackColorChanged += new EventHandler(this.BackColorChanging_label);
            // 
            // label28
            // 
            this.label28.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label28.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.label28.ForeColor = Color.White;
            this.label28.Location = new Point(887, 9);
            this.label28.Margin = new Padding(0);
            this.label28.Name = "label28";
            this.label28.Size = new Size(60, 39);
            this.label28.TabIndex = 107;
            this.label28.Text = "LOB";
            this.label28.TextAlign = ContentAlignment.MiddleCenter;
            this.label28.Visible = false;
            // 
            // awayLOB
            // 
            this.awayLOB.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.awayLOB.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.awayLOB.ForeColor = Color.White;
            this.awayLOB.Location = new Point(887, 53);
            this.awayLOB.Margin = new Padding(0);
            this.awayLOB.Name = "awayLOB";
            this.awayLOB.Size = new Size(60, 39);
            this.awayLOB.TabIndex = 105;
            this.awayLOB.TextAlign = ContentAlignment.MiddleCenter;
            this.awayLOB.Visible = false;
            // 
            // homeLOB
            // 
            this.homeLOB.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.homeLOB.Font = new Font("Segoe UI", 16.75F, FontStyle.Bold);
            this.homeLOB.ForeColor = Color.White;
            this.homeLOB.Location = new Point(887, 94);
            this.homeLOB.Margin = new Padding(0);
            this.homeLOB.Name = "homeLOB";
            this.homeLOB.Size = new Size(60, 39);
            this.homeLOB.TabIndex = 106;
            this.homeLOB.TextAlign = ContentAlignment.MiddleCenter;
            this.homeLOB.Visible = false;
            // 
            // panelCurrentPitcher
            // 
            this.panelCurrentPitcher.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.panelCurrentPitcher.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
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
            this.panelCurrentPitcher.Location = new Point(1179, 167);
            this.panelCurrentPitcher.Name = "panelCurrentPitcher";
            this.panelCurrentPitcher.Size = new Size(234, 219);
            this.panelCurrentPitcher.TabIndex = 48;
            // 
            // PitcherGS
            // 
            this.PitcherGS.Font = new Font("MicroFLF", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.PitcherGS.ForeColor = Color.White;
            this.PitcherGS.Location = new Point(166, 76);
            this.PitcherGS.Margin = new Padding(3, 5, 1, 5);
            this.PitcherGS.Name = "PitcherGS";
            this.PitcherGS.Size = new Size(65, 15);
            this.PitcherGS.TabIndex = 29;
            this.PitcherGS.Text = "0";
            this.PitcherGS.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelGS
            // 
            this.labelGS.AutoSize = true;
            this.labelGS.Font = new Font("MicroFLF", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.labelGS.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.labelGS.Location = new Point(10, 76);
            this.labelGS.Name = "labelGS";
            this.labelGS.Size = new Size(116, 15);
            this.labelGS.TabIndex = 28;
            this.labelGS.Text = "GAMES STARTED";
            // 
            // PitcherRecord
            // 
            this.PitcherRecord.Font = new Font("MicroFLF", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.PitcherRecord.ForeColor = Color.White;
            this.PitcherRecord.Location = new Point(166, 91);
            this.PitcherRecord.Margin = new Padding(3, 5, 1, 5);
            this.PitcherRecord.Name = "PitcherRecord";
            this.PitcherRecord.Size = new Size(65, 15);
            this.PitcherRecord.TabIndex = 27;
            this.PitcherRecord.Text = "0";
            this.PitcherRecord.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelRecord
            // 
            this.labelRecord.AutoSize = true;
            this.labelRecord.Font = new Font("MicroFLF", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.labelRecord.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.labelRecord.Location = new Point(10, 91);
            this.labelRecord.Name = "labelRecord";
            this.labelRecord.Size = new Size(59, 15);
            this.labelRecord.TabIndex = 26;
            this.labelRecord.Text = "RECORD";
            // 
            // label26
            // 
            this.label26.Font = new Font("MicroFLF", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label26.Location = new Point(109, 46);
            this.label26.Name = "label26";
            this.label26.Size = new Size(56, 15);
            this.label26.TabIndex = 25;
            this.label26.Text = "MATCH";
            this.label26.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.Font = new Font("MicroFLF", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label25.Location = new Point(174, 46);
            this.label25.Name = "label25";
            this.label25.Size = new Size(57, 15);
            this.label25.TabIndex = 24;
            this.label25.Text = "CAREER";
            this.label25.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PitcherHomeRunsToday
            // 
            this.PitcherHomeRunsToday.Font = new Font("MicroFLF", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.PitcherHomeRunsToday.ForeColor = Color.White;
            this.PitcherHomeRunsToday.Location = new Point(126, 166);
            this.PitcherHomeRunsToday.Margin = new Padding(3, 5, 1, 5);
            this.PitcherHomeRunsToday.Name = "PitcherHomeRunsToday";
            this.PitcherHomeRunsToday.Size = new Size(39, 15);
            this.PitcherHomeRunsToday.TabIndex = 23;
            this.PitcherHomeRunsToday.Text = "0";
            this.PitcherHomeRunsToday.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PitcherStrikeoutsToday
            // 
            this.PitcherStrikeoutsToday.Font = new Font("MicroFLF", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.PitcherStrikeoutsToday.ForeColor = Color.White;
            this.PitcherStrikeoutsToday.Location = new Point(126, 151);
            this.PitcherStrikeoutsToday.Margin = new Padding(3, 5, 1, 5);
            this.PitcherStrikeoutsToday.Name = "PitcherStrikeoutsToday";
            this.PitcherStrikeoutsToday.Size = new Size(39, 15);
            this.PitcherStrikeoutsToday.TabIndex = 22;
            this.PitcherStrikeoutsToday.Text = "0";
            this.PitcherStrikeoutsToday.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PitcherWalksToday
            // 
            this.PitcherWalksToday.Font = new Font("MicroFLF", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.PitcherWalksToday.ForeColor = Color.White;
            this.PitcherWalksToday.Location = new Point(126, 136);
            this.PitcherWalksToday.Margin = new Padding(3, 5, 1, 5);
            this.PitcherWalksToday.Name = "PitcherWalksToday";
            this.PitcherWalksToday.Size = new Size(39, 15);
            this.PitcherWalksToday.TabIndex = 21;
            this.PitcherWalksToday.Text = "0";
            this.PitcherWalksToday.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PitcherIPToday
            // 
            this.PitcherIPToday.Font = new Font("MicroFLF", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.PitcherIPToday.ForeColor = Color.White;
            this.PitcherIPToday.Location = new Point(126, 121);
            this.PitcherIPToday.Margin = new Padding(3, 5, 1, 5);
            this.PitcherIPToday.Name = "PitcherIPToday";
            this.PitcherIPToday.Size = new Size(39, 15);
            this.PitcherIPToday.TabIndex = 20;
            this.PitcherIPToday.Text = "0";
            this.PitcherIPToday.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PitcherBAA
            // 
            this.PitcherBAA.Font = new Font("MicroFLF", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.PitcherBAA.ForeColor = Color.White;
            this.PitcherBAA.Location = new Point(166, 196);
            this.PitcherBAA.Margin = new Padding(3, 5, 1, 5);
            this.PitcherBAA.Name = "PitcherBAA";
            this.PitcherBAA.Size = new Size(65, 15);
            this.PitcherBAA.TabIndex = 17;
            this.PitcherBAA.Text = "0";
            this.PitcherBAA.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PitcherWHIP
            // 
            this.PitcherWHIP.Font = new Font("MicroFLF", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.PitcherWHIP.ForeColor = Color.White;
            this.PitcherWHIP.Location = new Point(166, 181);
            this.PitcherWHIP.Margin = new Padding(3, 5, 1, 5);
            this.PitcherWHIP.Name = "PitcherWHIP";
            this.PitcherWHIP.Size = new Size(65, 15);
            this.PitcherWHIP.TabIndex = 16;
            this.PitcherWHIP.Text = "0";
            this.PitcherWHIP.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PitcherHomeRuns
            // 
            this.PitcherHomeRuns.Font = new Font("MicroFLF", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.PitcherHomeRuns.ForeColor = Color.White;
            this.PitcherHomeRuns.Location = new Point(166, 166);
            this.PitcherHomeRuns.Margin = new Padding(3, 5, 1, 5);
            this.PitcherHomeRuns.Name = "PitcherHomeRuns";
            this.PitcherHomeRuns.Size = new Size(65, 15);
            this.PitcherHomeRuns.TabIndex = 15;
            this.PitcherHomeRuns.Text = "0";
            this.PitcherHomeRuns.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PitcherStrikeouts
            // 
            this.PitcherStrikeouts.Font = new Font("MicroFLF", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.PitcherStrikeouts.ForeColor = Color.White;
            this.PitcherStrikeouts.Location = new Point(166, 151);
            this.PitcherStrikeouts.Margin = new Padding(3, 5, 1, 5);
            this.PitcherStrikeouts.Name = "PitcherStrikeouts";
            this.PitcherStrikeouts.Size = new Size(65, 15);
            this.PitcherStrikeouts.TabIndex = 14;
            this.PitcherStrikeouts.Text = "0";
            this.PitcherStrikeouts.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PitcherWalks
            // 
            this.PitcherWalks.Font = new Font("MicroFLF", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.PitcherWalks.ForeColor = Color.White;
            this.PitcherWalks.Location = new Point(166, 136);
            this.PitcherWalks.Margin = new Padding(3, 5, 1, 5);
            this.PitcherWalks.Name = "PitcherWalks";
            this.PitcherWalks.Size = new Size(65, 15);
            this.PitcherWalks.TabIndex = 13;
            this.PitcherWalks.Text = "0";
            this.PitcherWalks.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PitcherIP
            // 
            this.PitcherIP.Font = new Font("MicroFLF", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.PitcherIP.ForeColor = Color.White;
            this.PitcherIP.Location = new Point(166, 121);
            this.PitcherIP.Margin = new Padding(3, 5, 1, 5);
            this.PitcherIP.Name = "PitcherIP";
            this.PitcherIP.Size = new Size(65, 15);
            this.PitcherIP.TabIndex = 12;
            this.PitcherIP.Text = "0";
            this.PitcherIP.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PitcherERA
            // 
            this.PitcherERA.Font = new Font("MicroFLF", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.PitcherERA.ForeColor = Color.White;
            this.PitcherERA.Location = new Point(166, 106);
            this.PitcherERA.Margin = new Padding(3, 5, 1, 5);
            this.PitcherERA.Name = "PitcherERA";
            this.PitcherERA.Size = new Size(65, 15);
            this.PitcherERA.TabIndex = 11;
            this.PitcherERA.Text = "0";
            this.PitcherERA.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PitcherGames
            // 
            this.PitcherGames.Font = new Font("MicroFLF", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.PitcherGames.ForeColor = Color.White;
            this.PitcherGames.Location = new Point(166, 61);
            this.PitcherGames.Margin = new Padding(3, 5, 1, 5);
            this.PitcherGames.Name = "PitcherGames";
            this.PitcherGames.Size = new Size(65, 15);
            this.PitcherGames.TabIndex = 10;
            this.PitcherGames.Text = "0";
            this.PitcherGames.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new Font("MicroFLF", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label43.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label43.Location = new Point(10, 196);
            this.label43.Name = "label43";
            this.label43.Size = new Size(111, 15);
            this.label43.TabIndex = 9;
            this.label43.Text = "OPPONENT AVG";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new Font("MicroFLF", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label42.Location = new Point(10, 181);
            this.label42.Name = "label42";
            this.label42.Size = new Size(41, 15);
            this.label42.TabIndex = 8;
            this.label42.Text = "WHIP";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new Font("MicroFLF", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label41.Location = new Point(10, 166);
            this.label41.Name = "label41";
            this.label41.Size = new Size(86, 15);
            this.label41.TabIndex = 7;
            this.label41.Text = "HOME RUNS";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new Font("MicroFLF", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label40.Location = new Point(10, 151);
            this.label40.Name = "label40";
            this.label40.Size = new Size(87, 15);
            this.label40.TabIndex = 6;
            this.label40.Text = "STRIKEOUTS";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new Font("MicroFLF", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label39.Location = new Point(10, 136);
            this.label39.Name = "label39";
            this.label39.Size = new Size(55, 15);
            this.label39.TabIndex = 5;
            this.label39.Text = "WALKS";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new Font("MicroFLF", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label38.Location = new Point(10, 121);
            this.label38.Name = "label38";
            this.label38.Size = new Size(63, 15);
            this.label38.TabIndex = 4;
            this.label38.Text = "INNINGS";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new Font("MicroFLF", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.label35.Location = new Point(10, 106);
            this.label35.Name = "label35";
            this.label35.Size = new Size(32, 15);
            this.label35.TabIndex = 3;
            this.label35.Text = "ERA";
            // 
            // labelGames
            // 
            this.labelGames.Font = new Font("MicroFLF", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.labelGames.ForeColor = Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.labelGames.Location = new Point(10, 61);
            this.labelGames.Name = "labelGames";
            this.labelGames.Size = new Size(57, 15);
            this.labelGames.TabIndex = 2;
            this.labelGames.Text = "GAMES";
            // 
            // PitchingTeamColor
            // 
            this.PitchingTeamColor.Controls.Add(this.PitcherName);
            this.PitchingTeamColor.Controls.Add(this.PitchingTeam);
            this.PitchingTeamColor.Dock = DockStyle.Top;
            this.PitchingTeamColor.Location = new Point(0, 0);
            this.PitchingTeamColor.Name = "PitchingTeamColor";
            this.PitchingTeamColor.Size = new Size(234, 43);
            this.PitchingTeamColor.TabIndex = 0;
            // 
            // PitcherName
            // 
            this.PitcherName.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.PitcherName.ForeColor = Color.White;
            this.PitcherName.Location = new Point(46, 3);
            this.PitcherName.Name = "PitcherName";
            this.PitcherName.Size = new Size(178, 39);
            this.PitcherName.TabIndex = 8;
            this.PitcherName.Text = "Player";
            this.PitcherName.TextAlign = ContentAlignment.MiddleLeft;
            this.PitcherName.BackColorChanged += new EventHandler(this.BackColorChanging_label);
            // 
            // PitchingTeam
            // 
            this.PitchingTeam.BackgroundImageLayout = ImageLayout.Stretch;
            this.PitchingTeam.Location = new Point(3, 3);
            this.PitchingTeam.Margin = new Padding(3, 3, 3, 1);
            this.PitchingTeam.Name = "PitchingTeam";
            this.PitchingTeam.Size = new Size(37, 37);
            this.PitchingTeam.TabIndex = 7;
            // 
            // PitcherPhoto
            // 
            this.PitcherPhoto.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.PitcherPhoto.BackgroundImageLayout = ImageLayout.Stretch;
            this.PitcherPhoto.Location = new Point(1033, 167);
            this.PitcherPhoto.Margin = new Padding(3, 3, 0, 3);
            this.PitcherPhoto.Name = "PitcherPhoto";
            this.PitcherPhoto.Size = new Size(146, 219);
            this.PitcherPhoto.TabIndex = 49;
            // 
            // panel2Base
            // 
            this.panel2Base.Controls.Add(this.lb_Runner2_Name);
            this.panel2Base.Controls.Add(this.panel31);
            this.panel2Base.Location = new Point(643, 144);
            this.panel2Base.Name = "panel2Base";
            this.panel2Base.Size = new Size(197, 100);
            this.panel2Base.TabIndex = 50;
            this.panel2Base.Visible = false;
            // 
            // lb_Runner2_Name
            // 
            this.lb_Runner2_Name.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lb_Runner2_Name.Dock = DockStyle.Fill;
            this.lb_Runner2_Name.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lb_Runner2_Name.ForeColor = Color.Gainsboro;
            this.lb_Runner2_Name.Location = new Point(0, 23);
            this.lb_Runner2_Name.Name = "lb_Runner2_Name";
            this.lb_Runner2_Name.Padding = new Padding(5, 5, 0, 0);
            this.lb_Runner2_Name.Size = new Size(197, 77);
            this.lb_Runner2_Name.TabIndex = 2;
            this.lb_Runner2_Name.Text = "label32";
            this.lb_Runner2_Name.Click += new EventHandler(this.lb_Runner2_Name_Click);
            // 
            // panel31
            // 
            this.panel31.Controls.Add(this.lb2ndBase);
            this.panel31.Dock = DockStyle.Top;
            this.panel31.Location = new Point(0, 0);
            this.panel31.Name = "panel31";
            this.panel31.Size = new Size(197, 23);
            this.panel31.TabIndex = 1;
            // 
            // lb2ndBase
            // 
            this.lb2ndBase.Dock = DockStyle.Fill;
            this.lb2ndBase.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lb2ndBase.ForeColor = Color.White;
            this.lb2ndBase.Location = new Point(0, 0);
            this.lb2ndBase.Name = "lb2ndBase";
            this.lb2ndBase.Size = new Size(197, 23);
            this.lb2ndBase.TabIndex = 0;
            this.lb2ndBase.Text = "2ND BASE";
            this.lb2ndBase.TextAlign = ContentAlignment.MiddleLeft;
            this.lb2ndBase.BackColorChanged += new EventHandler(this.BackColorChanging_label);
            // 
            // RunnerOn2Photo
            // 
            this.RunnerOn2Photo.BackgroundImageLayout = ImageLayout.Stretch;
            this.RunnerOn2Photo.Location = new Point(576, 144);
            this.RunnerOn2Photo.Name = "RunnerOn2Photo";
            this.RunnerOn2Photo.Size = new Size(67, 100);
            this.RunnerOn2Photo.TabIndex = 0;
            // 
            // panel1Base
            // 
            this.panel1Base.Controls.Add(this.lb_Runner1_Name);
            this.panel1Base.Controls.Add(this.panel33);
            this.panel1Base.Location = new Point(1214, 490);
            this.panel1Base.Margin = new Padding(0);
            this.panel1Base.Name = "panel1Base";
            this.panel1Base.Size = new Size(197, 100);
            this.panel1Base.TabIndex = 51;
            this.panel1Base.Visible = false;
            // 
            // lb_Runner1_Name
            // 
            this.lb_Runner1_Name.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lb_Runner1_Name.Dock = DockStyle.Bottom;
            this.lb_Runner1_Name.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lb_Runner1_Name.ForeColor = Color.Gainsboro;
            this.lb_Runner1_Name.Location = new Point(0, 23);
            this.lb_Runner1_Name.Name = "lb_Runner1_Name";
            this.lb_Runner1_Name.Padding = new Padding(5, 5, 0, 0);
            this.lb_Runner1_Name.Size = new Size(197, 77);
            this.lb_Runner1_Name.TabIndex = 2;
            this.lb_Runner1_Name.Text = "label44";
            this.lb_Runner1_Name.Click += new EventHandler(this.lb_Runner1_Name_Click);
            // 
            // panel33
            // 
            this.panel33.Controls.Add(this.lb1stBase);
            this.panel33.Dock = DockStyle.Top;
            this.panel33.Location = new Point(0, 0);
            this.panel33.Name = "panel33";
            this.panel33.Size = new Size(197, 23);
            this.panel33.TabIndex = 1;
            // 
            // lb1stBase
            // 
            this.lb1stBase.Dock = DockStyle.Fill;
            this.lb1stBase.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lb1stBase.ForeColor = Color.White;
            this.lb1stBase.Location = new Point(0, 0);
            this.lb1stBase.Name = "lb1stBase";
            this.lb1stBase.Size = new Size(197, 23);
            this.lb1stBase.TabIndex = 1;
            this.lb1stBase.Text = "1ST BASE";
            this.lb1stBase.TextAlign = ContentAlignment.MiddleLeft;
            this.lb1stBase.BackColorChanged += new EventHandler(this.BackColorChanging_label);
            // 
            // RunnerOn1Photo
            // 
            this.RunnerOn1Photo.BackgroundImageLayout = ImageLayout.Stretch;
            this.RunnerOn1Photo.Location = new Point(1147, 490);
            this.RunnerOn1Photo.Name = "RunnerOn1Photo";
            this.RunnerOn1Photo.Size = new Size(67, 100);
            this.RunnerOn1Photo.TabIndex = 0;
            // 
            // panel3Base
            // 
            this.panel3Base.Controls.Add(this.lb_Runner3_Name);
            this.panel3Base.Controls.Add(this.panel36);
            this.panel3Base.Location = new Point(79, 505);
            this.panel3Base.Name = "panel3Base";
            this.panel3Base.Size = new Size(197, 100);
            this.panel3Base.TabIndex = 52;
            this.panel3Base.Visible = false;
            // 
            // lb_Runner3_Name
            // 
            this.lb_Runner3_Name.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lb_Runner3_Name.Dock = DockStyle.Fill;
            this.lb_Runner3_Name.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lb_Runner3_Name.ForeColor = Color.Gainsboro;
            this.lb_Runner3_Name.Location = new Point(0, 23);
            this.lb_Runner3_Name.Name = "lb_Runner3_Name";
            this.lb_Runner3_Name.Padding = new Padding(5, 5, 0, 0);
            this.lb_Runner3_Name.Size = new Size(197, 77);
            this.lb_Runner3_Name.TabIndex = 2;
            this.lb_Runner3_Name.Text = "label45";
            // 
            // panel36
            // 
            this.panel36.Controls.Add(this.lb3rdBase);
            this.panel36.Dock = DockStyle.Top;
            this.panel36.Location = new Point(0, 0);
            this.panel36.Name = "panel36";
            this.panel36.Size = new Size(197, 23);
            this.panel36.TabIndex = 1;
            // 
            // lb3rdBase
            // 
            this.lb3rdBase.Dock = DockStyle.Fill;
            this.lb3rdBase.Font = new Font("MicroFLF", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lb3rdBase.ForeColor = Color.White;
            this.lb3rdBase.Location = new Point(0, 0);
            this.lb3rdBase.Name = "lb3rdBase";
            this.lb3rdBase.Size = new Size(197, 23);
            this.lb3rdBase.TabIndex = 1;
            this.lb3rdBase.Text = "3RD BASE";
            this.lb3rdBase.TextAlign = ContentAlignment.MiddleLeft;
            this.lb3rdBase.BackColorChanged += new EventHandler(this.BackColorChanging_label);
            // 
            // RunnerOn3Photo
            // 
            this.RunnerOn3Photo.BackgroundImageLayout = ImageLayout.Stretch;
            this.RunnerOn3Photo.Location = new Point(12, 505);
            this.RunnerOn3Photo.Name = "RunnerOn3Photo";
            this.RunnerOn3Photo.Size = new Size(67, 100);
            this.RunnerOn3Photo.TabIndex = 0;
            // 
            // label32
            // 
            this.label32.Dock = DockStyle.Left;
            this.label32.Font = new Font("MicroFLF", 12F);
            this.label32.Location = new Point(0, 0);
            this.label32.Margin = new Padding(3, 0, 0, 0);
            this.label32.MaximumSize = new Size(140, 31);
            this.label32.Name = "label32";
            this.label32.Size = new Size(124, 31);
            this.label32.TabIndex = 53;
            this.label32.Text = "Last At-bat:";
            this.label32.TextAlign = ContentAlignment.MiddleLeft;
            this.label32.BackColorChanged += new EventHandler(this.BackColorChanging_label);
            // 
            // label44
            // 
            this.label44.Dock = DockStyle.Right;
            this.label44.Font = new Font("MicroFLF", 14F);
            this.label44.ForeColor = Color.White;
            this.label44.Location = new Point(520, 0);
            this.label44.MaximumSize = new Size(400, 31);
            this.label44.Name = "label44";
            this.label44.Size = new Size(250, 31);
            this.label44.TabIndex = 54;
            this.label44.Text = "00";
            this.label44.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnBuntAttempt
            // 
            this.btnBuntAttempt.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnBuntAttempt.BackColor = Color.Gainsboro;
            this.btnBuntAttempt.FlatAppearance.BorderSize = 0;
            this.btnBuntAttempt.FlatStyle = FlatStyle.Flat;
            this.btnBuntAttempt.Font = new Font("MicroFLF", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.btnBuntAttempt.Location = new Point(388, 10);
            this.btnBuntAttempt.Name = "btnBuntAttempt";
            this.btnBuntAttempt.Size = new Size(300, 35);
            this.btnBuntAttempt.TabIndex = 55;
            this.btnBuntAttempt.TabStop = false;
            this.btnBuntAttempt.Text = "BUNT ATTEMPT";
            this.btnBuntAttempt.UseVisualStyleBackColor = false;
            this.btnBuntAttempt.Click += new EventHandler(this.btnBuntAttempt_Click);
            // 
            // btnStandings
            // 
            this.btnStandings.BackColor = Color.Gainsboro;
            this.btnStandings.FlatAppearance.BorderSize = 0;
            this.btnStandings.FlatStyle = FlatStyle.Flat;
            this.btnStandings.Font = new Font("MicroFLF", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.btnStandings.Location = new Point(12, 144);
            this.btnStandings.Name = "btnStandings";
            this.btnStandings.Size = new Size(300, 35);
            this.btnStandings.TabIndex = 56;
            this.btnStandings.Text = "CURRENT STANDINGS";
            this.btnStandings.UseVisualStyleBackColor = false;
            this.btnStandings.Click += new EventHandler(this.btnStandings_Click);
            // 
            // btnShowAvailablePitchers
            // 
            this.btnShowAvailablePitchers.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnShowAvailablePitchers.FlatAppearance.BorderSize = 0;
            this.btnShowAvailablePitchers.FlatStyle = FlatStyle.Flat;
            this.btnShowAvailablePitchers.Font = new Font("MicroFLF", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAvailablePitchers.ForeColor = Color.White;
            this.btnShowAvailablePitchers.Location = new Point(1033, 386);
            this.btnShowAvailablePitchers.Name = "btnShowAvailablePitchers";
            this.btnShowAvailablePitchers.Size = new Size(380, 35);
            this.btnShowAvailablePitchers.TabIndex = 57;
            this.btnShowAvailablePitchers.Text = "CHANGE PITCHER";
            this.btnShowAvailablePitchers.UseVisualStyleBackColor = true;
            this.btnShowAvailablePitchers.Visible = false;
            this.btnShowAvailablePitchers.BackColorChanged += new EventHandler(this.BackColorChanging_label);
            this.btnShowAvailablePitchers.Click += new EventHandler(this.btnShowAvailablePitchers_Click);
            // 
            // btnOtherResults
            // 
            this.btnOtherResults.BackColor = Color.Gainsboro;
            this.btnOtherResults.FlatAppearance.BorderSize = 0;
            this.btnOtherResults.FlatStyle = FlatStyle.Flat;
            this.btnOtherResults.Font = new Font("MicroFLF", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.btnOtherResults.Location = new Point(12, 185);
            this.btnOtherResults.Name = "btnOtherResults";
            this.btnOtherResults.Size = new Size(300, 35);
            this.btnOtherResults.TabIndex = 59;
            this.btnOtherResults.Text = "SCHEDULE AND RESULTS";
            this.btnOtherResults.UseVisualStyleBackColor = false;
            this.btnOtherResults.Click += new EventHandler(this.btnOtherResults_Click);
            // 
            // btnPlayerStats
            // 
            this.btnPlayerStats.BackColor = Color.Gainsboro;
            this.btnPlayerStats.FlatAppearance.BorderSize = 0;
            this.btnPlayerStats.FlatStyle = FlatStyle.Flat;
            this.btnPlayerStats.Font = new Font("MicroFLF", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayerStats.Location = new Point(12, 226);
            this.btnPlayerStats.Name = "btnPlayerStats";
            this.btnPlayerStats.Size = new Size(300, 35);
            this.btnPlayerStats.TabIndex = 60;
            this.btnPlayerStats.Text = "PLAYER STATS";
            this.btnPlayerStats.UseVisualStyleBackColor = false;
            this.btnPlayerStats.Click += new EventHandler(this.btnPlayerStats_Click);
            // 
            // panel15
            // 
            this.panel15.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel15.Dock = DockStyle.Left;
            this.panel15.Location = new Point(124, 0);
            this.panel15.Margin = new Padding(0, 3, 3, 1);
            this.panel15.MaximumSize = new Size(31, 31);
            this.panel15.Name = "panel15";
            this.panel15.Size = new Size(31, 31);
            this.panel15.TabIndex = 61;
            // 
            // label27
            // 
            this.label27.Dock = DockStyle.Fill;
            this.label27.Font = new Font("MicroFLF", 14F, FontStyle.Bold);
            this.label27.ForeColor = Color.Black;
            this.label27.Location = new Point(155, 0);
            this.label27.Name = "label27";
            this.label27.Size = new Size(365, 31);
            this.label27.TabIndex = 62;
            this.label27.Text = "00";
            this.label27.TextAlign = ContentAlignment.MiddleLeft;
            this.label27.BackColorChanged += new EventHandler(this.BackColorChanging_label);
            // 
            // panelLastAtBat
            // 
            this.panelLastAtBat.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) 
                                                          | AnchorStyles.Right)));
            this.panelLastAtBat.BackColor = Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panelLastAtBat.Controls.Add(this.label27);
            this.panelLastAtBat.Controls.Add(this.panel15);
            this.panelLastAtBat.Controls.Add(this.label32);
            this.panelLastAtBat.Controls.Add(this.label44);
            this.panelLastAtBat.Location = new Point(331, 852);
            this.panelLastAtBat.Name = "panelLastAtBat";
            this.panelLastAtBat.Size = new Size(770, 31);
            this.panelLastAtBat.TabIndex = 63;
            this.panelLastAtBat.Visible = false;
            // 
            // btnTeamStats
            // 
            this.btnTeamStats.BackColor = Color.Gainsboro;
            this.btnTeamStats.FlatAppearance.BorderSize = 0;
            this.btnTeamStats.FlatStyle = FlatStyle.Flat;
            this.btnTeamStats.Font = new Font("MicroFLF", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.btnTeamStats.Location = new Point(12, 267);
            this.btnTeamStats.Name = "btnTeamStats";
            this.btnTeamStats.Size = new Size(300, 35);
            this.btnTeamStats.TabIndex = 64;
            this.btnTeamStats.Text = "TEAM STATS";
            this.btnTeamStats.UseVisualStyleBackColor = false;
            this.btnTeamStats.Click += new EventHandler(this.btnTeamStats_Click);
            // 
            // btnManualMode
            // 
            this.btnManualMode.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            this.btnManualMode.BackColor = Color.Gainsboro;
            this.btnManualMode.FlatAppearance.BorderSize = 0;
            this.btnManualMode.FlatStyle = FlatStyle.Flat;
            this.btnManualMode.Font = new Font("MicroFLF", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.btnManualMode.Location = new Point(413, 750);
            this.btnManualMode.Name = "btnManualMode";
            this.btnManualMode.Size = new Size(300, 35);
            this.btnManualMode.TabIndex = 65;
            this.btnManualMode.TabStop = false;
            this.btnManualMode.Text = "MANUAL";
            this.btnManualMode.UseVisualStyleBackColor = false;
            this.btnManualMode.Click += new EventHandler(this.btnManualMode_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            // 
            // btnAutoMode
            // 
            this.btnAutoMode.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            this.btnAutoMode.BackColor = Color.Gainsboro;
            this.btnAutoMode.FlatAppearance.BorderSize = 0;
            this.btnAutoMode.FlatStyle = FlatStyle.Flat;
            this.btnAutoMode.Font = new Font("MicroFLF", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoMode.Location = new Point(719, 750);
            this.btnAutoMode.Name = "btnAutoMode";
            this.btnAutoMode.Size = new Size(300, 35);
            this.btnAutoMode.TabIndex = 66;
            this.btnAutoMode.TabStop = false;
            this.btnAutoMode.Text = "AUTOMATIC";
            this.btnAutoMode.UseVisualStyleBackColor = false;
            this.btnAutoMode.Click += new EventHandler(this.btnAutoMode_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) 
                                                  | AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnNewPitch);
            this.panel1.Controls.Add(this.btnBuntAttempt);
            this.panel1.Location = new Point(331, 791);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(770, 55);
            this.panel1.TabIndex = 67;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(1423, 1041);
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
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new Size(1339, 1000);
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
            this.ClientSizeChanged += new EventHandler(this.MainForm_ClientSizeChanged);
            panel27.ResumeLayout(false);
            this.panelCurrentSituationPitcher.ResumeLayout(false);
            this.panelCurrentSituationBatter.ResumeLayout(false);
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
            this.panel22.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            this.AwayTeamNextBatters.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panelNextHomeBatters.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            this.panel24.ResumeLayout(false);
            this.panel25.ResumeLayout(false);
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
        private Panel panelCurrentSituationBatter;
        private Label lbBatterSecondName;
        private Label lbBatterNumber;
        private Panel panelScoreBoard;
        private Panel panel18;
        private Panel AwayTeamNextBatters;
        private Panel panel16;
        private Panel homeTeamNextBatters;
        private Label away_DueUP;
        private Label home_DueUP;
        private Panel panelNextAwayBatters;
        private Panel panel22;
        private Label AwayNext3;
        private Label AwayNextNumber3;
        private Panel panel21;
        private Label AwayNext2;
        private Label AwayNextNumber2;
        private Panel panel20;
        private Label AwayNext1;
        private Label AwayNextNumber1;
        private Panel panelNextHomeBatters;
        private Panel panel23;
        private Label homeNext3;
        private Label homeNextNumber3;
        private Panel panel24;
        private Label homeNext2;
        private Label homeNextNumber2;
        private Panel panel25;
        private Label homeNext1;
        private Label homeNextNumber1;
        private Label BatterStats;
        private Label AwayNext3Stats;
        private Label AwayNext2Stats;
        private Label AwayNext1Stats;
        private Label HomeNext3Stats;
        private Label HomeNext2Stats;
        private Label HomeNext1Stats;
        private Label label33;
        private Label label34;
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
    }
}

