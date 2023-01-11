using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKR.EF.Entities.Tables;

namespace VKR.EF.Entities.Mappers
{
    public class PlayerInTeamEntityMap: IEntityTypeConfiguration<PlayerInTeam>
    {
        public void Configure(EntityTypeBuilder<PlayerInTeam> builder)
        {
            builder.ToTable("PlayersInTeams");

            builder.HasKey(pit => pit.Id);

            builder.Property(pit => pit.Id)
                .HasColumnName("PlayerInTeamID");

            builder.HasOne(pit => pit.Player)
                .WithMany(p => p.PlayersInTeam)
                .HasForeignKey(pit => pit.PlayerId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(pit => pit.Team)
                .WithMany(t => t.PlayersInTeam)
                .HasForeignKey(pit => pit.TeamId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(pit => pit.InTeamStatus)
                .WithMany(its => its.PlayerInTeams)
                .HasForeignKey(pit => pit.CurrentPlayerInTeamStatus)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.Property(pit => pit.CurrentPlayerInTeamStatus)
                .HasColumnName("InTeamStatus");
        }
    }
}