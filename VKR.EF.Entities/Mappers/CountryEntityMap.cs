﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKR.EF.Entities.Tables;

namespace VKR.EF.Entities.Mappers
{
    public class CountryEntityMap : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");

            builder.HasKey(c => c.CountryCode);

            builder.Property(c => c.CountryCode)
                .HasMaxLength(3);

            builder.Property(c => c.CountryName)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasAlternateKey(c => c.CountryName);
        }
    }
}