using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class ManInTeamViewMap: IEntityTypeConfiguration<ManInTeam>
    {
        public void Configure(EntityTypeBuilder<ManInTeam> builder)
        {
            builder.ToView("PeopleWithBirthdayToday");
            builder.HasNoKey();

            builder.Ignore(mt => mt.City);
        }
    }
}