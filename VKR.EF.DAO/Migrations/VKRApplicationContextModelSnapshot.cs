﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VKR.EF.DAO;

namespace VKR.EF.DAO.Migrations
{
    [DbContext(typeof(VKRApplicationContext))]
    partial class VKRApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<short>("TripleProbability")
                        .HasColumnType("smallint");

                    b.HasKey("TeamAbbreviation");

                    b.HasAlternateKey("TeamCity", "TeamName");

                    b.HasIndex("DivisionId");

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

            modelBuilder.Entity("VKR.EF.Entities.Division", b =>
                {
                    b.HasOne("VKR.EF.Entities.League", "League")
                        .WithMany("Divisions")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("League");
                });

            modelBuilder.Entity("VKR.EF.Entities.Team", b =>
                {
                    b.HasOne("VKR.EF.Entities.Division", "Division")
                        .WithMany("Teams")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Division");
                });

            modelBuilder.Entity("VKR.EF.Entities.Division", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("VKR.EF.Entities.League", b =>
                {
                    b.Navigation("Divisions");
                });
#pragma warning restore 612, 618
        }
    }
}
