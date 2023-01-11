using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;
using System.Configuration;

namespace VKR.EF.DAO.Contexts
{
    public sealed class VKRApplicationContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamBalance> TeamStandings { get; set; }
        public DbSet<MatchFromSchedule> NextMatches { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<RunsByTeam> RunsByTeam { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<TeamStadiumForTypeOfMatch> TeamStadiumForTypeOfMatch { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerBattingStats> PlayersBattingStats { get; set; }
        public DbSet<PlayerPitchingStats> PlayersPitchingStats { get; set; }
        public DbSet<TeamBattingStats> TeamsBattingStats { get; set; }
        public DbSet<TeamPitchingStats> TeamsPitchingStats { get; set; }
        public DbSet<StartingLineup> StartingLineups { get; set; }
        public DbSet<LineupType> LineupTypes { get; set; }
        public DbSet<LineupForMatch> LineupsForMatches { get; set; }
        public DbSet<PlayerPosition> PlayersPositions { get; set; }
        public DbSet<PlayerInTeam> PlayersInTeams { get; set; }
        public DbSet<AtBat> AtBats { get; set; }
        public DbSet<MatchResult> MatchResults { get; set; }
        public DbSet<PitcherResults> PitcherResults { get; set; }
        public DbSet<ActiveMatchResult> ActiveMatchResults { get; set; }
        public DbSet<TeamColor> TeamColors { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<LeagueSeason> LeagueSeasons { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Run> Runs { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<StadiumFactor> StadiumFactors { get; set; }
        public DbSet<RetiredNumber> RetiredNumbers { get; set; }
        public DbSet<TeamHistoricalName> TeamHistoricalNames { get; set; }

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
            modelBuilder.ApplyConfiguration(new Entities.Mappers.TeamRatingEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.SeasonEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.LeagueSeasonEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.RunEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.StadiumFactorEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.RetiredNumberEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.TeamHistoricalNameEntityMap());

            modelBuilder.ApplyConfiguration(new Entities.Mappers.PlayerBattingStatsViewMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.PlayerPitchingStatsViewMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.StandingsViewMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.TeamBattingStatsViewMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.TeamPitchingStatsViewMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.RunsScoredByTeamViewMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.ActiveMatchResultsViewMap());

            modelBuilder.ApplyConfiguration(new Entities.Mappers.TeamStreakFunctionMap());

            modelBuilder.HasDbFunction(typeof(VKRApplicationContext)
                        .GetMethod(nameof(ReturnStreakForAllTeams), new[] { typeof(DateTime), typeof(TypeOfMatchEnum) }))
                        .HasName("ReturnStreakForAllTeams");

            modelBuilder.HasDbFunction(typeof(VKRApplicationContext)
                    .GetMethod(nameof(GetStaminaForThisPitcher), new[] { typeof(uint), typeof(DateTime) }))
                .HasName("GetStaminaForThisPitcher");

            modelBuilder.Ignore<Batter>();
            modelBuilder.Ignore<Pitcher>();
        }

        public IQueryable<TeamStreak> ReturnStreakForAllTeams(DateTime date, TypeOfMatchEnum MatchType) => FromExpression(() => ReturnStreakForAllTeams(date, MatchType));

        [DbFunction("GetStaminaForThisPitcher", "DBO")]
        public int GetStaminaForThisPitcher(uint pitcherId, DateTime matchDate) => throw new NotImplementedException();
    }
}