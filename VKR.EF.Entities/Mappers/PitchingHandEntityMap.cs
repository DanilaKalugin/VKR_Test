using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class PitchingHandEntityMap : IEntityTypeConfiguration<PitchingHand>
    {
        public void Configure(EntityTypeBuilder<PitchingHand> builder)
        {
            builder.HasKey(ph => ph.PitchingHandId);

            builder.Property(ph => ph.Description)
                .HasMaxLength(5)
                .IsRequired();

            builder.HasAlternateKey(ph => ph.Description);

            builder.Property(ph => ph.PitchingHandId)
                .HasConversion<byte>();

            builder.HasData(
                Enum.GetValues(typeof(PitchingHandEnum))
                    .Cast<PitchingHandEnum>()
                    .Select(e => new PitchingHand()
                    {
                        PitchingHandId = e,
                        Description = e.ToString()
                    })
            );
        }
    }
}