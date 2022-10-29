using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VKR.EF.Entities;

namespace VKR.PL.NET5
{
    public partial class SelectPlayerPositionForm : Form
    {
        public PlayerPosition? Position;

        public SelectPlayerPositionForm(Man player, List<PlayerPosition> positions, string lineupType)
        {
            InitializeComponent();
            cbPlaceOfBirth.DataSource = positions;
            cbPlaceOfBirth.DisplayMember = "FullTitle";

            txtPlayer.Text = player.FullName;
            textBox1.Text = lineupType;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            Position = cbPlaceOfBirth.SelectedItem as PlayerPosition;
            DialogResult = DialogResult.OK;
        }
    }
}