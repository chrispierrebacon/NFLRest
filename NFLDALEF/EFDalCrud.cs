using NFLCommon;
using NFLCommon.DALInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace NFLDALEF
{
    public class EFDalCrud<T> : IDalCrud<T> where T : class
    {
        internal NFLDBEntities _entities = new NFLDBEntities();
        internal FieldInfo _field;
        internal DbSet<T> _dbSet;

        public EFDalCrud(string dbSet)
        {
            _field = _entities.GetType().GetField(dbSet);
            _dbSet = (DbSet<T>) _field.GetValue(null);
        }

        public T Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public int Update(T obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Guid Create(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
