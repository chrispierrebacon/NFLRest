using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLObjects.Objects
{
    public class PuntingStat : Stat
    {
        public Guid Id  { get; set; } = Guid.Empty;
        public int Punts  { get; set; } = 0;
        public int Yards  { get; set; } = 0;
        public int Average  { get; set; } = 0;
        public int InsideTwenty  { get; set; } = 0;
        public int Long  { get; set; } = 0;
    }
}
