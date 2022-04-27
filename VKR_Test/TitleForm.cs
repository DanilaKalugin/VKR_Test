using System;
using System.Windows.Forms;

namespace VKR_Test
{
    public partial class TitleForm : Form
    {
        public TitleForm()
        {
            InitializeComponent();
            lbTitleEnglish.Text = lbTitleEnglish.Text.ToUpper();
        }

        private void button1_Click(object sender, EventArgs e) => Close();
    }
}