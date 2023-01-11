using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKR.EF.Entities.Tables;

namespace VKR.EF.Entities.Mappers
{
    public class RetiredNumberEntityMap: IEntityTypeConfiguration<RetiredNumber>
    {
        public void Configure(EntityTypeBuilder<RetiredNumber> builder)
        {
            builder.ToTable("RetiredNumbers");

            builder.HasKey(rn => rn.Id);

            builder.Property(rn => rn.Number)
                .IsRequired();

            builder.Property(rn => rn.Person)
                .HasMaxLength(75)
                .IsRequired();

            builder.Property(rn => rn.Date)
                .HasColumnType("date")
                .IsRequired();

            builder.HasOne(rn => rn.Team)
                .WithMany(t => t.RetiredNumbers)
                .HasForeignKey(rn => rn.TeamId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}