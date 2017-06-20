using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFLCommon;
using NFLCommon.DALInterfaces;

namespace NFLDALEF
{
    public class PlayersTeamsGamesDal : IPlayersTeamsGames
    {
        public Guid Create(PlayersTeamsGame obj)
        {
            using (var entities = new NFLDBEntities())
            {
                entities.PlayersTeamsGames.Add(obj);
                entities.SaveChanges();
            }
            return Guid.Empty;
        }

        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlayersTeamsGame> Get(string filterJson)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlayersTeamsGame> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Update(PlayersTeamsGame obj)
        {
            throw new NotImplementedException();
        }
    }
}
