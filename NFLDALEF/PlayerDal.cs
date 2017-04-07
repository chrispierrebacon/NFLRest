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

            using (var entities = new NFLDBEntities())
            {
                entities.Players.Add(player);
                entities.SaveChanges();
            }

            return guid;
        }

        public Player Get(Guid playerId)
        {
            using (var entities = new NFLDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.Players.FirstOrDefault(i => i.PlayerId.Equals(playerId));
            }
        }

        public Guid GetPlayerIdByGsisId(string GsisId)
        {
            using (var entities = new NFLDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.Players.FirstOrDefault(i => i.GsisId.Equals(GsisId))?.PlayerId ?? Guid.Empty;
            }
        }

        public IEnumerable<Player> GetAll()
        {
            using (var entities = new NFLDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.Players;
            }
        }

        public int Update(Player player)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid playerId)
        {
            using (var entities = new NFLDBEntities())
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
}
