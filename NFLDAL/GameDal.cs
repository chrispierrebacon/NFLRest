using NFLEF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using System.Data;

namespace NFLDAL
{
    public class GameDal : IGameDal
    {
        private readonly IDatabaseAccess _databaseAccess;

        public GameDal(IDatabaseAccess databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }

        public Guid Create(Game game)
        {
            var parameters = new Dictionary<string, object>
            {
                { "HomeTeam", game.HomeTeam },
                { "AwayTeam", game.AwayTeam },
                { "DateTime", game.DateTime },
                { "SeasonType", game.SeasonType },
                { "Eid", game.Eid },
                { "GameKey", game.GameKey },
                { "Week", game.Week },
                { "WT", game.WT },
                { "LT", game.LT },
                { "WTScoreFirstQtr", game.WTScoreFirstQtr },
                { "WTScoreSecondQtr", game.WTScoreSecondQtr },
                { "WTScoreThirdQtr", game.WTScoreThirdQtr },
                { "WTScoreFourthQtr", game.WTScoreFourthQtr },
                { "WTScoreOT", game.WTScoreOT },
                { "WTScoreFinal", game.WTScoreFinal },
                { "LTScoreFirstQtr", game.LTScoreFirstQtr },
                { "LTScoreSecondQtr", game.LTScoreSecondQtr },
                { "LTScoreThirdQtr", game.LTScoreThirdQtr },
                { "LTScoreFourthQtr", game.LTScoreFourthQtr },
                { "LTScoreOT", game.LTScoreOT },
                { "LTScoreFinal", game.LTScoreFinal },
                { "NeutralField", game.NeutralField }
            };

            var outputParameters = new Dictionary<string, SqlDbType>
            {
                { "Id", SqlDbType.UniqueIdentifier }
            };

            var returnDictionary = _databaseAccess.NonQuery("CREATE_Game", parameters, outputParameters);
            return returnDictionary.ContainsKey("Id") ? Guid.Parse(returnDictionary["Id"].ToString()) : Guid.Empty;
        }

        public Game Get(Guid gameId)
        {
            var parameters = new Dictionary<string, object>
            {
                { "GameId", gameId }
            };

            var reader =  _databaseAccess.Query("GET_Game", parameters);

            Game game = new Game();
            game.GameId = reader.ContainsKey("GameId") ? Guid.Parse(reader["GameId"].ToString()) : Guid.Empty;
            game.HomeTeam = reader.ContainsKey("HomeTeam") ? reader["HomeTeam"].ToString() : string.Empty;
            game.AwayTeam = reader.ContainsKey("AwayTeam") ? reader["AwayTeam"].ToString() : string.Empty;
            game.DateTime = reader.ContainsKey("DateTime") ? (DateTime)reader["DateTime"] : new DateTime(1753, 1, 1);
            game.SeasonType = reader.ContainsKey("SeasonType") ? reader["SeasonType"].ToString() : "NONE";
            game.Eid = reader.ContainsKey("Eid") ? (int)reader["Eid"] : -1;
            game.GameKey = reader.ContainsKey("GameKey") ? (int)reader["GameKey"] : -1;
            game.Week = reader.ContainsKey("Week") ? (int)reader["Week"] : -1;
            game.WT = reader.ContainsKey("WT") ? reader["WT"].ToString() : string.Empty;
            game.LT = reader.ContainsKey("LT") ? reader["LT"].ToString() : string.Empty;
            game.WTScoreFirstQtr = reader.ContainsKey("WTScoreFirstQtr") ? (int)reader["WTScoreFirstQtr"] : -1;
            game.WTScoreSecondQtr = reader.ContainsKey("WTScoreSecondQtr") ? (int)reader["WTScoreSecondQtr"] : -1;
            game.WTScoreThirdQtr = reader.ContainsKey("WTScoreThirdQtr") ? (int)reader["WTScoreThirdQtr"] : -1;
            game.WTScoreFourthQtr = reader.ContainsKey("WTScoreFourthQtr") ? (int)reader["WTScoreFourthQtr"] : -1;
            game.WTScoreOT = reader.ContainsKey("WTScoreOT") ? (int)reader["WTScoreOT"] : -1;
            game.WTScoreFinal = reader.ContainsKey("WTScoreFinal") ? (int)reader["WTScoreFinal"] : -1;
            game.LTScoreFirstQtr = reader.ContainsKey("LTScoreFirstQtr") ? (int)reader["LTScoreFirstQtr"] : -1;
            game.LTScoreSecondQtr = reader.ContainsKey("LTScoreSecondQtr") ? (int)reader["LTScoreSecondQtr"] : -1;
            game.LTScoreThirdQtr = reader.ContainsKey("LTScoreThirdQtr") ? (int)reader["LTScoreThirdQtr"] : -1;
            game.LTScoreFourthQtr = reader.ContainsKey("LTScoreFourthQtr") ? (int)reader["LTScoreFourthQtr"] : -1;
            game.LTScoreOT = reader.ContainsKey("LTScoreOT") ? (int)reader["LTScoreOT"] : -1;
            game.LTScoreFinal = reader.ContainsKey("LTScoreFinal") ? (int)reader["LTScoreFinal"] : -1;
            game.NeutralField = reader.ContainsKey("NeutralField") ? (bool)reader["NeutralField"] : false;

            return game;
        }

        public Guid GetGameIdByEid(long Eid)
        {
            var parameters = new Dictionary<string, object>
            {
                { "Eid", Eid }
            };

            var reader = _databaseAccess.Query("GET_GameIdByEid", parameters);
            return reader.ContainsKey("GameId") ? Guid.Parse(reader["GameId"].ToString()) : Guid.Empty;
        }

        public int Update(Game game)
        {
            var parameters = new Dictionary<string, object>
            {
                { "GameId", game.GameId },
                { "HomeTeam", game.HomeTeam },
                { "AwayTeam", game.AwayTeam },
                { "DateTime", game.DateTime },
                { "SeasonType", game.SeasonType },
                { "Eid", game.Eid },
                { "GameKey", game.GameKey },
                { "Week", game.Week },
                { "WT", game.WT },
                { "LT", game.LT },
                { "WTScoreFirstQtr", game.WTScoreFirstQtr },
                { "WTScoreSecondQtr", game.WTScoreSecondQtr },
                { "WTScoreThirdQtr", game.WTScoreThirdQtr },
                { "WTScoreFourthQtr", game.WTScoreFourthQtr },
                { "WTScoreOT", game.WTScoreOT },
                { "WTScoreFinal", game.WTScoreFinal },
                { "LTScoreFirstQtr", game.LTScoreFirstQtr },
                { "LTScoreSecondQtr", game.LTScoreSecondQtr },
                { "LTScoreThirdQtr", game.LTScoreThirdQtr },
                { "LTScoreFourthQtr", game.LTScoreFourthQtr },
                { "LTScoreOT", game.LTScoreOT },
                { "LTScoreFinal", game.LTScoreFinal },
                { "NeutralField", game.NeutralField }
            };
            
            var reader = _databaseAccess.NonQuery("UPDATE_Game", parameters);
            return reader.ContainsKey("ReturnVal") ? (int)reader["ReturnVal"] : 0;
        }

        public int Delete(Guid gameId)
        {
            var parameters = new Dictionary<string, object>
            {
                { "GameId", gameId }
            };

            var reader = _databaseAccess.NonQuery("DELETE_Game", parameters);
            return reader.ContainsKey("ReturnVal") ? (int)reader["ReturnVal"] : 0;
        }
    }
}
