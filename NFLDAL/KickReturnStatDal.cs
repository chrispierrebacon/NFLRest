using NFLObjects.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLDAL
{
    public class KickReturnStatDal : IKickReturnStatDal
    {
        private readonly IDatabaseAccess _databaseAccess;

        public KickReturnStatDal(IDatabaseAccess databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }

        public Guid Create(KickReturnStat stat)
        {
            var parameters = new Dictionary<string, object>
            {
                { "GameId", stat.GameId },
                { "PlayerId", stat.PlayerId },
                { "Returns", stat.Returns },
                { "Average", stat.Average },
                { "Touchdowns", stat.Touchdowns },
                { "Long", stat.Long },
                { "LongTouchdown", stat.LongTouchdown },
                { "GsisId", stat.GsisId }
            };

            var outputParameters = new Dictionary<string, SqlDbType>
            {
                { "Id", SqlDbType.UniqueIdentifier }
            };

            var reader = _databaseAccess.NonQuery("CREATE_KickReturnStat", parameters, outputParameters);
            return reader.ContainsKey("Id") ? Guid.Parse(reader["Id"].ToString()) : Guid.Empty;
        }

        public KickReturnStat Get(Guid Id)
        {
            throw new NotImplementedException();
        }

        public int Update(KickReturnStat obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
