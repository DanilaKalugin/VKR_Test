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

                    b.Property<int>("YearOfFoundation")
                        .HasColumnType("int")
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

                    b.Property<string>("TeamCity")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("TeamAbbreviation");

                    b.HasIndex("DivisionId");

                    b.ToTable("Teams");
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
