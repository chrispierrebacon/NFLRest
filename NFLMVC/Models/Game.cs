using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NFLMVC.Models
{
    public class Game
    {
        public int Id { get; set; }
        public System.Guid GameId { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public System.DateTime DateTime { get; set; }
        public string SeasonType { get; set; } = "NONE";
        public int Season { get; set; }
        public long Eid { get; set; }
        public long GameKey { get; set; }
        public int Week { get; set; }
        public string WT { get; set; }
        public string LT { get; set; }
        public int WTScoreFirstQtr { get; set; }
        public int WTScoreSecondQtr { get; set; }
        public int WTScoreThirdQtr { get; set; }
        public int WTScoreFourthQtr { get; set; }
        public int WTScoreOT { get; set; }
        public int WTScoreFinal { get; set; }
        public int LTScoreFirstQtr { get; set; }
        public int LTScoreSecondQtr { get; set; }
        public int LTScoreThirdQtr { get; set; }
        public int LTScoreFourthQtr { get; set; }
        public int LTScoreOT { get; set; }
        public int LTScoreFinal { get; set; }
        public bool NeutralField { get; set; }
    }
}