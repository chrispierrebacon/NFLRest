using NFLEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLDAL
{
    public class PassingStatDal : IPassingStatDal
    {
        private readonly IDatabaseAccess _databaseAccess;

        public PassingStatDal(IDatabaseAccess databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }

        public Guid Create(PassingStat stat)
        {
            var parameters = new Dictionary<string, object>
            {
                { "GameId", stat.GameId },
                { "PlayerId", stat.PlayerId },
                { "Attempts", stat.Attempts },
                { "Completions", stat.Completions },
                { "Yards", stat.Yards },
                { "Touchdowns", stat.Touchdowns },
                { "Interceptions", stat.Interceptions },
                { "TwoPointAttempts", stat.TwoPointAttempts },
                { "TwoPointMakes", stat.TwoPointMakes },
                { "GsisId", stat.GsisId }
            };

            var outputParameters = new Dictionary<string, SqlDbType>
            {
                { "Id", SqlDbType.UniqueIdentifier }
            };

            var reader = _databaseAccess.NonQuery("CREATE_PassingStat", parameters, outputParameters);
            return reader.ContainsKey("Id") ? Guid.Parse(reader["Id"].ToString()) : Guid.Empty;
        }

        public PassingStat Get(Guid Id)
        {
            throw new NotImplementedException();
        }

        public int Update(PassingStat obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
