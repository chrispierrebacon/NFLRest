using NFLCommon;
using System;
using System.Collections.Generic;
using System.Data;
using NFLCommon.DALInterfaces;
using System.Linq;
using System.Data.Entity.Validation;

namespace NFLDALEF
{
    public class PlayerDal : IPlayerDal
    {
        public void InsertPositions()
        {
            List<string> posStrings = new List<string>
            {
                "QB",
                "RB",
                "FB",
                "WR",
                "TE",
                "OL",
                "C",
                "G",
                "LG",
                "RG",
                "T",
                "LT",
                "RT",
                "K",
                "KR",
                "DL",
                "DE",
                "DT",
                "NT",
                "LB",
                "ILB",
                "OLB",
                "MLB",
                "DB",
                "CB",
                "FS",
                "SS",
                "S",
                "P",
                "PR",
                "LS",
                "NONE"
            };

            List<Position> positions = new List<Position>();

            foreach (var str in posStrings)
            {
                Position newPosition = new Position
                {
                    Name = str
                };

                positions.Add(newPosition);
            }

            using (var entities = new NFLDBEntities())
            {
                entities.Positions.AddRange(positions);
                entities.SaveChanges();
            }
        }

        public Guid Create(Player player)
        {
            Guid guid = Guid.NewGuid();
            player.PlayerId = guid;

            using (var entities = new NFLDBEntities())
            {
                entities.Players.Add(player);
                try
                {
                    // Your code...
                    // Could also be before try if you know the exception occurs in SaveChanges

                    entities.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    //foreach (var eve in e.EntityValidationErrors)
                    //{
                    //    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    //        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    //    foreach (var ve in eve.ValidationErrors)
                    //    {
                    //        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                    //            ve.PropertyName, ve.ErrorMessage);
                    //    }
                    //}
                    throw;
                }
            }

            return guid;
        }

        public IEnumerable<Player> Get(string filterJson)
        {
            throw new NotImplementedException();
        }

        public Guid GetPlayerIdByGsisId(string GsisId)
        {
            using (var entities = new NFLDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.Players.FirstOrDefault(i => i.GsisId.Equals(GsisId))?.PlayerId ?? Guid.Empty;
            }
        }

        public IEnumerable<Player> GetAll()
        {
            using (var entities = new NFLDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.Players;
            }
        }

        public int Update(Player player)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid playerId)
        {
            using (var entities = new NFLDBEntities())
            {
                var stat = entities.Players.FirstOrDefault(i => i.PlayerId.Equals(playerId));
                if (stat != null)
                {
                    entities.Players.Remove(stat);
                    return 1;
                }
                return 0; 
            }
        }

        
    }
}
