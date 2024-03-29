﻿using System.ComponentModel;
using System.Windows.Forms;

namespace VKR.PL.NET5
{
    partial class TeamsSelectForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamsSelectForm));
            this.pbAwayLogo = new System.Windows.Forms.Panel();
            this.numAwayTeamColor = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numHomeTeamColor = new System.Windows.Forms.NumericUpDown();
            this.lbHomeTitle = new System.Windows.Forms.Label();
            this.lbHomeCity = new System.Windows.Forms.Label();
            this.pbHomeLogo = new System.Windows.Forms.Panel();
            this.btnIncreaseAwayTeamNumberBy1 = new System.Windows.Forms.Button();
            this.btnDecreaseAwayTeamNumberBy1 = new System.Windows.Forms.Button();
            this.btnIncreaseHomeTeamNumberBy1 = new System.Windows.Forms.Button();
            this.btnDecreaseHomeTeamNumberBy1 = new System.Windows.Forms.Button();
            this.AwayOverallRating = new CircularProgressBar.CircularProgressBar();
            this.AwayOffensiveRating = new CircularProgressBar.CircularProgressBar();
            this.AwayDefensiveRating = new CircularProgressBar.CircularProgressBar();
            this.HomeDefensiveRating = new CircularProgressBar.CircularProgressBar();
            this.HomeOffensiveRating = new CircularProgressBar.CircularProgressBar();
            this.HomeOverallRating = new CircularProgressBar.CircularProgressBar();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnAcceptTeamsSelection = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.AwayTeamBalance = new System.Windows.Forms.Label();
            this.HomeTeamBalance = new System.Windows.Forms.Label();
            this.btnSwap = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbAwayTitle = new System.Windows.Forms.Label();
            this.lbAwayCity = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numAwayTeamColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHomeTeamColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbAwayLogo
            // 
            this.pbAwayLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbAwayLogo.Location = new System.Drawing.Point(12, 107);
            this.pbAwayLogo.Name = "pbAwayLogo";
            this.pbAwayLogo.Size = new System.Drawing.Size(300, 300);
            this.pbAwayLogo.TabIndex = 0;
            // 
            // numAwayTeamColor
            // 
            this.numAwayTeamColor.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numAwayTeamColor.Location = new System.Drawing.Point(118, 413);
            this.numAwayTeamColor.Name = "numAwayTeamColor";
            this.numAwayTeamColor.Size = new System.Drawing.Size(194, 26);
            this.numAwayTeamColor.TabIndex = 4;
            this.numAwayTeamColor.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 418);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Team Color:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(118, 413);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 26);
            this.label4.TabIndex = 5;
            this.label4.Text = "label4";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(778, 413);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 26);
            this.label5.TabIndex = 12;
            this.label5.Text = "label5";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(669, 418);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Team Color:";
            // 
            // numHomeTeamColor
            // 
            this.numHomeTeamColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numHomeTeamColor.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numHomeTeamColor.Location = new System.Drawing.Point(778, 413);
            this.numHomeTeamColor.Name = "numHomeTeamColor";
            this.numHomeTeamColor.Size = new System.Drawing.Size(194, 26);
            this.numHomeTeamColor.TabIndex = 11;
            this.numHomeTeamColor.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // lbHomeTitle
            // 
            this.lbHomeTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbHomeTitle.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbHomeTitle.ForeColor = System.Drawing.Color.White;
            this.lbHomeTitle.Location = new System.Drawing.Point(672, 82);
            this.lbHomeTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lbHomeTitle.Name = "lbHomeTitle";
            this.lbHomeTitle.Padding = new System.Windows.Forms.Padding(17, 0, 17, 0);
            this.lbHomeTitle.Size = new System.Drawing.Size(300, 22);
            this.lbHomeTitle.TabIndex = 10;
            this.lbHomeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbHomeTitle.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            // 
            // lbHomeCity
            // 
            this.lbHomeCity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbHomeCity.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbHomeCity.ForeColor = System.Drawing.Color.White;
            this.lbHomeCity.Location = new System.Drawing.Point(672, 59);
            this.lbHomeCity.Margin = new System.Windows.Forms.Padding(0);
            this.lbHomeCity.Name = "lbHomeCity";
            this.lbHomeCity.Padding = new System.Windows.Forms.Padding(17, 0, 17, 0);
            this.lbHomeCity.Size = new System.Drawing.Size(300, 23);
            this.lbHomeCity.TabIndex = 9;
            this.lbHomeCity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbHomeCity.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            // 
            // pbHomeLogo
            // 
            this.pbHomeLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbHomeLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbHomeLogo.Location = new System.Drawing.Point(672, 107);
            this.pbHomeLogo.Name = "pbHomeLogo";
            this.pbHomeLogo.Size = new System.Drawing.Size(300, 300);
            this.pbHomeLogo.TabIndex = 7;
            // 
            // btnIncreaseAwayTeamNumberBy1
            // 
            this.btnIncreaseAwayTeamNumberBy1.FlatAppearance.BorderSize = 0;
            this.btnIncreaseAwayTeamNumberBy1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncreaseAwayTeamNumberBy1.ForeColor = System.Drawing.Color.White;
            this.btnIncreaseAwayTeamNumberBy1.Location = new System.Drawing.Point(295, 59);
            this.btnIncreaseAwayTeamNumberBy1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnIncreaseAwayTeamNumberBy1.Name = "btnIncreaseAwayTeamNumberBy1";
            this.btnIncreaseAwayTeamNumberBy1.Size = new System.Drawing.Size(17, 45);
            this.btnIncreaseAwayTeamNumberBy1.TabIndex = 13;
            this.btnIncreaseAwayTeamNumberBy1.Text = ">";
            this.btnIncreaseAwayTeamNumberBy1.UseVisualStyleBackColor = true;
            this.btnIncreaseAwayTeamNumberBy1.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            this.btnIncreaseAwayTeamNumberBy1.Click += new System.EventHandler(this.btnIncreaseAwayTeamNumberBy1_Click);
            // 
            // btnDecreaseAwayTeamNumberBy1
            // 
            this.btnDecreaseAwayTeamNumberBy1.FlatAppearance.BorderSize = 0;
            this.btnDecreaseAwayTeamNumberBy1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecreaseAwayTeamNumberBy1.ForeColor = System.Drawing.Color.White;
            this.btnDecreaseAwayTeamNumberBy1.Location = new System.Drawing.Point(12, 59);
            this.btnDecreaseAwayTeamNumberBy1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnDecreaseAwayTeamNumberBy1.Name = "btnDecreaseAwayTeamNumberBy1";
            this.btnDecreaseAwayTeamNumberBy1.Size = new System.Drawing.Size(17, 45);
            this.btnDecreaseAwayTeamNumberBy1.TabIndex = 14;
            this.btnDecreaseAwayTeamNumberBy1.Text = "<";
            this.btnDecreaseAwayTeamNumberBy1.UseVisualStyleBackColor = true;
            this.btnDecreaseAwayTeamNumberBy1.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            this.btnDecreaseAwayTeamNumberBy1.Click += new System.EventHandler(this.btnDecreaseAwayTeamNumberBy1_Click);
            // 
            // btnIncreaseHomeTeamNumberBy1
            // 
            this.btnIncreaseHomeTeamNumberBy1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIncreaseHomeTeamNumberBy1.FlatAppearance.BorderSize = 0;
            this.btnIncreaseHomeTeamNumberBy1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncreaseHomeTeamNumberBy1.ForeColor = System.Drawing.Color.White;
            this.btnIncreaseHomeTeamNumberBy1.Location = new System.Drawing.Point(955, 59);
            this.btnIncreaseHomeTeamNumberBy1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnIncreaseHomeTeamNumberBy1.Name = "btnIncreaseHomeTeamNumberBy1";
            this.btnIncreaseHomeTeamNumberBy1.Size = new System.Drawing.Size(17, 45);
            this.btnIncreaseHomeTeamNumberBy1.TabIndex = 15;
            this.btnIncreaseHomeTeamNumberBy1.Text = ">";
            this.btnIncreaseHomeTeamNumberBy1.UseVisualStyleBackColor = true;
            this.btnIncreaseHomeTeamNumberBy1.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            this.btnIncreaseHomeTeamNumberBy1.Click += new System.EventHandler(this.btnIncreaseHomeTeamNumberBy1_Click);
            // 
            // btnDecreaseHomeTeamNumberBy1
            // 
            this.btnDecreaseHomeTeamNumberBy1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDecreaseHomeTeamNumberBy1.FlatAppearance.BorderSize = 0;
            this.btnDecreaseHomeTeamNumberBy1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecreaseHomeTeamNumberBy1.ForeColor = System.Drawing.Color.White;
            this.btnDecreaseHomeTeamNumberBy1.Location = new System.Drawing.Point(672, 59);
            this.btnDecreaseHomeTeamNumberBy1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnDecreaseHomeTeamNumberBy1.Name = "btnDecreaseHomeTeamNumberBy1";
            this.btnDecreaseHomeTeamNumberBy1.Size = new System.Drawing.Size(17, 45);
            this.btnDecreaseHomeTeamNumberBy1.TabIndex = 16;
            this.btnDecreaseHomeTeamNumberBy1.Text = "<";
            this.btnDecreaseHomeTeamNumberBy1.UseVisualStyleBackColor = true;
            this.btnDecreaseHomeTeamNumberBy1.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            this.btnDecreaseHomeTeamNumberBy1.Click += new System.EventHandler(this.btnDecreaseHomeTeamNumberBy1_Click);
            // 
            // AwayOverallRating
            // 
            this.AwayOverallRating.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.AwayOverallRating.AnimationSpeed = 500;
            this.AwayOverallRating.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.AwayOverallRating.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AwayOverallRating.ForeColor = System.Drawing.Color.White;
            this.AwayOverallRating.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.AwayOverallRating.InnerMargin = 0;
            this.AwayOverallRating.InnerWidth = 21;
            this.AwayOverallRating.Location = new System.Drawing.Point(325, 132);
            this.AwayOverallRating.MarqueeAnimationSpeed = 0;
            this.AwayOverallRating.Maximum = 99;
            this.AwayOverallRating.Name = "AwayOverallRating";
            this.AwayOverallRating.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.AwayOverallRating.OuterMargin = -5;
            this.AwayOverallRating.OuterWidth = 5;
            this.AwayOverallRating.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.AwayOverallRating.ProgressWidth = 5;
            this.AwayOverallRating.SecondaryFont = new System.Drawing.Font("Forza Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AwayOverallRating.Size = new System.Drawing.Size(66, 65);
            this.AwayOverallRating.StartAngle = 270;
            this.AwayOverallRating.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.AwayOverallRating.SubscriptMargin = new System.Windows.Forms.Padding(0);
            this.AwayOverallRating.SubscriptText = "";
            this.AwayOverallRating.SuperscriptColor = System.Drawing.Color.Black;
            this.AwayOverallRating.SuperscriptMargin = new System.Windows.Forms.Padding(0);
            this.AwayOverallRating.SuperscriptText = "";
            this.AwayOverallRating.TabIndex = 17;
            this.AwayOverallRating.Text = "0";
            this.AwayOverallRating.TextMargin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.AwayOverallRating.Value = 68;
            // 
            // AwayOffensiveRating
            // 
            this.AwayOffensiveRating.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.AwayOffensiveRating.AnimationSpeed = 500;
            this.AwayOffensiveRating.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.AwayOffensiveRating.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AwayOffensiveRating.ForeColor = System.Drawing.Color.White;
            this.AwayOffensiveRating.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.AwayOffensiveRating.InnerMargin = 0;
            this.AwayOffensiveRating.InnerWidth = 21;
            this.AwayOffensiveRating.Location = new System.Drawing.Point(325, 226);
            this.AwayOffensiveRating.MarqueeAnimationSpeed = 2000;
            this.AwayOffensiveRating.Maximum = 99;
            this.AwayOffensiveRating.Name = "AwayOffensiveRating";
            this.AwayOffensiveRating.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.AwayOffensiveRating.OuterMargin = -5;
            this.AwayOffensiveRating.OuterWidth = 5;
            this.AwayOffensiveRating.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.AwayOffensiveRating.ProgressWidth = 5;
            this.AwayOffensiveRating.SecondaryFont = new System.Drawing.Font("Forza Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AwayOffensiveRating.Size = new System.Drawing.Size(66, 66);
            this.AwayOffensiveRating.StartAngle = 270;
            this.AwayOffensiveRating.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.AwayOffensiveRating.SubscriptMargin = new System.Windows.Forms.Padding(0);
            this.AwayOffensiveRating.SubscriptText = "";
            this.AwayOffensiveRating.SuperscriptColor = System.Drawing.Color.White;
            this.AwayOffensiveRating.SuperscriptMargin = new System.Windows.Forms.Padding(0);
            this.AwayOffensiveRating.SuperscriptText = "";
            this.AwayOffensiveRating.TabIndex = 18;
            this.AwayOffensiveRating.Text = "0";
            this.AwayOffensiveRating.TextMargin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.AwayOffensiveRating.Value = 68;
            // 
            // AwayDefensiveRating
            // 
            this.AwayDefensiveRating.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.AwayDefensiveRating.AnimationSpeed = 500;
            this.AwayDefensiveRating.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.AwayDefensiveRating.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AwayDefensiveRating.ForeColor = System.Drawing.Color.White;
            this.AwayDefensiveRating.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.AwayDefensiveRating.InnerMargin = 0;
            this.AwayDefensiveRating.InnerWidth = 21;
            this.AwayDefensiveRating.Location = new System.Drawing.Point(325, 320);
            this.AwayDefensiveRating.MarqueeAnimationSpeed = 2000;
            this.AwayDefensiveRating.Maximum = 99;
            this.AwayDefensiveRating.Name = "AwayDefensiveRating";
            this.AwayDefensiveRating.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.AwayDefensiveRating.OuterMargin = -5;
            this.AwayDefensiveRating.OuterWidth = 5;
            this.AwayDefensiveRating.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.AwayDefensiveRating.ProgressWidth = 5;
            this.AwayDefensiveRating.SecondaryFont = new System.Drawing.Font("Forza Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AwayDefensiveRating.Size = new System.Drawing.Size(66, 66);
            this.AwayDefensiveRating.StartAngle = 270;
            this.AwayDefensiveRating.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.AwayDefensiveRating.SubscriptMargin = new System.Windows.Forms.Padding(0);
            this.AwayDefensiveRating.SubscriptText = "";
            this.AwayDefensiveRating.SuperscriptColor = System.Drawing.Color.White;
            this.AwayDefensiveRating.SuperscriptMargin = new System.Windows.Forms.Padding(0);
            this.AwayDefensiveRating.SuperscriptText = "";
            this.AwayDefensiveRating.TabIndex = 19;
            this.AwayDefensiveRating.Text = "0";
            this.AwayDefensiveRating.TextMargin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.AwayDefensiveRating.Value = 68;
            // 
            // HomeDefensiveRating
            // 
            this.HomeDefensiveRating.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HomeDefensiveRating.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.HomeDefensiveRating.AnimationSpeed = 500;
            this.HomeDefensiveRating.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.HomeDefensiveRating.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HomeDefensiveRating.ForeColor = System.Drawing.Color.White;
            this.HomeDefensiveRating.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.HomeDefensiveRating.InnerMargin = 0;
            this.HomeDefensiveRating.InnerWidth = 21;
            this.HomeDefensiveRating.Location = new System.Drawing.Point(593, 320);
            this.HomeDefensiveRating.MarqueeAnimationSpeed = 2000;
            this.HomeDefensiveRating.Maximum = 99;
            this.HomeDefensiveRating.Name = "HomeDefensiveRating";
            this.HomeDefensiveRating.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.HomeDefensiveRating.OuterMargin = -5;
            this.HomeDefensiveRating.OuterWidth = 5;
            this.HomeDefensiveRating.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.HomeDefensiveRating.ProgressWidth = 5;
            this.HomeDefensiveRating.SecondaryFont = new System.Drawing.Font("Forza Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HomeDefensiveRating.Size = new System.Drawing.Size(66, 66);
            this.HomeDefensiveRating.StartAngle = 270;
            this.HomeDefensiveRating.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.HomeDefensiveRating.SubscriptMargin = new System.Windows.Forms.Padding(0);
            this.HomeDefensiveRating.SubscriptText = "";
            this.HomeDefensiveRating.SuperscriptColor = System.Drawing.Color.White;
            this.HomeDefensiveRating.SuperscriptMargin = new System.Windows.Forms.Padding(0);
            this.HomeDefensiveRating.SuperscriptText = "";
            this.HomeDefensiveRating.TabIndex = 22;
            this.HomeDefensiveRating.Text = "0";
            this.HomeDefensiveRating.TextMargin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.HomeDefensiveRating.Value = 68;
            // 
            // HomeOffensiveRating
            // 
            this.HomeOffensiveRating.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HomeOffensiveRating.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.HomeOffensiveRating.AnimationSpeed = 500;
            this.HomeOffensiveRating.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.HomeOffensiveRating.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HomeOffensiveRating.ForeColor = System.Drawing.Color.White;
            this.HomeOffensiveRating.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.HomeOffensiveRating.InnerMargin = 0;
            this.HomeOffensiveRating.InnerWidth = 21;
            this.HomeOffensiveRating.Location = new System.Drawing.Point(593, 226);
            this.HomeOffensiveRating.MarqueeAnimationSpeed = 2000;
            this.HomeOffensiveRating.Maximum = 99;
            this.HomeOffensiveRating.Name = "HomeOffensiveRating";
            this.HomeOffensiveRating.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.HomeOffensiveRating.OuterMargin = -5;
            this.HomeOffensiveRating.OuterWidth = 5;
            this.HomeOffensiveRating.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.HomeOffensiveRating.ProgressWidth = 5;
            this.HomeOffensiveRating.SecondaryFont = new System.Drawing.Font("Forza Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HomeOffensiveRating.Size = new System.Drawing.Size(66, 66);
            this.HomeOffensiveRating.StartAngle = 270;
            this.HomeOffensiveRating.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.HomeOffensiveRating.SubscriptMargin = new System.Windows.Forms.Padding(0);
            this.HomeOffensiveRating.SubscriptText = "";
            this.HomeOffensiveRating.SuperscriptColor = System.Drawing.Color.White;
            this.HomeOffensiveRating.SuperscriptMargin = new System.Windows.Forms.Padding(0);
            this.HomeOffensiveRating.SuperscriptText = "";
            this.HomeOffensiveRating.TabIndex = 21;
            this.HomeOffensiveRating.Text = "0";
            this.HomeOffensiveRating.TextMargin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.HomeOffensiveRating.Value = 68;
            // 
            // HomeOverallRating
            // 
            this.HomeOverallRating.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HomeOverallRating.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.HomeOverallRating.AnimationSpeed = 500;
            this.HomeOverallRating.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.HomeOverallRating.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HomeOverallRating.ForeColor = System.Drawing.Color.White;
            this.HomeOverallRating.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.HomeOverallRating.InnerMargin = 0;
            this.HomeOverallRating.InnerWidth = 21;
            this.HomeOverallRating.Location = new System.Drawing.Point(593, 132);
            this.HomeOverallRating.MarqueeAnimationSpeed = 2000;
            this.HomeOverallRating.Maximum = 99;
            this.HomeOverallRating.Name = "HomeOverallRating";
            this.HomeOverallRating.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.HomeOverallRating.OuterMargin = -5;
            this.HomeOverallRating.OuterWidth = 5;
            this.HomeOverallRating.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.HomeOverallRating.ProgressWidth = 5;
            this.HomeOverallRating.SecondaryFont = new System.Drawing.Font("Forza Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HomeOverallRating.Size = new System.Drawing.Size(66, 66);
            this.HomeOverallRating.StartAngle = 270;
            this.HomeOverallRating.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.HomeOverallRating.SubscriptMargin = new System.Windows.Forms.Padding(0);
            this.HomeOverallRating.SubscriptText = "";
            this.HomeOverallRating.SuperscriptColor = System.Drawing.Color.White;
            this.HomeOverallRating.SuperscriptMargin = new System.Windows.Forms.Padding(0);
            this.HomeOverallRating.SuperscriptText = "";
            this.HomeOverallRating.TabIndex = 20;
            this.HomeOverallRating.Text = "0";
            this.HomeOverallRating.TextMargin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.HomeOverallRating.Value = 68;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(315, 295);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 22);
            this.label9.TabIndex = 23;
            this.label9.Text = "DEFENSE";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(315, 107);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 22);
            this.label10.TabIndex = 24;
            this.label10.Text = "OVERALL";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(315, 201);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 22);
            this.label11.TabIndex = 25;
            this.label11.Text = "OFFENSE";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(582, 107);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 22);
            this.label12.TabIndex = 24;
            this.label12.Text = "OVERALL";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(582, 201);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 22);
            this.label13.TabIndex = 25;
            this.label13.Text = "OFFENSE";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.Font = new System.Drawing.Font("MicroFLF", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(582, 295);
            this.label14.Margin = new System.Windows.Forms.Padding(0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 22);
            this.label14.TabIndex = 23;
            this.label14.Text = "DEFENSE";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAcceptTeamsSelection
            // 
            this.btnAcceptTeamsSelection.FlatAppearance.BorderSize = 0;
            this.btnAcceptTeamsSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceptTeamsSelection.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAcceptTeamsSelection.ForeColor = System.Drawing.Color.White;
            this.btnAcceptTeamsSelection.Location = new System.Drawing.Point(318, 413);
            this.btnAcceptTeamsSelection.Name = "btnAcceptTeamsSelection";
            this.btnAcceptTeamsSelection.Size = new System.Drawing.Size(345, 28);
            this.btnAcceptTeamsSelection.TabIndex = 26;
            this.btnAcceptTeamsSelection.Text = "CONFIRM";
            this.btnAcceptTeamsSelection.UseVisualStyleBackColor = true;
            this.btnAcceptTeamsSelection.Click += new System.EventHandler(this.btnAcceptTeamsSelection_Click);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(29, 21);
            this.label15.Margin = new System.Windows.Forms.Padding(0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(266, 22);
            this.label15.TabIndex = 3;
            this.label15.Text = "AWAY";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(689, 21);
            this.label16.Margin = new System.Windows.Forms.Padding(0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(266, 22);
            this.label16.TabIndex = 10;
            this.label16.Text = "HOME";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AwayTeamBalance
            // 
            this.AwayTeamBalance.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AwayTeamBalance.ForeColor = System.Drawing.Color.White;
            this.AwayTeamBalance.Location = new System.Drawing.Point(315, 59);
            this.AwayTeamBalance.Name = "AwayTeamBalance";
            this.AwayTeamBalance.Size = new System.Drawing.Size(84, 45);
            this.AwayTeamBalance.TabIndex = 27;
            this.AwayTeamBalance.Text = "label17";
            this.AwayTeamBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HomeTeamBalance
            // 
            this.HomeTeamBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HomeTeamBalance.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HomeTeamBalance.ForeColor = System.Drawing.Color.White;
            this.HomeTeamBalance.Location = new System.Drawing.Point(582, 59);
            this.HomeTeamBalance.Name = "HomeTeamBalance";
            this.HomeTeamBalance.Size = new System.Drawing.Size(84, 45);
            this.HomeTeamBalance.TabIndex = 28;
            this.HomeTeamBalance.Text = "label18";
            this.HomeTeamBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSwap
            // 
            this.btnSwap.FlatAppearance.BorderSize = 0;
            this.btnSwap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwap.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSwap.ForeColor = System.Drawing.Color.White;
            this.btnSwap.Location = new System.Drawing.Point(325, 19);
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.Size = new System.Drawing.Size(334, 28);
            this.btnSwap.TabIndex = 29;
            this.btnSwap.Text = "SWAP";
            this.btnSwap.UseVisualStyleBackColor = true;
            this.btnSwap.Click += new System.EventHandler(this.btnSwap_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.Location = new System.Drawing.Point(417, 33);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowTemplate.Height = 37;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(150, 371);
            this.dataGridView1.TabIndex = 31;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbAwayTitle);
            this.panel1.Controls.Add(this.lbAwayCity);
            this.panel1.Location = new System.Drawing.Point(12, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 45);
            this.panel1.TabIndex = 32;
            // 
            // lbAwayTitle
            // 
            this.lbAwayTitle.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbAwayTitle.ForeColor = System.Drawing.Color.White;
            this.lbAwayTitle.Location = new System.Drawing.Point(0, 23);
            this.lbAwayTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lbAwayTitle.Name = "lbAwayTitle";
            this.lbAwayTitle.Padding = new System.Windows.Forms.Padding(17, 0, 17, 0);
            this.lbAwayTitle.Size = new System.Drawing.Size(300, 22);
            this.lbAwayTitle.TabIndex = 3;
            this.lbAwayTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbAwayTitle.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            // 
            // lbAwayCity
            // 
            this.lbAwayCity.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbAwayCity.ForeColor = System.Drawing.Color.White;
            this.lbAwayCity.Location = new System.Drawing.Point(0, 0);
            this.lbAwayCity.Margin = new System.Windows.Forms.Padding(0);
            this.lbAwayCity.Name = "lbAwayCity";
            this.lbAwayCity.Padding = new System.Windows.Forms.Padding(17, 0, 17, 0);
            this.lbAwayCity.Size = new System.Drawing.Size(300, 23);
            this.lbAwayCity.TabIndex = 3;
            this.lbAwayCity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbAwayCity.BackColorChanged += new System.EventHandler(this.BackColorChanging_label);
            // 
            // TeamsSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(984, 450);
            this.Controls.Add(this.btnDecreaseAwayTeamNumberBy1);
            this.Controls.Add(this.btnIncreaseAwayTeamNumberBy1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSwap);
            this.Controls.Add(this.HomeTeamBalance);
            this.Controls.Add(this.AwayTeamBalance);
            this.Controls.Add(this.btnAcceptTeamsSelection);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.HomeDefensiveRating);
            this.Controls.Add(this.HomeOffensiveRating);
            this.Controls.Add(this.HomeOverallRating);
            this.Controls.Add(this.AwayDefensiveRating);
            this.Controls.Add(this.AwayOffensiveRating);
            this.Controls.Add(this.AwayOverallRating);
            this.Controls.Add(this.btnDecreaseHomeTeamNumberBy1);
            this.Controls.Add(this.btnIncreaseHomeTeamNumberBy1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numHomeTeamColor);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lbHomeTitle);
            this.Controls.Add(this.lbHomeCity);
            this.Controls.Add(this.pbHomeLogo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numAwayTeamColor);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.pbAwayLogo);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "TeamsSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teams selection";
            this.Load += new System.EventHandler(this.TeamsSelectForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TeamsSelectForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numAwayTeamColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHomeTeamColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pbAwayLogo;
        private NumericUpDown numAwayTeamColor;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private NumericUpDown numHomeTeamColor;
        private Label lbHomeTitle;
        private Label lbHomeCity;
        private Panel pbHomeLogo;
        private Button btnIncreaseAwayTeamNumberBy1;
        private Button btnDecreaseAwayTeamNumberBy1;
        private Button btnIncreaseHomeTeamNumberBy1;
        private Button btnDecreaseHomeTeamNumberBy1;
        private CircularProgressBar.CircularProgressBar AwayOverallRating;
        private CircularProgressBar.CircularProgressBar AwayOffensiveRating;
        private CircularProgressBar.CircularProgressBar AwayDefensiveRating;
        private CircularProgressBar.CircularProgressBar HomeDefensiveRating;
        private CircularProgressBar.CircularProgressBar HomeOffensiveRating;
        private CircularProgressBar.CircularProgressBar HomeOverallRating;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Button btnAcceptTeamsSelection;
        private Label label15;
        private Label label16;
        private Label AwayTeamBalance;
        private Label HomeTeamBalance;
        private Button btnSwap;
        private DataGridView dataGridView1;
        private DataGridViewImageColumn Column1;
        private DataGridViewImageColumn Column2;
        private Panel panel1;
        private Label lbAwayCity;
        private Label lbAwayTitle;
    }
}