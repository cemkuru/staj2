using Abis.Mbs.Business.Abstract;
using Abis.Mbs.DataAccess.Concrete.EntityFramework;
using Abis.Mbs.Entities.Concrete;
using Abis.Mbs.MvcWebUI.Areas.Admin.Models;
using Abis.Mbs.MvcWebUI.Areas.User.Models;
using Abis.Mbs.MvcWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Abis.Mbs.MvcWebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    [Area("Admin")]

    public class AnnouncementController : Controller
    {
        private IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public ActionResult Index()
        {

            var announcementListViewModel = new AnnouncementListViewModel
            {
                Announcements = _announcementService.GetAll()
            };
            return View(announcementListViewModel);
        }

     
       
        public ActionResult Add()
        {
            var model = new AnnouncementAddViewModel
            {
                Announcement = new Announcement(),

            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Announcement announcement)
        {
            
            if (ModelState.IsValid)
            {
                _announcementService.Add(announcement);

                TempData.Add("message", "Announcement was successfully added");
            }

            return RedirectToAction("Index", new { area = "Admin" });



        }

        public ActionResult Update(int announcementId)
        {
            var model = new AnnouncementUpdateViewModel
            {
                Announcement = _announcementService.GetById(announcementId),

            };

            return View(model);

        }

        [HttpPost]
        public ActionResult Update(Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                _announcementService.Update(announcement);
                TempData.Add("message", "Announcement was successfully updated");
            }

            return RedirectToAction("Index", new { area = "Admin" });
        }
        public ActionResult Delete(int announcementId)
        {
            _announcementService.Delete(announcementId);
            TempData.Add("message", "Announcement was successfully deleted");
            return RedirectToAction("Index", new { area = "Admin" });
        }

    }
}