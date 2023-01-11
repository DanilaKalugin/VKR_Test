using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKR.EF.Entities.Views;

namespace VKR.EF.Entities.Mappers
{
    public class RunsScoredByTeamViewMap: IEntityTypeConfiguration<RunsByTeam>
    {
        public void Configure(EntityTypeBuilder<RunsByTeam> builder)
        {
            builder.ToView("RunsScoredAndAllowedForEveryMatch");
            builder.HasNoKey();
        }
    }
}