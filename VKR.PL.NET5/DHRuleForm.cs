using System;
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

        private void btnAcceptDHRule_Click(object sender, EventArgs e)
        {
            var matchId = _matchBL.GetNumberOfMatchesPlayed(NewMatch);
            NewMatch.MatchDate = dtpMatchDate.Value;
            NewMatch.DHRule = rbPlayWithDH.Checked;
            NewMatch.Id = matchId;
            NewMatch.MatchLength = (byte)numMatchLength.Value;

            _matchBL.StartNewMatch(NewMatch);
            NewMatch.AwayTeam.BattingLineup = _playerBL.GetCurrentLineupForThisMatch(NewMatch.AwayTeam, NewMatch);
            NewMatch.AwayTeam.PitchersPlayedInMatch.Add(_playerBL.GetStartingPitcherForThisTeam(NewMatch.AwayTeam, NewMatch));

            NewMatch.HomeTeam.BattingLineup = _playerBL.GetCurrentLineupForThisMatch(NewMatch.HomeTeam, NewMatch);
            NewMatch.HomeTeam.PitchersPlayedInMatch.Add(_playerBL.GetStartingPitcherForThisTeam(NewMatch.HomeTeam, NewMatch));
            
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