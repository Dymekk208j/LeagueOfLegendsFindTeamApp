using System.Collections.Generic;
using System.Web.Mvc;
using LeagueOfLegendsFindTeamApp.Models.DatabaseModels;
using LeagueOfLegendsFindTeamApp.Repository;

namespace LeagueOfLegendsFindTeamApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LanguageController : Controller
    {
        private readonly IRepository<Language, int> _repository;

        public LanguageController(IRepository<Language, int> repository)
        {
            _repository = repository;
        }


        // GET: Language
        [HttpGet]
        public ActionResult Management()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTable()
        {
            IEnumerable<Language> languages = _repository.GetAll();

            return PartialView("_TablePartialView", languages);
        }
        
        [HttpPost]
        public ActionResult AddNewLanguage(Language language)
        {
            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    _repository.Add(language);
                }
                else return PartialView("_CreateNewPartialView", language);
            }
            IEnumerable<Language> languages = _repository.GetAll();
            return PartialView("_TablePartialView", languages);
        }

        [HttpGet]
        public ActionResult GetCreateNewPartialView()
        {
            return PartialView("_CreateNewPartialView", new Language());
        }
    }
}