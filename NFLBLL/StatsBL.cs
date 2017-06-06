using NFLCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NFLCommon.DALInterfaces;

namespace NFLBLL
{
    public class StatsBL
    {
        NFLDBEntities entities = new NFLDBEntities();
        private readonly IGameDal _gameDal;
        private readonly IFumbleDal _fumbleDal;
        private readonly IKickingStatDal _kickingStatDal;
        private readonly IKickReturnStatDal _kickReturnStatDal;
        private readonly IPassingStatDal _passingStatDal;
        private readonly IPuntingStatDal _puntingStatDal;
        private readonly IPuntReturnStatDal _puntReturnStatDal;
        private readonly IReceivingStatDal _receivingStatDal;
        private readonly IRushingStatDal _rushingStatDal;
        private readonly IDefensiveStatDal _defensiveStatDal;
        private readonly IPlayerDal _playerDal;

        public StatsBL(IGameDal gameDal, IFumbleDal fumbleDal, IKickingStatDal kickingStatDal, IKickReturnStatDal kickReturnStatDal, IPassingStatDal passingStatDal,
                       IPuntingStatDal puntingStatDal, IPuntReturnStatDal puntReturnStatDal, IReceivingStatDal receivingStatDal, IRushingStatDal rushingStatDal,
                       IDefensiveStatDal defensiveStatDal, IPlayerDal playerDal)
        {
            _gameDal = gameDal;
            _fumbleDal = fumbleDal;
            _kickingStatDal = kickingStatDal;
            _kickReturnStatDal = kickReturnStatDal;
            _passingStatDal = passingStatDal;
            _puntingStatDal = puntingStatDal;
            _puntReturnStatDal = puntReturnStatDal;
            _receivingStatDal = receivingStatDal;
            _rushingStatDal = rushingStatDal;
            _defensiveStatDal = defensiveStatDal;
            _playerDal = playerDal;
        }

