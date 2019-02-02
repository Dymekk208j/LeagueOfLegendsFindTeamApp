using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LeagueOfLegendsFindTeamApp.Models.DatabaseModels;
using Unity.Attributes;
using WebGrease.Css.Extensions;

namespace LeagueOfLegendsFindTeamApp.Repository
{
    public class RegionRepository : IRepository<Region, int>
    {
        [Dependency]
        public ApplicationDbContext Context { get; set; }

        public RegionRepository(ApplicationDbContext context)
        {
            Context = context;
        }
        public IEnumerable<Region> GetAll()
        {
            return Context.Regions.ToList();
        }

        public Region Get(int id)
        {
            return Context.Regions.First(a => a.RegionId == id) ?? throw new InvalidOperationException();
        }

        public bool Add(Region entity)
        {
            Context.Regions.Add(entity);
            entity.GamerProfiles.ForEach(g => Context.Entry(g).State = EntityState.Unchanged);
            return Context.SaveChanges() > 0;
        }

        public bool Remove(Region entity)
        {
            try
            {
                Region obj = Context.Regions.First(a => a.RegionId == entity.RegionId);
                Context.Regions.Remove(obj);
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
                Region obj = Context.Regions.First(a => a.RegionId == id);
                Context.Regions.Remove(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return Context.SaveChanges() > 0;
        }

        public bool Update(Region entity)
        {
            try
            {
                Region region = Context.Regions.Single(a => a.RegionId == entity.RegionId) ?? throw new Exception($"Not found id: {entity.RegionId}");
                region.Name = entity.Name;

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