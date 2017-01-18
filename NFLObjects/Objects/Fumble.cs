using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLObjects.Objects
{
    public class Fumble : Stat
    {
        public Guid Id  { get; set; } = Guid.Empty;
        public int Total  { get; set; } = 0;
        public int Recovered  { get; set; } = 0;
        public int TeamRecovered  { get; set; } = 0;
        public int Yards  { get; set; } = 0;
        public int Lost  { get; set; } = 0;
    }
}
