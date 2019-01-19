using System.Collections.Generic;
using System.Web.Mvc;
using LeagueOfLegendsFindTeamApp.Models.DatabaseModels;
using LeagueOfLegendsFindTeamApp.Repository;

namespace LeagueOfLegendsFindTeamApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RegionController : Controller
    {
        private readonly IRepository<Region, int> _repository;

        public RegionController(IRepository<Region, int> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult Management()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTable()
        {
            IEnumerable<Region> regions = _repository.GetAll();

            return PartialView("_TablePartialView", regions);
        }

        [HttpPost]
        public ActionResult AddNewRegion(Region region)
        {
            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    _repository.Add(region);
                }
                else return PartialView("_CreateNewPartialView", region);
            }

            return PartialView("_TablePartialView", _repository.GetAll());
        }

        [HttpGet]
        public ActionResult GetCreateNewPartialView()
        {
            return PartialView("_CreateNewPartialView", new Region());
        }

        [HttpGet]
        public ActionResult GetModificationPartialView(int regionId)
        {
            return PartialView("_ModificationPartialView", _repository.Get(regionId));
        }

        [HttpPost]
        public ActionResult ModifyRegion(Region region)
        {
            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    _repository.Update(region);
                }
                else return PartialView("_ModificationPartialView", region);
            }

            return PartialView("_TablePartialView", _repository.GetAll());
        }

        [HttpGet]
        public ActionResult RemoveRegion(int regionId)
        {
            _repository.Remove(regionId);

            return PartialView("_TablePartialView", _repository.GetAll());
        }
    }
}