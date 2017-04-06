using NFLCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NFLCommon.DALInterfaces;

namespace NFLDALEF
{
    public class DefensiveStatDal : IDefensiveStatDal
    {
        NFLDBEntities entities = new NFLDBEntities();

        public Guid Create(DefensiveStat stat)
        {
            Guid guid = Guid.NewGuid();
            stat.DefensiveStatsId = guid;
            entities.DefensiveStats.Add(stat);
            entities.SaveChanges();
            return guid;
        }

        public DefensiveStat Get(Guid Id)
        {
            return entities.DefensiveStats.First(i => i.DefensiveStatsId.Equals(Id));
        }

        public IEnumerable<DefensiveStat> GetAll()
        {
            return entities.DefensiveStats;
        }

        public int Update(DefensiveStat obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid Id)
        {
            var stat = entities.DefensiveStats.FirstOrDefault(i => i.DefensiveStatsId.Equals(Id));
            if (stat != null)
            {
                entities.DefensiveStats.Remove(stat);
                return 1;
            }
            return 0;
        }        
    }
}
