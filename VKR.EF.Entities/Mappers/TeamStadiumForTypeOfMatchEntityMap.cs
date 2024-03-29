﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKR.EF.Entities.Tables;

namespace VKR.EF.Entities.Mappers
{
    public class TeamStadiumForTypeOfMatchEntityMap: IEntityTypeConfiguration<TeamStadiumForTypeOfMatch>
    {
        public void Configure(EntityTypeBuilder<TeamStadiumForTypeOfMatch> builder)
        {
            builder.HasKey(tsmt => new
            {
                tsmt.TeamAbbreviation,
                tsmt.TypeOfMatchId
            });

            builder.HasOne(tsmt => tsmt.Team)
                .WithMany(t => t.StadiumsForMatchTypes)
                .HasForeignKey(tsmt => tsmt.TeamAbbreviation)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(tsmt => tsmt.Stadium)
                .WithMany(s => s.StadiumsForMatchTypes)
                .HasForeignKey(tsmt => tsmt.StadiumId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(tsmt => tsmt.TypeOfMatch)
                .WithMany(mt => mt.TeamStadiumsForMatchTypes)
                .HasForeignKey(tsmt => tsmt.TypeOfMatchId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}