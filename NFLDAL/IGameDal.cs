using NFLEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLDAL
{
    public interface IGameDal : IDalCrud<Game>
    {
        Guid GetGameIdByEid(long Eid);
    }
}
