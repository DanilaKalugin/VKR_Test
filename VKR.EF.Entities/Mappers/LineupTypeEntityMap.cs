using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKR.EF.Entities.Tables;

namespace VKR.EF.Entities.Mappers
{
    public class LineupTypeEntityMap : IEntityTypeConfiguration<LineupType>
    {
        public void Configure(EntityTypeBuilder<LineupType> builder)
        {
            builder.ToTable("LineupType");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("LineupTypeId");

            builder.Property(x => x.Description)
                .HasMaxLength(15)
                .IsRequired();

            builder.HasOne(x => x.PitcherHand)
                .WithMany(ph => ph.LineupTypes)
                .HasForeignKey(x => x.PitcherHandId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}