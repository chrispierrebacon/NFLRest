using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLObjects.Objects
{
    public class Stat
    {
        public Guid PlayerId  { get; set; } = Guid.Empty;
        public Guid GameId  { get; set; } = Guid.Empty;
        public string GsisId  { get; set; } = string.Empty;
    }
}
