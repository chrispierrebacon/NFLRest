using System;

namespace NFLCommon.DALInterfaces
{
    public interface IPlayerDal : IDalCrud<Player>
    {
        Guid GetPlayerIdByGsisId(string GsisId);
    }
}