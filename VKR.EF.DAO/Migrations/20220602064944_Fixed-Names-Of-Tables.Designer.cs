﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VKR.EF.DAO.Contexts;

namespace VKR.EF.DAO.Migrations
{
    [DbContext(typeof(VKRApplicationContext))]
    [Migration("20220602064944_Fixed-Names-Of-Tables")]
    partial class FixedNamesOfTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VKR.EF.Entities.City", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("CityID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)")
                        .HasColumnName("Country");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CityName");

                    b.HasKey("Id");

                    b.HasIndex("CountryCode");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("VKR.EF.Entities.Country", b =>
                {
                    b.Property<string>("CountryCode")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CountryCode");

                    b.HasAlternateKey("CountryName");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("VKR.EF.Entities.Division", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DivisionNumber")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DivisionTitle")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("LeagueId")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("League");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("VKR.EF.Entities.League", b =>
                {
                    b.Property<string>("LeagueId")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("LeagueID");

                    b.Property<bool>("DHRule")
                        .HasColumnType("bit")
                        .HasColumnName("LeagueDHRule");

                    b.Property<string>("LeagueTitle")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<short>("YearOfFoundation")
                        .HasColumnType("smallint")
                        .HasColumnName("LeagueYearOfFoundation");

                    b.HasKey("LeagueId");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("VKR.EF.Entities.Manager", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("ManagerID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("ManagerDateOfBirth");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("ManagerFirstName");

                    b.Property<short>("PlaceOfBirth")
                        .HasColumnType("smallint")
                        .HasColumnName("ManagerPlaceOfBirth");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("ManagerSecondName");

                    b.HasKey("Id");

                    b.HasIndex("PlaceOfBirth");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("VKR.EF.Entities.Player", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("PlayerID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("PlayerDateOfBirth");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)")
                        .HasColumnName("PlayerFirstName");

                    b.Property<short>("PlaceOfBirth")
                        .HasColumnType("smallint");

                    b.Property<byte>("PlayerNumber")
                        .HasColumnType("tinyint");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)")
                        .HasColumnName("PlayerSecondName");

                    b.HasKey("Id");

                    b.HasIndex("PlaceOfBirth");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("VKR.EF.Entities.Stadium", b =>
                {
                    b.Property<short>("StadiumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

                    b.Property<long>("StadiumCapacity")
                        .HasColumnType("bigint");

                    b.Property<int>("StadiumDistanceToCenterfield")
                        .HasColumnType("int")
                        .HasColumnName("StadiumDistanceToCenterField");

                    b.Property<short>("StadiumLocation")
                        .HasColumnType("smallint");

                    b.Property<string>("StadiumTitle")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.HasKey("StadiumId");

                    b.HasAlternateKey("StadiumTitle");

                    b.HasIndex("StadiumLocation");

                    b.ToTable("Stadiums");
                });

            modelBuilder.Entity("VKR.EF.Entities.Team", b =>
                {
                    b.Property<string>("TeamAbbreviation")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int>("DivisionId")
                        .HasColumnType("int")
                        .HasColumnName("TeamDivision");

                    b.Property<byte>("DoublePlayProbability")
                        .HasColumnType("tinyint");

                    b.Property<short>("DoubleProbability")
                        .HasColumnType("smallint");

                    b.Property<short>("FlyoutOnHomeRunProbability")
                        .HasColumnType("smallint");

                    b.Property<short>("FlyoutProbability")
                        .HasColumnType("smallint");

                    b.Property<short>("FoulProbability")
                        .HasColumnType("smallint");

                    b.Property<short>("GroundoutProbability")
                        .HasColumnType("smallint");

                    b.Property<short>("HitByPitchProbability")
                        .HasColumnType("smallint");

                    b.Property<short>("HittingProbability")
                        .HasColumnType("smallint");

                    b.Property<short>("HomeRunProbability")
                        .HasColumnType("smallint");

                    b.Property<short>("PopoutOnFoulProbability")
                        .HasColumnType("smallint");

                    b.Property<byte>("SacrificeFlyProbability")
                        .HasColumnType("tinyint");

                    b.Property<short>("SingleProbability")
                        .HasColumnType("smallint");

                    b.Property<short>("StealingBaseProbability")
                        .HasColumnType("smallint");

                    b.Property<short>("StrikeZoneProbability")
                        .HasColumnType("smallint");

                    b.Property<short>("SuccessfulBuntAttemptProbability")
                        .HasColumnType("smallint");

                    b.Property<byte>("SuccessfulStealingBaseAttemptProbability")
                        .HasColumnType("tinyint")
                        .HasColumnName("StealingBaseSuccessfulAttemptProbability");

                    b.Property<byte>("SwingInStrikeZoneProbability")
                        .HasColumnType("tinyint");

                    b.Property<byte>("SwingOutsideStrikeZoneProbability")
                        .HasColumnType("tinyint");

                    b.Property<string>("TeamCity")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<short>("TeamManager")
                        .HasColumnType("smallint");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<short>("TeamStadium")
                        .HasColumnType("smallint");

                    b.Property<short>("TripleProbability")
                        .HasColumnType("smallint");

                    b.HasKey("TeamAbbreviation");

                    b.HasAlternateKey("TeamCity", "TeamName");

                    b.HasIndex("DivisionId");

                    b.HasIndex("TeamManager");

                    b.HasIndex("TeamStadium");

                    b.ToTable("Teams");

                    b.HasCheckConstraint("StrikeZoneProbability", "StrikeZoneProbability BETWEEN 1 AND 3000");

                    b.HasCheckConstraint("HitByPitchProbability", "HitByPitchProbability BETWEEN 1 AND 3000");

                    b.HasCheckConstraint("SwingInStrikeZoneProbability", "SwingInStrikeZoneProbability BETWEEN 1 AND 100");

                    b.HasCheckConstraint("SwingOutsideStrikeZoneProbability", "SwingOutsideStrikeZoneProbability BETWEEN 1 AND 100");

                    b.HasCheckConstraint("HittingProbability", "HittingProbability BETWEEN 1 AND 2000");

                    b.HasCheckConstraint("FoulProbability", "FoulProbability BETWEEN 1 AND 2000");

                    b.HasCheckConstraint("SingleProbability", "SingleProbability BETWEEN 1 AND 2000");

                    b.HasCheckConstraint("DoubleProbability", "DoubleProbability BETWEEN 1 AND 2000");

                    b.HasCheckConstraint("HomeRunProbability", "HomeRunProbability BETWEEN 1 AND 2000");

                    b.HasCheckConstraint("TripleProbability", "TripleProbability BETWEEN 1 AND 2000");

                    b.HasCheckConstraint("PopoutOnFoulProbability", "PopoutOnFoulProbability BETWEEN 1 AND 1000");

                    b.HasCheckConstraint("FlyoutOnHomeRunProbability", "FlyoutOnHomeRunProbability BETWEEN 1 AND 1000");

                    b.HasCheckConstraint("GroundoutProbability", "GroundoutProbability BETWEEN 1 AND 1000");

                    b.HasCheckConstraint("FlyoutProbability", "FlyoutProbability BETWEEN 1 AND 1000");

                    b.HasCheckConstraint("DoublePlayProbability", "DoublePlayProbability BETWEEN 1 AND 100");

                    b.HasCheckConstraint("SacrificeFlyProbability", "SacrificeFlyProbability BETWEEN 1 AND 100");

                    b.HasCheckConstraint("StealingBaseProbability", "StealingBaseProbability BETWEEN 1 AND 1000");

                    b.HasCheckConstraint("StealingBaseSuccessfulAttemptProbability", "StealingBaseSuccessfulAttemptProbability BETWEEN 1 AND 100");

                    b.HasCheckConstraint("SuccessfulBuntAttemptProbability", "SuccessfulBuntAttemptProbability BETWEEN 1 AND 100");
                });

            modelBuilder.Entity("VKR.EF.Entities.TeamColor", b =>
                {
                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(3)");

                    b.Property<byte>("ColorNumber")
                        .HasColumnType("tinyint");

                    b.Property<byte>("BlueComponent")
                        .HasColumnType("tinyint");

                    b.Property<byte>("GreenComponent")
                        .HasColumnType("tinyint");

                    b.Property<byte>("RedComponent")
                        .HasColumnType("tinyint");

                    b.HasKey("TeamName", "ColorNumber");

                    b.ToTable("TeamColors");
                });

            modelBuilder.Entity("VKR.EF.Entities.City", b =>
                {
                    b.HasOne("VKR.EF.Entities.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("VKR.EF.Entities.Division", b =>
                {
                    b.HasOne("VKR.EF.Entities.League", "League")
                        .WithMany("Divisions")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("League");
                });

            modelBuilder.Entity("VKR.EF.Entities.Manager", b =>
                {
                    b.HasOne("VKR.EF.Entities.City", "City")
                        .WithMany("Managers")
                        .HasForeignKey("PlaceOfBirth")
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("VKR.EF.Entities.Player", b =>
                {
                    b.HasOne("VKR.EF.Entities.City", "City")
                        .WithMany("Players")
                        .HasForeignKey("PlaceOfBirth")
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("VKR.EF.Entities.Stadium", b =>
                {
                    b.HasOne("VKR.EF.Entities.City", "StadiumCity")
                        .WithMany("Stadiums")
                        .HasForeignKey("StadiumLocation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StadiumCity");
                });

            modelBuilder.Entity("VKR.EF.Entities.Team", b =>
                {
                    b.HasOne("VKR.EF.Entities.Division", "Division")
                        .WithMany("Teams")
                        .HasForeignKey("DivisionId")
                        .IsRequired();

                    b.HasOne("VKR.EF.Entities.Manager", "Manager")
                        .WithMany("Teams")
                        .HasForeignKey("TeamManager")
                        .IsRequired();

                    b.HasOne("VKR.EF.Entities.Stadium", "Stadium")
                        .WithMany("Teams")
                        .HasForeignKey("TeamStadium")
                        .IsRequired();

                    b.Navigation("Division");

                    b.Navigation("Manager");

                    b.Navigation("Stadium");
                });

            modelBuilder.Entity("VKR.EF.Entities.TeamColor", b =>
                {
                    b.HasOne("VKR.EF.Entities.Team", "Team")
                        .WithMany("TeamColors")
                        .HasForeignKey("TeamName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("VKR.EF.Entities.City", b =>
                {
                    b.Navigation("Managers");

                    b.Navigation("Players");

                    b.Navigation("Stadiums");
                });

            modelBuilder.Entity("VKR.EF.Entities.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("VKR.EF.Entities.Division", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("VKR.EF.Entities.League", b =>
                {
                    b.Navigation("Divisions");
                });

            modelBuilder.Entity("VKR.EF.Entities.Manager", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("VKR.EF.Entities.Stadium", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("VKR.EF.Entities.Team", b =>
                {
                    b.Navigation("TeamColors");
                });
#pragma warning restore 612, 618
        }
    }
}
