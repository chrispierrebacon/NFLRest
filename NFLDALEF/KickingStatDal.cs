using NFLCommon;
using System;
using System.Collections.Generic;
using System.Data;
using NFLCommon.DALInterfaces;
using System.Linq;

namespace NFLDALEF
{
    public class KickingStatDal : IKickingStatDal
    {
        public Guid Create(KickingStat kickingStat)
        {
            Guid guid = Guid.NewGuid();
            kickingStat.KickingStatsId = guid;
            using (var entities = new NFLDBEntities())
            {
                entities.KickingStats.Add(kickingStat);
                entities.SaveChanges();
            }
            return guid;
        }

        public IEnumerable<KickingStat> Get(string filterJson)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KickingStat> GetAll()
        {
            using (var entities = new NFLDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.KickingStats;
            }
        }

        public int Update(KickingStat kickingStat)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid kickingStatId)
        {
            using (var entities = new NFLDBEntities())
            {
                var stat = entities.KickingStats.FirstOrDefault(i => i.KickingStatsId.Equals(kickingStatId));
                if (stat != null)
                {
                    entities.KickingStats.Remove(stat);
                    return 1;
                }
                return 0;
            }                
        }
    }
}
