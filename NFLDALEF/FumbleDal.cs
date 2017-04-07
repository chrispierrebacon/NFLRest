using NFLCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NFLCommon.DALInterfaces;

namespace NFLDALEF
{
    public class FumbleDal : IFumbleDal
    {
        public Guid Create(Fumble stat)
        {
            Guid guid = Guid.NewGuid();
            stat.FumblesId = guid;
            using (var entities = new NFLDBEntities())
            {
                entities.Fumbles.Add(stat);
                entities.SaveChanges();
            }
            return guid;
        }

        public IEnumerable<Fumble> Get(string filterJson)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fumble> GetAll()
        {
            using (var entities = new NFLDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.Fumbles;
            }
        }

        public int Update(Fumble obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid Id)
        {
            using (var entities = new NFLDBEntities())
            {
                var stat = entities.Fumbles.FirstOrDefault(i => i.FumblesId.Equals(Id));
                if (stat != null)
                {
                    entities.Fumbles.Remove(stat);
                    return 1;
                }
                return 0;
            }
        }
    }
}
