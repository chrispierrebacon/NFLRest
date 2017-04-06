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
        NFLDBEntities entities = new NFLDBEntities();

        public Guid Create(Fumble stat)
        {
            Guid guid = Guid.NewGuid();
            stat.FumblesId = guid;
            entities.Fumbles.Add(stat);
            entities.SaveChanges();
            return guid;
        }

        public Fumble Get(Guid Id)
        {
            return entities.Fumbles.FirstOrDefault(i => i.Id.Equals(Id));
        }

        public IEnumerable<Fumble> GetAll()
        {
            return entities.Fumbles;
        }

        public int Update(Fumble obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid Id)
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
