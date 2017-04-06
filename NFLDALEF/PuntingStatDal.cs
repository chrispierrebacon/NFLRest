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
        NFLDBEntities entities = new NFLDBEntities();

        public Guid Create(PuntingStat puntingStat)
        {
            Guid guid = Guid.NewGuid();
            puntingStat.PuntingStatsId = guid;
            entities.PuntingStats.Add(puntingStat);
            entities.SaveChanges();
            return guid;
        }

        public PuntingStat Get(Guid puntingStatId)
        {
            return entities.PuntingStats.FirstOrDefault(i => i.PuntingStatsId.Equals(puntingStatId));
        }

        public IEnumerable<PuntingStat> GetAll()
        {
            return entities.PuntingStats;
        }

        public int Update(PuntingStat puntingStat)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid puntingStatId)
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
