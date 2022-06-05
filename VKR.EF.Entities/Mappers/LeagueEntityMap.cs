using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class LeagueEntityMap : IEntityTypeConfiguration<League>
    {
        public void Configure(EntityTypeBuilder<League> builder)
        {
            builder.ToTable("Leagues");

            builder.HasKey(l => l.LeagueId);

            builder.Property(l => l.LeagueId)
                .HasMaxLength(2)
                .HasColumnName("LeagueID");

            builder.Property(l => l.LeagueTitle)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(l => l.DHRule)
                .IsRequired()
                .HasColumnName("LeagueDHRule");

            builder.Property(l => l.YearOfFoundation).IsRequired()
                .HasColumnName("LeagueYearOfFoundation")
                .HasColumnType("smallint");
        }
    }
}