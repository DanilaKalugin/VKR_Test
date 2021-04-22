using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VKR.BLL;

namespace VKR_Test
{
    public partial class StadiumSelectionForm : Form
    {
        private readonly StadiumsBL stadiumsBL;
        List<Stadium> stadiums;
        int StadiumNumber;
        Team HomeTeam;
        Team AwayTeam;
        public bool ExitFromCurrentMatch;
        public int MatchNumberForDelete;

        public StadiumSelectionForm(Team _HomeTeam, Team _AwayTeam)
        {
            InitializeComponent();
            stadiumsBL = new StadiumsBL();
            stadiums = stadiumsBL.GetAllStadims();
            Stadium HomeTeamStadium = stadiums.Where(stadium => stadium.stadiumId == _HomeTeam.Stadium).First();
            StadiumNumber = stadiums.IndexOf(HomeTeamStadium);
            panel1.BackgroundImage = Image.FromFile($"SmallTeamLogos/{_AwayTeam.TeamAbbreviation}.png");
            panel2.BackgroundImage = Image.FromFile($"SmallTeamLogos/{_HomeTeam.TeamAbbreviation}.png");
            HomeTeam = _HomeTeam;
            AwayTeam = _AwayTeam;
        }

        public void DisplayCurrentStadium(int _Number)
        {
            label7.Text = stadiums[_Number].stadiumLocation;
            label1.Text = stadiums[_Number].StadiumTitle;
            label6.Text = stadiums[_Number].stadiumCapacity.ToString("N0", CultureInfo.InvariantCulture);
            label5.Text = stadiums[_Number].stadiumDistanceToCenterfield + " ft";
            if (File.Exists($"Stadiums/Stadium{stadiums[_Number].stadiumId.ToString("000")}.jpg"))
            {
                panel4.BackgroundImage = Image.FromFile($"Stadiums/Stadium{stadiums[_Number].stadiumId.ToString("000")}.jpg");
            }
            else
            {
                panel4.BackgroundImage = null;
            }
        }

        private void StadiumSelectionForm_Load(object sender, EventArgs e)
        {
            DisplayCurrentStadium(StadiumNumber);
        }

        private void btnIncreaseStadiumNumberBy1_Click(object sender, EventArgs e)
        {
            StadiumNumber = StadiumNumber == stadiums.Count - 1 ? 0 : StadiumNumber + 1;
            DisplayCurrentStadium(StadiumNumber);
        }

        private void btnDecreaseStadiumNumberBy1_Click(object sender, EventArgs e)
        {
            StadiumNumber = StadiumNumber == 0 ? stadiums.Count - 1 : StadiumNumber - 1;
            DisplayCurrentStadium(StadiumNumber);
        }

        private void btnAcceptSelectedStadium_Click(object sender, EventArgs e)
        {
            Stadium stadiumForThisMatch = stadiums[StadiumNumber];
            DHRuleForm DHForm = new DHRuleForm(HomeTeam, AwayTeam, stadiumForThisMatch);
            DHForm.ShowDialog();

            if (DHForm.DialogResult == DialogResult.OK)
            {
                DialogResult = DialogResult.OK;
                DHForm.Dispose();
                Hide();
            }
            else if (DHForm.DialogResult == DialogResult.Yes)
            {
                ExitFromCurrentMatch = DHForm.ExitFromCurrentMatch;
                MatchNumberForDelete = DHForm.MatchNumber;
                DHForm.Dispose();
                Hide();
                DialogResult = DialogResult.Yes;
            }
        }
    }
}