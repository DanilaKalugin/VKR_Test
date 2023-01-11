using System.Collections.Generic;
using System.Linq;
using VKR.EF.Entities.Enums;
using VKR.EF.Entities.Views;

namespace VKR.EF.Entities.Tables
{
    public class Player : Man
    {
        public byte PlayerNumber {get; set;}
        public BattingHand BattingHand { get; set; }
        public BattingHandEnum PlayerBattingHand { get; set; }
        public PitchingHand PitchingHand { get; set; }
        public PitchingHandEnum PlayerPitchingHand { get; set; }
        public List<PlayerPosition> Positions { get; set; }
        public PlayerStatus PlayerStatus { get; set; }
        public PlayerStatusEnum CurrentPlayerStatus { get; set; }
        public virtual List<PlayerInTeam> PlayersInTeam { get; set; }

        public PlayerBattingStats BattingStats;
        public PlayerPitchingStats PitchingStats;
        public bool CanPlayAsPitcher => Positions.Any(pp => pp.ShortTitle == "P");

        public Player SetBattingStats(PlayerBattingStats battingStats)
        {
            BattingStats = battingStats;
            return this;
        }

        public Player SetPitchingStats(PlayerPitchingStats stats)
        {
            PitchingStats = stats;
            return this;
        }
    }
}