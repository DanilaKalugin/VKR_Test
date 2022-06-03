using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class PitcherResultEntityMap: IEntityTypeConfiguration<PitcherResults>
    {
        public void Configure(EntityTypeBuilder<PitcherResults> builder)
        {
            builder.ToTable("PitcherResults");

            builder.HasKey(x => new {x.PitcherId, x.MatchId});

            builder.Property(pr => pr.MatchId).HasColumnName("Match");
            builder.Property(pr => pr.PitcherId).HasColumnName("Pitcher");
            builder.Property(pr => pr.IsQualityStart)
                .HasColumnName("QualityStart")
                .IsRequired();

            builder.Property(pr => pr.IsCompleteGame)
                .HasColumnName("CompleteGame")
                .IsRequired();

            builder.Property(pr => pr.IsShutout)
                .HasColumnName("Shutout")
                .IsRequired();

            builder.HasOne(ml => ml.Pitcher)
                .WithMany(pit => pit.PitcherResults)
                .HasForeignKey(ml => ml.PitcherId)
                .OnDelete(DeleteBehavior.Cascade).IsRequired();

            builder.HasOne(ml => ml.Match)
                .WithMany(m => m.PitcherResults)
                .HasForeignKey(ml => ml.MatchId)
                .OnDelete(DeleteBehavior.Cascade).IsRequired();
        }
    }
}