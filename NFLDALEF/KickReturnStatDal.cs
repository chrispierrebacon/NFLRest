using NFLCommon;
using System;
using System.Collections.Generic;
using System.Data;
using NFLCommon.DALInterfaces;
using System.Linq;

namespace NFLDALEF
{
    public class KickReturnStatDal : IKickReturnStatDal
    {
        public Guid Create(KickReturnStat kickReturnStat)
        {
            Guid guid = Guid.NewGuid();
            kickReturnStat.KickReturnStatsId = guid;
            using (var entities = new NFLDBEntities())
            {
                entities.KickReturnStats.Add(kickReturnStat);
                entities.SaveChanges();
            }
            return guid;
        }

        public IEnumerable<KickReturnStat> Get(string filterJson)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KickReturnStat> GetAll()
        {
            using (var entities = new NFLDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.KickReturnStats;
            }
        }

        public int Update(KickReturnStat kickReturnStat)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid kickReturnStatId)
        {
            using (var entities = new NFLDBEntities())
            {
                var stat = entities.KickReturnStats.FirstOrDefault(i => i.KickReturnStatsId.Equals(kickReturnStatId));
                if (stat != null)
                {
                    entities.KickReturnStats.Remove(stat);
                    return 1;
                }
                return 0;
            }
        }

        
    }
}
