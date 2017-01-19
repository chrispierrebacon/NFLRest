using System.Data.SqlClient;
using NFLEF;
using System.Collections.Generic;
using System;
using System.Data;
using System.Threading.Tasks;

namespace NFLDAL
{
    public class TeamDal : ITeamDal
    {
        private readonly IDatabaseAccess _databaseAccess;

        public TeamDal(IDatabaseAccess databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }

        public Guid Create(Team team)
        {
            var parameters = new Dictionary<string, object>
            {
                { "Prefix", team.Prefix },
                { "City",  team.City },
                { "NickName", team.NickName },
                { "Conference", team.Conference },
                { "Division", team.Division }
            };

            var outputParameters = new Dictionary<string, SqlDbType>
            {
                { "Id", SqlDbType.UniqueIdentifier }
            };

            var reader = _databaseAccess.NonQuery("CREATE_Team", parameters, outputParameters);
            return reader.ContainsKey("Id") ? Guid.Parse(reader["Id"].ToString()) : Guid.Empty;
        }

        public Team Get(Guid id)
        {
            var parameters = new Dictionary<string, object>
            {
                { "TeamId", id }
            };

            var reader = _databaseAccess.Query("GET_Team", parameters);

            Team team = new Team();
            
            team.TeamId = reader.ContainsKey("TeamId") ? Guid.Parse(reader["TeamId"].ToString()) : Guid.Empty;
            team.Prefix = reader.ContainsKey("Prefix") ? (string)reader["Prefix"] : string.Empty;
            team.City = reader.ContainsKey("City") ? (string)reader["City"] : string.Empty;
            team.NickName = reader.ContainsKey("NickName") ? (string)reader["NickName"] : string.Empty;
            team.Conference = reader.ContainsKey("Conference") ? (string)reader["Conference"] : string.Empty;
            team.Division = reader.ContainsKey("Division") ? (string)reader["Division"] : string.Empty;

            return team;            
        }

        public int Update(Team team)
        {
            var parameters = new Dictionary<string, object>
            {
                { "TeamId", team.TeamId },
                { "City",  team.City },
                { "NickName", team.NickName },
                { "Conference", team.Conference },
                { "Division", team.Division }
            };

            var reader = _databaseAccess.NonQuery("UPDATE_Team", parameters);
            return reader.ContainsKey("ReturnVal") ? (int)reader["ReturnVal"] : -1;
        }

        public int Delete(Guid id)
        {
            var parameters = new Dictionary<string, object>
            {
                { "TeamId", id }
            };

            var reader = _databaseAccess.NonQuery("DELETE_Team", parameters);
            return reader.ContainsKey("ReturnVal") ? (int)reader["ReturnVal"] : -1;
        }
    }
}
