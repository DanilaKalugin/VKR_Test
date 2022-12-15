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
    [Migration("20220603053418_Added-Entity-TypeOfMatch")]
    partial class AddedEntityTypeOfMatch
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PlayerPlayerPosition", b =>
                {
                    b.Property<long>("PlayersId")
                        .HasColumnType("bigint");

                    b.Property<string>("PositionsShortTitle")
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("PlayersId", "PositionsShortTitle");

                    b.HasIndex("PositionsShortTitle");

                    b.ToTable("PlayersPositions");
                });

            modelBuilder.Entity("VKR.EF.Entities.BattingHand", b =>
                {
                    b.Property<byte>("BattingHandId")
                        .HasColumnType("tinyint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.HasKey("BattingHandId");

                    b.HasAlternateKey("Description");

                    b.ToTable("BattingHand");

                    b.HasData(
                        new
                        {
                            BattingHandId = (byte)1,
                            Description = "Left"
                        },
                        new
                        {
                            BattingHandId = (byte)2,
                            Description = "Right"
                        },
                        new
                        {
                            BattingHandId = (byte)3,
                            Description = "Switch"
                        });
                });

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

            modelBuilder.Entity("VKR.EF.Entities.InTeamStatus", b =>
                {
                    b.Property<byte>("InTeamStatusId")
                        .HasColumnType("tinyint");

                    b.Property<string>("InTeamStatusTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("InTeamStatusId");

                    b.HasAlternateKey("InTeamStatusTitle");

                    b.ToTable("InTeamStatuses");

                    b.HasData(
                        new
                        {
                            InTeamStatusId = (byte)0,
                            InTeamStatusTitle = "NotInThisTeam"
                        },
                        new
                        {
                            InTeamStatusId = (byte)1,
                            InTeamStatusTitle = "ActiveRoster"
                        },
                        new
                        {
                            InTeamStatusId = (byte)2,
                            InTeamStatusTitle = "Reserve"
                        });
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

            modelBuilder.Entity("VKR.EF.Entities.Match", b =>
                {
                    b.Property<int>("MatchID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AwayTeamAbbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)")
                        .HasColumnName("AwayTeam");

                    b.Property<bool>("DHRule")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("HomeTeamAbbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)")
                        .HasColumnName("HomeTeam");

                    b.Property<bool>("IsQuickMatch")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("MatchDate")
                        .HasColumnType("date");

                    b.Property<bool>("MatchEnded")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<byte>("MatchLength")
                        .HasColumnType("tinyint");

                    b.Property<short>("StadiumId")
                        .HasColumnType("smallint")
                        .HasColumnName("Stadium");

                    b.HasKey("MatchID");

                    b.HasIndex("AwayTeamAbbreviation");

                    b.HasIndex("HomeTeamAbbreviation");

                    b.HasIndex("StadiumId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("VKR.EF.Entities.PitchingHand", b =>
                {
                    b.Property<byte>("PitchingHandId")
                        .HasColumnType("tinyint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("PitchingHandId");

                    b.HasAlternateKey("Description");

                    b.ToTable("PitchingHand");

                    b.HasData(
                        new
                        {
                            PitchingHandId = (byte)1,
                            Description = "Left"
                        },
                        new
                        {
                            PitchingHandId = (byte)2,
                            Description = "Right"
                        });
                });

            modelBuilder.Entity("VKR.EF.Entities.Player", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("PlayerID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

                    b.Property<byte>("CurrentPlayerStatus")
                        .HasColumnType("tinyint");

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

                    b.Property<byte>("PlayerBattingHand")
                        .HasColumnType("tinyint");

                    b.Property<byte>("PlayerNumber")
                        .HasColumnType("tinyint");

                    b.Property<byte>("PlayerPitchingHand")
                        .HasColumnType("tinyint");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)")
                        .HasColumnName("PlayerSecondName");

                    b.HasKey("Id");

                    b.HasIndex("CurrentPlayerStatus");

                    b.HasIndex("PlaceOfBirth");

                    b.HasIndex("PlayerBattingHand");

                    b.HasIndex("PlayerPitchingHand");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("VKR.EF.Entities.PlayerInTeam", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("PlayerInTeamID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

                    b.Property<byte>("CurrentPlayerInTeamStatus")
                        .HasColumnType("tinyint")
                        .HasColumnName("InTeamStatus");

                    b.Property<long>("PlayerId")
                        .HasColumnType("bigint");

                    b.Property<string>("TeamId")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("Id");

                    b.HasIndex("CurrentPlayerInTeamStatus");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("PlayersInTeams");
                });

            modelBuilder.Entity("VKR.EF.Entities.PlayerPosition", b =>
                {
                    b.Property<string>("ShortTitle")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("PositionCode");

                    b.Property<string>("FullTitle")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("PositionFullTitle");

                    b.Property<byte>("Number")
                        .HasColumnType("tinyint");

                    b.HasKey("ShortTitle");

                    b.HasAlternateKey("FullTitle");

                    b.HasAlternateKey("Number");

                    b.ToTable("PlayerPositions");
                });

            modelBuilder.Entity("VKR.EF.Entities.PlayerStatus", b =>
                {
                    b.Property<byte>("PlayerStatusId")
                        .HasColumnType("tinyint");

                    b.Property<string>("PlayerStatusName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("PlayerStatusId");

                    b.HasAlternateKey("PlayerStatusName");

                    b.ToTable("PlayerStatuses");

                    b.HasData(
                        new
                        {
                            PlayerStatusId = (byte)1,
                            PlayerStatusName = "Active"
                        },
                        new
                        {
                            PlayerStatusId = (byte)2,
                            PlayerStatusName = "FreeAgent"
                        },
                        new
                        {
                            PlayerStatusId = (byte)3,
                            PlayerStatusName = "Retired"
                        });
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

            modelBuilder.Entity("VKR.EF.Entities.TypeOfMatch", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Description");

                    b.ToTable("TypesOfMatches");

                    b.HasData(
                        new
                        {
                            Id = (byte)0,
                            Description = "QuickMatch"
                        },
                        new
                        {
                            Id = (byte)1,
                            Description = "RegularSeason"
                        },
                        new
                        {
                            Id = (byte)2,
                            Description = "Postseason"
                        },
                        new
                        {
                            Id = (byte)3,
                            Description = "SpringTraining"
                        });
                });

            modelBuilder.Entity("PlayerPlayerPosition", b =>
                {
                    b.HasOne("VKR.EF.Entities.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VKR.EF.Entities.PlayerPosition", null)
                        .WithMany()
                        .HasForeignKey("PositionsShortTitle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("VKR.EF.Entities.Match", b =>
                {
                    b.HasOne("VKR.EF.Entities.Team", "AwayTeam")
                        .WithMany("AwayMatches")
                        .HasForeignKey("AwayTeamAbbreviation")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("VKR.EF.Entities.Team", "HomeTeam")
                        .WithMany("HomeMatches")
                        .HasForeignKey("HomeTeamAbbreviation")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("VKR.EF.Entities.Stadium", "Stadium")
                        .WithMany("MatchesPlayedInThisStadium")
                        .HasForeignKey("StadiumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AwayTeam");

                    b.Navigation("HomeTeam");

                    b.Navigation("Stadium");
                });

            modelBuilder.Entity("VKR.EF.Entities.Player", b =>
                {
                    b.HasOne("VKR.EF.Entities.PlayerStatus", "PlayerStatus")
                        .WithMany("Players")
                        .HasForeignKey("CurrentPlayerStatus")
                        .IsRequired();

                    b.HasOne("VKR.EF.Entities.City", "City")
                        .WithMany("Players")
                        .HasForeignKey("PlaceOfBirth")
                        .IsRequired();

                    b.HasOne("VKR.EF.Entities.BattingHand", "BattingHand")
                        .WithMany("Players")
                        .HasForeignKey("PlayerBattingHand")
                        .IsRequired();

                    b.HasOne("VKR.EF.Entities.PitchingHand", "PitchingHand")
                        .WithMany("Players")
                        .HasForeignKey("PlayerPitchingHand")
                        .IsRequired();

                    b.Navigation("BattingHand");

                    b.Navigation("City");

                    b.Navigation("PitchingHand");

                    b.Navigation("PlayerStatus");
                });

            modelBuilder.Entity("VKR.EF.Entities.PlayerInTeam", b =>
                {
                    b.HasOne("VKR.EF.Entities.InTeamStatus", "InTeamStatus")
                        .WithMany("PlayerInTeams")
                        .HasForeignKey("CurrentPlayerInTeamStatus")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VKR.EF.Entities.Player", "Player")
                        .WithMany("PlayersInTeam")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VKR.EF.Entities.Team", "Team")
                        .WithMany("PlayersInTeam")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InTeamStatus");

                    b.Navigation("Player");

                    b.Navigation("Team");
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

            modelBuilder.Entity("VKR.EF.Entities.BattingHand", b =>
                {
                    b.Navigation("Players");
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

            modelBuilder.Entity("VKR.EF.Entities.InTeamStatus", b =>
                {
                    b.Navigation("PlayerInTeams");
                });

            modelBuilder.Entity("VKR.EF.Entities.League", b =>
                {
                    b.Navigation("Divisions");
                });

            modelBuilder.Entity("VKR.EF.Entities.Manager", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("VKR.EF.Entities.PitchingHand", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("VKR.EF.Entities.Player", b =>
                {
                    b.Navigation("PlayersInTeam");
                });

            modelBuilder.Entity("VKR.EF.Entities.PlayerStatus", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("VKR.EF.Entities.Stadium", b =>
                {
                    b.Navigation("MatchesPlayedInThisStadium");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("VKR.EF.Entities.Team", b =>
                {
                    b.Navigation("AwayMatches");

                    b.Navigation("HomeMatches");

                    b.Navigation("PlayersInTeam");

                    b.Navigation("TeamColors");
                });
#pragma warning restore 612, 618
        }
    }
}
