using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class TeamColorEntityMap : IEntityTypeConfiguration<TeamColor>
    {
        public void Configure(EntityTypeBuilder<TeamColor> builder)
        {
            builder.ToTable("TeamColors");

            builder.HasKey(tc => new{tc.TeamName, tc.ColorNumber});

            builder.Property(tc => tc.BlueComponent)
                .IsRequired();

            builder.Property(tc => tc.GreenComponent)
                .IsRequired();

            builder.Property(tc => tc.RedComponent)
                .IsRequired();

            builder.HasOne(tc => tc.Team)
                .WithMany(t => t.TeamColors)
                .HasForeignKey(tc => tc.TeamName)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}