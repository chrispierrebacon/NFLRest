using System;
using System.Collections.Generic;

namespace NFLCommon.DALInterfaces
{
    public interface IDalCrud<T> 
    {
        T Get(Guid id);
        Guid Create(T obj);
        IEnumerable<T> GetAll();
        int Update(T obj);
        int Delete(Guid id);
    }
}
