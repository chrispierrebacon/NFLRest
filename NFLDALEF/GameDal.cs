using NFLCommon;
using System;
using System.Collections.Generic;
using System.Data;
using NFLCommon.DALInterfaces;
using System.Linq;

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

        public Game Get(Guid gameId)
        {
            using (var entities = new NFLDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.Games.FirstOrDefault(i => i.GameId.Equals(gameId));
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

        public IEnumerable<Game> GetAll(out string something)
        {
            return entities.Games;
        }

        public int Update(Game game)
        {
            try
            {
                using (var entities = new NFLDBEntities())
                {
                    Game gameToDelete = entities.Games.FirstOrDefault(i => i.GameId == game.GameId);
                    entities.Games.Remove(gameToDelete);
                    entities.Games.Add(game);
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
}
