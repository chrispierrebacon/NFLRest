using NFLCommon;
using System;
using System.Collections.Generic;
using System.Data;
using NFLCommon.DALInterfaces;
using System.Linq;

namespace NFLDALEF
{
    public class RushingStatDal : IRushingStatDal
    {
        public Guid Create(RushingStat rushingStat)
        {
            Guid guid = Guid.NewGuid();
            rushingStat.RushingStatsId = guid;
            using (var entities = new NFLDBEntities())
            {
                entities.RushingStats.Add(rushingStat);
                entities.SaveChanges();
            }
            return guid;
        }

        public IEnumerable<RushingStat> Get(string filterJson)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RushingStat> GetAll()
        {
            using (var entities = new NFLDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.RushingStats;
            }
        }

        public int Update(RushingStat rushingStat)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid rushingStatId)
        {
            using (var entities = new NFLDBEntities())
            {
                var stat = entities.RushingStats.FirstOrDefault(i => i.RushingStatsId.Equals(rushingStatId));
                if (stat != null)
                {
                    entities.RushingStats.Remove(stat);
                    return 1;
                }
                return 0;
            }
        }

        
    }
}
