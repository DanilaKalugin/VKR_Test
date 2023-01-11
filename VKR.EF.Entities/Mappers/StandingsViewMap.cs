using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKR.EF.Entities.Views;

namespace VKR.EF.Entities.Mappers
{
    public class StandingsViewMap:IEntityTypeConfiguration<TeamBalance>
    {
        public void Configure(EntityTypeBuilder<TeamBalance> builder)
        {
            builder.ToView("StandingsBySeasonAndMatchType");
            builder.HasNoKey();

            builder.Property(vw => vw.HomeWins)
                .HasColumnName("HW");

            builder.Property(vw => vw.AwayWins)
                .HasColumnName("AW");

            builder.Property(vw => vw.HomeLosses)
                .HasColumnName("HL");

            builder.Property(vw => vw.AwayLosses)
                .HasColumnName("AL");
        }
    }
}