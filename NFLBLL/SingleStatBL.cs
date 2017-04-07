using NFLDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFLCommon.DALInterfaces;
using Newtonsoft.Json;

namespace NFLBLL
{
    // TODO: Make this abstract once there are concretes
    public class SingleStatBL<T>
    {
        internal readonly IDalCrud<T> _dalCrud;

        public SingleStatBL(IDalCrud<T> dalCrud)
        {
            _dalCrud = dalCrud;
        }

        public Guid Create(T obj)
        {
            return _dalCrud.Create(obj);
        }

        public IEnumerable<T> Get(string filterJson = "")
        {
            return _dalCrud.Get(filterJson);
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
