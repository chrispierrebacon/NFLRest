using NFLCommon;
using System;
using System.Collections.Generic;
using System.Data;
using NFLCommon.DALInterfaces;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Data.Entity;

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
                entities.Configuration.LazyLoadingEnabled = true;

                IQueryable<Game> games = entities.Games;

                if (string.IsNullOrEmpty(filterJson))
                {
                    // PRESEASON can lick lick lick my balls! yeah say that all the time
                    var gamess = games.Where(i => !i.SeasonType.Equals("PRE")).OrderByDescending(i => i.DateTime).Include(t => t.Team).Include(t => t.Team1).ToList();
                    return gamess;
                }

                GamesFilter filter = JsonConvert.DeserializeObject<GamesFilter>(filterJson);

                if (!filter.Id.Equals(Guid.Empty))
                {
                    return games.Where(i => i.GameId.Equals(filter.Id)).ToList();
                }

                // TODO use enums to make this more elegant
                StringBuilder seasonTypeBuilder = new StringBuilder();
                if (filter.PreSeasonOn)
                {
                    seasonTypeBuilder.Append("PRE");
                }
                if (filter.RegSeasonOn)
                {
                    seasonTypeBuilder.Append("REG");
                }
                if (filter.PostSeasonOn)
                {
                    seasonTypeBuilder.Append("POST");
                }
                string seasonType = seasonTypeBuilder.ToString();
                games = games.Where(i => seasonType.ToString().Contains(i.SeasonType));

                if (filter.Season != 0)
                {
                    games = games.Where(i => i.Season == filter.Season);
                }

                if (filter.Teams != null && filter.Teams.Count() > 0)
                {
                    if (filter.vsTeams)
                    {
                        string team1 = filter.Teams[0];
                        string team2 = filter.Teams[1];
                        games = games.Where(i => (i.HomeTeam.Equals(team1) && i.AwayTeam.Equals(team2)) || (i.HomeTeam.Equals(team2) && i.AwayTeam.Equals(team1)));
                    }
                    else
                    {
                        games = games.Where(i => filter.Teams.Contains(i.HomeTeam) || filter.Teams.Contains(i.AwayTeam));
                    }
                }

                games = games.Where(i => i.DateTime >= filter.StartDate && i.DateTime <= filter.EndDate);

                games = games.OrderByDescending(i => i.DateTime);
                var gamesList = games.Include(t => t.Team).Include(t => t.Team1).ToList();
                return gamesList;
            }
        }

        public Guid GetGameByEid(long Eid)
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
                    Game gameToUpdate = entities.Games.FirstOrDefault(i => i.GameId == game.GameId);
                    entities.Entry(gameToUpdate).CurrentValues.SetValues(game);
                    entities.SaveChanges();
                    return 1;
                }
            }
            catch(Exception ex)
            {
                return 0;
            }
            
        }

        public int UpdateScore(Game game)
        {
            try
            {
                using (var entities = new NFLDBEntities())
                {

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
            catch (Exception ex)
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
                    entities.SaveChanges();
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

        public List<string> Teams { get; set; }
        public bool vsTeams = false;
    }
}