        public int Create(GameStats request)
        {
            // Fetch GameId
            Guid gameId = _gameDal.GetGameIdByEid(request.Game.Eid);
            if (gameId.Equals(Guid.Empty))
            {
                return 0;
            }

            // Update Game
            request.Game.GameId = gameId;
            int gameResp = _gameDal.UpdateScore(request.Game);

            List<Task> tasks = new List<Task>();

            foreach(var fumble in request.Fumbles)
            {
                Task t = Task.Run(() =>
                {
                    Guid playerId = _playerDal.GetPlayerIdByGsisId(fumble.GsisId);
                    if (!playerId.Equals(Guid.Empty))
                    {
                        fumble.PlayerId = playerId;
                        fumble.GameId = gameId;
                        Guid fumbleResp = _fumbleDal.Create(fumble);
                    }                    
                });
                tasks.Add(t);
            }

            foreach(var kickingStat in request.KickingStats)
            {
                Task t = Task.Run(() =>
                {
                    Guid playerId = _playerDal.GetPlayerIdByGsisId(kickingStat.GsisId);
                    if (!playerId.Equals(Guid.Empty))
                    {
                        kickingStat.PlayerId = playerId;
                        kickingStat.GameId = gameId;
                        Guid kickingStatResp = _kickingStatDal.Create(kickingStat); 
                    }
                });
                tasks.Add(t);
            }

            foreach (var kickReturnStat in request.KickReturnStats)
            {
                Task t = Task.Run(() =>
                {
                    Guid playerId = _playerDal.GetPlayerIdByGsisId(kickReturnStat.GsisId);
                    if (!playerId.Equals(Guid.Empty))
                    {
                        kickReturnStat.PlayerId = playerId;
                        kickReturnStat.GameId = gameId;
                        Guid kickingStatResp = _kickReturnStatDal.Create(kickReturnStat); 
                    }
                });
                tasks.Add(t);
            }

            foreach (var passingStat in request.PassingStats)
            {
                Task t = Task.Run(() =>
                {
                    Guid playerId = _playerDal.GetPlayerIdByGsisId(passingStat.GsisId);
                    if (!playerId.Equals(Guid.Empty))
                    {
                        passingStat.PlayerId = playerId;
                        passingStat.GameId = gameId;
                        Guid kickingStatResp = _passingStatDal.Create(passingStat); 
                    }
                });
                tasks.Add(t);
            }

            foreach (var puntingStat in request.PuntingStats)
            {
                Task t = Task.Run(() =>
                {
                    Guid playerId = _playerDal.GetPlayerIdByGsisId(puntingStat.GsisId);
                    if (!playerId.Equals(Guid.Empty))
                    {
                        puntingStat.PlayerId = playerId;
                        puntingStat.GameId = gameId;
                        Guid kickingStatResp = _puntingStatDal.Create(puntingStat); 
                    }
                });
                tasks.Add(t);
            }

            foreach (var puntReturnStat in request.PuntReturnStats)
            {
                Task t = Task.Run(() =>
                {
                    Guid playerId = _playerDal.GetPlayerIdByGsisId(puntReturnStat.GsisId);
                    if (!playerId.Equals(Guid.Empty))
                    {
                        puntReturnStat.PlayerId = playerId;
                        puntReturnStat.GameId = gameId;
                        Guid kickingStatResp = _puntReturnStatDal.Create(puntReturnStat); 
                    }
                });
                tasks.Add(t);
            }

            foreach (var receivingStat in request.ReceivingStats)
            {
                Task t = Task.Run(() =>
                {
                    Guid playerId = _playerDal.GetPlayerIdByGsisId(receivingStat.GsisId);
                    if (!playerId.Equals(Guid.Empty))
                    {
                        receivingStat.PlayerId = playerId;
                        receivingStat.GameId = gameId;
                        Guid kickingStatResp = _receivingStatDal.Create(receivingStat); 
                    }
                });
                tasks.Add(t);
            }

            foreach (var rushingStat in request.RushingStats)
            {
                Task t = Task.Run(() =>
                {
                    Guid playerId = _playerDal.GetPlayerIdByGsisId(rushingStat.GsisId);
                    if (!playerId.Equals(Guid.Empty))
                    {
                        rushingStat.PlayerId = playerId;
                        rushingStat.GameId = gameId;
                        Guid kickingStatResp = _rushingStatDal.Create(rushingStat); 
                    }
                });
                tasks.Add(t);
            }

            foreach (var defensiveStat in request.DefensiveStats)
            {
                Task t = Task.Run(() =>
                {
                    Guid playerId = _playerDal.GetPlayerIdByGsisId(defensiveStat.GsisId);
                    if (!playerId.Equals(Guid.Empty))
                    {
                        defensiveStat.PlayerId = playerId;
                        defensiveStat.GameId = gameId;
                        Guid kickingStatResp = _defensiveStatDal.Create(defensiveStat); 
                    }
                });
                tasks.Add(t);
            }

            Task.WaitAll(tasks.ToArray());

            return 0;
        }

        public double GetOffensiveFantasyPointsForPlayerByDateRange(Guid playerId, DateTime startDate, DateTime endDate, bool PPR)
        {
            string[] seasonTypes = { "REG", "POST" };
            var gameIds = entities.Games.Where(i => i.DateTime >= startDate && i.DateTime <= endDate && seasonTypes.Contains(i.SeasonType)).Select(j => j.GameId).ToList();

            return GetOffensiveFantasyPointsByPlayerIdAndGameIds(playerId, gameIds, PPR);
        }

