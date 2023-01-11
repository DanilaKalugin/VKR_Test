using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKR.EF.Entities.Views;

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