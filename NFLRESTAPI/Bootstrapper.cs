using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using NFLBLL;
using NFLDAL;
using Autofac.Integration.WebApi;
using System.Reflection;
using Autofac.Integration.Mvc;
using NFLEF;

namespace NFLRESTAPI
{
    public class Bootstrapper
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            DatabaseAccess databaseAccess = new DatabaseAccess();

            GameDal gameDal = new GameDal(databaseAccess);
            var gameBL = new SingleStatBL<Game>(gameDal);

            PlayerDal playerDal = new PlayerDal(databaseAccess);
            var playerBL = new SingleStatBL<Player>(playerDal);

            TeamDal teamDal = new TeamDal(databaseAccess);
            var teamBL = new SingleStatBL<Team>(teamDal);

            FumbleDal fumbleDal = new FumbleDal(databaseAccess);
            var fumbleBL = new SingleStatBL<Fumble>(fumbleDal);

            KickingStatDal kickingStatDal = new KickingStatDal(databaseAccess);
            var kickingStatBL = new SingleStatBL<KickingStat>(kickingStatDal);

            KickReturnStatDal kickReturnStatDal = new KickReturnStatDal(databaseAccess);
            var kickReturnStatBL = new SingleStatBL<KickReturnStat>(kickReturnStatDal);

            PassingStatDal passingStatDal = new PassingStatDal(databaseAccess);
            var passingStatBL = new SingleStatBL<PassingStat>(passingStatDal);

            PuntingStatDal puntingStatDal = new PuntingStatDal(databaseAccess);
            var puntingStatBL = new SingleStatBL<PuntingStat>(puntingStatDal);

            PuntReturnStatDal puntReturnStatDal = new PuntReturnStatDal(databaseAccess);
            var puntReturnStatBL = new SingleStatBL<PuntReturnStat>(puntReturnStatDal);

            ReceivingStatDal receivingStatDal = new ReceivingStatDal(databaseAccess);
            var receivingStatBL = new SingleStatBL<ReceivingStat>(receivingStatDal);

            RushingStatDal rushingStatDal = new RushingStatDal(databaseAccess);
            var rushingStatBL = new SingleStatBL<RushingStat>(rushingStatDal);

            DefensiveStatDal defensiveStatDal = new DefensiveStatDal(databaseAccess);
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