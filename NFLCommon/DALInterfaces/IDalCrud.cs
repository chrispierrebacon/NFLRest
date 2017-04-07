using System;
using System.Collections.Generic;

namespace NFLCommon.DALInterfaces
{
    public interface IDalCrud<T> 
    {
        IEnumerable<T> Get(string filterJson);
        Guid Create(T obj);
        IEnumerable<T> GetAll();
        int Update(T obj);
        int Delete(Guid id);
    }
}
