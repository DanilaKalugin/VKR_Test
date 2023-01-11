using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VKR.EF.Entities;
using VKR.EF.Entities.Tables;
using VKR.PL.Utils.NET5;

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
            panel1.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/PlayerPhotos/Player{player.Id:0000}.png");
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            Position = cbPlaceOfBirth.SelectedItem as PlayerPosition;
            DialogResult = DialogResult.OK;
        }
    }
}