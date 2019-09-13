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

namespace Abis.Mbs.MvcWebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class ApplicationController : Controller
    {
        private readonly UserManager<CustomIdentityUser> _userManager;
        private readonly IApplicationService _applicationService;
        private readonly IJobService _jobService;
        private readonly IUserProfileService _userProfileService;





        public ApplicationController(UserManager<CustomIdentityUser> userManager,
                                    IApplicationService applicationService,
                                    IJobService jobService,
                                    IUserProfileService userProfileService
                                   )
        {
            _userManager = userManager;
            _applicationService = applicationService;
            _jobService = jobService;
            _userProfileService = userProfileService;

        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Add(int Id)
        {
            string username = User.Identity.Name;
            CustomIdentityUser identityUser = _userManager.FindByNameAsync(username).Result;
            UserProfile user = _userProfileService.GetAll().FirstOrDefault(x => x.UserId.Equals(identityUser.Id));

            var job = _jobService.GetById(Id);
            var apps = _applicationService.GetAll();
            var a = new Application
            {
                JobID = job.JobID,
                UserId = user.ID,
                
            };
            _applicationService.Add(a);

            var model = new ApplicationAddViewModel
            {
                Applications = apps,
                Job = new Job(),

            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(JobViewModel job)
        {
            if (ModelState.IsValid)
            {
                string username = User.Identity.Name;
                CustomIdentityUser identityUser = _userManager.FindByNameAsync(username).Result;
                UserProfile user = _userProfileService.GetAll().FirstOrDefault(x => x.UserId.Equals(identityUser.Id));

                var a = new Application
                {
                    JobID = job.Job.JobID,
                    UserId = user.ID
                };
                _applicationService.Add(a);

                TempData["applicationMessage"] = "Your application has been sent sucessfully";
            }
            return RedirectToAction(" JobFormIndex", "JobForm", new { area = "User" });
        }
        public string GetUsername(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            return user.UserName; 
            //var user = _userProfileService.GetUserProfileById(id);
        }
        public string GetJob(int id)
        {
            var job = _jobService.GetById(id);
            return job.Department;
            //var user = _userProfileService.GetUserProfileById(id);
        }
    }
}
