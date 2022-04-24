using Entities;
using System;
using System.Windows.Forms;
using VKR.BLL;

namespace VKR_Test
{
    public partial class DHRuleForm : Form
    {
        public bool ExitFromCurrentMatch;
        private readonly MatchBL _matchBL;
        private readonly PlayerBL _playerBL;
        public int MatchNumber;
        public Match NewMatch;

        public DHRuleForm(Match match)
        {
            InitializeComponent();
            _matchBL = new MatchBL();
            _playerBL = new PlayerBL();
            Program.MatchDate = _matchBL.GetMaxDateForAllMatches();
            NewMatch = match;
            numMatchLength.Value = 9;
            dtpMatchDate.Value = match.MatchDate;
            rbPlayWithDH.Checked = NewMatch.HomeTeam.DHRule;
            rbPlayWithoutDH.Checked = !NewMatch.HomeTeam.DHRule;
        }

        private void btnAcceptDHRule_Click(object sender, EventArgs e)
        {
            int MatchID = _matchBL.GetNumberOfMatchesPlayed(NewMatch);
            NewMatch.MatchDate = dtpMatchDate.Value;
            NewMatch.DHRule = rbPlayWithDH.Checked;
            NewMatch.MatchID = MatchID;
            NewMatch.MatchLength = (int)numMatchLength.Value;

            _matchBL.StartNewMatch(NewMatch);
            NewMatch.AwayTeam.BattingLineup = _playerBL.GetCurrentLineupForThisMatch(NewMatch.AwayTeam.TeamAbbreviation, MatchID);
            NewMatch.AwayTeam.PitchersPlayedInMatch.Add(_playerBL.GetStartingPitcherForThisTeam(NewMatch.AwayTeam, NewMatch));

            NewMatch.HomeTeam.BattingLineup = _playerBL.GetCurrentLineupForThisMatch(NewMatch.HomeTeam.TeamAbbreviation, MatchID);
            NewMatch.HomeTeam.PitchersPlayedInMatch.Add(_playerBL.GetStartingPitcherForThisTeam(NewMatch.HomeTeam, NewMatch));

            MainForm newMatchForm = new MainForm(NewMatch);
            Visible = false;
            newMatchForm.ShowDialog();

            if (newMatchForm.DialogResult == DialogResult.OK)
            {
                DialogResult = DialogResult.OK;
                newMatchForm.Dispose();
                Hide();
            }
            else if (newMatchForm.DeleteThisMatch)
            {
                ExitFromCurrentMatch = newMatchForm.DeleteThisMatch;
                MatchNumber = newMatchForm.currentMatch.MatchID;
                newMatchForm.Dispose();
                Hide();
                DialogResult = DialogResult.Yes;
            }
        }

        private void numMatchLength_ValueChanged(object sender, EventArgs e)
        {
            labelMatchLength.Text = (numMatchLength.Value % 10 == 1 && numMatchLength.Value % 100 != 11) ? $"{numMatchLength.Value} INNING" : $"{numMatchLength.Value} INNINGS";
        }
    }
}