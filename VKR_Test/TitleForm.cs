using System;
using System.Windows.Forms;

namespace VKR_Test
{
    public partial class TitleForm : Form
    {
        public TitleForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenuForm form = new MainMenuForm();
            form.ShowDialog();
        }
    }
}