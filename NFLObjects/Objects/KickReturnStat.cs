using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLObjects.Objects
{
    public class KickReturnStat : Stat
    {
        public Guid Id  { get; set; } = Guid.Empty;
        public int Returns  { get; set; } = 0;
        public int Average  { get; set; } = 0;
        public int Touchdowns  { get; set; } = 0;
        public int Long  { get; set; } = 0;
        public int LongTouchdown  { get; set; } = 0;
    }
}
