using System.Linq;
using System.Web.Mvc;
using LeagueOfLegendsFindTeamApp.Models.DatabaseModels;
using LeagueOfLegendsFindTeamApp.Repository;

namespace LeagueOfLegendsFindTeamApp.Controllers
{
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

                return PartialView("_LeaguesPartialView", _repository.GetAll());
            }

            return PartialView("_ModificationPartialView", league);
        }

        [HttpGet]
        public ActionResult RemoveLeague(int leagueId)
        {
            _repository.Remove(leagueId);

            return PartialView("_LeaguesPartialView", _repository.GetAll());
        }
    }
}