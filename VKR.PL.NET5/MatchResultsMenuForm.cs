﻿using System;
using System.Windows.Forms;
using VKR.BLL.NET5;

namespace VKR.PL.NET5
{
    public partial class MatchResultsMenuForm : Form
    {
        private readonly MatchBL _matchBL = new();

        public MatchResultsMenuForm() => InitializeComponent();

        private async void btnResultsByDate_Click(object sender, EventArgs e)
        {
            Visible = false;
            var matchDate = await _matchBL.GetMaxDateForAllMatchesAsync();
            using (var form = new MatchResultsForm(matchDate, false, MatchScheduleBL.TableType.Results))
                form.ShowDialog();
            Visible = true;
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            Visible = false;
            using (var form = new MatchResultsForm(MatchScheduleBL.TableType.Results)) 
                form.ShowDialog();
            Visible = true;
        }

        private void btnCloseResultsMenu_Click(object sender, EventArgs e) => Close();

        private void btnScheduleByTeam_Click(object sender, EventArgs e)
        {
            Visible = false;
            using (var form = new MatchResultsForm(MatchScheduleBL.TableType.Schedule)) 
                form.ShowDialog();
            Visible = true;
        }

        private async void btnScheduleByDate_Click(object sender, EventArgs e)
        {
            Visible = false;
            var matchDate = await _matchBL.GetMaxDateForAllMatchesAsync();
            using (var form = new MatchResultsForm(matchDate, false, MatchScheduleBL.TableType.Schedule))
                form.ShowDialog();
            Visible = true;
        }
    }
}