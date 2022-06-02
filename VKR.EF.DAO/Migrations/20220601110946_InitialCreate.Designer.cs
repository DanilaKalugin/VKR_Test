﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VKR.EF.DAO;

namespace VKR.EF.DAO.Migrations
{
    [DbContext(typeof(VKRApplicationContext))]
    [Migration("20220601110946_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
#pragma warning restore 612, 618
        }
    }
}