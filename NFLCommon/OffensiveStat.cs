using System;

namespace NFLCommon
{
    public class OffensiveStat
    {
        public Player Player { get; set; } = new Player();
        public Fumble Fumble { get; set; } = new Fumble();
        public PassingStat PassingStat { get; set; } = new PassingStat();
        public RushingStat RushingStat { get; set; } = new RushingStat();
        public ReceivingStat ReceivingStat { get; set; } = new ReceivingStat();
        public PuntReturnStat PuntReturnStat { get; set; } = new PuntReturnStat();
        public KickReturnStat KickReturnStat { get; set; } = new KickReturnStat();
    }
}
