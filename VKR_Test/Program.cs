using System;
using System.Windows.Forms;

namespace VKR_Test
{
    static class Program
    {
        public static DateTime MatchDate;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
       {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TitleForm());
        }
    }
}