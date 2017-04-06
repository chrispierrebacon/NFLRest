using NFLCommon;
using System;
using System.Collections.Generic;
using System.Data;
using NFLCommon.DALInterfaces;

namespace NFLDAL
{
    public class PlayerDal : IPlayerDal
    {
        private readonly IDatabaseAccess _databaseAccess;

        public PlayerDal(IDatabaseAccess databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }

        public Guid Create(Player player)
        {
            var parameters = new Dictionary<string, object>
            {
                { "FirstName", player.FirstName },
                { "LastName", player.LastName },
                { "Position", player.Position.ToString() },
                { "Team", player.Team },
                { "Birthdate", player.Birthdate },
                { "College", player.College },
                { "FullName", player.FullName },
                { "GsisId", player.GsisId },
                { "GsisName", player.GsisName },
                { "Height", player.Height },
                { "Number", player.Number },
                { "ProfileId", player.ProfileId },
                { "ProfileUrl", player.ProfileUrl },
                { "Status", player.Status.ToString() },
                { "Weight", player.Weight },
                { "YearsPro", player.YearsPro }
            };

            var outputParameters = new Dictionary<string, SqlDbType>
            {
                { "Id", SqlDbType.UniqueIdentifier }
            };

            var reader = _databaseAccess.NonQuery("CREATE_Player", parameters, outputParameters);
            return reader.ContainsKey("Id") ? Guid.Parse(reader["Id"].ToString()) : Guid.Empty;
        }

        public Player Get(Guid Id)
        {
            var parameters = new Dictionary<string, object>
            {
                { "PlayerId", Id }
            };

            var reader = _databaseAccess.Query("GET_Players", parameters);

            Player player = new Player();

            player.PlayerId = reader.ContainsKey("PlayerId") ? Guid.Parse(reader["PlayerId"].ToString()) : Guid.Empty;
            player.FirstName = reader.ContainsKey("FirstName") ? reader["FirstName"].ToString() : string.Empty;
            player.LastName = reader.ContainsKey("LastName") ? reader["LastName"].ToString() : string.Empty;
            player.Position = reader.ContainsKey("Position") ? reader["Position"].ToString() : "NONE";
            player.Team = reader.ContainsKey("Team") ? reader["Team"].ToString() : string.Empty;
            player.Birthdate = reader.ContainsKey("Birthdate") ? (DateTime)reader["Birthdate"] : new DateTime(1753, 1, 1);
            player.College = reader.ContainsKey("College") ? reader["College"].ToString() : string.Empty;
            player.FullName = reader.ContainsKey("FullName") ? reader["FullName"].ToString() : string.Empty;
            player.GsisId = reader.ContainsKey("GsisId") ? reader["GsisId"].ToString() : string.Empty;
            player.GsisName = reader.ContainsKey("GsisName") ? reader["GsisName"].ToString() : string.Empty;
            player.Height = reader.ContainsKey("Height") ? (int)reader["Height"] : -1;
            player.Number = reader.ContainsKey("Number") ? (int)reader["Number"] : -1;
            player.ProfileId = reader.ContainsKey("ProfileId") ? (int)reader["ProfileId"] : -1;
            player.ProfileUrl = reader.ContainsKey("ProfileUrl") ? reader["ProfileUrl"].ToString() : string.Empty;
            player.Status = reader.ContainsKey("Status") ? reader["Status"].ToString() : "RET";
            player.ProfileId = reader.ContainsKey("ProfileId") ? (int)reader["ProfileId"] : -1;
            player.Weight = reader.ContainsKey("Weight") ? (int)reader["Weight"] : -1;
            player.YearsPro = reader.ContainsKey("YearsPro") ? (int)reader["YearsPro"] : -1;

            return player;
        }

        public int Update(Player player)
        {
            var parameters = new Dictionary<string, object>
            {
                { "PlayerId", player.Id },
                { "FirstName", player.FirstName },
                { "LastName", player.LastName },
                { "Position", player.Position },
                { "Team", player.Team },
                { "Birthdate", player.Birthdate },
                { "College", player.College },
                { "FullName", player.FullName },
                { "GsisId", player.GsisId },
                { "GsisName", player.GsisName },
                { "Height", player.Height },
                { "Number", player.Number },
                { "ProfileId", player.ProfileId },
                { "ProfileUrl", player.ProfileUrl },
                { "Status", player.Status.ToString() },
                { "Weight", player.Weight },
                { "YearsPro", player.YearsPro }
            };

            var reader = _databaseAccess.NonQuery("UPDATE_Player", parameters);
            return reader.ContainsKey("PlayerId") ? (int)reader["PlayerId"] : -1;
        }

        public int Delete(Guid id)
        {
            var parameters = new Dictionary<string, object>
            {
                { "PlayerId", id }
            };

            var reader = _databaseAccess.NonQuery("DELETE_Player", parameters);
            return reader.ContainsKey("ReturnVal") ? (int)reader["ReturnVal"] : -1;
        }

        public Guid GetPlayerIdByGsisId(string GsisId)
        {
            var parameters = new Dictionary<string, object>
            {
                { "Gsid", GsisId }
            };

            var reader = _databaseAccess.Query("GET_PlayerIdByGsisId", parameters);
            return reader.ContainsKey("PlayerId") ? Guid.Parse(reader["PlayerId"].ToString()) : Guid.Empty;
        }

        public IEnumerable<Player> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
