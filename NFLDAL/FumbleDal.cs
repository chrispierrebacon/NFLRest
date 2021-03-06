﻿using NFLCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NFLCommon.DALInterfaces;

namespace NFLDAL
{
    public class FumbleDal : IFumbleDal
    {
        NFLDBEntities entities = new NFLDBEntities();
        private readonly IDatabaseAccess _databaseAccess;

        public FumbleDal(IDatabaseAccess databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }

        public Guid Create(Fumble fumble)
        {
            var parameters = new Dictionary<string, object>
            {
                { "GameId", fumble.GameId },
                { "PlayerId", fumble.PlayerId },
                { "Total", fumble.Total },
                { "Recovered", fumble.Recovered },
                { "TeamRecovered", fumble.TeamRecovered },
                { "Yards", fumble.Yards },
                { "Lost", fumble.Lost },
                { "GsisId", fumble.GsisId }
            };

            var outputParameters = new Dictionary<string, SqlDbType>
            {
                { "Id", SqlDbType.UniqueIdentifier }
            };

            var returnDictionary = _databaseAccess.NonQuery("CREATE_Fumble", parameters, outputParameters);
            return returnDictionary.ContainsKey("Id") ? Guid.Parse(returnDictionary["Id"].ToString()) : Guid.Empty;
        }

        public Fumble Get(Guid Id)
        {
            return entities.Fumbles.FirstOrDefault(i => i.Id.Equals(Id));
        }

        public IEnumerable<Fumble> GetAll()
        {
            return entities.Fumbles;
        }

        public int Update(Fumble obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fumble> Get(string filterJson)
        {
            throw new NotImplementedException();
        }
    }
}
