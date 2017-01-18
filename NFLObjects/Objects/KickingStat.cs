using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLObjects.Objects
{
    public class KickingStat : Stat
    {
        public Guid Id  { get; set; } = Guid.Empty;
        public int FieldGoalsMade  { get; set; } = 0;
        public int FieldGoalsAttempted  { get; set; } = 0;
        public int Yards  { get; set; } = 0;
        public int TotalPoints  { get; set; } = 0;
        public int ExtraPointsMade  { get; set; } = 0;
        public int ExtraPointsMissed { get; set; } = 0;
        public int ExtraPointsAttempted  { get; set; } = 0;
        public int ExtraPointsBlocked  { get; set; } = 0;
        public int ExtraPointsTotal  { get; set; } = 0;
    }
}
