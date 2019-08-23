using Abis.Mbs.Business.Abstract;
using Abis.Mbs.MvcWebUI.Areas.User.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            var  model = new AnnouncementListViewModel
            {
                Announcements = announcements
            };
            return View(model);
        }

        public ActionResult Detial(int id) 
        {
           
            var announcements = _announcementService.GetById(id);
            var  model = new AnnouncementViewModel
            {
                Announcement = announcements
            };
          
            return View(model);
        }

    }
}
