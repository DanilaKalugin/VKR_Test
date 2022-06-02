using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class StadiumEntityMap : IEntityTypeConfiguration<Stadium>
    {
        public void Configure(EntityTypeBuilder<Stadium> builder)
        {
            builder.ToTable("Stadiums");

            builder.HasKey(s => s.StadiumId);

            builder.HasAlternateKey(s => s.StadiumTitle);

            builder.Property(s => s.StadiumId)
                .HasColumnType("smallint");

            builder.Property(s => s.StadiumTitle).IsRequired()
                .HasMaxLength(75);

            builder.Property(s => s.StadiumCapacity).IsRequired();
            builder.Property(s => s.StadiumDistanceToCenterfield)
                .HasColumnName("StadiumDistanceToCenterField")
                .IsRequired();

            builder.HasOne(s => s.StadiumCity)
                .WithMany(c => c.Stadiums)
                .HasForeignKey(s => s.StadiumLocation)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
