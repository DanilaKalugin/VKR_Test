using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class RunEntityMap : IEntityTypeConfiguration<Run>
    {
        public void Configure(EntityTypeBuilder<Run> builder)
        {
            builder.ToTable("Runs");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                .HasColumnName("RunID")
                .HasColumnType("bigint")
                .UseIdentityColumn();

            builder.Property(ab => ab.Inning)
                .IsRequired();

            builder.HasOne(r => r.Match)
                .WithMany(m => m.Runs)
                .HasForeignKey(m => m.MatchId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(ab => ab.Runner)
                .WithMany(b => b.Runs)
                .HasForeignKey(ab => ab.RunnerId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(ab => ab.Pitcher)
                .WithMany(b => b.RunsForPitcher)
                .HasForeignKey(ab => ab.PitcherId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.Property(ab => ab.MatchId).HasColumnName("Match");
            builder.Property(ab => ab.RunnerId).HasColumnName("Runner");
            builder.Property(ab => ab.PitcherId).HasColumnName("Pitcher");
            builder.Property(r => r.IsEarned).IsRequired();
        }
    }
}