using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.EF.Entities;
using VKR.PL.Utils.NET5;

namespace VKR.PL.NET5
{
    public partial class StadiumSelectionForm : Form
    {
        private readonly StadiumsBL _stadiumsBL = new();
        private List<Stadium?> _stadiums;
        private int _stadiumNumber;
        public bool ExitFromCurrentMatch;
        public int MatchNumberForDelete;
        public Match NewMatch;

        public StadiumSelectionForm(Match match)
        {
            InitializeComponent();
            NewMatch = match;
            
            pbAwayTeamLogo.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/SmallTeamLogos/{NewMatch.AwayTeam.TeamAbbreviation}.png");
            pbHomeTeamLogo.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/SmallTeamLogos/{NewMatch.HomeTeam.TeamAbbreviation}.png");
        }

        public void DisplayCurrentStadium()
        {
            lbStadiumLocation.Text = _stadiums[_stadiumNumber]?.StadiumCity.CityLocation;
            lbStadiumName.Text = _stadiums[_stadiumNumber]?.StadiumTitle;
            lbStadiumCapacity.Text = _stadiums[_stadiumNumber]?.StadiumCapacity.ToString("N0", CultureInfo.InvariantCulture);
            lbDistanceToCenterField.Text = _stadiums[_stadiumNumber]?.StadiumDistanceToCenterfield + " ft";

            pbStadiumPhoto.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/Stadiums/Stadium{_stadiums[_stadiumNumber]?.StadiumId:000}.jpg");
        }

        private async void StadiumSelectionForm_Load(object sender, EventArgs e)
        {
            var stadiumsTask = _stadiumsBL.GetAllStadiumsAsync();
            var homeTeamStadiumTask = _stadiumsBL.GetHomeStadiumForThisTeamAndTypeOfMatch(NewMatch.HomeTeam, NewMatch.MatchTypeId);

            await Task.WhenAll(stadiumsTask, homeTeamStadiumTask);

            Stadium homeTeamStadium;
            (_stadiums, homeTeamStadium) = (stadiumsTask.Result, homeTeamStadiumTask.Result);
            _stadiumNumber = _stadiums.IndexOf(_stadiums.FirstOrDefault(stadium => stadium?.StadiumId == homeTeamStadium.StadiumId));
            DisplayCurrentStadium();
        }

        private void btnIncreaseStadiumNumberBy1_Click(object sender, EventArgs e)
        {
            _stadiumNumber = _stadiumNumber == _stadiums.Count - 1 ? 0 : _stadiumNumber + 1;
            DisplayCurrentStadium();
        }

        private void btnDecreaseStadiumNumberBy1_Click(object sender, EventArgs e)
        {
            _stadiumNumber = _stadiumNumber == 0 ? _stadiums.Count - 1 : _stadiumNumber - 1;
            DisplayCurrentStadium();
        }

        private void btnAcceptSelectedStadium_Click(object sender, EventArgs e)
        {
            var stadiumForThisMatch = _stadiums[_stadiumNumber];
            NewMatch.Stadium = stadiumForThisMatch;

            using var designatedHitterForm = new DHRuleForm(NewMatch);
            Visible = false;
            designatedHitterForm.ShowDialog();

            switch (designatedHitterForm.DialogResult)
            {
                case DialogResult.OK:
                    DialogResult = DialogResult.OK;
                    designatedHitterForm.Dispose();
                    Hide();
                    break;
                case DialogResult.Yes:
                    ExitFromCurrentMatch = designatedHitterForm.ExitFromCurrentMatch;
                    MatchNumberForDelete = designatedHitterForm.MatchNumber;
                    designatedHitterForm.Dispose();
                    Hide();
                    DialogResult = DialogResult.Yes;
                    break;
                default:
                    Visible = true;
                    break;
            }
        }
    }
}