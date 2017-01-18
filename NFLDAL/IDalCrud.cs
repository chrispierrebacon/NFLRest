using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLDAL
{
    public interface IDalCrud<T> 
    {
        Guid Create(T obj);
        T Get(Guid Id);
        int Update(T obj);
        int Delete(Guid Id);
    }
}
