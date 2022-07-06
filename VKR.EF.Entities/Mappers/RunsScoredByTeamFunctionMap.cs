using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class RunsScoredByTeamFunctionMap: IEntityTypeConfiguration<RunsScoredByTeam>
    {
        public void Configure(EntityTypeBuilder<RunsScoredByTeam> builder)
        {
            builder.ToFunction("RunsScoredByTeamBeforeThisDateInMatchType");
            builder.HasNoKey();
        }
    }
}
