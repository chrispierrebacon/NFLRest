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
        NFLDBEntities entities = new NFLDBEntities();

        public Guid Create(PassingStat passingStat)
        {
            Guid guid = Guid.NewGuid();
            passingStat.PassingStatsId = guid;
            entities.PassingStats.Add(passingStat);
            entities.SaveChanges();
            return guid;
        }

        public PassingStat Get(Guid passingStatId)
        {
            return entities.PassingStats.FirstOrDefault(i => i.PassingStatsId.Equals(passingStatId));
        }

        public IEnumerable<PassingStat> GetAll()
        {
            return entities.PassingStats;
        }

        public int Update(PassingStat passingStat)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid passingStatId)
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
