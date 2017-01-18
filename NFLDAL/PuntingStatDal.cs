using NFLObjects.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLDAL
{
    public class PuntingStatDal : IPuntingStatDal
    {
        private readonly IDatabaseAccess _databaseAccess;

        public PuntingStatDal(IDatabaseAccess databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }

        public Guid Create(PuntingStat stat)
        {
            var parameters = new Dictionary<string, object>
            {
                { "GameId", stat.GameId },
                { "PlayerId", stat.PlayerId },
                { "Punts", stat.Punts },
                { "Yards", stat.Yards },
                { "Average", stat.Average },
                { "InsideTwenty", stat.InsideTwenty },
                { "Long", stat.Long },
                { "GsisId", stat.GsisId }
            };

            var outputParameters = new Dictionary<string, SqlDbType>
            {
                { "Id", SqlDbType.UniqueIdentifier }
            };

            var returnDictionary = _databaseAccess.NonQuery("CREATE_PuntingStat", parameters, outputParameters);
            return returnDictionary.ContainsKey("Id") ? Guid.Parse(returnDictionary["Id"].ToString()) : Guid.Empty;
        }

        public PuntingStat Get(Guid Id)
        {
            throw new NotImplementedException();
        }

        public int Update(PuntingStat obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
