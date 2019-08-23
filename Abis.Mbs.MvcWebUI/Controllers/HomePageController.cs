using Abis.Mbs.Business.Abstract;
using Abis.Mbs.MvcWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Abis.Mbs.MvcWebUI.Controllers
{
    [AllowAnonymous]

    public class HomePageController : Controller
    {
        

        private IAnnouncementService _announcementService;
        public HomePageController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        [AllowAnonymous]
        public IActionResult Index(int page = 1)
        {
            int pageSize = 3;
            var announcements = _announcementService.GetAll();

            var model = new AnnouncementListViewModel
            {
                Announcements = announcements.Skip((page - 1) * pageSize).Take(pageSize).ToList()
            };
            return View(model);

        }

        public ActionResult Details(int id)
        {

            var announcements = _announcementService.GetById(id);
            var  model = new Areas.User.Models.AnnouncementViewModel
            {
                Announcement = announcements
            };

            return View(model);
        }

        public IActionResult Announcements()
        {
            return View();
        }
    }
}