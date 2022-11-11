using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.EF.Entities;
using VKR.PL.Utils.NET5;

namespace VKR.PL.NET5
{
    public partial class SetStadiumForMatchTypeAndTeam : Form
    {
        private readonly StadiumsBL _stadiumsBl = new();
        private readonly TeamStadiumForTypeOfMatch _tsmt;
        private List<Stadium> _stadiums;

        public SetStadiumForMatchTypeAndTeam(TeamStadiumForTypeOfMatch tsmt)
        {
            InitializeComponent();
            _tsmt = tsmt;
        }

        private void SetStadiumForMatchTypeAndTeam_Load(object sender, EventArgs e)
        {
            panel1.BackgroundImage = ImageHelper.ShowImageIfExists($"Images/TeamLogoForMenu/{_tsmt.Team.TeamAbbreviation}.png");
            txtTeam.Value = _tsmt.Team.TeamName;
            txtMatchType.Value = _tsmt.TypeOfMatchId.ToString();
            Text = $"Set new stadium for {_tsmt.Team.FullTeamName}";
        }

        private async void btnClose_Click(object sender, EventArgs e)
        {
            await _stadiumsBl.UpdateStadiumForThisTeamAndMatchType(_tsmt);
            DialogResult = DialogResult.OK;
        }

        private async void SetStadiumForMatchTypeAndTeam_VisibleChanged(object sender, EventArgs e)
        {
            await FillStadiumsTable();

            cbStadiums.SelectedItem = _stadiums.First(s => s.StadiumId == _tsmt.StadiumId);
        }

        private async Task FillStadiumsTable()
        {
            _stadiums = await _stadiumsBl.GetAllStadiumsAsync();

            cbStadiums.DataSource = _stadiums;
            cbStadiums.DisplayMember = "StadiumTitle";
            cbStadiums.ValueMember = "StadiumId";
        }

        private void cbStadiums_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_tsmt is null) return;
            _tsmt.StadiumId = (ushort)cbStadiums.SelectedValue;
        }
    }
}