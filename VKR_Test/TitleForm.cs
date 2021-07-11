using System;
using System.Drawing;
using System.Windows.Forms;

namespace VKR_Test
{
    public partial class TitleForm : Form
    {
        public TitleForm()
        {
            InitializeComponent();
            lbTitleEnglish.Text = lbTitleEnglish.Text.ToUpper();
            lbTitleEnglish.BackColor = Color.FromArgb(0, lbTitleEnglish.BackColor);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}