        public double GetOffensiveFantasyPointsByPlayerIdAndGameIds(Guid playerId, List<Guid> gameIds, bool PPR)
        {
            double points = 0;
            
            var fumbles = entities.Fumbles.Where(i => gameIds.Contains(i.GameId) && i.PlayerId == playerId);
            if (fumbles.Any())
            {
                points += fumbles.Sum(i => i.Lost) * -2;
            }

            var kickingStats = entities.KickingStats.Where(i => gameIds.Contains(i.GameId) && i.PlayerId == playerId);
            if (kickingStats.Any())
            {
                points +=
                         (kickingStats.Sum(i => i.FieldGoalsMade) * 3) + (kickingStats.Sum(i => i.FieldGoalsAttempted - i.FieldGoalsMade) * -1)
                       + (kickingStats.Sum(i => i.ExtraPointsMade) * 1) + (kickingStats.Sum(i => i.ExtraPointsTotal - i.ExtraPointsMade) * -1);
            }

            var passingStats = entities.PassingStats.Where(i => gameIds.Contains(i.GameId) && i.PlayerId == playerId);
            if (passingStats.Any())
            {
                points += passingStats.Sum(i => i.Yards) * .04;
                points += passingStats.Sum(i => i.Touchdowns) * 4;
                points += passingStats.Sum(i => i.Interceptions) * -2;
                points += passingStats.Sum(i => i.TwoPointMakes) * 2;
            }

            var receivingStats = entities.ReceivingStats.Where(i => gameIds.Contains(i.GameId) && i.PlayerId == playerId);
            if (receivingStats.Any())
            {
                points +=
                         (receivingStats.Sum(i => i.Yards) * .1) + (receivingStats.Sum(i => i.Touchdowns) * 6) + receivingStats.Sum(i => i.TwoPointsMade) * 2;

                if (PPR)
                {
                    points += receivingStats.Sum(i => i.Receptions);
                }
            }

            var rushingStats = entities.RushingStats.Where(i => gameIds.Contains(i.GameId) && i.PlayerId == playerId);
            if (rushingStats.Any())
            {
                points +=
                         (rushingStats.Sum(i => i.Yards) * .1) + (rushingStats.Sum(i => i.Touchdowns) * 6) + (rushingStats.Sum(i => i.TwoPointsMade) * 2);
            }
            return points;
        }

        public int GetDefensiveFantasyPointsByDateRange(string teamName, DateTime startDate, DateTime endDate)
        {
            string[] seasonTypes = { "REG", "POST" };
            var gameIds = entities.Games.Where(i => i.DateTime >= startDate && i.DateTime <= endDate && seasonTypes.Contains(i.SeasonType)).Select(j => j.GameId).ToList();

            return GetDefensiveFantasyPointsByTeamNameAndGameId(teamName, gameIds);
        }

        public int GetDefensiveFantasyPointsByTeamNameAndGameId(string teamName, List<Guid> gameIds)
        {
            int fantasyPoints = 0;

            foreach(var gameId in gameIds)
            {
                Game game = entities.Games.Where(i => i.GameId == gameId).FirstOrDefault();
                bool isHT = game.HomeTeam.Equals(teamName);
                GameStats teamGameStats = GetGameStatsByIdsAndTeamName(gameId, teamName);
                string oppTeam = isHT ? game.AwayTeam : game.HomeTeam;
                GameStats oppGameStats = GetGameStatsByIdsAndTeamName(gameId, oppTeam);

                // Sack points
                fantasyPoints += teamGameStats.DefensiveStats.Sum(i => i.Sacks) * 1;
                // Int points
                fantasyPoints += teamGameStats.DefensiveStats.Sum(i => i.Interceptions) * 2;

                // D/STPoints = TotalPoints - (OffensivePoints + Kicking points)
                // This includes safeties
                fantasyPoints += isHT ? teamGameStats.Game.HTScoreFinal : teamGameStats.Game.ATScoreFinal;
                fantasyPoints -= GetOffensivePoints(teamGameStats);
                fantasyPoints += GetPointsAllowedFantasyPoints(isHT ? game.HTScoreFinal : game.ATScoreFinal);
            }

            return fantasyPoints;
        }

