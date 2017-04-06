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
        NFLDBEntities entities = new NFLDBEntities();

        public Guid Create(KickingStat kickingStat)
        {
            Guid guid = Guid.NewGuid();
            kickingStat.KickingStatsId = guid;
            entities.KickingStats.Add(kickingStat);
            entities.SaveChanges();
            return guid;
        }

        public KickingStat Get(Guid kickingStatId)
        {
            return entities.KickingStats.FirstOrDefault(i => i.KickingStatsId.Equals(kickingStatId));
        }

        public IEnumerable<KickingStat> GetAll()
        {
            return entities.KickingStats;
        }

        public int Update(KickingStat kickingStat)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid kickingStatId)
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
