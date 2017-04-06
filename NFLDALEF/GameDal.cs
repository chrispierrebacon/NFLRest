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
        NFLDBEntities entities = new NFLDBEntities();

        public GameDal()
        {
            entities.Configuration.ProxyCreationEnabled = false;
        }       

        public Guid Create(Game game)
        {
            Guid guid = Guid.NewGuid();
            game.GameId = guid;
            entities.Games.Add(game);
            entities.SaveChanges();
            return guid;
        }

        public Game Get(Guid gameId)
        {
            return entities.Games.FirstOrDefault(i => i.GameId.Equals(gameId));
        }

        public Guid GetGameIdByEid(long Eid)
        {
            return entities.Games.FirstOrDefault(i => i.Eid.Equals(Eid)).GameId;
        }

        public IEnumerable<Game> GetAll()
        {
            return entities.Games;
        }

        public int Update(Game game)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid gameId)
        {
            var stat = entities.Games.FirstOrDefault(i => i.GameId.Equals(gameId));
            if (stat != null)
            {
                entities.Games.Remove(stat);
                return 1;
            }
            return 0;
        }
    }
}
