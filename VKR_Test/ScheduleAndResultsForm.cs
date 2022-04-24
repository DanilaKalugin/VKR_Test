using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VKR_Test
{
    public partial class ScheduleAndResultsForm : Form
    {
        private Match currentMatch;
        private MatchResultsForm form;

        public ScheduleAndResultsForm(Match match)
        {
            InitializeComponent();
            currentMatch = match;
            seriesHeader.Text = $"{currentMatch.AwayTeam.TeamAbbreviation} - {currentMatch.HomeTeam.TeamAbbreviation} series";
            team1Header.Text = currentMatch.AwayTeam.TeamTitle;
            team2Header.Text = currentMatch.HomeTeam.TeamTitle;
        }

        private void btnSeriesHistory_Click(object sender, EventArgs e)
        {
            form = new MatchResultsForm(currentMatch.AwayTeam, currentMatch.HomeTeam, MatchResultsForm.TableType.Results);
            Visible = false;
            form.ShowDialog();
            Visible = true;
        }

        private void btnSeriesNextMatches_Click(object sender, EventArgs e)
        {
            form = new MatchResultsForm(currentMatch.AwayTeam, currentMatch.HomeTeam, MatchResultsForm.TableType.Schedule);
            Visible = false;
            form.ShowDialog();
            Visible = true;
        }

        private void btnMatchDayResults_Click(object sender, EventArgs e)
        {
            form = new MatchResultsForm(currentMatch.MatchDate, true, MatchResultsForm.TableType.Results);
            Visible = false;
            form.ShowDialog();
            Visible = true;
        }

        private void btnMatchDayUpcomingMatches_Click(object sender, EventArgs e)
        {
            form = new MatchResultsForm(currentMatch.MatchDate, true, MatchResultsForm.TableType.Schedule);
            Visible = false;
            form.ShowDialog();
            Visible = true;
        }

        private void btnTeam1Last10Matches_Click(object sender, EventArgs e)
        {
            form = new MatchResultsForm(currentMatch.AwayTeam, MatchResultsForm.TableType.Results);
            Visible = false;
            form.ShowDialog();
            Visible = true;
        }

        private void btnTeam1Next10Matches_Click(object sender, EventArgs e)
        {
            form = new MatchResultsForm(currentMatch.AwayTeam, MatchResultsForm.TableType.Schedule);
            Visible = false;
            form.ShowDialog();
            Visible = true;
        }

        private void btnTeam2Last10Matches_Click(object sender, EventArgs e)
        {
            form = new MatchResultsForm(currentMatch.HomeTeam, MatchResultsForm.TableType.Results);
            Visible = false;
            form.ShowDialog();
            Visible = true;
        }

        private void btnTeam2Next10Matches_Click(object sender, EventArgs e)
        {
            form = new MatchResultsForm(currentMatch.HomeTeam, MatchResultsForm.TableType.Schedule);
            Visible = false;
            form.ShowDialog();
            Visible = true;
        }
    }
}