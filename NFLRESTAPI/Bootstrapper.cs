using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using NFLBLL;
using NFLDALEF;
using Autofac.Integration.WebApi;
using System.Reflection;
using Autofac.Integration.Mvc;
using NFLCommon;
using NFLCommon.BLLInterfaces;
using NFLCommon.DALInterfaces;

namespace NFLRESTAPI
{
    public class Bootstrapper
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            GameDal gameDal = new GameDal();
            var gameBL = new GamesBL(gameDal);

            PlayerDal playerDal = new PlayerDal();
            var playerBL = new SingleStatBL<Player>(playerDal);

            TeamDal teamDal = new TeamDal();
            var teamBL = new SingleStatBL<Team>(teamDal);

            FumbleDal fumbleDal = new FumbleDal();
            var fumbleBL = new SingleStatBL<Fumble>(fumbleDal);

            KickingStatDal kickingStatDal = new KickingStatDal();
            var kickingStatBL = new SingleStatBL<KickingStat>(kickingStatDal);

            KickReturnStatDal kickReturnStatDal = new KickReturnStatDal();
            var kickReturnStatBL = new SingleStatBL<KickReturnStat>(kickReturnStatDal);

            PassingStatDal passingStatDal = new PassingStatDal();
            var passingStatBL = new SingleStatBL<PassingStat>(passingStatDal);

            PuntingStatDal puntingStatDal = new PuntingStatDal();
            var puntingStatBL = new SingleStatBL<PuntingStat>(puntingStatDal);

            PuntReturnStatDal puntReturnStatDal = new PuntReturnStatDal();
            var puntReturnStatBL = new SingleStatBL<PuntReturnStat>(puntReturnStatDal);

            ReceivingStatDal receivingStatDal = new ReceivingStatDal();
            var receivingStatBL = new SingleStatBL<ReceivingStat>(receivingStatDal);

            RushingStatDal rushingStatDal = new RushingStatDal();
            var rushingStatBL = new SingleStatBL<RushingStat>(rushingStatDal);

            DefensiveStatDal defensiveStatDal = new DefensiveStatDal();
            var defensiveStatBL = new SingleStatBL<DefensiveStat>(defensiveStatDal);

            StatsBL statsBL = new StatsBL(gameDal, fumbleDal, kickingStatDal, kickReturnStatDal, passingStatDal, puntingStatDal, puntReturnStatDal, receivingStatDal, rushingStatDal, defensiveStatDal, playerDal);

            builder.RegisterInstance(gameBL).As<IBLCrud<Game>>();
            builder.RegisterInstance(playerBL).As<IBLCrud<Player>>();
            builder.RegisterInstance(teamBL).As<IBLCrud<Team>>();
            builder.RegisterInstance(statsBL);

            return builder.Build();
        }
    }
}