using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLEF
{
    public class FantasyPoints
    {
        public double PassingStatsToFantasyPoints(PassingStat stat)
        {
            return stat.Yards * 0.04 + stat.Touchdowns * 4 + stat.Interceptions * -2 + stat.TwoPointMakes * 2;
        }

        public double RushingStatsToFantasyPoints(RushingStat stat)
        {
            return stat.Yards * .1 + stat.Touchdowns * 6 + stat.TwoPointsMade * 2;
        }
    }
}
