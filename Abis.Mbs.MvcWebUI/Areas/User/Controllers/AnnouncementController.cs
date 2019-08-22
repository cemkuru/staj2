    using Abis.Mbs.Business.Abstract;
using Abis.Mbs.MvcWebUI.Areas.User.Models;
using Abis.Mbs.MvcWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abis.Mbs.MvcWebUI.Areas.User.Controllers
{
    [Authorize (Roles = "User")]
    [Area("User")]
    public class AnnouncementController : Controller
    {
        private IAnnouncementService _announcementService;
        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public ActionResult Index(int page = 1)
        {

            var announcements = _announcementService.GetAll();
            AnnouncementListViewModel model = new AnnouncementListViewModel
            {
                Announcements = announcements
            };
            return View(model);
        }

        public ActionResult Detial(int id) 
        {
           
            var announcements = _announcementService.GetById(id);
            AnnouncementViewModel model = new AnnouncementViewModel
            {
                Announcement = announcements
            };
          
            return View(model);
        }

    }
}
