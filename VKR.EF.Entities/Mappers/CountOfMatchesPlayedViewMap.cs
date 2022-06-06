using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class CountOfMatchesPlayedViewMap : IEntityTypeConfiguration<CountOfMatchesPlayed>
    {
        public void Configure(EntityTypeBuilder<CountOfMatchesPlayed> builder)
        {
            builder.ToView("CountOfMatchesPlayed");

            builder.HasNoKey();

            builder.Property(vw => vw.PlayerId).HasColumnType("bigint");
        }
    }
}
