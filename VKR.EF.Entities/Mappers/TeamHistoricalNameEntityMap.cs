using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKR.EF.Entities.Tables;

namespace VKR.EF.Entities.Mappers
{
    public class TeamHistoricalNameEntityMap : IEntityTypeConfiguration<TeamHistoricalName>
    {
        public void Configure(EntityTypeBuilder<TeamHistoricalName> builder)
        {
            builder.ToTable("TeamHistoricalNames");
            builder.HasKey(thn => new {thn.TeamAbbreviation, thn.FirstSeasonWithName});

            builder.Property(t => t.TeamRegion)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.TeamName)
                .HasMaxLength(35)
                .IsRequired();

            builder.Property(thn => thn.FirstSeasonWithName)
                .IsRequired();

            builder.HasCheckConstraint("FirstSeasonGreaterThan1850", "FirstSeasonWithName > 1850");
            builder.HasCheckConstraint("LastSeasonGreaterThan1850", "LastSeasonWithName > 1850");
            builder.HasCheckConstraint("LastSeasonMustBeGreaterThanFirst", "LastSeasonWithName >= FirstSeasonWithName");

            builder.HasOne(thn => thn.Team)
                .WithMany(t => t.HistoricalNames)
                .HasForeignKey(thn => thn.TeamAbbreviation)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}