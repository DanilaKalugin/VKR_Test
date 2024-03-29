﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKR.EF.Entities.Tables;

namespace VKR.EF.Entities.Mappers
{
    public class LineupForMatchEntityMap : IEntityTypeConfiguration<LineupForMatch>
    {
        public void Configure(EntityTypeBuilder<LineupForMatch> builder)
        {
            builder.ToTable("LineupsForMatches");

            builder.HasKey(ml => ml.Id);

            builder.Property(ml => ml.PlayerNumberInLineup)
                .HasColumnName("NumberInLineup")
                .IsRequired();

            builder.HasOne(ml => ml.PlayerInTeam)
                .WithMany(pit => pit.PlayersPlayedInMatch)
                .HasForeignKey(ml => ml.PlayerInTeamId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(ml => ml.PlayerPosition)
                .WithMany(pp => pp.PlayerPositionsInLineup)
                .HasForeignKey(sl => sl.PlayerPositionId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
            
            builder.HasOne(ml => ml.Match)
                .WithMany(m => m.LineupsForMatches)
                .HasForeignKey(ml => ml.MatchId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.Property(sl => sl.PlayerPositionId)
                .HasColumnName("PlayerPosition");

            builder.Property(sl => sl.Id).ValueGeneratedOnAdd();
        }
    }
}