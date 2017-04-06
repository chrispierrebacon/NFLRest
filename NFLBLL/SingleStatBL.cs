using NFLDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFLCommon.BLLInterfaces;
using NFLCommon.DALInterfaces;

namespace NFLBLL
{
    public class SingleStatBL<T> : IBLCrud<T>
    {
        private readonly IDalCrud<T> _dalCrud;

        public SingleStatBL(IDalCrud<T> dalCrud)
        {
            _dalCrud = dalCrud;
        }

        public Guid Create(T obj)
        {
            return _dalCrud.Create(obj);
        }

        public IEnumerable<T> GetAll()
        {
            return _dalCrud.GetAll();
        }

        public T Get(Guid Id)
        {
            return _dalCrud.Get(Id);
        }

        public int Update(T obj)
        {
            return _dalCrud.Update(obj);
        }

        public int Delete(Guid Id)
        {
            return _dalCrud.Delete(Id);
        }
    }
}
