using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class LineupTypeEntityMap : IEntityTypeConfiguration<LineupType>
    {
        public void Configure(EntityTypeBuilder<LineupType> builder)
        {
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
