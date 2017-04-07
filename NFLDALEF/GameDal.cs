using NFLCommon;
using System;
using System.Collections.Generic;
using System.Data;
using NFLCommon.DALInterfaces;
using System.Linq;
using Newtonsoft.Json;
using System.Text;

namespace NFLDALEF
{
    public class GameDal : IGameDal
    {
        public Guid Create(Game game)
        {
            Guid guid = Guid.NewGuid();
            game.GameId = guid;

            using (var entities = new NFLDBEntities())
            {
                entities.Games.Add(game);
                entities.SaveChanges();
            }
                
            return guid;
        }

        public IEnumerable<Game> Get(string filterJson)
        {
            using (var entities = new NFLDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;

                IEnumerable<Game> games = entities.Games;

                if (string.IsNullOrEmpty(filterJson))
                {
                    games.ToList();
                }

                GamesFilter filter = JsonConvert.DeserializeObject<GamesFilter>(filterJson);

                if (!filter.Id.Equals(Guid.Empty))
                {
                    return games.Where(i => i.GameId.Equals(filter.Id));
                }

                // TODO use enums to make this more elegant
                StringBuilder seasonType = new StringBuilder();
                if (filter.PreSeasonOn)
                {
                    seasonType.Append("PRE");
                }
                if (filter.RegSeasonOn)
                {
                    seasonType.Append("REG");
                }
                if (filter.PostSeasonOn)
                {
                    seasonType.Append("POST");
                }

                games = games.Where(i => seasonType.ToString().Contains(i.SeasonType));

                if (filter.Season != 0)
                {
                    games = games.Where(i => i.Season == filter.Season);
                }
                games = games.Where(i => i.DateTime >= filter.StartDate && i.DateTime <= filter.EndDate);

                games = games.OrderByDescending(i => i.DateTime);
                var gamesList = games.ToList();
                return gamesList;
            }
        }

        public Guid GetGameIdByEid(long Eid)
        {
            using (var entities = new NFLDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.Games.FirstOrDefault(i => i.Eid.Equals(Eid))?.GameId ?? Guid.Empty;
            }
        }

        public IEnumerable<Game> GetAll()
        {
            using (var entities = new NFLDBEntities())
            {
                return entities.Games.ToList();
            }
        }

        public int Update(Game game)
        {
            try
            {
                using (var entities = new NFLDBEntities())
                {

                    // TODO: For now just update the scores, but later we'll want to update evrything
                    Game gameToUpdate = entities.Games.FirstOrDefault(i => i.GameId == game.GameId);
                    gameToUpdate.ATScoreFinal = game.ATScoreFinal;
                    gameToUpdate.ATScoreFirstQtr = game.ATScoreFirstQtr;
                    gameToUpdate.ATScoreFourthQtr = game.ATScoreFourthQtr;
                    gameToUpdate.ATScoreOT = game.ATScoreOT;
                    gameToUpdate.ATScoreSecondQtr = game.ATScoreSecondQtr;
                    gameToUpdate.ATScoreThirdQtr = game.ATScoreThirdQtr;

                    gameToUpdate.HTScoreFinal = game.HTScoreFinal;
                    gameToUpdate.HTScoreFirstQtr = game.HTScoreFirstQtr;
                    gameToUpdate.HTScoreFourthQtr = game.HTScoreFourthQtr;
                    gameToUpdate.HTScoreOT = game.HTScoreOT;
                    gameToUpdate.HTScoreSecondQtr = game.HTScoreSecondQtr;
                    gameToUpdate.HTScoreThirdQtr = game.HTScoreThirdQtr;
                    
                    entities.SaveChanges();
                }
                
                return 1;
            }
            catch(Exception ex)
            {
                // TODO some elegant logic
                throw new Exception();
            }
        }

        public int Delete(Guid gameId)
        {
            using (var entities = new NFLDBEntities())
            {
                var stat = entities.Games.FirstOrDefault(i => i.GameId.Equals(gameId));
                if (stat != null)
                {
                    entities.Games.Remove(stat);
                    return 1;
                }
            }            
            return 0;
        }
    }

    public class GamesFilter
    {
        public Guid Id { get; set; } = Guid.Empty;
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
