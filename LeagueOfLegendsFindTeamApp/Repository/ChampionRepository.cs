using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LeagueOfLegendsFindTeamApp.Models.DatabaseModels;
using Unity.Attributes;

namespace LeagueOfLegendsFindTeamApp.Repository
{
    public class ChampionRepository : IRepository<Champion, int>
    {
          [Dependency]
          public ApplicationDbContext Context { get; set; }

          public ChampionRepository(ApplicationDbContext context)
          {
              Context = context;
          }

          public IEnumerable<Champion> GetAll()
          {
              return Context.Champions.Include("Portrait").Include("Icon").ToList();
          }

          public Champion Get(int id)
          {
              return Context.Champions.Include("Portrait").Include("Icon").First(c => c.ChampionId == id);
          }

          public bool Add(Champion entity)
          {
             
              Context.Champions.Add(entity);
              Context.Entry(entity.Icon).State = EntityState.Unchanged;
              Context.Entry(entity.Portrait).State = EntityState.Unchanged;
            return Context.SaveChanges() > 0;
          }

          public bool Remove(Champion entity)
          {
              try
              {
                  Champion obj = Context.Champions.First(a => a.ChampionId == entity.ChampionId);
                  Context.Champions.Remove(obj);
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
                  Champion obj = Context.Champions.First(a => a.ChampionId == id);
                  Context.Champions.Remove(obj);
              }
              catch (Exception e)
              {
                  Console.WriteLine(e);
                  return false;
              }
              return Context.SaveChanges() > 0;
          }

          public bool Update(Champion entity)
          {
              try
              {
                  Champion champion = Context.Champions.Single(a => a.ChampionId == entity.ChampionId) ?? throw new Exception($"Not found id: {entity.ChampionId}");
                  champion.Name = entity.Name;
                  champion.Icon = Context.Images.Single(a => a.ImageId == entity.Icon.ImageId);
                  champion.Portrait = Context.Images.Single(a => a.ImageId == entity.Portrait.ImageId);
            
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