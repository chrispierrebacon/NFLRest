using NFLCommon;
using System;
using System.Collections.Generic;
using System.Data;
using NFLCommon.DALInterfaces;

namespace NFLDAL
{
    public class KickingStatDal : IKickingStatDal
    {
        private readonly IDatabaseAccess _databaseAccess;

        public KickingStatDal(IDatabaseAccess databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }

        public Guid Create(KickingStat stat)
        {
            var parameters = new Dictionary<string, object>
            {
                { "GameId", stat.GameId },
                { "PlayerId", stat.PlayerId },
                { "FieldGoalsMade", stat.FieldGoalsMade },
                { "FieldGoalsAttempted", stat.FieldGoalsAttempted },
                { "Yards", stat.Yards },
                { "TotalPoints", stat.TotalPoints },
                { "ExtraPointsMade", stat.ExtraPointsMade },
                { "ExtraPointsMissed", stat.ExtraPointsMissed },
                { "ExtraPointsAttempted", stat.ExtraPointsAttempted },
                { "ExtraPointsBlocked", stat.ExtraPointsBlocked },
                { "ExtraPointsTotal", stat.ExtraPointsTotal },
                { "GsisId", stat.GsisId }
            };

            var outputParameters = new Dictionary<string, SqlDbType>
            {
                { "Id", SqlDbType.UniqueIdentifier }
            };

            var reader = _databaseAccess.NonQuery("CREATE_KickingStat", parameters, outputParameters);
            return reader.ContainsKey("Id") ? Guid.Parse(reader["Id"].ToString()) : Guid.Empty;
        }

        public KickingStat Get(Guid Id)
        {
            throw new NotImplementedException();
        }

        public int Update(KickingStat obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KickingStat> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KickingStat> Get(string filterJson)
        {
            throw new NotImplementedException();
        }
    }
}
