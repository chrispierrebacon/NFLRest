using NFLCommon;
using System;
using System.Collections.Generic;
using System.Data;
using NFLCommon.DALInterfaces;
using System.Linq;
using Newtonsoft.Json;

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
                { "Season", game.Season },
                { "Eid", game.Eid },
                { "GameKey", game.GameKey },
                { "Week", game.Week },
                { "HTScoreFirstQtr", game.HTScoreFirstQtr },
                { "HTScoreSecondQtr", game.HTScoreSecondQtr },
                { "HTScoreThirdQtr", game.HTScoreThirdQtr },
                { "HTScoreFourthQtr", game.HTScoreFourthQtr },
                { "HTScoreOT", game.HTScoreOT },
                { "HTScoreFinal", game.HTScoreFinal },
                { "ATScoreFirstQtr", game.ATScoreFirstQtr },
                { "ATScoreSecondQtr", game.ATScoreSecondQtr },
                { "ATScoreThirdQtr", game.ATScoreThirdQtr },
                { "ATScoreFourthQtr", game.ATScoreFourthQtr },
                { "ATScoreOT", game.ATScoreOT },
                { "ATScoreFinal", game.ATScoreFinal },
                { "NeutralField", game.NeutralField }
            };

            var outputParameters = new Dictionary<string, SqlDbType>
            {
                { "Id", SqlDbType.UniqueIdentifier }
            };

            var returnDictionary = _databaseAccess.NonQuery("CREATE_Game", parameters, outputParameters);
            return returnDictionary.ContainsKey("Id") ? Guid.Parse(returnDictionary["Id"].ToString()) : Guid.Empty;
        }

        public IEnumerable<Game> Get(string filterString)
        {
            GamesFilter filter = JsonConvert.DeserializeObject<GamesFilter>(filterString);

            var parameters = new Dictionary<string, object>
            {
                { "GameId", filter.Id },
            };

            var reader =  _databaseAccess.Query("GET_Games", parameters);

            List<Game> games = new List<Game>();

            foreach(var something in reader)
            {
                Game game = new Game();

                game.GameId = reader.ContainsKey("GameId") ? Guid.Parse(reader["GameId"].ToString()) : Guid.Empty;
                game.HomeTeam = reader.ContainsKey("HomeTeam") ? reader["HomeTeam"].ToString() : string.Empty;
                game.AwayTeam = reader.ContainsKey("AwayTeam") ? reader["AwayTeam"].ToString() : string.Empty;
                game.DateTime = reader.ContainsKey("DateTime") ? (DateTime)reader["DateTime"] : new DateTime(1753, 1, 1);
                game.SeasonType = reader.ContainsKey("SeasonType") ? reader["SeasonType"].ToString() : "NONE";
                game.Eid = reader.ContainsKey("Eid") ? (int)reader["Eid"] : -1;
                game.GameKey = reader.ContainsKey("GameKey") ? (int)reader["GameKey"] : -1;
                game.Week = reader.ContainsKey("Week") ? (int)reader["Week"] : -1;
                game.HTScoreFirstQtr = reader.ContainsKey("HTScoreFirstQtr") ? (int)reader["HTScoreFirstQtr"] : -1;
                game.HTScoreSecondQtr = reader.ContainsKey("HTScoreSecondQtr") ? (int)reader["HTScoreSecondQtr"] : -1;
                game.HTScoreThirdQtr = reader.ContainsKey("HTScoreThirdQtr") ? (int)reader["HTScoreThirdQtr"] : -1;
                game.HTScoreFourthQtr = reader.ContainsKey("HTScoreFourthQtr") ? (int)reader["HTScoreFourthQtr"] : -1;
                game.HTScoreOT = reader.ContainsKey("HTScoreOT") ? (int)reader["HTScoreOT"] : -1;
                game.HTScoreFinal = reader.ContainsKey("HTScoreFinal") ? (int)reader["HTScoreFinal"] : -1;
                game.ATScoreFirstQtr = reader.ContainsKey("ATScoreFirstQtr") ? (int)reader["ATScoreFirstQtr"] : -1;
                game.ATScoreSecondQtr = reader.ContainsKey("ATScoreSecondQtr") ? (int)reader["ATScoreSecondQtr"] : -1;
                game.ATScoreThirdQtr = reader.ContainsKey("ATScoreThirdQtr") ? (int)reader["ATScoreThirdQtr"] : -1;
                game.ATScoreFourthQtr = reader.ContainsKey("ATScoreFourthQtr") ? (int)reader["ATScoreFourthQtr"] : -1;
                game.ATScoreOT = reader.ContainsKey("ATScoreOT") ? (int)reader["ATScoreOT"] : -1;
                game.ATScoreFinal = reader.ContainsKey("ATScoreFinal") ? (int)reader["ATScoreFinal"] : -1;
                game.NeutralField = reader.ContainsKey("NeutralField") ? (bool)reader["NeutralField"] : false;

                games.Add(game);
            }


            return games;
        }

        public Guid GetGameByEid(long Eid)
        {
            var parameters = new Dictionary<string, object>
            {
                { "Eid", Eid }
            };

            var reader = _databaseAccess.Query("GET_GameIdByEid", parameters);
            return reader.ContainsKey("GameId") ? Guid.Parse(reader["GameId"].ToString()) : Guid.Empty;
        }

        public IEnumerable<Game> GetAll()
        {
            throw new NotImplementedException();
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
                { "Season", game.Season },
                { "Eid", game.Eid },
                { "GameKey", game.GameKey },
                { "Week", game.Week },
                { "HTScoreFirstQtr", game.HTScoreFirstQtr },
                { "HTScoreSecondQtr", game.HTScoreSecondQtr },
                { "HTScoreThirdQtr", game.HTScoreThirdQtr },
                { "HTScoreFourthQtr", game.HTScoreFourthQtr },
                { "HTScoreOT", game.HTScoreOT },
                { "HTScoreFinal", game.HTScoreFinal },
                { "ATScoreFirstQtr", game.ATScoreFirstQtr },
                { "ATScoreSecondQtr", game.ATScoreSecondQtr },
                { "ATScoreThirdQtr", game.ATScoreThirdQtr },
                { "ATScoreFourthQtr", game.ATScoreFourthQtr },
                { "ATScoreOT", game.ATScoreOT },
                { "ATScoreFinal", game.ATScoreFinal },
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

        public int UpdateScore(Game game)
        {
            throw new NotImplementedException();
        }
    }

    public class GamesFilter
    {
        public Guid Id { get; set; } = Guid.Empty;
        public bool PreSeasonOn { get; set; } = false;
        public bool PostSeasonOn { get; set; } = true;
        public bool RegSeasonOn { get; set; } = true;
        public int Season { get; set; }
        // When the nfl was founded. It would be cool to have all this data
        public DateTime StartDate { get; set; } = new DateTime(1920, 8, 20);
        // Some time far in the future
        public DateTime EndDate { get; set; } = new DateTime(2100, 1, 1);
    }
}
