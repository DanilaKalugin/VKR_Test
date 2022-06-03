using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VKR.EF.Entities.Mappers
{
    public class StartingLineupEntityMap: IEntityTypeConfiguration<StartingLineup>
    {
        public void Configure(EntityTypeBuilder<StartingLineup> builder)
        {
            builder.HasKey(sl => new { sl.PlayerInTeamId, sl.LineupTypeId });

            builder.Property(sl => sl.PlayerNumberInLineup)
                .HasColumnName("PlayerPositionInLineup").IsRequired();

            builder.HasOne(sl => sl.PlayerInTeam)
                .WithMany(pit => pit.PlayersInStartingLineups)
                .HasForeignKey(sl => sl.PlayerInTeamId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sl => sl.Type)
                .WithMany(lt => lt.StartingLineups)
                .HasForeignKey(sl => sl.LineupTypeId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(sl => sl.PlayerPosition)
                .WithMany(pp => pp.PlayerPositionsInStartingLineups)
                .HasForeignKey(sl => sl.PlayerPositionId)
                .OnDelete(DeleteBehavior.Cascade).IsRequired();

            builder.Property(sl => sl.PlayerPositionId)
                .HasColumnName("PlayerPosition");
        }
    }
}