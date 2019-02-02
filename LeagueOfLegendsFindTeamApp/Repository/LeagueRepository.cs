using LeagueOfLegendsFindTeamApp.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Unity.Attributes;

namespace LeagueOfLegendsFindTeamApp.Repository
{
    public class LeagueRepository : IRepository<League, int>
    {
        [Dependency]
        public ApplicationDbContext Context { get; set; }

        public LeagueRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public IEnumerable<League> GetAll()
        {
            return Context.Leagues.Include("Logo").ToList();
        }

        public League Get(int id)
        {
            return Context.Leagues.Include("Logo").First(a => a.LeagueId == id) ?? throw new InvalidOperationException();
        }

        public bool Add(League entity)
        {
            Context.Leagues.Add(entity);

            Context.Entry(entity.Logo).State = EntityState.Unchanged;

            return Context.SaveChanges() > 0;
        }

        public bool Remove(League entity)
        {
            try
            {
                League obj = Context.Leagues.First(a => a.LeagueId == entity.LeagueId);
                Context.Leagues.Remove(obj);
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
                League obj = Context.Leagues.First(a => a.LeagueId == id);
                Context.Leagues.Remove(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return Context.SaveChanges() > 0;
        }

        public bool Update(League entity)
        {
            try
            {
                League league = Context.Leagues.Single(a => a.LeagueId == entity.LeagueId) ?? throw new Exception($"Not found id: {entity.LeagueId}");
                league.Name = entity.Name;
                league.Division = entity.Division;
                league.LeagueValue = entity.LeagueValue;
                league.Logo = Context.Images.Single(a => a.ImageId == entity.Logo.ImageId);

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