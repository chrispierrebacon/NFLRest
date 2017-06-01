using NFLCommon;
using System;
using System.Collections.Generic;
using System.Data;
using NFLCommon.DALInterfaces;

namespace NFLDAL
{
    public class PuntReturnStatDal : IPuntReturnStatDal
    {
        private readonly IDatabaseAccess _databaseAccess;

        public PuntReturnStatDal(IDatabaseAccess databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }

        public Guid Create(PuntReturnStat stat)
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

            var returnDictionary = _databaseAccess.NonQuery("CREATE_PuntReturnStat", parameters, outputParameters);
            return returnDictionary.ContainsKey("Id") ? Guid.Parse(returnDictionary["Id"].ToString()) : Guid.Empty;
        }

        public PuntReturnStat Get(Guid Id)
        {
            throw new NotImplementedException();
        }

        public int Update(PuntReturnStat obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PuntReturnStat> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PuntReturnStat> Get(string filterJson)
        {
            throw new NotImplementedException();
        }
    }
}
