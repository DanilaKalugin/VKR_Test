namespace VKR.EF.Entities
{
    public class PlayerBattingStats: BattingStats
    {
        public uint PlayerID;
        public PlayerBattingStats(int g, int singles, int doubles, int triples, int hr, int sf, int sac, int rbi, int hbp, int sb, int cs, int runs, int bb, int k, int go, int ao, int po, int pa, int gidp, int tgp, uint playerID) :
            base(g, singles, doubles, triples, hr, sf, sac, rbi, hbp, sb, cs, runs, bb, k, go, ao, po, pa, gidp, tgp)
        {
            PlayerID = playerID;
        }

        public PlayerBattingStats()
        {
                
        }
    }
}
