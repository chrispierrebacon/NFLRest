using System;

namespace NFLCommon.DALInterfaces
{
    public interface IGameDal : IDalCrud<Game>
    {
        Guid GetGameIdByEid(long Eid);
    }
}
