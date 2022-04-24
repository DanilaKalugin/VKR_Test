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
        private readonly StadiumsBL _stadiumsBL;
        private List<Stadium> _stadiums;
        private int _stadiumNumber;
        public bool ExitFromCurrentMatch;
        public int MatchNumberForDelete;
        public Match NewMatch;

        public StadiumSelectionForm(Match match)
        {
            InitializeComponent();
            _stadiumsBL = new StadiumsBL();
            NewMatch = match;
            _stadiums = _stadiumsBL.GetAllStadims();
            var HomeTeamStadium = _stadiums.Where(stadium => stadium.StadiumId == NewMatch.HomeTeam.Stadium).First();
            _stadiumNumber = _stadiums.IndexOf(HomeTeamStadium);
            pbAwayTeamLogo.BackgroundImage = Image.FromFile($"SmallTeamLogos/{NewMatch.AwayTeam.TeamAbbreviation}.png");
            pbHomeTeamLogo.BackgroundImage = Image.FromFile($"SmallTeamLogos/{NewMatch.HomeTeam.TeamAbbreviation}.png");
        }

        public void DisplayCurrentStadium(int number)
        {
            lbStadiumLocation.Text = _stadiums[number].StadiumLocation;
            lbStadiumName.Text = _stadiums[number].StadiumTitle;
            lbStadiumCapacity.Text = _stadiums[number].StadiumCapacity.ToString("N0", CultureInfo.InvariantCulture);
            lbDistanceToCenterField.Text = _stadiums[number].StadiumDistanceToCenterfield + " ft";

            if (File.Exists($"Stadiums/Stadium{_stadiums[number].StadiumId:000}.jpg"))
            {
                pbStadiumPhoto.BackgroundImage = Image.FromFile($"Stadiums/Stadium{_stadiums[number].StadiumId:000}.jpg");
            }
            else
            {
                pbStadiumPhoto.BackgroundImage = null;
            }
        }

        private void StadiumSelectionForm_Load(object sender, EventArgs e)
        {
            DisplayCurrentStadium(_stadiumNumber);
        }

        private void btnIncreaseStadiumNumberBy1_Click(object sender, EventArgs e)
        {
            _stadiumNumber = _stadiumNumber == _stadiums.Count - 1 ? 0 : _stadiumNumber + 1;
            DisplayCurrentStadium(_stadiumNumber);
        }

        private void btnDecreaseStadiumNumberBy1_Click(object sender, EventArgs e)
        {
            _stadiumNumber = _stadiumNumber == 0 ? _stadiums.Count - 1 : _stadiumNumber - 1;
            DisplayCurrentStadium(_stadiumNumber);
        }

        private void btnAcceptSelectedStadium_Click(object sender, EventArgs e)
        {
            var stadiumForThisMatch = _stadiums[_stadiumNumber];
            NewMatch.Stadium = stadiumForThisMatch;
            var designatedHitterForm = new DHRuleForm(NewMatch);
            Visible = false;
            designatedHitterForm.ShowDialog();

            if (designatedHitterForm.DialogResult == DialogResult.OK)
            {
                DialogResult = DialogResult.OK;
                designatedHitterForm.Dispose();
                Hide();
            }
            else if (designatedHitterForm.DialogResult == DialogResult.Yes)
            {
                ExitFromCurrentMatch = designatedHitterForm.ExitFromCurrentMatch;
                MatchNumberForDelete = designatedHitterForm.MatchNumber;
                designatedHitterForm.Dispose();
                Hide();
                DialogResult = DialogResult.Yes;
            }
            else Visible = true;
        }
    }
}