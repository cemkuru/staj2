using System;
using System.IO;
using System.Linq;
using Abis.Mbs.Business.Abstract;
using Abis.Mbs.Entities.Concrete;
using Abis.Mbs.MvcWebUI.Areas.User.Models;
using Abis.Mbs.MvcWebUI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



namespace Abis.Mbs.MvcWebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class UserProfileController : Controller
    {
        private readonly UserManager<CustomIdentityUser> _userManager;
        private readonly IHostingEnvironment hostingEnvironment;
        private IUserProfileService _userProfileService;
        private IDepartmentService _departmentService;
        private ILanguageService _languageService;

       

        public UserProfileController(UserManager<CustomIdentityUser> userManager,
                                    IUserProfileService userProfileService,
                                    IDepartmentService departmentService,
                                    ILanguageService languageService,
                                    IHostingEnvironment environment)
        {
            _userManager = userManager;
            _userProfileService = userProfileService;
            _departmentService = departmentService;
            _languageService = languageService;
            hostingEnvironment = environment;
        }




        // Profile Details
        public ActionResult Details()
        {
           
            string username = User.Identity.Name;
            CustomIdentityUser user = _userManager.FindByNameAsync(username).Result;


            var userProfile = _userProfileService.GetAll().FirstOrDefault(x => x.UserId.Equals(user.Id));

            if (userProfile == null)
            {
                var profile = new UserProfile()
                {
                    UserId = user.Id,
                    DepId = 5,
                    LanguageID = 1
                };

                _userProfileService.Add(profile);
                userProfile = profile;

            }
            var departement = _departmentService.GetById(userProfile.DepId);
            var language = _languageService.GetById(userProfile.LanguageID);

            UserProfileViewModel model = new UserProfileViewModel()
            {
                UserProfile = userProfile,
                CustomIdentityUser = user,
                Department = departement,
                Language = language

            };

            return View(model);
        }
       

        //GET: Edit Profile
        public ActionResult Edit()
        {
            string username = User.Identity.Name;
            CustomIdentityUser identityUser = _userManager.FindByNameAsync(username).Result;
            //Fetch userProfile
            UserProfile user = _userProfileService.GetAll().FirstOrDefault(x => x.UserId.Equals(identityUser.Id));

            ////Construct the model
            UserProfileUpdateViewModel model = new UserProfileUpdateViewModel();
            model.UserProfile = user;
            model.DepId = user.DepId;
            model.LanguageID = user.LanguageID;
            model.Departments = _departmentService.GetAll();
            model.Languages = _languageService.GetAll();

            return View(model);
        }

        //POST : Edit Profile
        [HttpPost]
        public ActionResult Edit(UserProfileUpdateViewModel userProfileViewModel, IFormFile Photo)
        {

            if (ModelState.IsValid)
            {
                // Add User Photo to the profile
                var filename = string.Empty;                          
                // upload Photo
                if (Photo != null)
                {
                    // Find route path
                    filename = Path.Combine("UserImages", Guid.NewGuid() + Photo.FileName);
                    
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filename); //extract the filname of the pic
                    Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }


                // Editing Part...

                string username = User.Identity.Name;
                CustomIdentityUser identityUser = _userManager.FindByNameAsync(username).Result;

                //Get userProfile
                UserProfile user = _userProfileService.GetAll().FirstOrDefault(x => x.UserId.Equals(identityUser.Id));


                //user profile Id is connected to Logged in User
                user.UserId = identityUser.Id;

                //Update the profile
                user.Project = userProfileViewModel.UserProfile.Project;
                user.SKills = userProfileViewModel.UserProfile.SKills;
                user.DepId = userProfileViewModel.DepId;
                user.LanguageID = userProfileViewModel.LanguageID;
                user.Experience = userProfileViewModel.UserProfile.Experience;
                user.CGPA = userProfileViewModel.UserProfile.CGPA;
                user.Education = userProfileViewModel.UserProfile.Education; 
                user.UserPhoto = filename;
                _userProfileService.Update(user);

            }

            return RedirectToAction("Details", new { area = "User" });
        }



      
        //public ActionResult Index()
        //{
        //    HtmlToPdfConverter converter = new HtmlToPdfConverter();

        //    WebKitConverterSettings settings = new WebKitConverterSettings();

        //    settings.WebKitPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/QtBinariesWindows");
        //    converter.ConverterSettings = settings;

        //    PdfDocument document = converter.Convert("https://localhost:44375/User/UserProfile/Index");

        //    MemoryStream ms = new MemoryStream();
        //    document.Save(ms);
        //    document.Close(true);

        //    ms.Position = 0;

        //    FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");

        //    fileStreamResult.FileDownloadName = "UserProfile.pdf";

        //    return fileStreamResult;
        //}

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