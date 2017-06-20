using System.Collections.Concurrent;
using System.Collections.Generic;

namespace NFLCommon
{
    public class CondensedGameStats
    {
        public Game Game { get; set; } = new Game();
        public ConcurrentBag<OffensiveStat> OffensiveStats { get; set; } = new ConcurrentBag<OffensiveStat>();
        public ConcurrentBag<DefStatWithFumble> DefStatsWithFumbles { get; set; } = new ConcurrentBag<DefStatWithFumble>();
    }
}
