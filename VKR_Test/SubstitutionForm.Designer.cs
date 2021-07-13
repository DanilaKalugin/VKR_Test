
namespace VKR_Test
{
    partial class SubstitutionForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubstitutionForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTeamLogo = new System.Windows.Forms.Panel();
            this.lbHeader = new System.Windows.Forms.Label();
            this.lbTeamTitle = new System.Windows.Forms.Label();
            this.dgvAvailablePlayers = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailablePlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.panelTeamLogo);
            this.panel1.Controls.Add(this.lbHeader);
            this.panel1.Controls.Add(this.lbTeamTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(524, 100);
            this.panel1.TabIndex = 0;
            // 
            // panelTeamLogo
            // 
            this.panelTeamLogo.Location = new System.Drawing.Point(440, 12);
            this.panelTeamLogo.Name = "panelTeamLogo";
            this.panelTeamLogo.Size = new System.Drawing.Size(72, 72);
            this.panelTeamLogo.TabIndex = 2;
            // 
            // lbHeader
            // 
            this.lbHeader.AutoSize = true;
            this.lbHeader.Font = new System.Drawing.Font("MicroFLF", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeader.ForeColor = System.Drawing.Color.DimGray;
            this.lbHeader.Location = new System.Drawing.Point(12, 70);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(250, 14);
            this.lbHeader.TabIndex = 1;
            this.lbHeader.Text = "SELECT NEW PITCHER FOR THIS TEAM";
            // 
            // lbTeamTitle
            // 
            this.lbTeamTitle.AutoSize = true;
            this.lbTeamTitle.Font = new System.Drawing.Font("MicroFLF", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTeamTitle.Location = new System.Drawing.Point(12, 18);
            this.lbTeamTitle.Name = "lbTeamTitle";
            this.lbTeamTitle.Size = new System.Drawing.Size(70, 21);
            this.lbTeamTitle.TabIndex = 0;
            this.lbTeamTitle.Text = "label1";
            // 
            // dgvAvailablePlayers
            // 
            this.dgvAvailablePlayers.AllowUserToAddRows = false;
            this.dgvAvailablePlayers.AllowUserToDeleteRows = false;
            this.dgvAvailablePlayers.AllowUserToResizeColumns = false;
            this.dgvAvailablePlayers.AllowUserToResizeRows = false;
            this.dgvAvailablePlayers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAvailablePlayers.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("MicroFLF", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAvailablePlayers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAvailablePlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailablePlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("MicroFLF", 18F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAvailablePlayers.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvAvailablePlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAvailablePlayers.EnableHeadersVisualStyles = false;
            this.dgvAvailablePlayers.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvAvailablePlayers.Location = new System.Drawing.Point(0, 100);
            this.dgvAvailablePlayers.MultiSelect = false;
            this.dgvAvailablePlayers.Name = "dgvAvailablePlayers";
            this.dgvAvailablePlayers.ReadOnly = true;
            this.dgvAvailablePlayers.RowHeadersVisible = false;
            this.dgvAvailablePlayers.RowTemplate.Height = 120;
            this.dgvAvailablePlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAvailablePlayers.Size = new System.Drawing.Size(524, 625);
            this.dgvAvailablePlayers.TabIndex = 1;
            this.dgvAvailablePlayers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle5.NullValue")));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column1.FillWeight = 92F;
            this.Column1.HeaderText = "";
            this.Column1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 86;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 242F;
            this.Column2.HeaderText = "Player";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.FillWeight = 110F;
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 102;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4.FillWeight = 70F;
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 66;
            // 
            // SubstitutionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 725);
            this.Controls.Add(this.dgvAvailablePlayers);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SubstitutionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PitcherSubstitutionForm";
            this.Load += new System.EventHandler(this.PitcherSubstitutionForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailablePlayers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbHeader;
        private System.Windows.Forms.Label lbTeamTitle;
        private System.Windows.Forms.DataGridView dgvAvailablePlayers;
        private System.Windows.Forms.Panel panelTeamLogo;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}