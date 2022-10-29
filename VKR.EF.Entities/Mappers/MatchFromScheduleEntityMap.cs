using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class MatchFromScheduleEntityMap : IEntityTypeConfiguration<MatchFromSchedule>
    {
        public void Configure(EntityTypeBuilder<MatchFromSchedule> builder)
        {
            builder.ToTable("NextMatches");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.MatchDate)
                .HasColumnType("date")
                .IsRequired();

            builder.HasOne(m => m.AwayTeam)
                .WithMany(t => t.NextAwayMatches)
                .HasForeignKey(m => m.AwayTeamAbbreviation)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(m => m.HomeTeam)
                .WithMany(t => t.NextHomeMatches)
                .HasForeignKey(m => m.HomeTeamAbbreviation)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(m => m.MatchType)
                .WithMany(mt => mt.NextMatchesOfThisType)
                .HasForeignKey(m => m.MatchTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.Property(m => m.Id).HasColumnName("MatchID");

            builder.Property(m => m.AwayTeamAbbreviation)
                .HasColumnName("AwayTeam");

            builder.Property(m => m.HomeTeamAbbreviation)
                .HasColumnName("HomeTeam");

            builder.Property(m => m.MatchTypeId)
                .HasColumnName("MatchType");

            builder.Property(nm => nm.IsPlayed)
                .IsRequired();

            builder.HasOne(m => m.Season)
                .WithMany(s => s.NextMatches)
                .HasForeignKey(m => m.SeasonId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.Property(m => m.SeasonId)
                .HasColumnName("Season");
        }
    }
}