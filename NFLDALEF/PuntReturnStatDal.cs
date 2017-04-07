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
        public Guid Create(PuntReturnStat puntReturnStat)
        {
            Guid guid = Guid.NewGuid();
            puntReturnStat.PuntReturnStatsId = guid;
            using (var entities = new NFLDBEntities())
            {
                entities.PuntReturnStats.Add(puntReturnStat);
                entities.SaveChanges();
            }
            return guid;
        }

        public IEnumerable<PuntReturnStat> Get(string filterJson)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PuntReturnStat> GetAll()
        {
            using (var entities = new NFLDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.PuntReturnStats;
            }
        }

        public int Update(PuntReturnStat puntReturnStat)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid puntReturnStatId)
        {
            using (var entities = new NFLDBEntities())
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
}
