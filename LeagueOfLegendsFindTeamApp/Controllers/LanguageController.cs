using System.Web.Mvc;

namespace LeagueOfLegendsFindTeamApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LanguageController : Controller
    {
        // GET: Language
        [HttpGet]
        public ActionResult Management()
        {
            return View();
        }
    }
}