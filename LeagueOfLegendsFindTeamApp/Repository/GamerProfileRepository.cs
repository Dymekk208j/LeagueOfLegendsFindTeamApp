using LeagueOfLegendsFindTeamApp.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Ajax.Utilities;
using Unity.Attributes;

namespace LeagueOfLegendsFindTeamApp.Repository
{
    public class GamerProfileRepository : IRepository<GamerProfile, int>
    {
        [Dependency]
        public ApplicationDbContext Context { get; set; }

        public GamerProfileRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public IEnumerable<GamerProfile> GetAll()
        {
            return Context.GamerProfiles
                .Include("Portrait")
                .Include("PrimaryPosition")
                .Include("SecondaryPosition")
                .Include("Region")
                .Include("SoloQLeague")
                .Include("FlexLeague")
                .Include("League3")
                //.Include("ChampionsPool")
                //.Include("JoinRequests")
                // .Include("TeamInvitations")
                .Include("ApplicationUser").ToList();//TODO: usuniete                 

        }

        public GamerProfile Get(int id)
        {
            return Context.GamerProfiles
                .Include("Portrait")
                .Include("PrimaryPosition")
                .Include("SecondaryPosition")
                .Include("Region")
                .Include("SoloQLeague")
                .Include("FlexLeague")
                .Include("League3")
                .Include("ChampionsPool")
                .Include("JoinRequests")
                .Include("TeamInvitations")
                .Include("ApplicationUser").First(g => g.GamerProfileId == id);
        }

        public GamerProfile Get(string userId)
        {
            return Context.GamerProfiles
                .Include("Portrait")
                .Include("PrimaryPosition")
                .Include("SecondaryPosition")
                .Include("Region")
                .Include("SoloQLeague")
                .Include("FlexLeague")
                .Include("League3")
                .Include("ChampionsPool")
                .Include("JoinRequests")
                .Include("TeamInvitations")
                .Include("ApplicationUser").First(g => g.ApplicationUser.Id == userId);
        }

        public bool Add(GamerProfile entity)
        {
            Context.GamerProfiles.Add(entity);
            Context.Entry(entity.Portrait).State = EntityState.Unchanged;
            Context.Entry(entity.PrimaryPosition).State = EntityState.Unchanged;
            Context.Entry(entity.SecondaryPosition).State = EntityState.Unchanged;
            Context.Entry(entity.Region).State = EntityState.Unchanged;
            Context.Entry(entity.SoloQLeague).State = EntityState.Unchanged;
            Context.Entry(entity.FlexLeague).State = EntityState.Unchanged;
            Context.Entry(entity.League3).State = EntityState.Unchanged;
            entity.ChampionsPool.ForEach(a => Context.Entry(a).State = EntityState.Unchanged);
            entity.JoinRequests.ForEach(a => Context.Entry(a).State = EntityState.Unchanged);
            entity.TeamInvitations.ForEach(a => Context.Entry(a).State = EntityState.Unchanged);
            Context.Entry(entity.ApplicationUser).State = EntityState.Unchanged;

            return Context.SaveChanges() > 0;
        }

        public bool Remove(GamerProfile entity)
        {
            try
            {
                GamerProfile obj = Context.GamerProfiles.First(a => a.GamerProfileId == entity.GamerProfileId);
                Context.GamerProfiles.Remove(obj);
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
                GamerProfile obj = Context.GamerProfiles.First(a => a.GamerProfileId == id);
                Context.GamerProfiles.Remove(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return Context.SaveChanges() > 0;
        }

        public bool Update(GamerProfile entity)
        {
            try
            {
                GamerProfile gamerProfile = Context.GamerProfiles.Single(a => a.GamerProfileId == entity.GamerProfileId) ?? throw new Exception($"Not found id: {entity.GamerProfileId}");
                gamerProfile.Portrait = Context.Images.Single(a => a.ImageId == entity.Portrait.ImageId);
                gamerProfile.InGameName = entity.InGameName;
                gamerProfile.PrimaryPosition = Context.Positions.Single(a => a.PositionId == entity.PrimaryPosition.PositionId);
                gamerProfile.SecondaryPosition = Context.Positions.Single(a => a.PositionId == entity.SecondaryPosition.PositionId);
                gamerProfile.Region = Context.Regions.Single(a => a.RegionId == entity.Region.RegionId);
                gamerProfile.ConfirmedInGameName = entity.ConfirmedInGameName;
                gamerProfile.SoloQLeague = Context.Leagues.Single(a => a.LeagueId == entity.SoloQLeague.LeagueId);
                gamerProfile.FlexLeague = Context.Leagues.Single(a => a.LeagueId == entity.FlexLeague.LeagueId);
                gamerProfile.League3 = Context.Leagues.Single(a => a.LeagueId == entity.League3.LeagueId);
                gamerProfile.ChampionsPool = entity.ChampionsPool;
                gamerProfile.JoinRequests = entity.JoinRequests;
                gamerProfile.TeamInvitations = entity.TeamInvitations;
                gamerProfile.ApplicationUser = entity.ApplicationUser;

                return Context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public List<Position> GetPositionsList()
        {
            return Context.Positions.ToList();
        }

        public List<League> GetLeaguesList()
        {
            return Context.Leagues.ToList();
        }

        public List<Region> GetRegionsList()
        {
            return Context.Regions.ToList();
        }

        public List<Champion> GetChampionsList()
        {
            return Context.Champions.ToList();
        }

        public List<Image> GetPortraits()
        {
            return Context.Images.Where(img => img.ImageType == ImageType.PlayerIcon).ToList();
        }

        public string GetLeagueLogoUrl(int leagueId)
        {
            return Context.Leagues.Include("Logo").First(i => i.LeagueValue == leagueId).Logo.Url;
        }

        public string GetDivisionName(int leagueId)
        {
            return Context.Leagues.Include("Logo").First(i => i.LeagueValue == leagueId).Name;
        }
    }
}