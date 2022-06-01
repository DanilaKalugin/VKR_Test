using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class TeamEntityMap : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(t => t.TeamAbbreviation);

            builder.Property(t => t.TeamAbbreviation).HasMaxLength(3);
            builder.Property(t => t.TeamCity).HasMaxLength(50).IsRequired();
            builder.Property(t => t.TeamName).HasMaxLength(35).IsRequired();

            builder.Property(t => t.DivisionId).HasColumnName("TeamDivision").IsRequired();

            builder.HasOne(t => t.Division)
                .WithMany(d => d.Teams)
                .HasForeignKey(t => t.DivisionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}