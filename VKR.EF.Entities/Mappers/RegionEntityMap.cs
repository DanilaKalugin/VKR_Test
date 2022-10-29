using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class RegionEntityMap: IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.ToTable("Regions");

            builder.HasKey(r => r.RegionCode);

            builder.Property(r => r.RegionCode)
                .HasMaxLength(3);

            builder.Property(r => r.RegionName)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(r => r.Country)
                .WithMany(c => c.Regions)
                .HasForeignKey(r => r.CountryCode)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.Property(r => r.CountryCode)
                .HasColumnName("Country")
                .IsRequired();

            builder.HasAlternateKey(r => new {r.RegionName, r.CountryCode});
        }
    }
}