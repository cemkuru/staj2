using Abis.Mbs.Business.Abstract;

using Abis.Mbs.MvcWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Abis.Mbs.MvcWebUI.Controllers
{
    [AllowAnonymous]

    public class HomeController : Controller
    {
        private IAnnouncementService _announcementService;
        public HomeController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }
        public IActionResult Index()
        {
            var announcements = _announcementService.GetAll();
            var model = new AnnouncementListViewModel
            {
                Announcements = announcements
            };
            return View(model);
           
        }

        public ActionResult Details(int id)
        {

            var announcements = _announcementService.GetById(id);
            var  model = new AnnouncementViewModel
            {
                Announcement = announcements
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Announcements()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
