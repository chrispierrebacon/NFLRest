using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using NFLCommon;

namespace NFLDAL
{
    public class DatabaseAccess : IDatabaseAccess
    {
        public Dictionary<string, object> Query(string storedProcedure, Dictionary<string, object> parameters)
        {
            string connString = @"Data Source=(localdb)\ProjectsV12;Initial Catalog=NFLDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (var conn = new SqlConnection(connString))
            {
                using (var command = new SqlCommand(storedProcedure, conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    foreach(string key in parameters.Keys)
                    {
                        command.Parameters.AddWithValue(key, parameters[key]);
                    }

                    conn.Open();

                    var reader = command.ExecuteReader();

                    Dictionary<string, object> returnParams = new Dictionary<string, object>();

                    if (reader.Read())
                    {
                        for(int i =0; i<reader.FieldCount; i++)
                        {
                            returnParams.Add(reader.GetName(i), reader.GetValue(i));
                        }
                    }

                    return returnParams;
                }
            }
        }

        public Dictionary<string, object> NonQuery(string storedProcedure, Dictionary<string, object> parameters, Dictionary<string, SqlDbType> outputParameters = null)
        {
            string connString = @"Data Source=(localdb)\ProjectsV12;Initial Catalog=NFLDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (var conn = new SqlConnection(connString))
            {
                using (var command = new SqlCommand(storedProcedure, conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    foreach (string key in parameters.Keys)
                    {
                        command.Parameters.AddWithValue(key, parameters[key]);
                    };

                    if (outputParameters != null)
                    {
                        foreach (string key in outputParameters.Keys)
                        {
                            command.Parameters.Add(key, outputParameters[key]).Direction = ParameterDirection.Output;
                        }
                    }

                    command.Parameters.Add("ErrorMessage", SqlDbType.NVarChar, 256).Direction = ParameterDirection.Output;
                    command.Parameters.Add("ErrorNumber", SqlDbType.Int).Direction = ParameterDirection.Output;

                    conn.Open();

                    int response = command.ExecuteNonQuery();

                    var returnDictionary = new Dictionary<string, object>();
                    returnDictionary.Add("ReturnVal", response);

                    if (outputParameters != null)
                    {
                        foreach (string key in outputParameters.Keys)
                        {
                            returnDictionary.Add(key, command.Parameters[key].Value);
                        }
                    }

                    return returnDictionary;
                }
            }
        }
    }
}
