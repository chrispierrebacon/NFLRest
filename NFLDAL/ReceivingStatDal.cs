using NFLCommon;
using System;
using System.Collections.Generic;
using System.Data;
using NFLCommon.DALInterfaces;

namespace NFLDAL
{
    public class ReceivingStatDal : IReceivingStatDal
    {
        private readonly IDatabaseAccess _databaseAccess;

        public ReceivingStatDal(IDatabaseAccess databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }

        public Guid Create(ReceivingStat stat)
        {
            var parameters = new Dictionary<string, object>
            {
                { "GameId", stat.GameId },
                { "PlayerId", stat.PlayerId },
                { "Receptions", stat.Receptions },
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

            var returnDictionary = _databaseAccess.NonQuery("CREATE_ReceivingStat", parameters, outputParameters);
            return returnDictionary.ContainsKey("Id") ? Guid.Parse(returnDictionary["Id"].ToString()) : Guid.Empty;
        }

        public ReceivingStat Get(Guid Id)
        {
            throw new NotImplementedException();
        }

        public int Update(ReceivingStat obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReceivingStat> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReceivingStat> Get(string filterJson)
        {
            throw new NotImplementedException();
        }
    }
}
