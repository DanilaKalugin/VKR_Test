using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using VKR.BLL.NET5;
using VKR.EF.Entities;

namespace VKR.PL.NET5
{
    public partial class DHRuleForm : Form
    {
        public bool ExitFromCurrentMatch;
        private readonly MatchBL _matchBL = new();
        private readonly PlayerBL _playerBL = new();
        public int MatchNumber;
        public Match NewMatch;

        public DHRuleForm(Match match)
        {
            InitializeComponent();
            NewMatch = match;
            numMatchLength.Value = 9;
            dtpMatchDate.Value = match.MatchDate;
            rbPlayWithDH.Checked = NewMatch.HomeTeam.Division.League.DHRule;
            rbPlayWithoutDH.Checked = !NewMatch.HomeTeam.Division.League.DHRule;
        }

        private async void btnAcceptDHRule_Click(object sender, EventArgs e)
        {
            var matchId = await _matchBL.GetNextMatchId(NewMatch);
            NewMatch.MatchDate = dtpMatchDate.Value;
            NewMatch.DHRule = rbPlayWithDH.Checked;
            NewMatch.Id = matchId;
            NewMatch.MatchLength = (byte)numMatchLength.Value;

            await _matchBL.StartNewMatch(NewMatch);

            var awayTeamTask = _playerBL.GetCurrentLineupForThisMatch(NewMatch.AwayTeam, NewMatch);
            var homeTeamTask = _playerBL.GetCurrentLineupForThisMatch(NewMatch.HomeTeam, NewMatch);

            await Task.WhenAll(awayTeamTask, homeTeamTask);
            (NewMatch.AwayTeam.BattingLineup, NewMatch.HomeTeam.BattingLineup) = (awayTeamTask.Result, homeTeamTask.Result);

            var awayPitcher = await _playerBL.GetStartingPitcherForThisTeam(NewMatch.AwayTeam, NewMatch);
            var homePitcher = await _playerBL.GetStartingPitcherForThisTeam(NewMatch.HomeTeam, NewMatch);

            NewMatch.AwayTeam.PitchersPlayedInMatch.Add(awayPitcher);
            NewMatch.HomeTeam.PitchersPlayedInMatch.Add(homePitcher);
            
            using var newMatchForm = new MainForm(NewMatch);
            Visible = false;
            newMatchForm.ShowDialog();

            if (newMatchForm.DialogResult == DialogResult.OK)
            {
                DialogResult = DialogResult.OK;
                Hide();
            }
            else if (newMatchForm.DeleteThisMatch)
            {
                ExitFromCurrentMatch = newMatchForm.DeleteThisMatch;
                MatchNumber = NewMatch.Id;
                Hide();
                DialogResult = DialogResult.Yes;
            }
        }

        private void numMatchLength_ValueChanged(object sender, EventArgs e) => labelMatchLength.Text = numMatchLength.Value % 10 == 1 && numMatchLength.Value % 100 != 11 ? $"{numMatchLength.Value} INNING" : $"{numMatchLength.Value} INNINGS";
    }
}