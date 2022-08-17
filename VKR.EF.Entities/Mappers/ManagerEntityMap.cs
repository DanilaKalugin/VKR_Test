using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class ManagerEntityMap : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.ToTable("Managers");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .HasColumnName("ManagerID")
                .HasColumnType("smallint");

            builder.Property(m => m.FirstName)
                .HasColumnName("ManagerFirstName")
                .HasMaxLength(30).IsRequired();

            builder.Property(m => m.SecondName)
                .HasColumnName("ManagerSecondName")
                .HasMaxLength(30).IsRequired();

            builder.Property(m => m.DateOfBirth)
                .HasColumnName("ManagerDateOfBirth")
                .HasColumnType("date").IsRequired();

            builder.HasOne(m => m.City)
                .WithMany(c => c.Managers)
                .HasForeignKey(m => m.PlaceOfBirth)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired();

            builder.Property(m => m.PlaceOfBirth)
                .HasColumnType("smallint")
                .HasColumnName("ManagerPlaceOfBirth");
        }
    }
}