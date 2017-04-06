using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLCommon.BLLInterfaces
{
    public interface IBLCrud<T>
    {
        Guid Create(T obj);
        T Get(Guid Id);
        IEnumerable<T> GetAll();
        int Update(T obj);
        int Delete(Guid Id);
    }
}
