using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VKR.BLL.NET5;
using VKR.EF.DAO;
using VKR.EF.DAO.Interfaces;

namespace VKR.PL.NET5
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<MainMenuForm>());
        }

        public static IServiceProvider? ServiceProvider { get; private set; }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IManDAO, ManEFDAO>();
                    services.AddTransient<IStandingsDAO, StandingsEFDAO>();

                    services.AddTransient<ManBL>();
                    services.AddTransient<StandingsBL>();

                    services.AddTransient<MainMenuForm>();
                });
        }
    }
}