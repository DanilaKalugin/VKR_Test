using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class CountryEntityMap : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");

            builder.HasKey(c => c.CountryCode);

            builder.Property(c => c.CountryCode).HasMaxLength(3);
            builder.Property(c => c.CountryName).HasMaxLength(50).IsRequired();

            builder.HasAlternateKey(c => c.CountryName);
        }
    }
}
