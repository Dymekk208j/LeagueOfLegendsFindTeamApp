using System.Collections.Generic;
using System.Web.Mvc;
using LeagueOfLegendsFindTeamApp.Models.DatabaseModels;
using LeagueOfLegendsFindTeamApp.Repository;

namespace LeagueOfLegendsFindTeamApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TeamTypeController : Controller
    {
        private readonly IRepository<TeamType, int> _repository;

        public TeamTypeController(IRepository<TeamType, int> repository)
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
            IEnumerable<TeamType> teamTypes = _repository.GetAll();

            return PartialView("_TablePartialView", teamTypes);
        }

        [HttpPost]
        public ActionResult AddNewTeamType(TeamType teamType)
        {
            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    _repository.Add(teamType);
                }
                else return PartialView("_CreateNewPartialView", teamType);
            }

            return PartialView("_TablePartialView", _repository.GetAll());
        }

        [HttpGet]
        public ActionResult GetCreateNewPartialView()
        {
            return PartialView("_CreateNewPartialView", new TeamType());
        }

        [HttpGet]
        public ActionResult GetModificationPartialView(int teamTypeId)
        {
            return PartialView("_ModificationPartialView", _repository.Get(teamTypeId));
        }

        [HttpPost]
        public ActionResult ModifyTeamType(TeamType teamType)
        {
            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    _repository.Update(teamType);
                }
                else return PartialView("_ModificationPartialView", teamType);
            }

            return PartialView("_TablePartialView", _repository.GetAll());
        }

        [HttpGet]
        public ActionResult RemoveTeamType(int teamTypeId)
        {
            _repository.Remove(teamTypeId);

            return PartialView("_TablePartialView", _repository.GetAll());
        }
    }
}