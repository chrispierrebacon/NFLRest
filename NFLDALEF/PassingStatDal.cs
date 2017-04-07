using NFLCommon;
using System;
using System.Collections.Generic;
using System.Data;
using NFLCommon.DALInterfaces;
using System.Linq;

namespace NFLDALEF
{
    public class PassingStatDal : IPassingStatDal
    {
        public Guid Create(PassingStat passingStat)
        {
            Guid guid = Guid.NewGuid();
            passingStat.PassingStatsId = guid;
            using (var entities = new NFLDBEntities())
            {
                entities.PassingStats.Add(passingStat);
                entities.SaveChanges();
            }
            return guid;
        }

        public IEnumerable<PassingStat> Get(string filterJson)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PassingStat> GetAll()
        {
            using (var entities = new NFLDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.PassingStats;
            }
        }

        public int Update(PassingStat passingStat)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid passingStatId)
        {
            using (var entities = new NFLDBEntities())
            {
                var stat = entities.PassingStats.FirstOrDefault(i => i.PassingStatsId.Equals(passingStatId));
                if (stat != null)
                {
                    entities.PassingStats.Remove(stat);
                    return 1;
                }
                return 0;
            }
        }

        
    }
}
