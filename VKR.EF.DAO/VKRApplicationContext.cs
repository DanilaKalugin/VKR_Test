using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;
using System.Configuration;
using System.Diagnostics;

namespace VKR.EF.DAO
{
    public sealed class VKRApplicationContext : DbContext
    {
        public DbSet<ManInTeam> ManInTeam { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamBalance> TeamStandings { get; set; }
        public DbSet<MatchFromSchedule> NextMatches { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<RunsByTeam> Runs { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<TeamStadiumForTypeOfMatch> TeamStadiumForTypeOfMatch { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerBattingStats> PlayersBattingStats { get; set; }
        public DbSet<PlayerPitchingStats> PlayersPitchingStats { get; set; }
        public DbSet<TeamBattingStats> TeamsBattingStats { get; set; }
        public DbSet<TeamPitchingStats> TeamsPitchingStats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-I3JNR48\SQLEXPRESS;Initial Catalog=VKR_EF;Integrated Security=True;");

            optionsBuilder.LogTo(s => Debug.WriteLine(s), new[] { DbLoggerCategory.Database.Command.Name });
        }

        public static string GetConnectionString()
        {
            var currentConnection = ConfigurationManager.AppSettings["CurrentConnectionString"];
            var connectionString = ConfigurationManager.ConnectionStrings[currentConnection].ConnectionString;
            return connectionString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Entities.Mappers.LeagueEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.DivisionEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.TeamEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.CountryEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.CityEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.StadiumEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.ManagerEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.TeamColorEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.PlayerEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.BattingHandEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.PitchingHandEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.PlayerPositionEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.InTeamStatusEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.PlayerStatusEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.PlayerInTeamEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.MatchEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.TypeOfMatchEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.TeamStadiumForTypeOfMatchEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.MatchFromScheduleEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.LineupTypeEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.StartingLineupEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.LineupForMatchEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.AtBatResultEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.AtBatEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.PitcherResultEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.PitcherResultsTypeEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.RegionEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.MatchResultEntityMap());

            modelBuilder.ApplyConfiguration(new Entities.Mappers.ManInTeamViewMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.PlayerBattingStatsViewMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.PlayerPitchingStatsViewMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.StandingsViewMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.TeamBattingStatsViewMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.TeamPitchingStatsViewMap());

            modelBuilder.ApplyConfiguration(new Entities.Mappers.TeamStreakViewMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.RunsScoredByTeamFunctionMap());

            modelBuilder.HasDbFunction(typeof(VKRApplicationContext)
                        .GetMethod(nameof(ReturnStreakForAllTeams), new [] {typeof(DateTime), typeof(byte)}))
                        .HasName("ReturnStreakForAllTeams");
        }

        public IQueryable<TeamStreak> ReturnStreakForAllTeams(DateTime date, byte MatchType)
        {
            return FromExpression(() => ReturnStreakForAllTeams(date, MatchType));
        }
    }
}