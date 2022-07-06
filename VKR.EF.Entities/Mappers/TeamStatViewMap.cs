using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class TeamStatViewMap: IEntityTypeConfiguration<TeamStat>
    {
        public void Configure(EntityTypeBuilder<TeamStat> builder)
        {
            builder.HasNoKey();
            builder.ToFunction("GetStreakForAllTeams");
        }
    }
}