using Entities;
using System;
using System.Windows.Forms;
using VKR.BLL;

namespace VKR_Test
{
    public partial class DHRuleForm : Form
    {
        public bool ExitFromCurrentMatch;
        private readonly MatchBL matchBL;
        private readonly TeamsBL teamsBL;
        public int MatchNumber;
        public Match newMatch;

        public DHRuleForm(Match match)
        {
            InitializeComponent();
            matchBL = new MatchBL();
            teamsBL = new TeamsBL();
            Program.MatchDate = matchBL.GetMaxDateForAllMatches();
            newMatch = match;
            numMatchLength.Value = 9;
            dtpMatchDate.Value = match.MatchDate;
            rbPlayWithDH.Checked = newMatch.HomeTeam.DHRule;
            rbPlayWithoutDH.Checked = !newMatch.HomeTeam.DHRule;
        }

        private void btnAcceptDHRule_Click(object sender, EventArgs e)
        {
            int MatchID = matchBL.GetNumberOfMatchesPlayed(newMatch);
            newMatch.MatchDate = dtpMatchDate.Value;
            newMatch.DHRule = rbPlayWithDH.Checked;
            newMatch.MatchID = MatchID;
            newMatch.MatchLength = (int)numMatchLength.Value;

            matchBL.StartNewMatch(newMatch);
            newMatch.AwayTeam.BattingLineup = teamsBL.GetCurrentLineupForThisMatch(newMatch.AwayTeam.TeamAbbreviation, MatchID);
            newMatch.AwayTeam.PitchersPlayedInMatch.Add(teamsBL.GetStartingPitcherForThisTeam(newMatch.AwayTeam, newMatch));

            newMatch.HomeTeam.BattingLineup = teamsBL.GetCurrentLineupForThisMatch(newMatch.HomeTeam.TeamAbbreviation, MatchID);
            newMatch.HomeTeam.PitchersPlayedInMatch.Add(teamsBL.GetStartingPitcherForThisTeam(newMatch.HomeTeam, newMatch));

            MainForm newMatchForm = new MainForm(newMatch);
            //Visible = false;
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