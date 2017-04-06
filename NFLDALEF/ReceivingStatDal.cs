using NFLCommon;
using System;
using System.Collections.Generic;
using System.Data;
using NFLCommon.DALInterfaces;
using System.Linq;

namespace NFLDALEF
{
    public class ReceivingStatDal : IReceivingStatDal
    {
        NFLDBEntities entities = new NFLDBEntities();

        public Guid Create(ReceivingStat receivingStat)
        {
            Guid guid = Guid.NewGuid();
            receivingStat.ReceivingStatsId = guid;
            entities.ReceivingStats.Add(receivingStat);
            entities.SaveChanges();
            return guid;
        }

        public ReceivingStat Get(Guid receivingStatId)
        {
            return entities.ReceivingStats.FirstOrDefault(i => i.ReceivingStatsId.Equals(receivingStatId));
        }

        public IEnumerable<ReceivingStat> GetAll()
        {
            return entities.ReceivingStats;
        }

        public int Update(ReceivingStat receivingStat)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid receivingStatId)
        {
            var stat = entities.ReceivingStats.FirstOrDefault(i => i.ReceivingStatsId.Equals(receivingStatId));
            if (stat != null)
            {
                entities.ReceivingStats.Remove(stat);
                return 1;
            }
            return 0;
        }
    }
}
