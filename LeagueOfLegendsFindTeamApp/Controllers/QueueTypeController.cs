using System.Collections.Generic;
using System.Web.Mvc;
using LeagueOfLegendsFindTeamApp.Models.DatabaseModels;
using LeagueOfLegendsFindTeamApp.Repository;

namespace LeagueOfLegendsFindTeamApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class QueueTypeController : Controller
    {
        private readonly IRepository<QueueType, int> _repository;

        public QueueTypeController(IRepository<QueueType, int> repository)
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
            IEnumerable<QueueType> queueTypes = _repository.GetAll();

            return PartialView("_TablePartialView", queueTypes);
        }

        [HttpPost]
        public ActionResult AddNewQueueType(QueueType queueType)
        {
            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    _repository.Add(queueType);
                }
                else return PartialView("_CreateNewPartialView", queueType);
            }

            return PartialView("_TablePartialView", _repository.GetAll());
        }

        [HttpGet]
        public ActionResult GetCreateNewPartialView()
        {
            return PartialView("_CreateNewPartialView", new QueueType());
        }

        [HttpGet]
        public ActionResult GetModificationPartialView(int queueId)
        {
            return PartialView("_ModificationPartialView", _repository.Get(queueId));
        }

        [HttpPost]
        public ActionResult ModifyQueueType(QueueType queueType)
        {
            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    _repository.Update(queueType);
                }
                else return PartialView("_ModificationPartialView", queueType);
            }

            return PartialView("_TablePartialView", _repository.GetAll());
        }

        [HttpGet]
        public ActionResult RemoveQueueType(int queueTypeId)
        {
            _repository.Remove(queueTypeId);

            return PartialView("_TablePartialView", _repository.GetAll());
        }
    }
}