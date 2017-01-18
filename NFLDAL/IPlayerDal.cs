using NFLObjects.Objects;
using System;
using System.Threading.Tasks;

namespace NFLDAL
{
    public interface IPlayerDal : IDalCrud<Player>
    {
        Guid GetPlayerIdByGsisId(string GsisId);
    }
}