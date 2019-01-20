using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LeagueOfLegendsFindTeamApp.Models.DatabaseModels;
using Unity.Attributes;

namespace LeagueOfLegendsFindTeamApp.Repository
{
    public class ImageRepository : IRepository<Image, int>
    {
        [Dependency]
        public ApplicationDbContext Context { get; set; }

        public ImageRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public IEnumerable<Image> GetAll()
        {
            return Context.Images.ToList();
        }

        public Image Get(int id)
        {
            return Context.Images.First(a => a.ImageId == id) ?? throw new InvalidOperationException();
        }

        public bool Add(Image entity)
        {
            Context.Images.Add(entity);
            return Context.SaveChanges() > 0;
        }

        public bool Remove(Image entity)
        {
            try
            {
                Image obj = Context.Images.First(a => a.ImageId == entity.ImageId);
                Context.Images.Remove(obj);
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
                Image obj = Context.Images.First(a => a.ImageId == id);
                Context.Images.Remove(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return Context.SaveChanges() > 0;
        }

        public bool Update(Image entity)
        {
            try
            {
                //Image image = Context.Images.Single(a => a.ImageId == entity.ImageId) ?? throw new Exception($"Not found id: {entity.ImageId}");
                //TODO: Sprawdzic czy to w ogole dziala
                Context.Entry(entity).State = EntityState.Modified;
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