using System;

namespace NFLCommon.DALInterfaces
{
    public interface IGameDal : IDalCrud<Game>
    {
        Guid GetGameByEid(long Eid);
        int UpdateScore(Game game);
    }
}
