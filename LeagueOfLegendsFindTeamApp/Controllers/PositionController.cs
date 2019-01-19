using System.Collections.Generic;
using System.Web.Mvc;
using LeagueOfLegendsFindTeamApp.Models.DatabaseModels;
using LeagueOfLegendsFindTeamApp.Repository;

namespace LeagueOfLegendsFindTeamApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PositionController : Controller
    {
        private readonly IRepository<Position, int> _repository;

        public PositionController(IRepository<Position, int> repository)
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
            IEnumerable<Position> positions = _repository.GetAll();

            return PartialView("_TablePartialView", positions);
        }

        [HttpPost]
        public ActionResult AddNewPosition(Position position)
        {
            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    _repository.Add(position);
                }
                else return PartialView("_CreateNewPartialView", position);
            }

            return PartialView("_TablePartialView", _repository.GetAll());
        }

        [HttpGet]
        public ActionResult GetCreateNewPartialView()
        {
            return PartialView("_CreateNewPartialView", new Position());
        }

        [HttpGet]
        public ActionResult GetModificationPartialView(int positionId)
        {
            return PartialView("_ModificationPartialView", _repository.Get(positionId));
        }

        [HttpPost]
        public ActionResult ModifyPosition(Position position)
        {
            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    _repository.Update(position);
                }
                else return PartialView("_ModificationPartialView", position);
            }

            return PartialView("_TablePartialView", _repository.GetAll());
        }

        [HttpGet]
        public ActionResult RemovePosition(int positionId)
        {
            _repository.Remove(positionId);

            return PartialView("_TablePartialView", _repository.GetAll());
        }
    }
}