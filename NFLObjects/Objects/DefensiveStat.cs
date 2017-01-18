using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLObjects.Objects
{
    public class DefensiveStat : Stat
    {
        public int Id  { get; set; } = -1;
        public Guid DefensiveStatsId  { get; set; } = Guid.Empty;
        public int Tackles  { get; set; } = 0;
        public int Assists  { get; set; } = 0;
        public int Sacks  { get; set; } = 0;
        public int Interceptions  { get; set; } = 0;
        public int ForcedFumbles  { get; set; } = 0;
    }
}
