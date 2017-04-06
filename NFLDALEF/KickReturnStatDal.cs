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
        NFLDBEntities entities = new NFLDBEntities();

        public Guid Create(KickReturnStat kickReturnStat)
        {
            Guid guid = Guid.NewGuid();
            kickReturnStat.KickReturnStatsId = guid;
            entities.KickReturnStats.Add(kickReturnStat);
            entities.SaveChanges();
            return guid;
        }

        public KickReturnStat Get(Guid kickReturnStatId)
        {
            return entities.KickReturnStats.FirstOrDefault(i => i.KickReturnStatsId.Equals(kickReturnStatId));
        }

        public IEnumerable<KickReturnStat> GetAll()
        {
            return entities.KickReturnStats;
        }

        public int Update(KickReturnStat kickReturnStat)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid kickReturnStatId)
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
