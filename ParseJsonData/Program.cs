using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Collections.Concurrent;
using NFLEF;

namespace ParseJsonData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var stuff = parseStats();


            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/json; charset=utf-8" }
            };

            foreach (var game in parseGames())
            {
                RestRequest<Game> restRequest = new RestRequest<Game>();
                restRequest.MakeRequest("http://localhost:49786", "api/games", game, Method.POST, headers);
            }

            foreach (var stat in parseStats())
            {
                RestRequest<GameStats> restRequest = new RestRequest<GameStats>();
                restRequest.MakeRequest("http://localhost:49786", "api/stats", stat, Method.POST, headers);
            }
        }

        private static List<Team> getTeams()
        {
            var teams = new List<Team>
            {
                new Team
                {
                    Prefix = "BUF",
                    City = "Buffalo",
                    NickName = "Bills",
                    Conference = "AFC",
                    Division = "East"
                },

                new Team
                {
                    Prefix = "MIA",
                    City = "Miami",
                    NickName = "Dolphins",
                    Conference = "AFC",
                    Division = "East"
                },

                new Team
                {
                    Prefix = "NE",
                    City = "New England",
                    NickName = "Patriots",
                    Conference = "AFC",
                    Division = "East"
                },

                new Team
                {
                    Prefix = "NYJ",
                    City = "New York",
                    NickName = "Jets",
                    Conference = "AFC",
                    Division = "East"
                },

                new Team
                {
                    Prefix = "BAL",
                    City = "Baltimore",
                    NickName = "Ravens",
                    Conference = "AFC",
                    Division = "North"
                },

                new Team
                {
                    Prefix = "CIN",
                    City = "Cincinatti",
                    NickName = "Bengals",
                    Conference = "AFC",
                    Division = "North"
                },

                new Team
                {
                    Prefix = "CLE",
                    City = "Cleveland",
                    NickName = "Browns",
                    Conference = "AFC",
                    Division = "North"
                },

                new Team
                {
                    Prefix = "PIT",
                    City = "Pittsburg",
                    NickName = "Steelers",
                    Conference = "AFC",
                    Division = "North"
                },

                new Team
                {
                    Prefix = "HOU",
                    City = "Houston",
                    NickName = "Texans",
                    Conference = "AFC",
                    Division = "South"
                },

                new Team
                {
                    Prefix = "IND",
                    City = "Indianapolis",
                    NickName = "Colts",
                    Conference = "AFC",
                    Division = "South"
                },

                new Team
                {
                    Prefix ="JAC",
                    City = "Jacksonville",
                    NickName = "Jaguars",
                    Conference = "AFC",
                    Division = "South"
                },

                new Team
                {
                    Prefix = "TEN",
                    City = "Tennessee",
                    NickName = "Titans",
                    Conference = "AFC",
                    Division = "South"
                },

                new Team
                {
                    Prefix = "DEN",
                    City = "Denver",
                    NickName = "Broncos",
                    Conference = "AFC",
                    Division = "West"
                },

                new Team
                {
                    Prefix = "KC",
                    City = "Kansas City",
                    NickName = "Chiefs",
                    Conference = "AFC",
                    Division = "West"
                },

                new Team
                {
                    Prefix = "OAK",
                    City = "Oakland",
                    NickName = "Raiders",
                    Conference = "AFC",
                    Division = "West"
                },

                new Team
                {
                    Prefix = "SD",
                    City = "San Diego",
                    NickName = "Chargers",
                    Conference = "AFC",
                    Division = "West"
                },

                new Team
                {
                    Prefix = "DAL",
                    City = "Dallas",
                    NickName = "Cowboys",
                    Conference = "NFC",
                    Division = "East"
                },

                new Team
                {
                    Prefix = "PHI",
                    City = "Philadelphia",
                    NickName = "Eagles",
                    Conference = "NFC",
                    Division = "East"
                },

                new Team
                {
                    Prefix = "NYG",
                    City = "New York",
                    NickName = "Giants",
                    Conference = "NFC",
                    Division = "East"
                },

                // Go fuck yourself
                new Team
                {
                    Prefix = "WAS",
                    City = "Washington",
                    NickName = "Redskins",
                    Conference = "NFC",
                    Division = "East"
                },

                new Team
                {
                    Prefix = "CHI",
                    City = "Chicago",
                    NickName = "Bears",
                    Conference = "NFC",
                    Division = "North"
                },

                new Team
                {
                    Prefix = "DET",
                    City = "Detroit",
                    NickName = "Lions",
                    Conference = "NFC",
                    Division = "North"
                },

                new Team
                {
                    Prefix = "GB",
                    City = "Green Bay",
                    NickName = "Packers",
                    Conference = "NFC",
                    Division = "North"
                },

                new Team
                {
                    Prefix = "MIN",
                    City = "Minnesota",
                    NickName = "Vikings",
                    Conference = "NFC",
                    Division = "North"
                },

                new Team
                {
                    Prefix = "ATL",
                    City = "Atlanta",
                    NickName = "Falcons",
                    Conference = "NFC",
                    Division = "South"
                },

                new Team
                {
                    Prefix = "CAR",
                    City = "Carolina",
                    NickName = "Panthers",
                    Conference = "NFC",
                    Division = "South"
                },

                new Team
                {
                    Prefix = "NO",
                    City = "New Orleans",
                    NickName = "Saints",
                    Conference = "NFC",
                    Division = "South"
                },

                new Team
                {
                    Prefix = "TB",
                    City = "Tampa Bay",
                    NickName = "Buccaneers",
                    Conference = "NFC",
                    Division = "South"
                },

                new Team
                {
                    Prefix = "ARI",
                    City = "Arizona",
                    NickName = "Cardinals",
                    Conference = "NFC",
                    Division = "West"
                },

                new Team
                {
                    Prefix = "LA",
                    City = "Los Angeles",
                    NickName = "Rams",
                    Conference = "NFC",
                    Division = "West"
                },

                new Team
                {
                    Prefix = "SF",
                    City = "San Francisco",
                    NickName = "49ers",
                    Conference = "NFC",
                    Division = "West"
                },

                new Team
                {
                    Prefix = "SEA",
                    City = "Seattle",
                    NickName = "Seahawks",
                    Conference = "NFC",
                    Division = "West"
                }
            };

            return teams;
        }

        private static List<Game> parseGames()
        {
            string jsonString = File.ReadAllText(@"C:\Projects\nflgame\nflgame\schedule.json");

            dynamic deserializedJson = JsonConvert.DeserializeObject(jsonString);
            dynamic jsonGames = deserializedJson.games;

            var games = new List<Game>();

            foreach(var g in jsonGames)
            {
                Game game = new Game();
                game.AwayTeam = g.Last.away;
                game.HomeTeam = g.Last.home;
                Regex regex = new Regex(@"[0-9]+");
                string shit = g.Last.time;
                var matches = regex.Matches(shit);

                int hour = Convert.ToInt32(matches[0].ToString());
                if ((g.Last.meridiem == null || g.Last.mergidiem == "PM") && hour < 12)
                {
                    hour += 12;
                }

                game.DateTime = new DateTime(Convert.ToInt32(g.Last.year), Convert.ToInt32(g.Last.month), Convert.ToInt32(g.Last.day), hour, Convert.ToInt32(matches[1].ToString()), 0);
                game.SeasonType = g.Last.season_type;
                game.Eid = g.Last.eid;
                game.GameKey = g.Last.gamekey;
                game.Week = g.Last.week;

                games.Add(game);
            }

            return games;   
        }

        private static List<Player> parsePlayers()
        {
            string jsonString = File.ReadAllText(@"C:\Projects\nflgame\nflgame\players.json");

            dynamic deserializedJson = JsonConvert.DeserializeObject(jsonString);
            JEnumerable<JToken> children = deserializedJson.Children();

            var players = new List<Player>();
            foreach(var p in children)
            {
                dynamic shit = p.First();

                Player player = new Player();
                player.Birthdate = shit.birthdate != null ? shit.birthdate : new DateTime(1753, 1, 1);
                player.College = shit.college;
                player.FirstName = shit.first_name;
                player.FullName = shit.full_name;
                player.GsisId = shit.gsis_id;
                player.GsisName = shit.gsis_name != null ? shit.gsis_name : "";
                player.Height = shit.height != null ? shit.height : -1;
                player.LastName = shit.last_name;
                player.ProfileId = shit.profile_id;
                player.ProfileUrl = shit.profile_url;
                player.Weight = shit.weight != null ? shit.weight : -1;
                player.YearsPro = shit.years_pro != null ? shit.years_pro : -1;
                player.Position = shit.position != null ? shit.position : "NONE";
                player.Number = shit.number != null ? shit.number : -1;
                player.Status = shit.status != null ? shit.status : "RET";
                player.Team = shit.team != null ? shit.team : "NONE";
                players.Add(player);
            }

            return players;
        }

        private static List<GameStats> parseStats()
        {
            List<GameStats> requests = new List<GameStats>();

            List<Task> tasks = new List<Task>();

            foreach (var file in Directory.GetFiles(@"C:\Projects\nflgame\nflgame\gamecenter-json\Games"))
            {
                Task t = Task.Run(() =>
                {
                    string jsonString = File.ReadAllText(file);

                    var statsRequest = new GameStats();
                    dynamic bitches = JsonConvert.DeserializeObject(jsonString);
                    JEnumerable<JToken> children = bitches.Children();
                    dynamic game = children.First().First();

                    buildGame(game, statsRequest);
                    dynamic cunts = children.First();
                    statsRequest.Game.DateTime = DateTime.ParseExact(cunts.Name, "yyyyMMddff", CultureInfo.InvariantCulture);
                    statsRequest.Game.Eid = Convert.ToInt32(cunts.Name);

                    buildStatsRequest(game.home.stats, statsRequest);
                    buildStatsRequest(game.away.stats, statsRequest);

                    requests.Add(statsRequest);
                });
                tasks.Add(t);
            }

            Task.WaitAll(tasks.ToArray());
            return requests;
        }

        private static void buildGame(dynamic g, GameStats request)
        {
            Game game = new Game();

            dynamic winningTeam = g.home.score.T > g.away.score.T ? g.home : g.away;
            dynamic losingTeam = g.home.score.T > g.away.score.T ? g.away : g.home;

            game.HomeTeam = g.home.abbr;
            game.AwayTeam = g.away.abbr;

            game.WT = winningTeam.abbr;
            game.WTScoreFirstQtr = winningTeam.score["1"];
            game.WTScoreSecondQtr = winningTeam.score["2"];
            game.WTScoreThirdQtr = winningTeam.score["3"];
            game.WTScoreFourthQtr = winningTeam.score["4"];
            game.WTScoreOT = winningTeam.score["5"];
            game.WTScoreFinal = winningTeam.score.T;

            game.LT = losingTeam.abbr;
            game.LTScoreFirstQtr = losingTeam.score["1"];
            game.LTScoreSecondQtr = losingTeam.score["2"];
            game.LTScoreThirdQtr = losingTeam.score["3"];
            game.LTScoreFourthQtr = losingTeam.score["4"];
            game.LTScoreOT = losingTeam.score["5"];
            game.LTScoreFinal = losingTeam.score.T;

            request.Game = game;
        } 

        private static void buildStatsRequest(dynamic stats, GameStats request)
        {
            request.PassingStats.AddRange(buildPassingStats(stats));
            request.RushingStats.AddRange(buildRushingStats(stats));
            request.ReceivingStats.AddRange(buildReceivingStats(stats));
            request.Fumbles.AddRange(buildFumbleStats(stats));
            request.KickingStats.AddRange(buildKickingStats(stats));
            request.PuntingStats.AddRange(buildPuntingStats(stats));
            request.KickReturnStats.AddRange(buildKickReturnStats(stats));
            request.PuntReturnStats.AddRange(buildPuntReturnStats(stats));
            request.DefensiveStats.AddRange(buildDefensiveStats(stats));
        }

        private static List<PassingStat> buildPassingStats(dynamic teamStats)
        {
            var passingStats = new List<PassingStat>();

            foreach (var p in teamStats.passing)
            {
                var passingStat = new PassingStat();
                passingStat.GsisId = p.Name;
                JEnumerable<JToken> jStats = p.Children();
                dynamic stats = jStats.First();
                passingStat.Attempts = stats.att;
                passingStat.Completions = stats.cmp;
                passingStat.Yards = stats.yds;
                passingStat.Touchdowns = stats.tds;
                passingStat.Interceptions = stats.ints;
                passingStat.TwoPointAttempts = stats.twopta;
                passingStat.TwoPointMakes = stats.twoptm;
                passingStats.Add(passingStat);
            }

            return passingStats;
        }
                       
        private static List<RushingStat> buildRushingStats(dynamic teamStats)
        {
            var rushingStats = new List<RushingStat>();
            
            foreach(var r in teamStats.rushing)
            {
                var rushingStat = new RushingStat();
                rushingStat.GsisId = r.Name;
                JEnumerable<JToken> jStats = r.Children();
                dynamic stats = jStats.First();
                rushingStat.Attempts = stats.att;
                rushingStat.Yards = stats.yds;
                rushingStat.Touchdowns = stats.tds;
                rushingStat.Long = stats.lng;
                rushingStat.TwoPointAttempts = stats.twopta;
                rushingStat.TwoPointsMade = stats.twoptm;
                rushingStats.Add(rushingStat);
            }

            return rushingStats;
        }
                       
        private static List<ReceivingStat> buildReceivingStats(dynamic teamStats)
        {
            var receivingStats = new List<ReceivingStat>();

            foreach(var r in teamStats.receiving)
            {
                var receivingStat = new ReceivingStat();
                receivingStat.GsisId = r.Name;
                JEnumerable<JToken> jStats = r.Children();
                dynamic stats = jStats.First();
                receivingStat.Receptions = stats.rec;
                receivingStat.Yards = stats.yds;
                receivingStat.Touchdowns = stats.tds;
                receivingStat.Long = stats.lng;
                receivingStat.TwoPointAttempts = stats.twopta;
                receivingStat.TwoPointsMade = stats.twoptm;
                receivingStats.Add(receivingStat);
            }

            return receivingStats;
        }
                       
        private static List<Fumble> buildFumbleStats(dynamic teamStats)
        {
            var fumbles = new List<Fumble>();

            if (teamStats.fumbles != null)
            {
                foreach (var f in teamStats.fumbles)
                {
                    var fumble = new Fumble();
                    fumble.GsisId = f.Name;
                    JEnumerable<JToken> jStats = f.Children();
                    dynamic stats = jStats.First();
                    fumble.Total = stats.tot;
                    fumble.Recovered = stats.rcv;
                    fumble.TeamRecovered = stats.trcv;
                    fumble.Yards = stats.yds;
                    fumble.Lost = stats.lost;
                    fumbles.Add(fumble);
                }
            }
            return fumbles;
        }
                       
        private static List<KickingStat> buildKickingStats(dynamic teamStats)
        {
            var kickingStats = new List<KickingStat>();

            if (teamStats.kicking != null)
            {
                foreach (var k in teamStats.kicking)
                {
                    var kickingStat = new KickingStat();
                    kickingStat.GsisId = k.Name;
                    JEnumerable<JToken> jStats = k.Children();
                    dynamic stats = jStats.First();
                    kickingStat.FieldGoalsMade = stats.fgm;
                    kickingStat.FieldGoalsAttempted = stats.fga;
                    kickingStat.Yards = stats.fgyds;
                    kickingStat.TotalPoints = stats.totpfg;
                    kickingStat.ExtraPointsMade = stats.xpmade;
                    kickingStat.ExtraPointsMissed = stats.xpmissed;
                    kickingStat.ExtraPointsAttempted = stats.xpa;
                    kickingStat.ExtraPointsBlocked = stats.xpb;
                    kickingStat.ExtraPointsTotal = stats.xptot;
                    kickingStats.Add(kickingStat);
                }
            }
            return kickingStats;
        }
                       
        private static List<PuntingStat> buildPuntingStats(dynamic teamStats)
        {
            var puntingStats = new List<PuntingStat>();

            if (teamStats.punting != null)
            {
                foreach (var p in teamStats.punting)
                {
                    var puntingStat = new PuntingStat();
                    puntingStat.GsisId = p.Name;
                    JEnumerable<JToken> jStats = p.Children();
                    dynamic stats = jStats.First();
                    puntingStat.Punts = stats.pts;
                    puntingStat.Yards = stats.yds;
                    puntingStat.Average = stats.avg;
                    puntingStat.InsideTwenty = stats["i20"];
                    puntingStat.Long = stats.lng;
                    puntingStats.Add(puntingStat);
                }
            }
            return puntingStats;
        }
                       
        private static List<KickReturnStat> buildKickReturnStats(dynamic teamStats)
        {
            var kickReturnStats = new List<KickReturnStat>();

            if (teamStats.kickret != null)
            {
                foreach (var k in teamStats.kickret)
                {
                    var kickReturnStat = new KickReturnStat();
                    kickReturnStat.GsisId = k.Name;
                    JEnumerable<JToken> jStats = k.Children();
                    dynamic stats = jStats.First();
                    kickReturnStat.Returns = stats.ret;
                    kickReturnStat.Average = stats.avg;
                    kickReturnStat.Touchdowns = stats.tds;
                    kickReturnStat.Long = stats.lng;
                    kickReturnStat.LongTouchdown = stats.lngtd != null ? stats.lngtd : 0;
                    kickReturnStats.Add(kickReturnStat);
                }
            }
            return kickReturnStats;
        }
                       
        private static List<PuntReturnStat> buildPuntReturnStats(dynamic teamStats)
        {
            var puntReturnStats = new List<PuntReturnStat>();

            if (teamStats.puntret != null)
            {
                foreach (var p in teamStats.puntret)
                {
                    var puntReturnStat = new PuntReturnStat();
                    puntReturnStat.GsisId = p.Name;
                    JEnumerable<JToken> jStats = p.Children();
                    dynamic stats = jStats.First();
                    puntReturnStat.Returns = stats.ret;
                    puntReturnStat.Average = stats.avg;
                    puntReturnStat.Touchdowns = stats.tds;
                    puntReturnStat.Long = stats.lng;
                    puntReturnStat.LongTouchdown = stats.lngtd != null ? stats.lngtd : 0;
                    puntReturnStats.Add(puntReturnStat);
                }
            }
            return puntReturnStats;
        }
                       
        private static List<DefensiveStat> buildDefensiveStats(dynamic teamStats)
        {
            var defensiveStats = new List<DefensiveStat>();

            foreach(var d in teamStats.defense)
            {
                var defensiveStat = new DefensiveStat();
                defensiveStat.GsisId = d.Name;
                JEnumerable<JToken> jStats = d.Children();
                dynamic stats = jStats.First();
                defensiveStat.Tackles = stats.tkl;
                defensiveStat.Assists = stats.ast;
                defensiveStat.Sacks = stats.sk;
                defensiveStat.Interceptions = stats["int"];
                defensiveStat.ForcedFumbles = stats.ffum;
                defensiveStats.Add(defensiveStat);
            }

            return defensiveStats;
        }

    }
}
