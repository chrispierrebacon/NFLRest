using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFLBLL;
using NFLDALEF;
using System.Collections.Generic;

namespace NFLBLL.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            GameDal gameDal = new GameDal();
            PlayerDal playerDal = new PlayerDal();
            TeamDal teamDal = new TeamDal();
            FumbleDal fumbleDal = new FumbleDal();
            KickingStatDal kickingStatDal = new KickingStatDal();
            KickReturnStatDal kickReturnStatDal = new KickReturnStatDal();
            PassingStatDal passingStatDal = new PassingStatDal();
            PuntingStatDal puntingStatDal = new PuntingStatDal();
            PuntReturnStatDal puntReturnStatDal = new PuntReturnStatDal();
            ReceivingStatDal receivingStatDal = new ReceivingStatDal();
            RushingStatDal rushingStatDal = new RushingStatDal();
            DefensiveStatDal defensiveStatDal = new DefensiveStatDal();
            PlayersTeamsGamesDal ptgDal = new PlayersTeamsGamesDal();

            StatsBL statsBL = new StatsBL(gameDal, fumbleDal, kickingStatDal, kickReturnStatDal, passingStatDal, puntingStatDal, puntReturnStatDal, receivingStatDal, rushingStatDal, defensiveStatDal, playerDal, ptgDal);

            List<Guid> games = new List<Guid>();
            games.Add(Guid.Parse("DDB8C33F-F686-436C-912F-AD84A3DE5D65"));
            games.Add(Guid.Parse("3BBBC52A-CC93-4216-AA55-980B86D5B99A"));
            games.Add(Guid.Parse("E4B8900C-8A39-434C-A81D-7413E59FDDF7"));

            //var points = statsBL.GetOffensiveFantasyPointsByPlayerIdAndGameIds(Guid.Parse("6C3F77A3-D24B-4866-BA43-B21C3A877981"), games, true);
            var points = statsBL.GetOffensiveProjectedValue(Guid.Parse("093E97E4-EC41-4F01-AFF0-01EB11E3F6AE"), "CHI");
        }
    }
}
