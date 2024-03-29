﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKR.EF.Entities.Enums;
using VKR.EF.Entities.Tables;

namespace VKR.EF.Entities.Mappers
{
    public class BattingHandEntityMap : IEntityTypeConfiguration<BattingHand>
    {
        public void Configure(EntityTypeBuilder<BattingHand> builder)
        {
            builder.ToTable("BattingHand");
            builder.HasKey(bh => bh.BattingHandId);

            builder.HasAlternateKey(bh => bh.Description);

            builder.Property(bh => bh.BattingHandId)
                .HasConversion<byte>();

            builder.HasData(
                    Enum.GetValues(typeof(BattingHandEnum))
                        .Cast<BattingHandEnum>()
                        .Select(e => new BattingHand
                        {
                            BattingHandId = e,
                            Description = e.ToString()
                        })
                );

            builder.Property(bh => bh.Description)
                .HasMaxLength(6)
                .IsRequired();
        }
    }
}