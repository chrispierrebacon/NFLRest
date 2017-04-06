using NFLCommon;
using System;
using System.Collections.Generic;
using System.Data;
using NFLCommon.DALInterfaces;
using System.Linq;

namespace NFLDALEF
{
    public class PlayerDal : IPlayerDal
    {
        NFLDBEntities entities = new NFLDBEntities();

        public Guid Create(Player player)
        {
            Guid guid = Guid.NewGuid();
            player.PlayerId = guid;
            entities.Players.Add(player);
            entities.SaveChanges();
            return guid;
        }

        public Player Get(Guid playerId)
        {
            return entities.Players.FirstOrDefault(i => i.PlayerId.Equals(playerId));
        }

        public Guid GetPlayerIdByGsisId(string GsisId)
        {
            return entities.Players.FirstOrDefault(i => i.GsisId.Equals(GsisId)).PlayerId;
        }

        public IEnumerable<Player> GetAll()
        {
            return entities.Players;
        }

        public int Update(Player player)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid playerId)
        {
            var stat = entities.Players.FirstOrDefault(i => i.PlayerId.Equals(playerId));
            if (stat != null)
            {
                entities.Players.Remove(stat);
                return 1;
            }
            return 0;
        }

        
    }
}
