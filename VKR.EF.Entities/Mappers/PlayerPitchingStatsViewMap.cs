using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class PlayerPitchingStatsViewMap:IEntityTypeConfiguration<PlayerPitchingStats>
    {
        public void Configure(EntityTypeBuilder<PlayerPitchingStats> builder)
        {
            builder.ToView("PlayerPitchingStatsByYearAndMatchType");
            builder.HasNoKey();

            builder.Property(vw => vw.Strikeouts)
                .HasColumnName("K");

            builder.Property(vw => vw.WalksAllowed)
                .HasColumnName("BB");

            builder.Property(vw => vw.HitByPitch)
                .HasColumnName("HBP");

            builder.Property(vw => vw.Flyouts)
                .HasColumnName("AO");

            builder.Property(vw => vw.Groundouts)
                .HasColumnName("GO");

            builder.Property(vw => vw.SinglesAllowed)
                .HasColumnName("1B");

            builder.Property(vw => vw.DoublesAllowed)
                .HasColumnName("2B");

            builder.Property(vw => vw.TriplesAllowed)
                .HasColumnName("3B");

            builder.Property(vw => vw.HomeRunsAllowed)
                .HasColumnName("HR");

            builder.Property(vw => vw.StolenBasesAllowed)
                .HasColumnName("SB");

            builder.Property(vw => vw.CaughtStealing)
                .HasColumnName("CS");

            builder.Property(vw => vw.RunsAllowed)
                .HasColumnName("R");

            builder.Property(vw => vw.SacrificeFlies)
                .HasColumnName("SF");

            builder.Property(vw => vw.SacrificeBunts)
                .HasColumnName("SAC");

            builder.Property(vw => vw.DoublePlays)
                .HasColumnName("GIDP");

            builder.Property(vw => vw.GamesPlayed)
                .HasColumnName("GamesPlayed");

            builder.Property(vw => vw.TotalBattersFaced)
                .HasColumnName("TBF");

            builder.Property(vw => vw.Shutouts)
                .HasColumnName("SHO");

            builder.Property(vw => vw.QualityStarts)
                .HasColumnName("QS");

            builder.Property(vw => vw.CompleteGames)
                .HasColumnName("CG");

            builder.Property(vw => vw.Wins)
                .HasColumnName("W");

            builder.Property(vw => vw.Losses)
                .HasColumnName("L");

            builder.Property(vw => vw.Saves)
                .HasColumnName("SV");

            builder.Property(vw => vw.Holds)
                .HasColumnName("HLD");

            builder.Property(vw => vw.GamesStarted)
                .HasColumnName("GS");
        }
    }
}