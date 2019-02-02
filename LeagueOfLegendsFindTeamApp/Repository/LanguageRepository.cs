using LeagueOfLegendsFindTeamApp.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Unity.Attributes;

namespace LeagueOfLegendsFindTeamApp.Repository
{
    public class LanguageRepository : IRepository<Language, int>
    {
        [Dependency]
        public ApplicationDbContext Context { get; set; }

        public LanguageRepository(ApplicationDbContext context)
        {
            Context = context;
        }


        public IEnumerable<Language> GetAll()
        {
            return Context.Languages.ToList();
        }

        public Language Get(int id)
        {
            return Context.Languages.First(a => a.LanguageId == id) ?? throw new InvalidOperationException();
        }

        public bool Add(Language entity)
        {
            Context.Languages.Add(entity);
            foreach (var person in entity.Persons)
            {
                Context.Entry(person).State = EntityState.Unchanged;
            }

            return Context.SaveChanges() > 0;
        }

        public bool Remove(Language entity)
        {
            try
            {
                Language obj = Context.Languages.First(a => a.LanguageId == entity.LanguageId);
                Context.Languages.Remove(obj);
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
                Language obj = Context.Languages.First(a => a.LanguageId == id);
                Context.Languages.Remove(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return Context.SaveChanges() > 0;
        }

        public bool Update(Language entity)
        {
            try
            {
                Language language = Context.Languages.Single(a => a.LanguageId == entity.LanguageId) ?? throw new Exception($"Not found id: {entity.LanguageId}");
                language.Name = entity.Name;

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