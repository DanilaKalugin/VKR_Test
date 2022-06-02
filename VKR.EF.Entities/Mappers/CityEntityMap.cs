using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class CityEntityMap: IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("CityID")
                .HasColumnType("smallint");

            builder.Property(c => c.Name).HasColumnName("CityName")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.CountryCode).HasColumnName("Country")
                .IsRequired();

            builder.HasOne(c => c.Country)
                .WithMany(c => c.Cities)
                .HasForeignKey(c => c.CountryCode)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}