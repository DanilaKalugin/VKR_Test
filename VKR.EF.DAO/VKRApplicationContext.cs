using System;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public sealed class VKRApplicationContext : DbContext
    {
        public DbSet<League> Leagues { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<TeamColor> TeamColors { get; set; }
        public DbSet<Player> Players { get; set; }

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
        }
    }
}