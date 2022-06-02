using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class PlayerPositionEntityMap : IEntityTypeConfiguration<PlayerPosition>
    {
        public void Configure(EntityTypeBuilder<PlayerPosition> builder)
        {
            builder.ToTable("PlayerPositions");

            builder.HasKey(pp => pp.ShortTitle);

            builder.HasAlternateKey(pp => pp.Number);
            builder.HasAlternateKey(pp => pp.FullTitle);

            builder.Property(pp => pp.ShortTitle)
                .HasMaxLength(2)
                .HasColumnName("PositionCode");

            builder.Property(pp => pp.Number).IsRequired();

            builder.Property(pp => pp.FullTitle)
                .HasColumnName("PositionFullTitle")
                .HasMaxLength(20)
                .IsRequired();

            builder.HasMany(pp => pp.Players)
                .WithMany(p => p.Positions)
                .UsingEntity(pps => pps.ToTable("PlayersPositions"));
        }
    }
}