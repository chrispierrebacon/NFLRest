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
        NFLDBEntities entities = new NFLDBEntities();

        public Guid Create(RushingStat rushingStat)
        {
            Guid guid = Guid.NewGuid();
            rushingStat.RushingStatsId = guid;
            entities.RushingStats.Add(rushingStat);
            entities.SaveChanges();
            return guid;
        }

        public RushingStat Get(Guid rushingStatId)
        {
            return entities.RushingStats.FirstOrDefault(i => i.RushingStatsId.Equals(rushingStatId));
        }

        public IEnumerable<RushingStat> GetAll()
        {
            return entities.RushingStats;
        }

        public int Update(RushingStat rushingStat)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid rushingStatId)
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
