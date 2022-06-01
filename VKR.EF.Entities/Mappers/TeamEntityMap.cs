using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class TeamEntityMap : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(t => t.TeamAbbreviation);

            builder.Property(t => t.TeamAbbreviation).HasMaxLength(3);
            builder.Property(t => t.TeamCity).HasMaxLength(50).IsRequired();
            builder.Property(t => t.TeamName).HasMaxLength(35).IsRequired();
            builder.Property(t => t.DivisionId).HasColumnName("TeamDivision").IsRequired();
            builder.Property(t => t.StrikeZoneProbability).HasColumnType("smallint").IsRequired();
            builder.Property(t => t.HitByPitchProbability).HasColumnType("smallint").IsRequired();
            builder.Property(t => t.SwingInStrikeZoneProbability).IsRequired();
            builder.Property(t => t.SwingOutsideStrikeZoneProbability).IsRequired();
            builder.Property(t => t.HittingProbability).HasColumnType("smallint").IsRequired();
            builder.Property(t => t.FoulProbability).HasColumnType("smallint").IsRequired();
            builder.Property(t => t.SingleProbability).HasColumnType("smallint").IsRequired();
            builder.Property(t => t.DoubleProbability).HasColumnType("smallint").IsRequired();
            builder.Property(t => t.HomeRunProbability).HasColumnType("smallint").IsRequired();
            builder.Property(t => t.TripleProbability).HasColumnType("smallint").IsRequired();
            builder.Property(t => t.PopoutOnFoulProbability).HasColumnType("smallint").IsRequired();
            builder.Property(t => t.FlyoutOnHomeRunProbability).HasColumnType("smallint").IsRequired();
            builder.Property(t => t.GroundoutProbability).HasColumnType("smallint").IsRequired();
            builder.Property(t => t.FlyoutProbability).HasColumnType("smallint").IsRequired();
            builder.Property(t => t.DoublePlayProbability).IsRequired();
            builder.Property(t => t.SacrificeFlyProbability).IsRequired();
            builder.Property(t => t.StealingBaseProbability).HasColumnType("smallint").IsRequired();
            builder.Property(t => t.SuccessfulStealingBaseAttemptProbability).IsRequired()
                .HasColumnName("StealingBaseSuccessfulAttemptProbability");

            builder.Property(t => t.SuccessfulBuntAttemptProbability).HasColumnType("smallint").IsRequired();

            builder.HasAlternateKey(t => new { t.TeamCity, t.TeamName });

            builder.HasCheckConstraint("StrikeZoneProbability", "StrikeZoneProbability BETWEEN 1 AND 3000");
            builder.HasCheckConstraint("HitByPitchProbability", "HitByPitchProbability BETWEEN 1 AND 3000");
            builder.HasCheckConstraint("SwingInStrikeZoneProbability", "SwingInStrikeZoneProbability BETWEEN 1 AND 100");
            builder.HasCheckConstraint("SwingOutsideStrikeZoneProbability", "SwingOutsideStrikeZoneProbability BETWEEN 1 AND 100");
            builder.HasCheckConstraint("HittingProbability", "HittingProbability BETWEEN 1 AND 2000");
            builder.HasCheckConstraint("FoulProbability", "FoulProbability BETWEEN 1 AND 2000");
            builder.HasCheckConstraint("SingleProbability", "SingleProbability BETWEEN 1 AND 2000");
            builder.HasCheckConstraint("DoubleProbability", "DoubleProbability BETWEEN 1 AND 2000");
            builder.HasCheckConstraint("HomeRunProbability", "HomeRunProbability BETWEEN 1 AND 2000");
            builder.HasCheckConstraint("TripleProbability", "TripleProbability BETWEEN 1 AND 2000");
            builder.HasCheckConstraint("PopoutOnFoulProbability", "PopoutOnFoulProbability BETWEEN 1 AND 1000");
            builder.HasCheckConstraint("FlyoutOnHomeRunProbability", "FlyoutOnHomeRunProbability BETWEEN 1 AND 1000");
            builder.HasCheckConstraint("GroundoutProbability", "GroundoutProbability BETWEEN 1 AND 1000");
            builder.HasCheckConstraint("FlyoutProbability", "FlyoutProbability BETWEEN 1 AND 1000");
            builder.HasCheckConstraint("DoublePlayProbability", "DoublePlayProbability BETWEEN 1 AND 100");
            builder.HasCheckConstraint("SacrificeFlyProbability", "SacrificeFlyProbability BETWEEN 1 AND 100");
            builder.HasCheckConstraint("StealingBaseProbability", "StealingBaseProbability BETWEEN 1 AND 1000");
            builder.HasCheckConstraint("StealingBaseSuccessfulAttemptProbability", "StealingBaseSuccessfulAttemptProbability BETWEEN 1 AND 100");
            builder.HasCheckConstraint("SuccessfulBuntAttemptProbability", "SuccessfulBuntAttemptProbability BETWEEN 1 AND 100");
            
            builder.HasOne(t => t.Division)
                .WithMany(d => d.Teams)
                .HasForeignKey(t => t.DivisionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}