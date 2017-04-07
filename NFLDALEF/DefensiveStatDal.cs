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
        public Guid Create(DefensiveStat stat)
        {
            try
            {
                Guid guid = Guid.NewGuid();
                stat.DefensiveStatsId = guid;
                using (var entities = new NFLDBEntities())
                {
                    entities.DefensiveStats.Add(stat);
                    entities.SaveChanges();
                }
                return guid;
            }
            catch
            {
                return Guid.Empty;
            }
        }

        public DefensiveStat Get(Guid Id)
        {
            using (var entities = new NFLDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.DefensiveStats.First(i => i.DefensiveStatsId.Equals(Id)); 
            }
        }

        public IEnumerable<DefensiveStat> GetAll()
        {
            using (var entities = new NFLDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.DefensiveStats; 
            }
        }

        public int Update(DefensiveStat obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid Id)
        {
            using (var entities = new NFLDBEntities())
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
}
