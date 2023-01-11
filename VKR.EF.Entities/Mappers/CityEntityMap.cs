using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKR.EF.Entities.Tables;

namespace VKR.EF.Entities.Mappers
{
    public class CityEntityMap: IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("CityID")
                .HasColumnType("smallint")
                .UseIdentityColumn();

            builder.Property(c => c.Name)
                .HasColumnName("CityName")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.RegionCode)
                .HasColumnName("Region")
                .IsRequired();

            builder.HasOne(c => c.Region)
                .WithMany(r => r.Cities)
                .HasForeignKey(c => c.RegionCode)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}