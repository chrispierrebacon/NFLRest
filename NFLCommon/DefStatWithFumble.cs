using System;

namespace NFLCommon
{
    public class DefStatWithFumble
    {
        public Player Player { get; set; } = new Player();
        public DefensiveStat DefensiveStat { get; set; } = new DefensiveStat();
        public Fumble Fumble { get; set; } = new Fumble();
    }
}
