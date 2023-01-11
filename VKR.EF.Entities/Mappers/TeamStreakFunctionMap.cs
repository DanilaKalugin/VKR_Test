using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKR.EF.Entities.Functions;

namespace VKR.EF.Entities.Mappers
{
    public class TeamStreakFunctionMap: IEntityTypeConfiguration<TeamStreak>
    {
        public void Configure(EntityTypeBuilder<TeamStreak> builder)
        {
            builder.HasNoKey();
            builder.ToFunction("GetStreakForAllTeams");
        }
    }
}