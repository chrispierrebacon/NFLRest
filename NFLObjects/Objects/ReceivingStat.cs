using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLObjects.Objects
{
    public class ReceivingStat : Stat
    {
        public Guid Id  { get; set; } = Guid.Empty;
        public int Receptions  { get; set; } = 0;
        public int Yards  { get; set; } = 0;
        public int Touchdowns  { get; set; } = 0;
        public int Long  { get; set; } = 0;
        public int TwoPointAttempts  { get; set; } = 0;
        public int TwoPointsMade  { get; set; } = 0;
    }
}
