using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class TeamEntityMap : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Teams");

            builder.HasKey(t => t.TeamAbbreviation);

            builder.Property(t => t.TeamAbbreviation)
                .HasMaxLength(3);

            builder.Property(t => t.TeamCity)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.TeamName)
                .HasMaxLength(35)
                .IsRequired();

            builder.Property(t => t.DivisionId)
                .HasColumnName("TeamDivision")
                .IsRequired();
            
            builder.HasOne(t => t.Division)
                .WithMany(d => d.Teams)
                .HasForeignKey(t => t.DivisionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired();

            builder.HasOne(t => t.Manager)
                .WithMany(m => m.Teams)
                .HasForeignKey(t => t.TeamManager)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Property(t => t.TeamManager)
                .HasColumnType("smallint");

            builder.Property(t => t.FoundationYear)
                .HasColumnType("smallint")
                .IsRequired();

            builder.HasAlternateKey(t => new { t.TeamCity, t.TeamName });

            builder.HasCheckConstraint("FoundationYear", "FoundationYear BETWEEN 1850 AND 2022");
        }
    }
}