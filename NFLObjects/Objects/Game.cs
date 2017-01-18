using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLObjects.Objects
{
    public class Game
    {
        public Guid GameId { get; set; } = Guid.Empty;
        public string HomeTeam { get; set; } = string.Empty;
        public string AwayTeam { get; set; } = string.Empty;
        public DateTime DateTime { get; set; } = new DateTime(1753, 1, 1);
        public SeasonType SeasonType { get; set; } = SeasonType.NONE;
        public long Eid { get; set; } = 0;
        public long GameKey { get; set; } = 0;
        public int Week { get; set; } = 0;
        public string WT { get; set; } = string.Empty;
        public string LT { get; set; } = string.Empty;
        public int WTScoreFirstQtr { get; set; } = 0;
        public int WTScoreSecondQtr { get; set; } = 0;
        public int WTScoreThirdQtr { get; set; } = 0;
        public int WTScoreFourthQtr { get; set; } = 0;
        public int WTScoreOT { get; set; } = 0;
        public int WTScoreFinal { get; set; } = 0;
        public int LTScoreFirstQtr { get; set; } = 0;
        public int LTScoreSecondQtr { get; set; } = 0;
        public int LTScoreThirdQtr { get; set; } = 0;
        public int LTScoreFourthQtr { get; set; } = 0;
        public int LTScoreOT { get; set; } = 0;
        public int LTScoreFinal { get; set; } = 0;
        public bool NeutralField { get; set; } = false;
    }
}
