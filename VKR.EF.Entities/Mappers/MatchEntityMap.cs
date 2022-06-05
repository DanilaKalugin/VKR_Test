using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class MatchEntityMap : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.ToTable("Matches");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.DHRule)
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(m => m.MatchEnded)
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(m => m.MatchLength)
                .IsRequired();

            builder.Property(m => m.MatchDate)
                .HasColumnType("date")
                .IsRequired();

            builder.HasOne(m => m.AwayTeam)
                .WithMany(t => t.AwayMatches)
                .HasForeignKey(m => m.AwayTeamAbbreviation)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(m => m.HomeTeam)
                .WithMany(t => t.HomeMatches)
                .HasForeignKey(m => m.HomeTeamAbbreviation)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(m => m.Stadium)
                .WithMany(s => s.MatchesPlayedInThisStadium)
                .HasForeignKey(m => m.StadiumId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(m => m.MatchType)
                .WithMany(mt => mt.MatchesOfThisType)
                .HasForeignKey(m => m.MatchTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.Property(m => m.Id)
                .HasColumnName("MatchID");

            builder.Property(m => m.AwayTeamAbbreviation)
                .HasColumnName("AwayTeam");

            builder.Property(m => m.HomeTeamAbbreviation)
                .HasColumnName("HomeTeam");

            builder.Property(m => m.StadiumId)
                .HasColumnName("Stadium");

            builder.Property(m => m.MatchTypeId)
                .HasColumnName("MatchType");
        }
    }
}