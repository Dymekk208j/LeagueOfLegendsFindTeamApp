using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LeagueOfLegendsFindTeamApp.Models.DatabaseModels;
using Unity.Attributes;

namespace LeagueOfLegendsFindTeamApp.Repository
{
    public class ContactRepository : IRepository<Contact, int>
    {
        [Dependency]
        public ApplicationDbContext Context { get; set; }

        public ContactRepository(ApplicationDbContext context)
        {
            Context = context;
        }
        public IEnumerable<Contact> GetAll()
        {
            return Context.Contacts.ToList();
        }

        public Contact Get(int id)
        {
            return Context.Contacts.First(a => a.ContactId == id) ?? throw new InvalidOperationException();
        }

        public Contact Get(string userId)
        {
            return Context.Contacts.Include("ApplicationUser").First(a => a.ApplicationUser.Id == userId) ?? throw new InvalidOperationException();
        }
        public bool Add(Contact entity)
        {
            Context.Contacts.Add(entity);
            return Context.SaveChanges() > 0;
        }

        public bool Remove(Contact entity)
        {
            try
            {
                Contact obj = Context.Contacts.First(a => a.ContactId == entity.ContactId);
                Context.Contacts.Remove(obj);
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
                Contact obj = Context.Contacts.First(a => a.ContactId == id);
                Context.Contacts.Remove(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return Context.SaveChanges() > 0;
        }

        public bool Update(Contact entity)
        {
            try
            {
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