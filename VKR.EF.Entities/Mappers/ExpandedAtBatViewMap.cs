using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class ExpandedAtBatViewMap :IEntityTypeConfiguration<ExpandedAtBat>
    {
        public void Configure(EntityTypeBuilder<ExpandedAtBat> builder)
        {
            builder.ToView("ExpandedAtBats");

            builder.HasNoKey();

            builder.Property(vw => vw.AtBatId)
                .HasColumnName("AtBatID");

            builder.Property(vw => vw.Rbi)
                .HasColumnName("RBI");
        }
    }
}