using Entities;
using System;
using System.Drawing;
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
        private readonly MatchBL matchBL;
        private readonly TeamsBL teamsBL;

        public DHRuleForm(Team _HomeTeam, Team _AwayTeam, Stadium _stadium)
        {
            InitializeComponent();
            matchBL = new MatchBL();
            teamsBL = new TeamsBL();
            HomeTeam = _HomeTeam;
            AwayTeam = _AwayTeam;
            stadiumForThisMatch = _stadium;
            if (HomeTeam.DHRule)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            playingWithDH = radioButton1.Checked;
        }

        private void btnAcceptDHRule_Click(object sender, EventArgs e)
        {
            int MatchID = matchBL.GetNumberOfMatchesPlayed();
            Match newMatch = new Match(MatchID, HomeTeam, AwayTeam, stadiumForThisMatch, playingWithDH);
            matchBL.StartNewMatch(newMatch);
            newMatch.AwayTeam.BattingLineup = teamsBL.GetStartingLineupForThisMatch(newMatch.AwayTeam.TeamAbbreviation, playingWithDH);
            newMatch.AwayTeam.PitchersPlayedInMatch.AddRange(teamsBL.GetStartingPitcherForThisTeam(AwayTeam));

            newMatch.HomeTeam.BattingLineup = teamsBL.GetStartingLineupForThisMatch(newMatch.HomeTeam.TeamAbbreviation, playingWithDH);
            newMatch.HomeTeam.PitchersPlayedInMatch.AddRange(teamsBL.GetStartingPitcherForThisTeam(HomeTeam));

            MainForm newMatchForm = new MainForm(newMatch);
            newMatchForm.ShowDialog();

            if (newMatchForm.DialogResult == DialogResult.OK)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}