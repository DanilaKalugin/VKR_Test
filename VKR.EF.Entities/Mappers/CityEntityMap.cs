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

            builder.Property(c => c.RegionCode).HasColumnName("Region")
                .IsRequired();

            builder.HasOne(c => c.Region)
                .WithMany(r => r.Cities)
                .HasForeignKey(c => c.RegionCode)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}