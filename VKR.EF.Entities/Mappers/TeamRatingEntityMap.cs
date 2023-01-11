using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKR.EF.Entities.Tables;

namespace VKR.EF.Entities.Mappers
{
    public class TeamRatingEntityMap: IEntityTypeConfiguration<TeamRating>
    {
        public void Configure(EntityTypeBuilder<TeamRating> builder)
        {
            builder.ToTable("TeamRating");

            builder.HasKey(t => t.TeamAbbreviation);

            builder.Property(t => t.TeamAbbreviation)
                .HasMaxLength(3);

            builder.Property(t => t.SwingInStrikeZoneProbability)
                .IsRequired();

            builder.Property(t => t.SwingOutsideStrikeZoneProbability)
                .IsRequired();

            builder.Property(t => t.HittingProbability)
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(t => t.FoulProbability)
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(t => t.SingleProbability)
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(t => t.DoubleProbability)
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(t => t.HomeRunProbability)
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(t => t.TripleProbability)
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(t => t.PopoutOnFoulProbability)
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(t => t.FlyoutOnHomeRunProbability)
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(t => t.GroundoutProbability)
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(t => t.FlyoutProbability)
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(t => t.DoublePlayProbability)
                .IsRequired();

            builder.Property(t => t.SacrificeFlyProbability)
                .IsRequired();

            builder.Property(t => t.StealingBaseProbability)
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(t => t.SuccessfulStealingBaseAttemptProbability)
                .IsRequired()
                .HasColumnName("StealingBaseSuccessfulAttemptProbability");

            builder.Property(t => t.SuccessfulBuntAttemptProbability)
                .HasColumnType("smallint")
                .IsRequired();

            builder.HasCheckConstraint("StrikeZoneProbability1", "StrikeZoneProbability BETWEEN 1 AND 3000");
            builder.HasCheckConstraint("HitByPitchProbability1", "HitByPitchProbability BETWEEN 1 AND 3000");
            builder.HasCheckConstraint("SwingInStrikeZoneProbability1", "SwingInStrikeZoneProbability BETWEEN 1 AND 1000");
            builder.HasCheckConstraint("SwingOutsideStrikeZoneProbability1", "SwingOutsideStrikeZoneProbability BETWEEN 1 AND 1000");
            builder.HasCheckConstraint("HittingProbability1", "HittingProbability BETWEEN 1 AND 2000");
            builder.HasCheckConstraint("FoulProbability1", "FoulProbability BETWEEN 1 AND 2000");
            builder.HasCheckConstraint("SingleProbability1", "SingleProbability BETWEEN 1 AND 2000");
            builder.HasCheckConstraint("DoubleProbability1", "DoubleProbability BETWEEN 1 AND 2000");
            builder.HasCheckConstraint("HomeRunProbability1", "HomeRunProbability BETWEEN 1 AND 2000");
            builder.HasCheckConstraint("TripleProbability1", "TripleProbability BETWEEN 1 AND 2000");
            builder.HasCheckConstraint("PopoutOnFoulProbability1", "PopoutOnFoulProbability BETWEEN 1 AND 1000");
            builder.HasCheckConstraint("FlyoutOnHomeRunProbability1", "FlyoutOnHomeRunProbability BETWEEN 1 AND 1000");
            builder.HasCheckConstraint("GroundoutProbability1", "GroundoutProbability BETWEEN 1 AND 1000");
            builder.HasCheckConstraint("FlyoutProbability1", "FlyoutProbability BETWEEN 1 AND 1000");
            builder.HasCheckConstraint("DoublePlayProbability1", "DoublePlayProbability BETWEEN 1 AND 100");
            builder.HasCheckConstraint("SacrificeFlyProbability1", "SacrificeFlyProbability BETWEEN 1 AND 100");
            builder.HasCheckConstraint("StealingBaseProbability1", "StealingBaseProbability BETWEEN 1 AND 1000");
            builder.HasCheckConstraint("StealingBaseSuccessfulAttemptProbability1", "StealingBaseSuccessfulAttemptProbability BETWEEN 1 AND 100");
            builder.HasCheckConstraint("SuccessfulBuntAttemptProbability1", "SuccessfulBuntAttemptProbability BETWEEN 1 AND 1000");

            builder.HasOne(tr => tr.Team)
                .WithOne(t => t.TeamRating)
                .HasForeignKey<TeamRating>(tr => tr.TeamAbbreviation)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Ignore(t => t.NormalizedDefensiveRating);
            builder.Ignore(t => t.NormalizedOffensiveRating);
        }
    }
}