using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class CountOfMatchesPlayedByTeamViewMap:IEntityTypeConfiguration<CountOfMatchesPlayedByTeam>
    {
        public void Configure(EntityTypeBuilder<CountOfMatchesPlayedByTeam> builder)
        {

            builder.ToView("CountOfMatchesPlayedByTeam");

            builder.HasNoKey();
        }
    }
}