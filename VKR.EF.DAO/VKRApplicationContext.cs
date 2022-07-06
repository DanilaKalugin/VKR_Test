using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Dataflow;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using VKR.EF.DAO.Migrations;
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

            modelBuilder.ApplyConfiguration(new Entities.Mappers.ManInTeamViewMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.PlayerBattingStatsViewMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.StandingsViewMap());

            modelBuilder.ApplyConfiguration(new Entities.Mappers.TeamStatViewMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.RunsScoredByTeamFunctionMap());

            modelBuilder.HasDbFunction(typeof(VKRApplicationContext)
                    .GetMethod(nameof(ReturnStreakForAllTeams), 
                        new [] {typeof(DateTime), typeof(byte)}))
                    .HasName("ReturnStreakForAllTeams");

            modelBuilder.HasDbFunction(typeof(VKRApplicationContext)
                    .GetMethod(nameof(RunsScoredByTeamBeforeThisDateInMatchType),
                        new[] { typeof(byte), typeof(DateTime) }))
                .HasName("RunsScoredByTeamBeforeThisDateInMatchType");
        }

        public IQueryable<RunsScoredByTeam> RunsScoredByTeamBeforeThisDateInMatchType(byte MatchType, DateTime date)
        {
            return FromExpression(() => RunsScoredByTeamBeforeThisDateInMatchType(MatchType, date));
        }
        public IQueryable<TeamStat> ReturnStreakForAllTeams(DateTime date, byte MatchType)
        {
            return FromExpression(() => ReturnStreakForAllTeams(date, MatchType));
        }
    }
}