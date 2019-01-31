using System;
using System.Collections.Generic;
using System.Linq;
using LeagueOfLegendsFindTeamApp.Models.DatabaseModels;
using Unity.Attributes;

namespace LeagueOfLegendsFindTeamApp.Repository
{
    public class PersonRepository : IRepository<Person, int>
    {
        [Dependency]
        public ApplicationDbContext Context { get; set; }

        public PersonRepository(ApplicationDbContext context)
        {
            Context = context;
        }
        public IEnumerable<Person> GetAll()
        {
            return Context.Persons.Include("ApplicationUser").Include("Languages").ToList();
        }

        public List<Language> GetListOfLanguages()
        {
            return Context.Languages.ToList();
        }

        public Language GetLanguage(string name)
        {
            return Context.Languages.First(x => x.Name == name);
        }
        public Person Get(int id)
        {
            return Context.Persons.Include("Languages").First(a => a.PersonId == id) ?? throw new InvalidOperationException();
        }

        public bool Add(Person entity)
        {
            Context.Persons.Add(entity);
            return Context.SaveChanges() > 0;
        }

        public bool Remove(Person entity)
        {
            try
            {
                Person obj = Context.Persons.First(a => a.PersonId == entity.PersonId);
                Context.Persons.Remove(obj);
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
                Person obj = Context.Persons.First(a => a.PersonId == id);
                Context.Persons.Remove(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return Context.SaveChanges() > 0;
        }

        public bool Update(Person entity)
        {
            try
            {
                Person person = Context.Persons.Single(a => a.PersonId == entity.PersonId) ?? throw new Exception($"Not found id: {entity.PersonId}");
                person.FirstName = entity.FirstName;
                person.Country = entity.Country;
                person.Gender = entity.Gender;
                person.Languages = entity.Languages;
                person.LastName = entity.LastName;

                //TODO: sprawdzic czy dziala przypisywanie jezykow

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