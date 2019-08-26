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
    public class RegistrationController : Controller
    {
        private UserManager<CustomIdentityUser> _userManager;
        private RoleManager<CustomIdentityRole> _roleManager;
        private SignInManager<CustomIdentityUser> _signInManager;
        public RegistrationController
           (UserManager<CustomIdentityUser> userManager,
           RoleManager<CustomIdentityRole> roleManager,
           SignInManager<CustomIdentityUser> signInManager
           )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
           

        }
       
        public IActionResult Index()
        {
            var users=  _userManager.Users.ToList();
            return View(users);
        }

        public ActionResult Add()
        {
            var user = new CustomIdentityUser();

            return View();   
        }
        [HttpPost]
        public ActionResult Add(CustomIdentityUser customIdentityUser)
        {
            if (ModelState.IsValid)
            {
                _userManager.CreateAsync(customIdentityUser);
            }
            return RedirectToAction("Index/Registration",new { area = "Admin"}) ;
        }

        public ActionResult Update(int UserId)
        {
            var user = new CustomIdentityUser();

            return View();
            
        }

        [HttpPost]
        public ActionResult Update(CustomIdentityUser customIdentityUser)
        {
            if (ModelState.IsValid)
            {
                _userManager.UpdateAsync(customIdentityUser);

            }
            var user = new CustomIdentityUser();

            return RedirectToAction("Index", new { area = "Admin" });

        }

        public ActionResult Delete(CustomIdentityUser UserId)
        {
            _userManager.DeleteAsync(UserId);

            TempData["deletejobmessage"] = "Job has been deleted sucessfully";
            return RedirectToAction("Index", new { area = "Admin" });
        }

        //var model = new JobAddViewModel
        //{
        //    Job = new Job(),
        //};
        //    return View(model);
        //[HttpPost]
        //public ActionResult Add(CustomIdentityUser registration)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        var users = _userManager.CreateAsync(users);
        //        //_registrationService.Add(registration);
        //        //TempData.Add("message", "Registration was successfully added");
        //    }

        //    return RedirectToAction("Index");
        //}

        //public ActionResult Update(int registerId)
        //{
        //    //var model = new RegistrationUpdateViewModel
        //    //{
        //    //    REGISTRATION = _registrationService.GetById(registerId),

        //    //};

        //    return View(model);

        //}

        //[HttpPost]
        //public ActionResult Update(REGISTRATION registration)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _registrationService.Update(registration);
        //        TempData.Add("message", "Registration was successfully updated!");
        //    }

        //    return RedirectToAction("Index");
        //}

        //public ActionResult Delete(int registerId)
        //{
        //    _registrationService.Delete(registerId);
        //    TempData.Add("message", "Registration was successfully deleted");
        //    return RedirectToAction("Index");
        //}

    }
}