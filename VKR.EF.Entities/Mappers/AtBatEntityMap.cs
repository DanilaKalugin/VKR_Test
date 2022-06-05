using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class AtBatEntityMap : IEntityTypeConfiguration<AtBat>
    {
        public void Configure(EntityTypeBuilder<AtBat> builder)
        {
            builder.HasKey(ab => ab.Id);

            builder.Property(ab => ab.Id)
                .HasColumnName("AtBatID")
                .HasColumnType("bigint")
                .UseIdentityColumn();

            builder.Property(ab => ab.Outs)
                .IsRequired();

            builder.Property(ab => ab.RBI)
                .IsRequired();

            builder.Property(ab => ab.Inning)
                .IsRequired();

            builder.HasOne(ab => ab.Match)
                .WithMany(m => m.AtBats)
                .HasForeignKey(m => m.MatchId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(ab => ab.Batter)
                .WithMany(b => b.BattingAtBats)
                .HasForeignKey(ab => ab.BatterId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(ab => ab.AtBatResult)
                .WithMany(abr => abr.AtBats)
                .HasForeignKey(ab => ab.AtBatType)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(ab => ab.Pitcher)
                .WithMany(b => b.PitchingAtBats)
                .HasForeignKey(ab => ab.PitcherId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.Property(ab => ab.MatchId).HasColumnName("Match");
            builder.Property(ab => ab.BatterId).HasColumnName("Batter");
            builder.Property(ab => ab.AtBatType).HasColumnName("AtBatResult");
            builder.Property(ab => ab.PitcherId).HasColumnName("Pitcher");

        }
    }
}