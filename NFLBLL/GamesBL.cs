using NFLCommon;
using NFLCommon.DALInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLBLL
{
    public class GamesBL : SingleStatBL<Game>
    {
        public GamesBL(IDalCrud<Game> dalCrud) : base(dalCrud) { }

        public override IEnumerable<Game> GetAll()
        {
            var games = _dalCrud.GetAll();
            games = games.OrderByDescending(i => i.DateTime);

            return games.ToList();
        }
    }
}
