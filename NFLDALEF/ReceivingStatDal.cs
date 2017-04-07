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
        public Guid Create(ReceivingStat receivingStat)
        {
            Guid guid = Guid.NewGuid();
            receivingStat.ReceivingStatsId = guid;
            using (var entities = new NFLDBEntities())
            {
                entities.ReceivingStats.Add(receivingStat);
                entities.SaveChanges();
            }
            return guid;
        }

        public ReceivingStat Get(Guid receivingStatId)
        {
            using (var entities = new NFLDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.ReceivingStats.FirstOrDefault(i => i.ReceivingStatsId.Equals(receivingStatId));
            }
        }

        public IEnumerable<ReceivingStat> GetAll()
        {
            using (var entities = new NFLDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.ReceivingStats;
            }
        }

        public int Update(ReceivingStat receivingStat)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid receivingStatId)
        {
            using (var entities = new NFLDBEntities())
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
}
