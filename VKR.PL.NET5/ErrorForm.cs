﻿using System.Windows.Forms;

namespace VKR.PL.NET5
{
    public partial class ErrorForm : Form
    {
        public ErrorForm(string message)
        {
            InitializeComponent();
            lbHeader.Text = message.ToUpperInvariant();
        }
    }
}