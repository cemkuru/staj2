using Abis.Mbs.Entities.Concrete;
using Abis.Mbs.MvcWebUI.Areas.Admin.Models;
using Abis.Mbs.MvcWebUI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace Abis.Mbs.MvcWebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class RoleController : Controller
    {
        private UserManager<CustomIdentityUser> _userManager;
        private RoleManager<CustomIdentityRole> _roleManager;
        private SignInManager<CustomIdentityUser> _signInManager;
        public RoleController
           (UserManager<CustomIdentityUser> userManager,
           RoleManager<CustomIdentityRole> roleManager,
           SignInManager<CustomIdentityUser> signInManager
           )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;


        }

        //public IActionResult Index()
        //{
        //    var users = _userManager.Users.ToList();
        //    return View(users);
        //}


        //public ActionResult Add()
        //{
        //    var model = new AnnouncementAddViewModel
        //    {
        //        Announcement = new Announcement(),

        //    };
        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult Add(Announcement announcement)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        _announcementService.Add(announcement);

        //        TempData.Add("message", "Announcement was successfully added");
        //    }

        //    return RedirectToAction("Index", new { area = "Admin" });



        //}

        //public ActionResult Update(int announcementId)
        //{
        //    var model = new AnnouncementUpdateViewModel
        //    {
        //        Announcement = _announcementService.GetById(announcementId),

        //    };

        //    return View(model);

        //}

        //[HttpPost]
        //public ActionResult Update(Announcement announcement)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _announcementService.Update(announcement);
        //        TempData.Add("message", "Announcement was successfully updated");
        //    }

        //    return RedirectToAction("Index", new { area = "Admin" });
        //}
        //public ActionResult Delete(int announcementId)
        //{
        //    _announcementService.Delete(announcementId);
        //    TempData.Add("message", "Announcement was successfully deleted");
        //    return RedirectToAction("Index", new { area = "Admin" });
        //}

    }
}