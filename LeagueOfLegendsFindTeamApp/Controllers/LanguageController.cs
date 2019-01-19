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
         
            return PartialView("_TablePartialView", _repository.GetAll());
        }

        [HttpGet]
        public ActionResult GetCreateNewPartialView()
        {
            return PartialView("_CreateNewPartialView", new Language());
        }

        [HttpGet]
        public ActionResult GetModificationPartialView(int languageId)
        {
            Language language = _repository.Get(languageId);
            
            return PartialView("_ModificationPartialView", language);
        }

        [HttpPost]
        public ActionResult ModifyLanguage(Language language)
        {
            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    _repository.Update(language);
                }
                else return PartialView("_ModificationPartialView", language);
            }
          
            return PartialView("_TablePartialView", _repository.GetAll());
        }

        [HttpGet]
        public ActionResult RemoveLanguage(int languageId)
        {
           _repository.Remove(languageId);

            return PartialView("_TablePartialView", _repository.GetAll());
        }
    }
}