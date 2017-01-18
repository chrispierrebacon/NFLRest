using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLBLL
{
    public interface IBLCrud<T>
    {
        Guid Create(T obj);
        T Get(Guid Id);
        int Update(T obj);
        int Delete(Guid Id);
    }
}
