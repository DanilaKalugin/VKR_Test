using Entities;
using System;
using System.Windows.Forms;
using VKR.BLL;

namespace VKR_Test
{
    public partial class DHRuleForm : Form
    {
        Team HomeTeam;
        Team AwayTeam;
        Stadium stadiumForThisMatch;
        bool playingWithDH;
        public bool ExitFromCurrentMatch;
        private readonly MatchBL matchBL;
        private readonly TeamsBL teamsBL;
        public int MatchNumber;

        public DHRuleForm(Team _HomeTeam, Team _AwayTeam, Stadium _stadium)
        {
            InitializeComponent();
            matchBL = new MatchBL();
            teamsBL = new TeamsBL();
            Program.MatchDate = matchBL.GetMaxDateForAllMatches();
            dtpMatchDate.Value = Program.MatchDate;
            HomeTeam = _HomeTeam;
            AwayTeam = _AwayTeam;
            stadiumForThisMatch = _stadium;
            rbPlayWithDH.Checked = HomeTeam.DHRule;
            rbPlayWithoutDH.Checked = !HomeTeam.DHRule;
            playingWithDH = rbPlayWithDH.Checked;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            playingWithDH = rbPlayWithDH.Checked;
        }

        private void btnAcceptDHRule_Click(object sender, EventArgs e)
        {
            int MatchID = matchBL.GetNumberOfMatchesPlayed();
            Match newMatch = new Match(MatchID, HomeTeam, AwayTeam, stadiumForThisMatch, playingWithDH, dtpMatchDate.Value.Date);
            matchBL.StartNewMatch(newMatch);
            newMatch.AwayTeam.BattingLineup = teamsBL.GetCurrentLineupForThisMatch(newMatch.AwayTeam.TeamAbbreviation, MatchID);
            newMatch.AwayTeam.PitchersPlayedInMatch.AddRange(teamsBL.GetStartingPitcherForThisTeam(AwayTeam, newMatch));

            newMatch.HomeTeam.BattingLineup = teamsBL.GetCurrentLineupForThisMatch(newMatch.HomeTeam.TeamAbbreviation, MatchID);
            newMatch.HomeTeam.PitchersPlayedInMatch.AddRange(teamsBL.GetStartingPitcherForThisTeam(HomeTeam, newMatch));

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