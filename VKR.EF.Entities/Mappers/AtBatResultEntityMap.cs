using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class AtBatResultEntityMap : IEntityTypeConfiguration<AtBatResult>
    {
        public void Configure(EntityTypeBuilder<AtBatResult> builder)
        {
            builder.ToTable("TypesOfAtBatResults");

            builder.HasKey(mt => mt.Id);

            builder.HasAlternateKey(mt => mt.Description);

            builder.Property(mt => mt.Id)
                .HasConversion<byte>();

            builder.HasData(
                Enum.GetValues(typeof(AtBatType))
                    .Cast<AtBatType>()
                    .Select(e => new AtBatResult()
                    {
                        Id = e,
                        Description = e.ToString()
                    })
            );

            builder.Property(bh => bh.Description)
                .HasMaxLength(25)
                .IsRequired();
        }
    }
}