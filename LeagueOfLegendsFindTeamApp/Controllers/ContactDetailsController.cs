using System.Web.Mvc;
using LeagueOfLegendsFindTeamApp.Models.DatabaseModels;
using LeagueOfLegendsFindTeamApp.Repository;
using Microsoft.AspNet.Identity;

namespace LeagueOfLegendsFindTeamApp.Controllers
{
    [Authorize]
    public class ContactDetailsController : Controller
    {

        private readonly ContactRepository _contactRepository;

        public ContactDetailsController(ContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public ActionResult Management()
        {
            var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            var contactDetails = _contactRepository.Get(userId);

            return View(contactDetails);
        }

        [HttpPost]
        public ActionResult UpdateContactDetails(Contact contact)
        {
            _contactRepository.Update(contact);

            return View("Management", contact);
        }
    }
}