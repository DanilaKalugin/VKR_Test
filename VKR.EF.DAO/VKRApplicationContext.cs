using System;
using Microsoft.EntityFrameworkCore;

namespace VKR.EF.DAO
{
    public sealed class VKRApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-I3JNR48\SQLEXPRESS;Initial Catalog=VKR_EF;Integrated Security=True;");
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
            modelBuilder.ApplyConfiguration(new Entities.Mappers.LineupTypeMapper());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.StartingLineupEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.LineupForMatchEntityMap());
            modelBuilder.ApplyConfiguration(new Entities.Mappers.AtBatResultEntityMap());
        }
    }
}