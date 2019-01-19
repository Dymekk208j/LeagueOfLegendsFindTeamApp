using System;
using System.Collections.Generic;
using System.Linq;
using LeagueOfLegendsFindTeamApp.Models.DatabaseModels;
using Unity.Attributes;

namespace LeagueOfLegendsFindTeamApp.Repository
{
    public class PositionRepository : IRepository<Position, int>
    {
        [Dependency]
        public ApplicationDbContext Context { get; set; }

        public PositionRepository(ApplicationDbContext context)
        {
            Context = context;
        }
        public IEnumerable<Position> GetAll()
        {
            return Context.Positions.ToList();
        }

        public Position Get(int id)
        {
            return Context.Positions.First(a => a.PositionId == id) ?? throw new InvalidOperationException();
        }

        public bool Add(Position entity)
        {
            Context.Positions.Add(entity);
            return Context.SaveChanges() > 0;
        }

        public bool Remove(Position entity)
        {
            try
            {
                Position obj = Context.Positions.First(a => a.PositionId == entity.PositionId);
                Context.Positions.Remove(obj);
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
                Position obj = Context.Positions.First(a => a.PositionId == id);
                Context.Positions.Remove(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return Context.SaveChanges() > 0;
        }

        public bool Update(Position entity)
        {
            try
            {
                Position position = Context.Positions.Single(a => a.PositionId == entity.PositionId) ?? throw new Exception($"Not found id: {entity.PositionId}");
                position.Name = entity.Name;

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