using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NFLMVC.Models
{
    public class Game
    {
        [Display(AutoGenerateField =false)]
        public int Id { get; set; }

        [Display(AutoGenerateField = false)]
        public System.Guid GameId { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public System.DateTime DateTime { get; set; }
        public string SeasonType { get; set; } = "NONE";
        public int Season { get; set; }

        [Display(AutoGenerateField = false)]
        public long Eid { get; set; }

        [Display(AutoGenerateField = false)]
        public long GameKey { get; set; }
        public int Week { get; set; }

        [Display(Name ="1")]
        public int HTScoreFirstQtr { get; set; }
        public int HTScoreSecondQtr { get; set; }
        public int HTScoreThirdQtr { get; set; }
        public int HTScoreFourthQtr { get; set; }
        public int HTScoreOT { get; set; }
        public int HTScoreFinal { get; set; }
        public int ATScoreFirstQtr { get; set; }
        public int ATScoreSecondQtr { get; set; }
        public int ATScoreThirdQtr { get; set; }
        public int ATScoreFourthQtr { get; set; }
        public int ATScoreOT { get; set; }
        public int ATScoreFinal { get; set; }
        public bool NeutralField { get; set; }
    }
}