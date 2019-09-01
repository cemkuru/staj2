using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abis.Mbs.Business.Abstract;
using Abis.Mbs.Entities.Concrete;
using Abis.Mbs.MvcWebUI.Areas.User.Models;
using Abis.Mbs.MvcWebUI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Abis.Mbs.MvcWebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class UserProfileController : Controller
    {
        private readonly UserManager<CustomIdentityUser> _userManager;

        private IUserProfileService _userProfileService;

        //private readonly IApplicationUserService _applicationUserService;

        public UserProfileController(UserManager<CustomIdentityUser> userManager, IUserProfileService userProfileService)
        {
            _userManager = userManager;
            _userProfileService = userProfileService;
        }


     

        // Profile Details
        public ActionResult Details(int id)
        {
            string username = User.Identity.Name;
            CustomIdentityUser user = _userManager.FindByNameAsync(username).Result;
            var userProfile = _userProfileService.GetById(id);
            UserProfileViewModel model = new UserProfileViewModel()
            {
                UserProfile =  userProfile,
                CustomIdentityUser = user,               
                                 
            };
            //var userId = _userManager.GetUserId(HttpContext.User);
            //CustomIdentityUser user = _userManager.FindByIdAsync(userId).Result;
            //var profile = _userProfileService.GetAll().FirstOrDefault(u=> u.UserId == user.Id);
            //var model = new UserProfileViewModel()
            //{
            //    UserId =user.Id,
                
            //};

            return View(model);
        }

        // Create a Profile

        public ActionResult Create(UserProfileAddViewModel NewUser)
        {
            if (ModelState.IsValid)
            {
                var model = new UserProfile();
                //_userManager.CreateAsync(model);


            }
            return View(NewUser);
        }
        //GET: Edit Profile

        public ActionResult Edit(int id)
        {
            string username = User.Identity.Name;
            CustomIdentityUser user = _userManager.FindByNameAsync(username).Result;
            var userProfile = _userProfileService.GetById(id);

            UserProfileUpdateViewModel model = new UserProfileUpdateViewModel()
            {
                UserProfile = userProfile,
                CustomIdentityUser = user

            };

            return View(model);
        }

        //POST : Edit Profile
        [HttpPost]
        public ActionResult Edit(UserProfileUpdateViewModel userProfileViewModel)
        {
            if (ModelState.IsValid)
            {

                string username = User.Identity.Name;
                CustomIdentityUser identityUser = _userManager.FindByNameAsync(username).Result;
                _userManager.UpdateAsync(identityUser);
                var userProfile = _userProfileService.GetById(userProfileViewModel.UserProfile.ID);
               




                _userProfileService.Update(userProfile);
            }

            return RedirectToAction("Edit", new { area = "User" });
        }

        //Profile Index
        public ActionResult Index()
        {
            var userProfiles = _userProfileService.GetAll();
            UserProfileListViewModel model = new UserProfileListViewModel
            {
                UserProfiles = userProfiles
            };
            return View(model);
        }

        // Add Profile
        public ActionResult Add()
        {
            var model = new UserProfileAddViewModel
            {
                UserProfile = new UserProfile(),
            };
            return View(model);


        }

        // POST Add Profile
        [HttpPost]
        public ActionResult Add(UserProfile userProfile)
        {

            if (ModelState.IsValid)
            {

                _userProfileService.Add(userProfile);

                TempData["UserAddMessage"] = "Your application has been sent sucessfully";
            }

            return RedirectToAction("Index", new { area = "User" });


        }



        // Update Profile
        public ActionResult Update(int Id)
        {
            var model = new UserProfileUpdateViewModel
            {
                UserProfile = _userProfileService.GetById(Id)
            };
            return View(model);
        }

        //POST Update Profile
        [HttpPost]
        public ActionResult Update(UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                _userProfileService.Update(userProfile);
                TempData["UserUpdateMessage"] = "Your Profile has been update";
            }
            return RedirectToAction("Index", new { area = "User" });
        }

        // Delete Profile
        public ActionResult Delete(int Id)
        {
            _userProfileService.Delete(Id);

            TempData["UserDeleteMessage"] = "Your profile has been deleted";

            return RedirectToAction("Index", new { area = "User" });
        }
    }
}