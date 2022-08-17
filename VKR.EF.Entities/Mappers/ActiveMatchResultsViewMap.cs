using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class ActiveMatchResultsViewMap:IEntityTypeConfiguration<ActiveMatchResult>
    {
        public void Configure(EntityTypeBuilder<ActiveMatchResult> builder)
        {
            builder.ToView("TotalRunsForEachMatch");
            builder.HasNoKey();

            builder.Property(vw => vw.AwayTeamRuns)
                .HasColumnName("AwayRuns");

            builder.Property(vw => vw.HomeTeamRuns)
                .HasColumnName("HomeRuns");
        }
    }
}