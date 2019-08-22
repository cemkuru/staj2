using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abis.Mbs.Business.Abstract;
using Abis.Mbs.MvcWebUI.Areas.User.Models;
using Abis.Mbs.MvcWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Announcements()
        {
            return View();
        }
    }
}