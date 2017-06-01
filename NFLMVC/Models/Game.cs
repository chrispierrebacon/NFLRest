using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NFLMVC.Models
{
    public class Game
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public Guid GameId { get; set; }
        public string AwayTeam { get; set; }
        public string HomeTeam { get; set; }
        public string SeasonType { get; set; } = "NONE";
        public int Season { get; set; }
        public long Eid { get; set; }
        public long GameKey { get; set; }
        public int Week { get; set; }

        [Display(Name = "AT 1st")]
        public int ATScoreFirstQtr { get; set; }
        [Display(Name = "AT 2nd")]
        public int ATScoreSecondQtr { get; set; }
        [Display(Name = "AT 3rd")]
        public int ATScoreThirdQtr { get; set; }
        [Display(Name = "AT 4th")]
        public int ATScoreFourthQtr { get; set; }
        [Display(Name = "AT OT")]
        public int ATScoreOT { get; set; }
        [Display(Name = "AT Final")]
        public int ATScoreFinal { get; set; }

        [Display(Name = "HT 1st")]
        public int HTScoreFirstQtr { get; set; }
        [Display(Name = "HT 2nd")]
        public int HTScoreSecondQtr { get; set; }
        [Display(Name = "HT 3rd")]
        public int HTScoreThirdQtr { get; set; }
        [Display(Name = "HT 4th")]
        public int HTScoreFourthQtr { get; set; }
        [Display(Name = "HT OT")]
        public int HTScoreOT { get; set; }
        [Display(Name = "HT Final")]
        public int HTScoreFinal { get; set; }
        public bool NeutralField { get; set; }
    }
}