using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class TeamStreakViewMap: IEntityTypeConfiguration<TeamStreak>
    {
        public void Configure(EntityTypeBuilder<TeamStreak> builder)
        {
            builder.HasNoKey();
            builder.ToFunction("GetStreakForAllTeams");
        }
    }
}