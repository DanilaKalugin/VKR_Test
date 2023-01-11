using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKR.EF.Entities.Enums;
using VKR.EF.Entities.Tables;

namespace VKR.EF.Entities.Mappers
{
    public class PlayerStatusEntityMap : IEntityTypeConfiguration<PlayerStatus>
    {
        public void Configure(EntityTypeBuilder<PlayerStatus> builder)
        {
            builder.ToTable("PlayerStatuses");

            builder.HasKey(ps => ps.PlayerStatusId);

            builder.HasAlternateKey(ps => ps.PlayerStatusName);

            builder.Property(ps => ps.PlayerStatusId)
                .HasConversion<byte>();

            builder.HasData(
                Enum.GetValues(typeof(PlayerStatusEnum))
                    .Cast<PlayerStatusEnum>()
                    .Select(e => new PlayerStatus()
                    {
                        PlayerStatusId = e,
                        PlayerStatusName = e.ToString()
                    })
            );

            builder.Property(ps => ps.PlayerStatusName)
                .HasMaxLength(15)
                .IsRequired();
        }
    }
}