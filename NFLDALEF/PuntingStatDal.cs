using NFLCommon;
using System;
using System.Collections.Generic;
using System.Data;
using NFLCommon.DALInterfaces;
using System.Linq;

namespace NFLDALEF
{
    public class PuntingStatDal : IPuntingStatDal
    {
        public Guid Create(PuntingStat puntingStat)
        {
            Guid guid = Guid.NewGuid();
            puntingStat.PuntingStatsId = guid;
            using (var entities = new NFLDBEntities())
            {
                entities.PuntingStats.Add(puntingStat);
                entities.SaveChanges();
            }
            return guid;
        }

        public PuntingStat Get(Guid puntingStatId)
        {
            using (var entities = new NFLDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.PuntingStats.FirstOrDefault(i => i.PuntingStatsId.Equals(puntingStatId));
            }
        }

        public IEnumerable<PuntingStat> GetAll()
        {
            using (var entities = new NFLDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.PuntingStats;
            }
        }

        public int Update(PuntingStat puntingStat)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid puntingStatId)
        {
            using (var entities = new NFLDBEntities())
            {
                var stat = entities.PuntingStats.FirstOrDefault(i => i.PuntingStatsId.Equals(puntingStatId));
                if (stat != null)
                {
                    entities.PuntingStats.Remove(stat);
                    return 1;
                }
                return 0;
            }
        }
    }
}
