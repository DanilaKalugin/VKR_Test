using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VKR.BLL;

namespace VKR_Test
{
    public partial class MatchResultsMenuForm : Form
    {
        private readonly MatchBL matchBL;

        public MatchResultsMenuForm()
        {
            InitializeComponent();
            matchBL = new MatchBL();
        }

        private void btnResultsByDate_Click(object sender, EventArgs e)
        {
            MatchResultsForm form = new MatchResultsForm(matchBL.GetMaxDateForAllMatches(), false);
            Visible = false;
            form.ShowDialog();
            Visible = true;
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            MatchResultsForm form = new MatchResultsForm();
            Visible = false;
            form.ShowDialog();
            Visible = true;
        }

        private void btnCloseResultsMenu_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
