using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abis.Mbs.MvcWebUI.Models;
using Abis.Mbs.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Abis.Mbs.MvcWebUI.Areas.User.Models;

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
            AnnouncementListViewModel model = new AnnouncementListViewModel
            {
                Announcements = announcements
            };
            return View(model);
           
        }

        public ActionResult Details(int id)
        {

            var announcements = _announcementService.GetById(id);
            AnnouncementViewModel model = new AnnouncementViewModel
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
