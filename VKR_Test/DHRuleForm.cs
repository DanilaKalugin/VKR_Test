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
            dateTimePicker1.Value = Program.MatchDate;
            HomeTeam = _HomeTeam;
            AwayTeam = _AwayTeam;
            stadiumForThisMatch = _stadium;
            radioButton1.Checked = HomeTeam.DHRule;
            radioButton2.Checked = !HomeTeam.DHRule;
            playingWithDH = radioButton1.Checked;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            playingWithDH = radioButton1.Checked;
        }

        private void btnAcceptDHRule_Click(object sender, EventArgs e)
        {
            int MatchID = matchBL.GetNumberOfMatchesPlayed();
            Match newMatch = new Match(MatchID, HomeTeam, AwayTeam, stadiumForThisMatch, playingWithDH, dateTimePicker1.Value.Date);

            newMatch.AwayTeam.BattingLineup = teamsBL.GetStartingLineupForThisMatch(newMatch.AwayTeam.TeamAbbreviation, playingWithDH);
            newMatch.AwayTeam.PitchersPlayedInMatch.AddRange(teamsBL.GetStartingPitcherForThisTeam(AwayTeam));

            newMatch.HomeTeam.BattingLineup = teamsBL.GetStartingLineupForThisMatch(newMatch.HomeTeam.TeamAbbreviation, playingWithDH);
            newMatch.HomeTeam.PitchersPlayedInMatch.AddRange(teamsBL.GetStartingPitcherForThisTeam(HomeTeam));
            matchBL.StartNewMatch(newMatch);
            MainForm newMatchForm = new MainForm(newMatch);
            newMatchForm.ShowDialog();

            if (newMatchForm.DialogResult == DialogResult.OK)
            {
                DialogResult = DialogResult.OK;
                Close();
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