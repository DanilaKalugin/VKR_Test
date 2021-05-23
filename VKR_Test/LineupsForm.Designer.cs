
namespace VKR_Test
{
    partial class LineupsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LineupsForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDecreaseTeamNumberBy1 = new System.Windows.Forms.Button();
            this.btnIncreaseTeamNumberBy1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDecLineupTypeNumberBy1 = new System.Windows.Forms.Button();
            this.btnIncLineupTypeNumberBy1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_LineupHeader = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panelTeamLogo = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.Location = new System.Drawing.Point(13, 181);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(580, 199);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 6F;
            this.Column1.HeaderText = "Number";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 6F;
            this.Column2.HeaderText = "Position";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 88F;
            this.Column3.HeaderText = "Name";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // btnDecreaseTeamNumberBy1
            // 
            this.btnDecreaseTeamNumberBy1.FlatAppearance.BorderSize = 0;
            this.btnDecreaseTeamNumberBy1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecreaseTeamNumberBy1.ForeColor = System.Drawing.Color.Black;
            this.btnDecreaseTeamNumberBy1.Location = new System.Drawing.Point(488, 12);
            this.btnDecreaseTeamNumberBy1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnDecreaseTeamNumberBy1.Name = "btnDecreaseTeamNumberBy1";
            this.btnDecreaseTeamNumberBy1.Size = new System.Drawing.Size(17, 22);
            this.btnDecreaseTeamNumberBy1.TabIndex = 19;
            this.btnDecreaseTeamNumberBy1.Text = "<";
            this.btnDecreaseTeamNumberBy1.UseVisualStyleBackColor = true;
            this.btnDecreaseTeamNumberBy1.Click += new System.EventHandler(this.btnDecreaseTeamNumberBy1_Click);
            // 
            // btnIncreaseTeamNumberBy1
            // 
            this.btnIncreaseTeamNumberBy1.FlatAppearance.BorderSize = 0;
            this.btnIncreaseTeamNumberBy1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncreaseTeamNumberBy1.ForeColor = System.Drawing.Color.Black;
            this.btnIncreaseTeamNumberBy1.Location = new System.Drawing.Point(771, 12);
            this.btnIncreaseTeamNumberBy1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnIncreaseTeamNumberBy1.Name = "btnIncreaseTeamNumberBy1";
            this.btnIncreaseTeamNumberBy1.Size = new System.Drawing.Size(17, 22);
            this.btnIncreaseTeamNumberBy1.TabIndex = 18;
            this.btnIncreaseTeamNumberBy1.Text = ">";
            this.btnIncreaseTeamNumberBy1.UseVisualStyleBackColor = true;
            this.btnIncreaseTeamNumberBy1.Click += new System.EventHandler(this.btnIncreaseTeamNumberBy1_Click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(505, 12);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(266, 22);
            this.label7.TabIndex = 17;
            this.label7.Text = "label7";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDecLineupTypeNumberBy1
            // 
            this.btnDecLineupTypeNumberBy1.FlatAppearance.BorderSize = 0;
            this.btnDecLineupTypeNumberBy1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecLineupTypeNumberBy1.ForeColor = System.Drawing.Color.Black;
            this.btnDecLineupTypeNumberBy1.Location = new System.Drawing.Point(292, 383);
            this.btnDecLineupTypeNumberBy1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnDecLineupTypeNumberBy1.Name = "btnDecLineupTypeNumberBy1";
            this.btnDecLineupTypeNumberBy1.Size = new System.Drawing.Size(17, 22);
            this.btnDecLineupTypeNumberBy1.TabIndex = 22;
            this.btnDecLineupTypeNumberBy1.Text = "<";
            this.btnDecLineupTypeNumberBy1.UseVisualStyleBackColor = true;
            this.btnDecLineupTypeNumberBy1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnIncLineupTypeNumberBy1
            // 
            this.btnIncLineupTypeNumberBy1.FlatAppearance.BorderSize = 0;
            this.btnIncLineupTypeNumberBy1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncLineupTypeNumberBy1.ForeColor = System.Drawing.Color.Black;
            this.btnIncLineupTypeNumberBy1.Location = new System.Drawing.Point(575, 383);
            this.btnIncLineupTypeNumberBy1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnIncLineupTypeNumberBy1.Name = "btnIncLineupTypeNumberBy1";
            this.btnIncLineupTypeNumberBy1.Size = new System.Drawing.Size(17, 22);
            this.btnIncLineupTypeNumberBy1.TabIndex = 21;
            this.btnIncLineupTypeNumberBy1.Text = ">";
            this.btnIncLineupTypeNumberBy1.UseVisualStyleBackColor = true;
            this.btnIncLineupTypeNumberBy1.Click += new System.EventHandler(this.btnIncLineupTypeNumberBy1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(309, 383);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 22);
            this.label1.TabIndex = 20;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_LineupHeader
            // 
            this.lbl_LineupHeader.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_LineupHeader.ForeColor = System.Drawing.Color.Black;
            this.lbl_LineupHeader.Location = new System.Drawing.Point(9, 383);
            this.lbl_LineupHeader.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_LineupHeader.Name = "lbl_LineupHeader";
            this.lbl_LineupHeader.Size = new System.Drawing.Size(158, 22);
            this.lbl_LineupHeader.TabIndex = 23;
            this.lbl_LineupHeader.Text = "LINEUP";
            this.lbl_LineupHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("MicroFLF", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(6, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 74);
            this.label2.TabIndex = 26;
            this.label2.Text = "#99";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("MicroFLF", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(273, 37);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(515, 42);
            this.label3.TabIndex = 27;
            this.label3.Text = "label3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MicroFLF", 14F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(276, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 21);
            this.label4.TabIndex = 28;
            this.label4.Text = "label4";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.ColumnHeadersVisible = false;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("MicroFLF", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridView2.Location = new System.Drawing.Point(624, 181);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(580, 199);
            this.dataGridView2.TabIndex = 30;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dataGridView2.SelectionChanged += new System.EventHandler(this.dataGridView2_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.FillWeight = 88F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // panel10
            // 
            this.panel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel10.Location = new System.Drawing.Point(167, 12);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(106, 160);
            this.panel10.TabIndex = 25;
            // 
            // panelTeamLogo
            // 
            this.panelTeamLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTeamLogo.Location = new System.Drawing.Point(1044, 12);
            this.panelTeamLogo.Name = "panelTeamLogo";
            this.panelTeamLogo.Size = new System.Drawing.Size(160, 160);
            this.panelTeamLogo.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("MicroFLF", 14F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(624, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 25);
            this.label6.TabIndex = 32;
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // LineupsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 414);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panelTeamLogo);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.lbl_LineupHeader);
            this.Controls.Add(this.btnDecLineupTypeNumberBy1);
            this.Controls.Add(this.btnIncLineupTypeNumberBy1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDecreaseTeamNumberBy1);
            this.Controls.Add(this.btnIncreaseTeamNumberBy1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LineupsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Starting lineups";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button btnDecreaseTeamNumberBy1;
        private System.Windows.Forms.Button btnIncreaseTeamNumberBy1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDecLineupTypeNumberBy1;
        private System.Windows.Forms.Button btnIncLineupTypeNumberBy1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_LineupHeader;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Panel panelTeamLogo;
        private System.Windows.Forms.Label label6;
    }
}