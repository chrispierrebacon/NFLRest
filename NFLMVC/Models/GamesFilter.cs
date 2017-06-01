using NFLMVC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NFLMVC.Models
{
    public class GamesFilter : NFLFilter
    {
        public bool PreSeasonOn { get; set; } = false;
        public bool PostSeasonOn { get; set; } = true;
        public bool RegSeasonOn { get; set; } = true;
        public int Season { get; set; }
        // When the nfl was founded. It would be cool to have all this data
        public DateTime StartDate { get; set; } = new DateTime(1920, 8, 20);
        // Some time far in the future
        public DateTime EndDate { get; set; } = new DateTime(2100, 1, 1);
    }
}