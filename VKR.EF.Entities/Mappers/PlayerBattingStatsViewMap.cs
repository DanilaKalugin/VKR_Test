using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class PlayerBattingStatsViewMap: IEntityTypeConfiguration<PlayerBattingStats>
    {
        public void Configure(EntityTypeBuilder<PlayerBattingStats> builder)
        {
            builder.ToView("PlayerBattingStats");
            builder.HasNoKey();

            builder.Property(vw => vw.Strikeouts)
                .HasColumnName("K");

            builder.Property(vw => vw.Walks)
                .HasColumnName("BB");

            builder.Property(vw => vw.HitByPitch)
                .HasColumnName("HBP");

            builder.Property(vw => vw.Flyouts)
                .HasColumnName("AO");

            builder.Property(vw => vw.Groundouts)
                .HasColumnName("GO");

            builder.Property(vw => vw.Popouts)
                .HasColumnName("PO");

            builder.Property(vw => vw.Singles)
                .HasColumnName("1B");

            builder.Property(vw => vw.Doubles)
                .HasColumnName("2B");

            builder.Property(vw => vw.Triples)
                .HasColumnName("3B");

            builder.Property(vw => vw.HomeRuns)
                .HasColumnName("HR");

            builder.Property(vw => vw.StolenBases)
                .HasColumnName("SB");

            builder.Property(vw => vw.CaughtStealing)
                .HasColumnName("CS");

            builder.Property(vw => vw.Runs)
                .HasColumnName("R");

            builder.Property(vw => vw.SacrificeFlies)
                .HasColumnName("SF");

            builder.Property(vw => vw.SacrificeBunts)
                .HasColumnName("SAC");

            builder.Property(vw => vw.DoublePlay)
                .HasColumnName("GIDP");

            builder.Property(vw => vw.Games)
                .HasColumnName("GamesPlayed");
        }
    }
}
