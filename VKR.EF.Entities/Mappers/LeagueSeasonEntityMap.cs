using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKR.EF.Entities.Tables;

namespace VKR.EF.Entities.Mappers
{
    public class LeagueSeasonEntityMap:IEntityTypeConfiguration<LeagueSeason>
    {
        public void Configure(EntityTypeBuilder<LeagueSeason> builder)
        {
            builder.ToTable("LeagueSeasons");

            builder.HasKey(ls => new { ls.SeasonId, ls.MatchTypeId });

            builder.Property(ls => ls.SeasonId)
                .HasColumnName("Season");

            builder.Property(ls => ls.MatchTypeId)
                .HasColumnName("MatchType");

            builder.Property(ls => ls.SeasonStart)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(ls => ls.SeasonEnd)
                .HasColumnType("date")
                .IsRequired();

            builder.HasOne(ls => ls.Season)
                .WithMany(s => s.LeagueSeasons)
                .HasForeignKey(ls => ls.SeasonId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ls => ls.MatchType)
                .WithMany(mt => mt.LeagueSeasons)
                .HasForeignKey(ls => ls.MatchTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(ls => ls.MatchTypeId)
                .HasColumnName("MatchType");

            builder.HasCheckConstraint("SeasonStart", "YEAR(SeasonStart) = Season");

            builder.HasCheckConstraint("SeasonEnd", "YEAR(SeasonEnd) = Season");
        }
    }
}