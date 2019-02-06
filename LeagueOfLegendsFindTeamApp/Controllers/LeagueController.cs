using System;
using System.Linq;
using System.Web.Mvc;
using LeagueOfLegendsFindTeamApp.Models.DatabaseModels;
using LeagueOfLegendsFindTeamApp.Repository;

namespace LeagueOfLegendsFindTeamApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LeagueController : Controller
    {
        private readonly IRepository<League, int> _repository;
        private readonly IRepository<Image, int> _imageRepository;


        public LeagueController(IRepository<League, int> repository, IRepository<Image, int> imageRepository)
        {
            _repository = repository;
            _imageRepository = imageRepository;
        }

        [HttpGet]
        public ActionResult Management()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetLeaguesPartialView()
        {
            return PartialView("_LeaguesPartialView", _repository.GetAll());
        }

        [HttpGet]
        public ActionResult GetModificationPartialView(int leagueId)
        {
            return PartialView("_ModificationPartialView", _repository.Get(leagueId));
        }

        [HttpGet]
        public ActionResult GetSelectImagePartialView()
        {
            var images = _imageRepository.GetAll().Where(i => i.ImageType == ImageType.DivisionIcon).ToList();

            return PartialView("_SelectImagePartialView", images);
        }

        [HttpPost]
        public ActionResult UpdateLeague(League league)
        {
            league.Logo = _imageRepository.Get(league.Logo.ImageId);

            if (ModelState.IsValid)
            {
                _repository.Update(league);

                return RedirectToAction("GetLeaguesPartialView");
            }

            return PartialView("_ModificationPartialView", league);
        }

        [HttpGet]
        public ActionResult RemoveLeague(int leagueId)
        {
            _repository.Remove(leagueId);

            return RedirectToAction("GetLeaguesPartialView");
        }

        [HttpGet]
        public ActionResult GetCreatePartialView()
        {
            var league = new League()
            {
                Logo = new Image()
            };
            return PartialView("_CreatePartialView", league);
        }

        [HttpPost]
        public ActionResult CreateLeague(League league)
        {
            try
            {
                league.Logo = _imageRepository.Get(league.Logo.ImageId);
                ModelState.Clear();
                TryValidateModel(league);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
                ModelState.AddModelError("", @"You have to select logo");
            }

            
            if (ModelState.IsValid)
            {
                _repository.Add(league);

                return RedirectToAction("GetLeaguesPartialView");
            }

            return PartialView("_CreatePartialView", league);
        }
    }
}