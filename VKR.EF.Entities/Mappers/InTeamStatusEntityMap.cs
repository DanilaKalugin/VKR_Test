using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKR.EF.Entities.Enums;
using VKR.EF.Entities.Tables;

namespace VKR.EF.Entities.Mappers
{
    public class InTeamStatusEntityMap: IEntityTypeConfiguration<InTeamStatus>
    {
        public void Configure(EntityTypeBuilder<InTeamStatus> builder)
        {
            builder.ToTable("InTeamStatuses");

            builder.HasKey(its => its.InTeamStatusId);

            builder.Property(its => its.InTeamStatusTitle)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasAlternateKey(its => its.InTeamStatusTitle);

            builder.Property(its => its.InTeamStatusId)
                .HasConversion<byte>();

            builder.HasData(
                Enum.GetValues(typeof(InTeamStatusEnum))
                    .Cast<InTeamStatusEnum>()
                    .Select(e => new InTeamStatus()
                    {
                        InTeamStatusId = e,
                        InTeamStatusTitle = e.ToString()
                    })
            );
        }
    }
}