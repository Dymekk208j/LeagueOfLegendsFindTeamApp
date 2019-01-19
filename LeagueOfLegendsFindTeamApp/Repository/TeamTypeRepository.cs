using System;
using System.Collections.Generic;
using System.Linq;
using LeagueOfLegendsFindTeamApp.Models.DatabaseModels;
using Unity.Attributes;

namespace LeagueOfLegendsFindTeamApp.Repository
{
    public class TeamTypeRepository : IRepository<TeamType, int>
    {
        [Dependency]
        public ApplicationDbContext Context { get; set; }

        public TeamTypeRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public IEnumerable<TeamType> GetAll()
        {
            return Context.TeamTypes.ToList();
        }

        public TeamType Get(int id)
        {
            return Context.TeamTypes.First(a => a.TeamTypeId == id) ?? throw new InvalidOperationException();
        }

        public bool Add(TeamType entity)
        {
            Context.TeamTypes.Add(entity);
            return Context.SaveChanges() > 0;
        }

        public bool Remove(TeamType entity)
        {
            try
            {
                TeamType obj = Context.TeamTypes.First(a => a.TeamTypeId == entity.TeamTypeId);
                Context.TeamTypes.Remove(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return Context.SaveChanges() > 0;
        }

        public bool Remove(int id)
        {
            try
            {
                TeamType obj = Context.TeamTypes.First(a => a.TeamTypeId == id);
                Context.TeamTypes.Remove(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return Context.SaveChanges() > 0;
        }

        public bool Update(TeamType entity)
        {
            try
            {
                TeamType teamType = Context.TeamTypes.Single(a => a.TeamTypeId == entity.TeamTypeId) ?? throw new Exception($"Not found id: {entity.TeamTypeId}");
                teamType.Name = entity.Name;

                return Context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}