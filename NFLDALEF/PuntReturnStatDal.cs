using NFLCommon;
using System;
using System.Collections.Generic;
using System.Data;
using NFLCommon.DALInterfaces;
using System.Linq;

namespace NFLDALEF
{
    public class PuntReturnStatDal : IPuntReturnStatDal
    {
        NFLDBEntities entities = new NFLDBEntities();

        public Guid Create(PuntReturnStat puntReturnStat)
        {
            Guid guid = Guid.NewGuid();
            puntReturnStat.PuntReturnStatsId = guid;
            entities.PuntReturnStats.Add(puntReturnStat);
            entities.SaveChanges();
            return guid;
        }

        public PuntReturnStat Get(Guid puntReturnStatId)
        {
            return entities.PuntReturnStats.FirstOrDefault(i => i.PuntReturnStatsId.Equals(puntReturnStatId));
        }

        public IEnumerable<PuntReturnStat> GetAll()
        {
            return entities.PuntReturnStats;
        }

        public int Update(PuntReturnStat puntReturnStat)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid puntReturnStatId)
        {
            var stat = entities.PuntReturnStats.FirstOrDefault(i => i.PuntReturnStatsId.Equals(puntReturnStatId));
            if (stat != null)
            {
                entities.PuntReturnStats.Remove(stat);
                return 1;
            }
            return 0;
        }
    }
}
