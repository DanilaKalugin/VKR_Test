using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class CountOfMatchesPlayedForPitcherViewMap : IEntityTypeConfiguration<CountOfMatchesPlayedForPitcher>
    {
        public void Configure(EntityTypeBuilder<CountOfMatchesPlayedForPitcher> builder)
        {
            builder.ToView("CountOfMatchesPlayedForPitcher");

            builder.HasNoKey();

            builder.Property(vw => vw.PlayerId).HasColumnType("bigint");
        }
    }
}