        public GameStats GetGameStatsByIdsAndTeamName(Guid gameId, string teamName = "", GameStatsFilter filter = null)
        {
            if(filter == null)
            {
                filter = new GameStatsFilter();
            }

            GameStats gameStats = new GameStats();
            gameStats.Game = entities.Games.Where(i => i.GameId.Equals(gameId)).FirstOrDefault();

            if (filter.defensiveStatsOn)
            {
                var defensiveStats = entities.DefensiveStats.Where(i => i.GameId.Equals(gameId));
                gameStats.DefensiveStats = string.IsNullOrEmpty(teamName) ? defensiveStats.ToList() : defensiveStats.Where(i => i.Player.Team.Equals(teamName)).ToList();
            }

            if (filter.fumblesOn)
            {
                var fumbles = entities.Fumbles.Where(i => i.GameId.Equals(gameId));
                gameStats.Fumbles = string.IsNullOrEmpty(teamName) ? fumbles.ToList() : fumbles.Where(i => i.Player.Team.Equals(teamName)).ToList();
            }

            if (filter.kickingStatsOn)
            {
                var kickingStats = entities.KickingStats.Where(i => i.GameId.Equals(gameId));
                gameStats.KickingStats = string.IsNullOrEmpty(teamName) ? kickingStats.ToList() : kickingStats.Where(i => i.Player.Team.Equals(teamName)).ToList();

                var puntingStats = entities.PuntingStats.Where(i => i.GameId.Equals(gameId));
                gameStats.PuntingStats = string.IsNullOrEmpty(teamName) ? puntingStats.ToList() : puntingStats.Where(i => i.Player.Team.Equals(teamName)).ToList();
            }

            if (filter.returnStatsOn)
            {
                var kickReturnStats = entities.KickReturnStats.Where(i => i.GameId.Equals(gameId));
                gameStats.KickReturnStats = string.IsNullOrEmpty(teamName) ? kickReturnStats.ToList() : kickReturnStats.Where(i => i.Player.Team.Equals(teamName)).ToList();

                var puntReturnStats = entities.PuntReturnStats.Where(i => i.GameId.Equals(gameId));
                gameStats.PuntReturnStats = string.IsNullOrEmpty(teamName) ? puntReturnStats.ToList() : puntReturnStats.Where(i => i.Player.Team.Equals(teamName)).ToList();
            }

            if (filter.passingStatsOn)
            {
                var passingStats = entities.PassingStats.Where(i => i.GameId.Equals(gameId));
                gameStats.PassingStats = string.IsNullOrEmpty(teamName) ? passingStats.ToList() : passingStats.Where(i => i.Player.Team.Equals(teamName)).ToList();
            }

            if (filter.receivingStatsOn)
            {
                var receivingStats = entities.ReceivingStats.Where(i => i.GameId.Equals(gameId));
                gameStats.ReceivingStats = string.IsNullOrEmpty(teamName) ? receivingStats.ToList() : receivingStats.Where(i => i.Player.Team.Equals(teamName)).ToList();
            }

            if (filter.rushingStatsOn)
            {
                var rushingStats = entities.RushingStats.Where(i => i.GameId.Equals(gameId));
                gameStats.RushingStats = string.IsNullOrEmpty(teamName) ? rushingStats.ToList() : rushingStats.Where(i => i.Player.Team.Equals(teamName)).ToList();
            }

            return gameStats;
        }

        public int GetOffensivePoints(GameStats gameStats)
        {
            return gameStats.ReceivingStats.Sum(i => i.Touchdowns) * 6
                 + gameStats.RushingStats.Sum(i => i.Touchdowns) * 6
                 + gameStats.KickingStats.Sum(i => i.ExtraPointsMade) * 1
                 + gameStats.KickingStats.Sum(i => i.FieldGoalsMade) * 3;
        }

