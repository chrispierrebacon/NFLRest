using NFLCommon;
using System;
using System.Collections.Generic;
using System.Data;
using NFLCommon.DALInterfaces;
using System.Linq;

namespace NFLDALEF
{
    public class TeamDal : ITeamDal
    {
        NFLDBEntities entities = new NFLDBEntities();

        public Guid Create(Team team)
        {
            Guid guid = Guid.NewGuid();
            team.TeamId = guid;
            entities.Teams.Add(team);
            entities.SaveChanges();
            return guid;
        }

        public Team Get(Guid teamId)
        {
            return entities.Teams.FirstOrDefault(i => i.TeamId.Equals(teamId));
        }

        public IEnumerable<Team> GetAll()
        {
            return entities.Teams;
        }

        public int Update(Team team)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid teamId)
        {
            var stat = entities.Teams.FirstOrDefault(i => i.TeamId.Equals(teamId));
            if (stat != null)
            {
                entities.Teams.Remove(stat);
                return 1;
            }
            return 0;
        }
    }
}
