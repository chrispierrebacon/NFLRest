using NFLCommon;
using NFLCommon.DALInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NFLBLL
{
    public class GamesBL : SingleStatBL<Game>
    {
        public GamesBL(IDalCrud<Game> dalCrud) : base(dalCrud) { }

        public override IEnumerable<Game> Get(string gamesFilterJson)
        {
            if (string.IsNullOrEmpty(gamesFilterJson))
            {
                return _dalCrud.GetAll();
            }

            GamesFilter gamesFilter = JsonConvert.DeserializeObject<GamesFilter>(gamesFilterJson);

            if (!gamesFilter.Id.Equals(Guid.Empty))
            {
                return base.Get(gamesFilterJson);
            }

            // TODO use enums to make this more elegant
            StringBuilder seasonType = new StringBuilder();
            if (gamesFilter.PreSeasonOn)
            {
                seasonType.Append("PRE");
            }
            if (gamesFilter.RegSeasonOn)
            {
                seasonType.Append("REG");
            }
            if (gamesFilter.PostSeasonOn)
            {
                seasonType.Append("POST");
            }

            IEnumerable<Game> games = _dalCrud.GetAll()
                .Where(i => seasonType.ToString().Contains(i.SeasonType));
            
            if(gamesFilter.Season != 0)
            {
                games = games.Where(i => i.Season == gamesFilter.Season);
            }
            games = games.Where(i => i.DateTime >= gamesFilter.StartDate && i.DateTime <= gamesFilter.EndDate);

            games = games.OrderByDescending(i => i.DateTime);
            return games.ToList();
        }
    }

    public class GamesFilter : Filter
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
