using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKR.EF.Entities.Tables;

namespace VKR.EF.Entities.Mappers
{
    public class PlayerEntityMap : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Players");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("PlayerID");

            builder.Property(p => p.FirstName)
                .HasColumnName("PlayerFirstName")
                .HasMaxLength(35)
                .IsRequired();

            builder.Property(p => p.SecondName)
                            .HasColumnName("PlayerSecondName")
                            .HasMaxLength(35)
                            .IsRequired();

            builder.Property(p => p.PlayerNumber)
                .IsRequired();

            builder.Property(p => p.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("PlayerDateOfBirth");

            builder.HasOne(p => p.City)
                .WithMany(c => c.Players)
                .HasForeignKey(p => p.PlaceOfBirth)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired();

            builder.HasOne(p => p.BattingHand)
                .WithMany(bh => bh.Players)
                .HasForeignKey(p => p.PlayerBattingHand)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired();
            
            builder.HasOne(p => p.PitchingHand)
                .WithMany(ph => ph.Players)
                .HasForeignKey(p => p.PlayerPitchingHand)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired();
            
            builder.HasOne(p => p.PlayerStatus)
                .WithMany(ps => ps.Players)
                .HasForeignKey(p => p.CurrentPlayerStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired();
        }
    }
}