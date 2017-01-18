﻿using NFLObjects.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLDAL
{
    public class DefensiveStatDal : IDefensiveStatDal
    {
        private readonly IDatabaseAccess _databaseAccess;

        public DefensiveStatDal(IDatabaseAccess databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }

        public Guid Create(DefensiveStat stat)
        {
            var parameters = new Dictionary<string, object>
            {
                { "GameId", stat.GameId },
                { "PlayerId", stat.PlayerId },
                { "Tackles", stat.Tackles },
                { "Assists", stat.Assists },
                { "Sacks", stat.Sacks },
                { "Interceptions", stat.Interceptions },
                { "ForcedFumbles", stat.ForcedFumbles },
                { "GsisId", stat.GsisId }
            };

            var outputParameters = new Dictionary<string, SqlDbType>
            {
                { "Id", SqlDbType.UniqueIdentifier }
            };

            var returnDictionary = _databaseAccess.NonQuery("CREATE_DefensiveStat", parameters, outputParameters);
            return returnDictionary.ContainsKey("Id") ? Guid.Parse(returnDictionary["Id"].ToString()) : Guid.Empty;
        }

        public DefensiveStat Get(Guid Id)
        {
            throw new NotImplementedException();
        }

        public int Update(DefensiveStat obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid Id)
        {
            var parameters = new Dictionary<string, object>
            {
                { "DefensiveStatId", Id }
            };

            var outputParameters = new Dictionary<string, SqlDbType>
            {
                { "Id", SqlDbType.UniqueIdentifier }
            };

            var returnDictionary = _databaseAccess.NonQuery("DELETE_DefensiveStat", parameters, outputParameters);
            return returnDictionary.ContainsKey("ReturnVal") ? (int)returnDictionary["ReturnVal"] : 0;
        }
    }
}
