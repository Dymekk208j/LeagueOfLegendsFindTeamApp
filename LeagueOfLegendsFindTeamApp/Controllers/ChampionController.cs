using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LeagueOfLegendsFindTeamApp.Models.DatabaseModels;
using LeagueOfLegendsFindTeamApp.Repository;

namespace LeagueOfLegendsFindTeamApp.Controllers
{
    public class ChampionController : Controller
    {
        private readonly IRepository<Champion, int> _championRepository;
        private readonly IRepository<Image, int> _imageRepository;


        public ChampionController(IRepository<Champion, int> championRepository, IRepository<Image, int> imageRepository)
        {
            _championRepository = championRepository;
            _imageRepository = imageRepository;
        }
        public ActionResult Management()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTablePartialView()
        {
            IEnumerable<Champion> champions = _championRepository.GetAll();

            return PartialView("_TablePartialView", champions);
        }

        [HttpGet]
        public ActionResult GetSelectPortraitPartialView()
        {
            var images = _imageRepository.GetAll().Where(i => i.ImageType == ImageType.ChampionPortrait).ToList();

            return PartialView("_SelectPortraitPartialView", images);
        }

        [HttpGet]
        public ActionResult GetSelectIconPartialView()
        {
            var images = _imageRepository.GetAll().Where(i => i.ImageType == ImageType.ChampionIcon).ToList();

            return PartialView("_SelectIconPartialView", images);
        }

        [HttpGet]
        public ActionResult GetCreatePartialView()
        {
            var champion = new Champion()
            {
                Icon = new Image(),
                Portrait = new Image()
            };

            return PartialView("_CreatePartialView", champion);
        }
    }
}