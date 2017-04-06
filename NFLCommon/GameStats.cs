using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLCommon
{
    public class GameStats
    {
        public Game Game { get; set; }
        public List<Fumble> Fumbles { get; set; }
        public List<KickingStat> KickingStats { get; set; }
        public List<KickReturnStat> KickReturnStats { get; set; }
        public List<PassingStat> PassingStats { get; set; }
        public List<PuntingStat> PuntingStats { get; set; }
        public List<PuntReturnStat> PuntReturnStats { get; set; }
        public List<ReceivingStat> ReceivingStats { get; set; }
        public List<RushingStat> RushingStats { get; set; }
        public List<DefensiveStat> DefensiveStats { get; set; }

        public GameStats(Game game = null, List<Fumble> fumbles = null, List<KickingStat> kickingStats = null, List<KickReturnStat> kickReturnStats = null,
                            List<PassingStat> passingStats = null, List<PuntingStat> puntingStats = null, List<PuntReturnStat> puntReturnStats = null,
                            List<ReceivingStat> receivingStats = null, List<RushingStat> rushingStats = null, List<DefensiveStat> defensiveStats = null)
        {
            Game = game ?? new Game();
            Fumbles = fumbles ?? new List<Fumble>();
            KickingStats = kickingStats ?? new List<KickingStat>();
            KickReturnStats = kickReturnStats ?? new List<KickReturnStat>();
            PassingStats = passingStats ?? new List<PassingStat>();
            PuntingStats = puntingStats ?? new List<PuntingStat>();
            PuntReturnStats = puntReturnStats ?? new List<PuntReturnStat>();
            ReceivingStats = receivingStats ?? new List<ReceivingStat>();
            RushingStats = rushingStats ?? new List<RushingStat>();
            DefensiveStats = defensiveStats ?? new List<DefensiveStat>();
        }
    }
}
