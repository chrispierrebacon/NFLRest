using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace NFLCommon
{
    public interface IDatabaseAccess
    {
        Dictionary<string, object> Query(string storedProcedure, Dictionary<string, object> parameters);
        Dictionary<string, object> NonQuery(string storedProcedure, Dictionary<string, object> parameters, Dictionary<string, SqlDbType> outputParameters = null);
    }
}