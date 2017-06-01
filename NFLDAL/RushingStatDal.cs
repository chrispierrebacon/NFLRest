using NFLCommon;
using System;
using System.Collections.Generic;
using System.Data;
using NFLCommon.DALInterfaces;

namespace NFLDAL
{
    public class RushingStatDal : IRushingStatDal
    {
        private readonly IDatabaseAccess _databaseAccess;

        public RushingStatDal(IDatabaseAccess databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }

        public Guid Create(RushingStat stat)
        {
            var parameters = new Dictionary<string, object>
            {
                { "GameId", stat.GameId },
                { "PlayerId", stat.PlayerId },
                { "Attempts", stat.Attempts },
                { "Yards", stat.Yards },
                { "Touchdowns", stat.Touchdowns },
                { "Long", stat.Long },
                { "TwoPointAttempts", stat.TwoPointAttempts },
                { "TwoPointsMade", stat.TwoPointsMade },
                { "GsisId", stat.GsisId }
            };

            var outputParameters = new Dictionary<string, SqlDbType>
            {
                { "Id", SqlDbType.UniqueIdentifier }
            };

            var returnDictionary = _databaseAccess.NonQuery("CREATE_RushingStat", parameters, outputParameters);
            return returnDictionary.ContainsKey("Id") ? Guid.Parse(returnDictionary["Id"].ToString()) : Guid.Empty;
        }

        public RushingStat Get(Guid Id)
        {
            throw new NotImplementedException();
        }

        public int Update(RushingStat obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RushingStat> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RushingStat> Get(string filterJson)
        {
            throw new NotImplementedException();
        }
    }
}
