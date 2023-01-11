using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKR.EF.Entities.Enums;
using VKR.EF.Entities.Tables;

namespace VKR.EF.Entities.Mappers
{
    public class TypeOfMatchEntityMap : IEntityTypeConfiguration<TypeOfMatch>
    {
        public void Configure(EntityTypeBuilder<TypeOfMatch> builder)
        {
            builder.ToTable("TypesOfMatches");

            builder.HasKey(mt => mt.Id);

            builder.HasAlternateKey(mt => mt.Description);

            builder.Property(mt => mt.Id)
                .HasConversion<byte>();

            builder.HasData(
                Enum.GetValues(typeof(TypeOfMatchEnum))
                    .Cast<TypeOfMatchEnum>()
                    .Select(e => new TypeOfMatch
                    {
                        Id = e,
                        Description = e.ToString()
                    })
            );

            builder.Property(bh => bh.Description).HasMaxLength(20).IsRequired();
        }
    }
}