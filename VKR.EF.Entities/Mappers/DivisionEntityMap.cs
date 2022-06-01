using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class DivisionEntityMap : IEntityTypeConfiguration<Division>
    {
        public void Configure(EntityTypeBuilder<Division> builder)
        {
            builder.HasKey(d => d.Id);
                
            builder.Property(d => d.Id).HasColumnName("DivisionNumber");

            builder.Property(d => d.DivisionTitle).HasMaxLength(10).IsRequired();

            builder.Property(l => l.LeagueId).HasMaxLength(2)
                .HasColumnName("League").IsRequired();

            builder.HasOne(d => d.League)
                .WithMany(l => l.Divisions)
                .HasForeignKey(d => d.LeagueId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}