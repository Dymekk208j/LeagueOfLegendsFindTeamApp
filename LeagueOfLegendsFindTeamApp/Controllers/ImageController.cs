using System.Linq;
using System.Web.Mvc;
using LeagueOfLegendsFindTeamApp.Models.DatabaseModels;
using LeagueOfLegendsFindTeamApp.Repository;

namespace LeagueOfLegendsFindTeamApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ImageController : Controller
    {
        private readonly IRepository<Image, int> _repository;

        public ImageController(IRepository<Image, int> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult Management()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetSelectCategoryPartialView()
        {
            return PartialView("_SelectCategoryPartialView");
        }

        [HttpGet]
        public ActionResult GetImageListPartialView(ImageType imageType)
        {
            return PartialView("_ImageListPartialView", _repository.GetAll().Where(r => r.ImageType == imageType).ToList());
        }

        [HttpPost]
        public ActionResult CreateImage(Image image)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(image);

                return PartialView("_SelectCategoryPartialView");
            }
            return PartialView("_CreateImagePartialView", image);
        }

        [HttpGet]
        public ActionResult GetCreateImagePartialView()
        {
            return PartialView("_CreateImagePartialView", new Image());
        }

        [HttpGet]
        public ActionResult GetModificationPartialView(int imageId)
        {
            return PartialView("_ModificationPartialView", _repository.Get(imageId));
        }

        [HttpPost]
        public ActionResult UpdateImage(Image image)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(image);

                return PartialView("_SelectCategoryPartialView");
            }else return PartialView("_ModificationPartialView", image);
        }

        [HttpGet]
        public ActionResult RemoveImage(int imageId)
        {
            if (ModelState.IsValid)
            {
                _repository.Remove(imageId);
            }

            return PartialView("_SelectCategoryPartialView");
        }
    }
}