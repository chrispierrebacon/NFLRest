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
using NFLCommon;
using System.Xml.Serialization;
using System.Xml;

namespace ParseJsonData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/json; charset=utf-8" },
            };

            //var stuff = getWhatWeNeed();

            List<Task> tasks = new List<Task>();

            int Completions = 43;
            int Attempts = 62;
            int Yards = 466;
            int Touchdowns = 2;
            int Interceptions = 1;
            double comps = Completions;
            double atts = Attempts;
            double yds = Yards;
            double tds = Touchdowns;
            double ints = Interceptions;

            double a = ((comps / atts) - .3) * 5;
            a = setBounds(a);
            double b = ((yds / atts) - 3) * .25;
            b = setBounds(b);
            double c = (tds / atts) * 20;
            c = setBounds(c);
            double d = 2.375 - ((ints / atts) * 25);
            d = setBounds(d);
            double stuff = ((a + b + c + d) / 6) * 100;

            bool dummy = true;

            //var something = fetchGamesFromNFL();

            //foreach (var game in stuff)
            //{
            //    Task t = Task.Run(() =>
            //    {
            //        RestRequest<Game> restRequest = new RestRequest<Game>();
            //        restRequest.MakeRequest("http://localhost:49786", "api/games", game, Method.POST, headers);
            //    });
            //    tasks.Add(t);
            //}
            //Task.WaitAll(tasks.ToArray());

            //foreach (var team in getTeams())
            //{
            //    Task t = Task.Run(() =>
            //    {
            //        RestRequest<Team> restRequest = new RestRequest<Team>();
            //        restRequest.MakeRequest("http://localhost:49786", "api/teams", team, Method.POST, headers);
            //    });
            //    tasks.Add(t);
            //}
            //Task.WaitAll(tasks.ToArray());

            //foreach (var player in parsePlayers())
            //{
            //    RestRequest<Player> restRequest = new RestRequest<Player>();
            //    restRequest.MakeRequest("http://localhost:49786", "api/players", player, Method.POST, headers);
            //}

            //foreach (var game in fetchGamesFromNFL())
            //{
            //    Task t = Task.Run(() =>
            //    {
            //        RestRequest<Game> restRequest = new RestRequest<Game>();
            //        restRequest.MakeRequest("http://localhost:49786", "api/games", game, Method.POST, headers);
            //    });
            //    tasks.Add(t);
            //}
            //Task.WaitAll(tasks.ToArray());

            //foreach (var stat in parseStats())
            //{
            //    Task t = Task.Run(() =>
            //    {
            //        RestRequest<GameStats> restRequest = new RestRequest<GameStats>();
            //        restRequest.MakeRequest("http://localhost:49786", "api/stats", stat, Method.POST, headers);
            //    });
            //    tasks.Add(t);
            //}
            //Task.WaitAll(tasks.ToArray());
        }

        private static double setBounds(double dub)
        {
            dub = dub > 0 ? dub : 0;
            dub = dub < 2.375 ? dub : 2.375;
            return dub;
        }

        private static ConcurrentBag<Game> fetchGamesFromNFL()
        {
            List<Task> tasks = new List<Task>();

            ConcurrentBag<Game> games = new ConcurrentBag<Game>();

            for (int j = 1967; j < 2017; j++)
            {
                int sbWeek = 0;
                int postSeasonStarts = 0;
                // 14 game season
                if (j < 1978)
                {
                    sbWeek = 17;
                    postSeasonStarts = 15;
                }
                // 16 game season. They added a WC week too.
                else if (j < 1990)
                {
                    sbWeek = 20;
                    postSeasonStarts = 17;
                }
                // Bye week
                else if (j < 2009)
                {
                    sbWeek = 21;
                    postSeasonStarts = 18;
                }
                // I have an idea. Let's put the probowl the week before the super bowl. I bet everyone will watch now. (My ass)
                else
                {
                    sbWeek = 22;
                    postSeasonStarts = 18;
                }

                string seasonType = "REG";
                for (int i = 1; i < 23; i++)
                {
                    if (i == postSeasonStarts)
                    {
                        seasonType = "POST";
                    }

                    tasks.Add(fillTheBucket(i, j, seasonType, games));

                    if (i == sbWeek)
                    {
                        i = 23;
                        continue;
                    }
                }
            }
            Task.WaitAll(tasks.ToArray());
            return games;

        }

        private static ConcurrentBag<Game> getWhatWeNeed()
        {
            ConcurrentBag<Game> games = new ConcurrentBag<Game>();
            List<Task> tasks = new List<Task>();
            int[] arr = { 19, 20, 22 };
            for(int i = 0; i<3; i++)
            {
                tasks.Add(fillTheBucket(arr[i], 2016, "POST", games));
            }
            Task.WaitAll(tasks.ToArray());
            return games;
        }

        private static Task fillTheOtherBucket(int i, int j, string seasonType, ConcurrentBag<string> games)
        {
            Task t = Task.Run(() =>
            {
                try
                {
                    Dictionary<string, string> headers = new Dictionary<string, string>
                    {
                        { "Content-Type", "application/json; charset=utf-8" }
                    };

                    string url = "http://www.nfl.com/ajax/scorestrip?";

                    string endpoint = string.Format(url + "season={0}&seasonType={1}&week={2}", j, seasonType, i);
                    RestRequest<dynamic> request = new RestRequest<dynamic>();
                    var response = request.MakeRequest(endpoint, "", null, Method.GET, headers);
                    XmlDocument xml = new XmlDocument();
                    xml.Load(new StringReader(response.Content));
                    var xmlGames = xml.GetElementsByTagName("g");
                    foreach (XmlNode g in xmlGames)
                    {
                        games.Add(g.Attributes["v"].Value);
                        games.Add(g.Attributes["h"].Value);
                    }
                }
                catch (Exception)
                {
                }
            });
            return t;
        }

        private static Task fillTheBucket(int i, int j, string seasonType, ConcurrentBag<Game> games)
        {
            Task t = Task.Run(() =>
            {
                try
                {
                    Dictionary<string, string> headers = new Dictionary<string, string>
                    {
                        { "Content-Type", "application/json; charset=utf-8" }
                    };

                    string url = "http://www.nfl.com/ajax/scorestrip?";

                    string endpoint = string.Format(url + "season={0}&seasonType={1}&week={2}", j, seasonType, i);
                    RestRequest<dynamic> request = new RestRequest<dynamic>();
                    var response = request.MakeRequest(endpoint, "", null, Method.GET, headers);
                    XmlDocument xml = new XmlDocument();
                    xml.Load(new StringReader(response.Content));
                    var xmlGames = xml.GetElementsByTagName("g");
                    foreach (XmlNode g in xmlGames)
                    {
                        Game game = new Game();
                        game.AwayTeam = g.Attributes["v"].Value.Equals("JAX") ? "JAC" : g.Attributes["v"].Value;
                        game.HomeTeam = g.Attributes["h"].Value.Equals("JAX") ? "JAC" : g.Attributes["h"].Value;

                        string time = g.Attributes["t"].Value;
                        Regex regex = new Regex(@"[0-9]+");
                        var matches = regex.Matches(time);
                        int hour = Convert.ToInt32(matches[0].Value) + 12;
                        int minutes = Convert.ToInt32(matches[1].Value);

                        string date = g.Attributes["eid"].Value;
                        DateTime dateBuilder = DateTime.ParseExact(date, "yyyyMMddff", CultureInfo.InvariantCulture);
                        dateBuilder = dateBuilder.AddHours(hour);
                        dateBuilder = dateBuilder.AddMinutes(minutes);
                        game.DateTime = TimeZoneInfo.ConvertTimeToUtc(dateBuilder, TimeZoneInfo.FindSystemTimeZoneById("US Eastern Standard Time"));
                        game.SeasonType = seasonType;
                        game.GameType = g.Attributes["gt"].Value;
                        game.Eid = Convert.ToInt64(g.Attributes["eid"].Value);
                        game.GameKey = Convert.ToInt64(g.Attributes["gsis"].Value);
                        game.Week = i;
                        game.Season = j;
                        game.HTScoreFinal = Convert.ToInt32(g.Attributes["hs"].Value);
                        game.ATScoreFinal = Convert.ToInt32(g.Attributes["vs"].Value);
                        games.Add(game);
                    }
                }
                catch (Exception ex) 
                {

                }
            });
            return t;
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
                if ((g.Last.meridiem == null || g.Last.meridiem == "PM") && hour < 12)
                {
                    hour += 12;
                }

                string date = g.Last.eid;
                DateTime dateBuilder = DateTime.ParseExact(date, "yyyyMMddff", CultureInfo.InvariantCulture);
                dateBuilder = dateBuilder.AddHours(hour);
                game.DateTime = TimeZoneInfo.ConvertTimeToUtc(dateBuilder, TimeZoneInfo.FindSystemTimeZoneById("US Eastern Standard Time"));
                game.SeasonType = g.Last.season_type;
                game.Eid = g.Last.eid;
                game.GameKey = g.Last.gamekey;
                game.Week = g.Last.week;
                game.Season = g.Last.year;
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
                player.Birthdate = shit.birthdate != null && shit.birthdate != "//" ? shit.birthdate : new DateTime(1753, 1, 1);
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
                    dynamic games = JsonConvert.DeserializeObject(jsonString);
                    JEnumerable<JToken> children = games.Children();
                    dynamic game = children.First().First();

                    buildGame(game, statsRequest);
                    dynamic cunts = children.First();
                    statsRequest.Game.DateTime = DateTime.ParseExact(cunts.Name, "yyyyMMddff", CultureInfo.InvariantCulture);
                    statsRequest.Game.Eid = Convert.ToInt32(cunts.Name);

                    buildStatsRequest(game.home, statsRequest);
                    buildStatsRequest(game.away, statsRequest);

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

            game.HomeTeam = g.home.abbr == "JAX" ? "JAC" : g.home.abbr;
            game.AwayTeam = g.away.abbr == "JAX" ? "JAC" : g.away.abbr;

            game.HTScoreFirstQtr = g.home.score["1"];
            game.HTScoreSecondQtr = g.home.score["2"];
            game.HTScoreThirdQtr = g.home.score["3"];
            game.HTScoreFourthQtr = g.home.score["4"];
            game.HTScoreOT = g.home.score["5"];
            game.HTScoreFinal = g.home.score.T;

            game.ATScoreFirstQtr = g.away.score["1"];
            game.ATScoreSecondQtr = g.away.score["2"];
            game.ATScoreThirdQtr = g.away.score["3"];
            game.ATScoreFourthQtr = g.away.score["4"];
            game.ATScoreOT = g.away.score["5"];
            game.ATScoreFinal = g.away.score.T;

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
            var abbr = teamStats.abbr;
            
            var passingStats = new List<PassingStat>();

            if (teamStats.stats.passing != null)
            {
                foreach (var p in teamStats.stats.passing)
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
                    passingStat.Team = abbr;
                    passingStats.Add(passingStat);
                }
            }

            return passingStats;
        }
                       
        private static List<RushingStat> buildRushingStats(dynamic teamStats)
        {
            var abbr = teamStats.abbr;

            var rushingStats = new List<RushingStat>();

            if (teamStats.stats.rushing != null)
            {
                foreach (var r in teamStats.stats.rushing)
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
                    rushingStat.Team = abbr;
                    rushingStats.Add(rushingStat);
                }
            }

            return rushingStats;
        }
                       
        private static List<ReceivingStat> buildReceivingStats(dynamic teamStats)
        {
            var abbr = teamStats.abbr;

            var receivingStats = new List<ReceivingStat>();

            if (teamStats.stats.receiving != null)
            {
                foreach (var r in teamStats.stats.receiving)
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
                    receivingStat.Team = abbr;
                    receivingStats.Add(receivingStat);
                }
            }

            return receivingStats;
        }
                       
        private static List<Fumble> buildFumbleStats(dynamic teamStats)
        {
            var abbr = teamStats.abbr;

            var fumbles = new List<Fumble>();

            if (teamStats.stats.fumbles != null)
            {
                foreach (var f in teamStats.stats.fumbles)
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
                    fumble.Team = abbr;
                    fumbles.Add(fumble);
                }
            }
            return fumbles;
        }
                       
        private static List<KickingStat> buildKickingStats(dynamic teamStats)
        {
            var abbr = teamStats.abbr;

            var kickingStats = new List<KickingStat>();

            if (teamStats.stats.kicking != null)
            {
                foreach (var k in teamStats.stats.kicking)
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
                    kickingStat.Team = abbr;
                    kickingStats.Add(kickingStat);
                }
            }
            return kickingStats;
        }
                       
        private static List<PuntingStat> buildPuntingStats(dynamic teamStats)
        {
            var abbr = teamStats.abbr;

            var puntingStats = new List<PuntingStat>();

            if (teamStats.stats.punting != null)
            {
                foreach (var p in teamStats.stats.punting)
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
                    puntingStat.Team = abbr;
                    puntingStats.Add(puntingStat);
                }
            }
            return puntingStats;
        }
                       
        private static List<KickReturnStat> buildKickReturnStats(dynamic teamStats)
        {
            var abbr = teamStats.abbr;

            var kickReturnStats = new List<KickReturnStat>();

            if (teamStats.stats.kickret != null)
            {
                foreach (var k in teamStats.stats.kickret)
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
                    kickReturnStat.Team = abbr;
                    kickReturnStats.Add(kickReturnStat);
                }
            }
            return kickReturnStats;
        }
                       
        private static List<PuntReturnStat> buildPuntReturnStats(dynamic teamStats)
        {
            var abbr = teamStats.abbr;

            var puntReturnStats = new List<PuntReturnStat>();

            if (teamStats.stats.puntret != null)
            {
                foreach (var p in teamStats.stats.puntret)
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
                    puntReturnStat.Team = abbr;
                    puntReturnStats.Add(puntReturnStat);
                }
            }
            return puntReturnStats;
        }
                       
        private static List<DefensiveStat> buildDefensiveStats(dynamic teamStats)
        {
            var abbr = teamStats.abbr;

            var defensiveStats = new List<DefensiveStat>();

            if (teamStats.stats.defense != null)
            {
                foreach (var d in teamStats.stats.defense)
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
                    defensiveStat.Team = abbr;
                    defensiveStats.Add(defensiveStat);
                }
            }
            return defensiveStats;
        }
    }
}
