﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKR.EF.Entities.Enums;
using VKR.EF.Entities.Tables;

namespace VKR.EF.Entities.Mappers
{
    public class PitcherResultsTypeEntityMap : IEntityTypeConfiguration<PitcherResultsType>
    {
        public void Configure(EntityTypeBuilder<PitcherResultsType> builder)
        {
            builder.ToTable("TypesOfMatchResultsForPitcher");

            builder.HasKey(mt => mt.Id);

            builder.HasAlternateKey(mt => mt.Description);

            builder.Property(mt => mt.Id)
                .HasConversion<byte>();

            builder.HasData(
                Enum.GetValues(typeof(PitcherResultEnum))
                    .Cast<PitcherResultEnum>()
                    .Select(e => new PitcherResultsType
                    {
                        Id = e,
                        Description = e.ToString()
                    })
            );

            builder.Property(bh => bh.Description)
                .HasMaxLength(25)
                .IsRequired();
        }
    }
}