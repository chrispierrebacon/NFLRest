using NFLCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NFLCommon.DALInterfaces;
using System.Data.Entity;
using System.Collections.Concurrent;
using NFLBLL;

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
            Guid gameId = _gameDal.GetGameByEid(request.Game.Eid);
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

        public GameStats GetGamePriorityStats(Guid gameId)
        {
            GameStats gameStats = new GameStats();
            gameStats.Game = entities.Games.FirstOrDefault(i => i.GameId.Equals(gameId));

            // How bout all QBs that threw more than 50 yards
            gameStats.PassingStats.AddRange(entities.PassingStats.Where(i => i.GameId.Equals(gameId) && i.Yards > 50).OrderByDescending(i => i.Yards));
            // Get QB rushing stats too, just in case.
            var stuff = gameStats.PassingStats.Select(i => i.PlayerId);
            gameStats.RushingStats.AddRange(entities.RushingStats.Where(i => i.GameId.Equals(gameId) && stuff.Contains(i.PlayerId)));
            gameStats.ReceivingStats.AddRange(entities.ReceivingStats.Where(i => i.GameId.Equals(gameId) && stuff.Contains(i.PlayerId)));

            // Get players that scored over 8 fantasy points
            List<Guid> playersIds = new List<Guid>();
            playersIds.AddRange(entities.RushingStats.Where(i => i.GameId.Equals(gameId)).Select(i => i.PlayerId));
            playersIds.AddRange(entities.ReceivingStats.Where(i => i.GameId.Equals(gameId)).Select(i => i.PlayerId));
            playersIds = playersIds.Union(entities.ReceivingStats.Where(i => i.GameId.Equals(gameId)).Select(i => i.PlayerId)).ToList();

            foreach(var playerId in playersIds)
            {
                var rushingStats = entities.RushingStats.FirstOrDefault(i => i.GameId.Equals(gameId) && i.PlayerId.Equals(playerId));
                var receivingStats = entities.ReceivingStats.FirstOrDefault(i => i.GameId.Equals(gameId) && i.PlayerId.Equals(playerId));
                var kickReturnStats = entities.KickReturnStats.FirstOrDefault(i => i.GameId.Equals(gameId) && i.PlayerId.Equals(playerId));
                var puntReturnStats = entities.PuntReturnStats.FirstOrDefault(i => i.GameId.Equals(gameId) && i.PlayerId.Equals(playerId));
                var fumbles = entities.Fumbles.FirstOrDefault(i => i.GameId.Equals(gameId) && i.PlayerId.Equals(playerId));

                double fantasyPoints = (rushingStats?.Yards ?? 0) * .1 + (rushingStats?.Touchdowns ?? 0) * 6 + (rushingStats?.TwoPointsMade ?? 0) * 2
                                + (receivingStats?.Yards ?? 0) * .1 + (receivingStats?.Receptions ?? 0) + (receivingStats?.Touchdowns ?? 0) * 6 + (rushingStats?.TwoPointsMade ?? 0) * 2
                                + (kickReturnStats?.Touchdowns ?? 0) * 6 + (puntReturnStats?.Touchdowns ?? 0) * 6 + (fumbles?.Lost ?? 0) * -2;

                if(fantasyPoints > 12)
                {
                    if(rushingStats != null)
                    {
                        gameStats.RushingStats.Add(rushingStats);
                    }
                    if(receivingStats != null)
                    {
                        gameStats.ReceivingStats.Add(receivingStats);
                    }                    
                }
            }
            gameStats.RushingStats = gameStats.RushingStats.Distinct().ToList();
            gameStats.ReceivingStats = gameStats.ReceivingStats.Distinct().ToList();

            // If there's a return TD, return that
            // Maybe return a big return?
            gameStats.KickReturnStats.AddRange(entities.KickReturnStats.Where(i => i.GameId.Equals(gameId) && (i.Touchdowns > 0 || i.Long > 50)));
            gameStats.PuntReturnStats.AddRange(entities.PuntReturnStats.Where(i => i.GameId.Equals(gameId) && (i.Touchdowns > 0 || i.Long > 50)));


            var statzz = entities.Fumbles.Where(i => i.GameId.Equals(gameId)).ToList();
            // Return all lost fumbles. Lost fumbles are ALWAYS important. Fumbles recovered by your own team are ALWAYS irrelevant. Fucking Giants had 3 fumbles in SBILII and recovered them all...
            gameStats.Fumbles.AddRange(entities.Fumbles.Where(i => i.GameId.Equals(gameId) && (i.Lost > 0 || (i.TeamRecovered > i.Recovered))));

            // Find defensive players with forced fumbles or interceptions
            gameStats.DefensiveStats.AddRange(entities.DefensiveStats.Where(i => i.GameId.Equals(gameId) && (i.ForcedFumbles + i.Interceptions > 0)));
            // Find defensive players with a significant amount of tackles (>5)
            gameStats.DefensiveStats.AddRange(entities.DefensiveStats.Where(i => i.GameId.Equals(gameId) && i.Tackles >= 8));
            // Find defensive players with a significant amount of sacks (>=2)
            gameStats.DefensiveStats.AddRange(entities.DefensiveStats.Where(i => i.GameId.Equals(gameId) && i.Sacks >= 2));

            gameStats.DefensiveStats = gameStats.DefensiveStats.Distinct().ToList();

            return gameStats;
        }

        public CondensedGameStats GetCondensedGameStats(Guid gameId)
        {

            CondensedGameStats gameStats = new CondensedGameStats();
            gameStats.Game = entities.Games.FirstOrDefault(i => i.GameId.Equals(gameId));

            // Get all relevant offensive players
            List<Guid> relevantPlayerIds = new List<Guid>();

            // Get relevant QBs. I want the INTs because I want to see that stat where Fitzpatrick came in for 1 play and threw a pick. That is still so fucking funny.
            relevantPlayerIds.AddRange(entities.PassingStats.Where(i => i.GameId.Equals(gameId) && (i.Yards > 50 || i.Touchdowns > 0 || i.Interceptions > 0)).Select(j => j.PlayerId));

            // Get players who had big games
            List<Guid> possiblePlayerIds = new List<Guid>();
            possiblePlayerIds.AddRange(entities.RushingStats.Where(i => i.GameId.Equals(gameId)).Select(i => i.PlayerId));
            possiblePlayerIds.AddRange(entities.ReceivingStats.Where(i => i.GameId.Equals(gameId)).Select(i => i.PlayerId));
            possiblePlayerIds.AddRange(entities.KickReturnStats.Where(i => i.GameId.Equals(gameId)).Select(i => i.PlayerId));
            possiblePlayerIds.AddRange(entities.PuntReturnStats.Where(i => i.GameId.Equals(gameId)).Select(i => i.PlayerId));
            possiblePlayerIds = possiblePlayerIds.Distinct().ToList();

            foreach(var playerId in possiblePlayerIds)
            {
                var rushingStats = entities.RushingStats.FirstOrDefault(i => i.GameId.Equals(gameId) && i.PlayerId.Equals(playerId));
                var receivingStats = entities.ReceivingStats.FirstOrDefault(i => i.GameId.Equals(gameId) && i.PlayerId.Equals(playerId));
                var kickReturnStats = entities.KickReturnStats.FirstOrDefault(i => i.GameId.Equals(gameId) && i.PlayerId.Equals(playerId));
                var puntReturnStats = entities.PuntReturnStats.FirstOrDefault(i => i.GameId.Equals(gameId) && i.PlayerId.Equals(playerId));
                var fumbles = entities.Fumbles.FirstOrDefault(i => i.GameId.Equals(gameId) && i.PlayerId.Equals(playerId));

                double fantasyPoints = (rushingStats?.Yards ?? 0) * .1 + (rushingStats?.Touchdowns ?? 0) * 6 + (rushingStats?.TwoPointsMade ?? 0) * 2
                                + (receivingStats?.Yards ?? 0) * .1 + (receivingStats?.Receptions ?? 0) + (receivingStats?.Touchdowns ?? 0) * 6 + (rushingStats?.TwoPointsMade ?? 0) * 2
                                + (kickReturnStats?.Touchdowns ?? 0) * 6 + (puntReturnStats?.Touchdowns ?? 0) * 6 + (fumbles?.Lost ?? 0) * -2;

                if (fantasyPoints > 10)
                {
                    relevantPlayerIds.Add(playerId);
                }
            }
            
            relevantPlayerIds = relevantPlayerIds.Distinct().Reverse().ToList();

            // Get all the offensive stats for these players
            foreach(var playerId in relevantPlayerIds)
            {
                OffensiveStat oStat = new OffensiveStat();
                oStat.Player = entities.Players.FirstOrDefault(i => i.PlayerId.Equals(playerId));
                oStat.PassingStat = entities.PassingStats.FirstOrDefault(i => i.GameId.Equals(gameId) && i.PlayerId.Equals(playerId));
                oStat.RushingStat = entities.RushingStats.FirstOrDefault(i => i.GameId.Equals(gameId) && i.PlayerId.Equals(playerId));
                oStat.ReceivingStat = entities.ReceivingStats.FirstOrDefault(i => i.GameId.Equals(gameId) && i.PlayerId.Equals(playerId));
                oStat.KickReturnStat = entities.KickReturnStats.FirstOrDefault(i => i.GameId.Equals(gameId) && i.PlayerId.Equals(playerId) && i.Touchdowns > 0);
                oStat.PuntReturnStat = entities.PuntReturnStats.FirstOrDefault(i => i.GameId.Equals(gameId) && i.PlayerId.Equals(playerId) && i.Touchdowns > 0);
                oStat.Fumble = entities.Fumbles.FirstOrDefault(i => i.GameId.Equals(gameId) && i.PlayerId.Equals(playerId) && (i.Lost > 0 || i.TeamRecovered > 0));
                gameStats.OffensiveStats.Add(oStat);
            }

            // Get all relevant defensive players.
            relevantPlayerIds.Clear();
            relevantPlayerIds.AddRange(entities.DefensiveStats.Where(i => i.GameId.Equals(gameId) && (i.ForcedFumbles > 0 || i.Interceptions > 0 || i.Tackles > 7 || i.Sacks > 1)).Select(i => i.PlayerId));

            // Get all the defensive stats and the fumble stats
            foreach(var playerId in relevantPlayerIds)
            {
                DefStatWithFumble dStat = new DefStatWithFumble();
                dStat.Player = entities.Players.FirstOrDefault(i => i.PlayerId.Equals(playerId));
                dStat.DefensiveStat = entities.DefensiveStats.FirstOrDefault(i => i.GameId.Equals(gameId) && i.PlayerId.Equals(playerId));
                dStat.Fumble = entities.Fumbles.FirstOrDefault(i => i.GameId.Equals(gameId) && i.PlayerId.Equals(playerId) && (i.Lost > 0 || i.TeamRecovered > 0));
                gameStats.DefStatsWithFumbles.Add(dStat);
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

        #region TODO
        public double GetQBProjectedValue(Guid playerId, string oppTeam)
        {
            var passingStats = entities.PassingStats.Where(i => i.PlayerId.Equals(playerId));
            var lastFour = passingStats.OrderByDescending(i => i.Game.DateTime).Take(4);
            var lastSixteen = passingStats.OrderByDescending(i => i.Game.DateTime).Take(16);
            return 0;

        }

        public double GetRBProjectedValue(Guid playerId, string oppTeam)
        {
            // Dunno about extenuating.
            throw new NotImplementedException();
        }

        public double GetWRProjectedValue(Guid playerId, string oppTeam)
        {
            // Dunno about extenuating. 
            throw new NotImplementedException();

        }

        public double GetDefenseProjectedValue(Guid playerId, string oppTeam)
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
            // So does QB. Brady is gonna be more effective with Randy Moss than fucking Andrew Walter or Aaron Brooks. Holy shit the Raiders were terrible in '06.
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

        #endregion

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

    public static class ConcurrentBagExtension
    {
        public static void AddRange<T>(this ConcurrentBag<T> @this, IEnumerable<T> toAdd)
        {
            toAdd.AsParallel().ForAll(t => @this.Add(t));
        }

        public static void Clear<T>(this ConcurrentBag<T> @this)
        {
            T someItem;
            while (!@this.IsEmpty)
            {
                @this.TryTake(out someItem);
            }
        }
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
