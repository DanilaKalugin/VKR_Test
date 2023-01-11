using Microsoft.EntityFrameworkCore;
using System.Configuration;
using VKR.EF.Entities.Views;

namespace VKR.EF.DAO.Contexts
{
    internal class PlayerBirthdayContext : DbContext
    {
        public DbSet<ManInTeam> ManInTeam { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                var connectionString = GetConnectionString();
                optionsBuilder.UseSqlServer(connectionString);
            }
            catch
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-I3JNR48\SQLEXPRESS;Initial Catalog=VKR_EF;Integrated Security=True;");
            }
        }

        public static string GetConnectionString()
        {
            var currentConnection = ConfigurationManager.AppSettings["CurrentConnectionString"];
            var connectionString = ConfigurationManager.ConnectionStrings[currentConnection].ConnectionString;
            return connectionString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Entities.Mappers.ManInTeamViewMap());
        }
    }
}
