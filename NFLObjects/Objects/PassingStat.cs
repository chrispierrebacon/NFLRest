using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLObjects.Objects
{
    public class PassingStat : Stat
    {
        public Guid Id  { get; set; } = Guid.Empty;
        public int Attempts  { get; set; } = 0;
        public int Completions  { get; set; } = 0;
        public int Yards  { get; set; } = 0;
        public int Touchdowns  { get; set; } = 0;
        public int Interceptions  { get; set; } = 0;
        public int TwoPointAttempts  { get; set; } = 0;
        public int TwoPointMakes  { get; set; } = 0;
    }
}
