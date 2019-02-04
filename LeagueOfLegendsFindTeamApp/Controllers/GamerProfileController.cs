using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LeagueOfLegendsFindTeamApp.Models.DatabaseModels;
using LeagueOfLegendsFindTeamApp.Repository;

namespace LeagueOfLegendsFindTeamApp.Controllers
{
    //[Authorize]
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
            var profile = _repository.GetAll().First();
            return View(profile);
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