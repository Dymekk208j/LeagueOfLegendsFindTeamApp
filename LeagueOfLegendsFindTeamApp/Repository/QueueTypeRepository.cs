using System;
using System.Collections.Generic;
using System.Linq;
using LeagueOfLegendsFindTeamApp.Models.DatabaseModels;
using Unity.Attributes;

namespace LeagueOfLegendsFindTeamApp.Repository
{
    public class QueueTypeRepository : IRepository<QueueType, int>
    {
        [Dependency]
        public ApplicationDbContext Context { get; set; }

        public QueueTypeRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public IEnumerable<QueueType> GetAll()
        {
            return Context.QueueTypes.ToList();
        }

        public QueueType Get(int id)
        {
            return Context.QueueTypes.First(a => a.QueueTypeId == id) ?? throw new InvalidOperationException();
        }

        public bool Add(QueueType entity)
        {
            Context.QueueTypes.Add(entity);
            return Context.SaveChanges() > 0;
        }

        public bool Remove(QueueType entity)
        {
            try
            {
                QueueType obj = Context.QueueTypes.First(a => a.QueueTypeId == entity.QueueTypeId);
                Context.QueueTypes.Remove(obj);
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
                QueueType obj = Context.QueueTypes.First(a => a.QueueTypeId == id);
                Context.QueueTypes.Remove(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return Context.SaveChanges() > 0;
        }

        public bool Update(QueueType entity)
        {
            try
            {
                QueueType queueType = Context.QueueTypes.Single(a => a.QueueTypeId == entity.QueueTypeId) ?? throw new Exception($"Not found id: {entity.QueueTypeId}");
                queueType.Name = entity.Name;

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