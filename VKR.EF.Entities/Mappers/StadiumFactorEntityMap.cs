using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class StadiumFactorEntityMap: IEntityTypeConfiguration<StadiumFactor>
    {
        public void Configure(EntityTypeBuilder<StadiumFactor> builder)
        {
            builder.ToTable("StadiumFactors");

            builder.HasKey(sf => sf.StadiumId);

            builder.Property(sf => sf.StadiumId)
                .HasColumnName("Stadium");

            builder.Property(sf => sf.HittingFactor)
                .HasDefaultValue(1)
                .IsRequired();

            builder.Property(sf => sf.SingleFactor)
                .HasDefaultValue(1)
                .IsRequired();

            builder.Property(sf => sf.DoubleFactor)
                .HasDefaultValue(1)
                .IsRequired();

            builder.Property(sf => sf.TripleFactor)
                .HasDefaultValue(1)
                .IsRequired();

            builder.Property(sf => sf.HomeRunFactor)
                .HasDefaultValue(1)
                .IsRequired();

            builder.HasOne(sf => sf.Stadium)
                .WithOne(s => s.StadiumFactor)
                .HasForeignKey<StadiumFactor>(sf => sf.StadiumId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}