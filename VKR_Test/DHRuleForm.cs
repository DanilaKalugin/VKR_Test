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
            dtpMatchDate.Value = match.MatchDate;
            rbPlayWithDH.Checked = newMatch.HomeTeam.DHRule;
            rbPlayWithoutDH.Checked = !newMatch.HomeTeam.DHRule;
        }

        private void btnAcceptDHRule_Click(object sender, EventArgs e)
        {
            int MatchID = matchBL.GetNumberOfMatchesPlayed();
            newMatch.MatchDate = dtpMatchDate.Value;
            newMatch.DHRule = rbPlayWithDH.Checked;
            newMatch.MatchID = MatchID;

            matchBL.StartNewMatch(newMatch);
            newMatch.AwayTeam.BattingLineup = teamsBL.GetCurrentLineupForThisMatch(newMatch.AwayTeam.TeamAbbreviation, MatchID);
            newMatch.AwayTeam.PitchersPlayedInMatch.AddRange(teamsBL.GetStartingPitcherForThisTeam(newMatch.AwayTeam, newMatch));

            newMatch.HomeTeam.BattingLineup = teamsBL.GetCurrentLineupForThisMatch(newMatch.HomeTeam.TeamAbbreviation, MatchID);
            newMatch.HomeTeam.PitchersPlayedInMatch.AddRange(teamsBL.GetStartingPitcherForThisTeam(newMatch.HomeTeam, newMatch));

            MainForm newMatchForm = new MainForm(newMatch);
            newMatchForm.ShowDialog();

            if (newMatchForm.DialogResult == DialogResult.OK)
            {
                DialogResult = DialogResult.OK;
                newMatchForm.Dispose();
                Hide();
            }
            else if (newMatchForm.DialogResult == DialogResult.Yes)
            {
                ExitFromCurrentMatch = newMatchForm.DeleteThisMatch;
                MatchNumber = newMatchForm.currentMatch.MatchID;
                newMatchForm.Dispose();
                Hide();
                DialogResult = DialogResult.Yes;
            }
        }
    }
}