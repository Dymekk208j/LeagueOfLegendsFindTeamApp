using LeagueOfLegendsFindTeamApp.Models.DatabaseModels;
using LeagueOfLegendsFindTeamApp.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueOfLegendsFindTeamApp.Controllers
{
    [Authorize]
    public class GamerProfileController : Controller
    {
        private readonly GamerProfileRepository _repository;

        public GamerProfileController(GamerProfileRepository gamerProfileRepository)
        {
            _repository = gamerProfileRepository;
        }

        [HttpGet]
        public ActionResult Management()
        {
            var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();

            var profile = _repository.GetAll().First(u => u.ApplicationUser.Id == userId);
            return View(profile);
        }

        [HttpPost]
        public ActionResult UpdateGamerProfile(GamerProfile gamerProfile)
        {
            gamerProfile.ApplicationUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            try
            {
                gamerProfile.Portrait = _repository.GetPortrait(gamerProfile.Portrait.ImageId);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
                ModelState.AddModelError("", @"You have to select portrait");
            }

            try
            {
                gamerProfile.PrimaryPosition = _repository.GetPosition(gamerProfile.PrimaryPosition.PositionId);
                gamerProfile.SecondaryPosition = _repository.GetPosition(gamerProfile.SecondaryPosition.PositionId);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
                ModelState.AddModelError("", @"You have to select positions");
            }

            try
            {
                gamerProfile.SoloQLeague = _repository.GetLeague(gamerProfile.SoloQLeague.LeagueId);
                gamerProfile.FlexLeague = _repository.GetLeague(gamerProfile.FlexLeague.LeagueId);
                gamerProfile.League3 = _repository.GetLeague(gamerProfile.League3.LeagueId);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
                ModelState.AddModelError("", @"You have to select leagues position");
            }

            try
            {
                gamerProfile.Region = _repository.GetRegion(gamerProfile.Region.RegionId);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
                ModelState.AddModelError("", @"You have to select leagues position");
            }

            ModelState.Clear();
            TryValidateModel(gamerProfile);

            if (ModelState.IsValid)
            {
                _repository.Update(gamerProfile);

                return RedirectToAction("Management");
            }

            return PartialView("Management", gamerProfile);
        }

        [HttpGet]
        public ActionResult GetSelectPositionsPartialView()
        {

            return PartialView("_SelectPositionsPartialView", _repository.GetPositionsList());
        }

        [HttpGet]
        public ActionResult GetRegionsPartialView()
        {
            return PartialView("_SelectRegionPartialView", _repository.GetRegionsList());
        }

        [HttpGet]
        public ActionResult GetPortraitSelectModalPartialView()
        {
            return PartialView("_SelectPortraitPartialView", _repository.GetPortraits());
        }

        [HttpGet]
        public List<League> GetLeaguesList()
        {
            return _repository.GetLeaguesList();
        }

        [HttpGet]
        public List<Champion> GetChampionsList()
        {
            return _repository.GetChampionsList();
        }

        [HttpGet]
        public string GetLeagueLogoUrl(int leagueId)
        {
            if (Request.IsAjaxRequest())
            {
                return _repository.GetLeagueLogoUrl(leagueId);
            }

            throw new Exception("Not ajax request in GetLeagueLogoUrl, league id == " + leagueId.ToString());
        }

        [HttpGet]
        public string GetDivisionName(int leagueId)
        {
            if (Request.IsAjaxRequest())
            {
                return _repository.GetDivisionName(leagueId);
            }

            throw new Exception("Not ajax request in GetLeagueLogoUrl, league id == " + leagueId.ToString());
        }
    }
}