        // TODO: This should disregard defensive scores (and acquire currency), but we will need to get them first.
        public int GetPointsAllowedFantasyPoints(int pointsAllowed)
        {
            int fantasyPointsAllowed = 10;
            int y = (pointsAllowed - ((pointsAllowed / 6) + 1)) / 6;
            y += pointsAllowed / 6 == pointsAllowed % 6 ? 1 : 0;

            if (pointsAllowed != 0)
            {
                switch (y)
                {
                    case 0:
                        fantasyPointsAllowed = 7;
                        break;
                    case 1:
                        fantasyPointsAllowed = 4;
                        break;
                    case 2:
                        fantasyPointsAllowed = 1;
                        break;
                    case 3:
                        fantasyPointsAllowed = 0;
                        break;
                    case 4:
                        fantasyPointsAllowed = -1;
                        break;
                    default:
                        fantasyPointsAllowed = -4;
                        break;
                }
            }
            return fantasyPointsAllowed;
        }

        // Last 4 games * .3
        // Last 16 games * .2
        // Last performance against upcoming team *.5
        // Injuries
        // Weather
        // Other specific to position

        public double GetQBProjectedValue(Guid playerId)
        {
            throw new NotImplementedException();

        }

        public double GetRBProjectedValue(Guid playerId)
        {
            // Dunno about extenuating.
            throw new NotImplementedException();

        }

        public double GetWRProjectedValue(Guid playerId)
        {
            // Dunno about extenuating. 
            throw new NotImplementedException();

        }

        public double GetDefenseProjectedValue(Guid playerId)
        {
            // Dunno about extenuating. 
            throw new NotImplementedException();

        }

        public double GetQBValueForOneGame(Guid playerId, Guid gameId)
        {
            // Passing Yards * .3 
            // Ints * .2 can't be throwing the ball to the other team
            // TEAM TDs *.1 // The amount that a team gets the ball in the end zone matters more than whether or not it's a passing TD.
            // TDs *.1
            // The above ratio matters too. I want to take all 3 into account.
            // Big plays matter too.
            // How close is the game per quarter *.1 Garbage time points count too. We'll need to find a garbage time sweet spot. <21 points?
            throw new NotImplementedException();
        }

        public double GetRBValueForOneGame(Guid playerId, Guid gameId)
        {
            // Touches *.3
            // Yards * .3 
            // Fumbles *.2 can't be putting the ball on the ground
            // Being up needs to be given a priority. Run the ball to kill the clock
            throw new NotImplementedException();

        }

        public double GetWRValueForOneGame(Guid playerId, Guid gameId)
        {
            // Yards/Reception * .3 This matters the most. If Randy Moss only had 3 catches but they're all 80 yard TDs, I'll take that shit all day.
            // Closeness of game matters here too. You throw the ball more when you're down.
            // Targets matter.
            // So do drops.
            // So does QB. Brady is gonna be more effective with Randy Moss than fucking Andrew Walter or Aaron Brooks. Holy shit the Raiders were terrible in 06.
            throw new NotImplementedException();

        }

        public double GetTEValueForOneGame(Guid playerId, Guid gameId)
        {
            // Basically the same as WR. I need to determine if there's anything I need to change.
            throw new NotImplementedException();
        }

        public double GetDefenseValueForOneGame(Guid teamId, Guid gameId)
        {
            // Turnovers
            // Points allowed
            // Time on the field
            // Big plays
            throw new NotImplementedException();
        }

        //private void InsertStats(List<Stat> stats, IDalCrud<object> dalCrud, Guid gameId, Stat stat)
        //{
        //    foreach (var stat in stats)
        //    {
        //        stat.PlayerId = _playerDal.GetPlayerIdByGsisId(stat.GsisId);
        //        stat.GameId = gameId;
        //        dalCrud.Create(stat);
        //    }
        //}
    }

    public class GameStatsFilter
    {
        public bool passingStatsOn = true;
        public bool rushingStatsOn = true;
        public bool receivingStatsOn = true;
        public bool returnStatsOn = false;
        public bool kickingStatsOn = false;
        public bool defensiveStatsOn = false;
        public bool fumblesOn = false;
    }
}
