using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abis.Mbs.Business.Abstract;
using Abis.Mbs.Entities.Concrete;
using Abis.Mbs.MvcWebUI.Areas.Admin.Models;
using Abis.Mbs.MvcWebUI.Areas.User.Models;
using Abis.Mbs.MvcWebUI.Entities;
using Abis.Mbs.MvcWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Abis.Mbs.MvcWebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]

    public class JobFormController : Controller
    {
        private readonly UserManager<CustomIdentityUser> _userManager;

        private IJobFormService _jobformService;



        public JobFormController(IJobFormService jobformService, UserManager<CustomIdentityUser> userManager)
        {
            _jobformService = jobformService;
            _userManager = userManager;
        }


        public ActionResult JobFormIndex()
        {
            string username = User.Identity.Name;
            CustomIdentityUser user = _userManager.FindByNameAsync(username).Result;

            var jobforms = _jobformService.GetAllWithIncludeJob();
            JobFormListViewModel model = new JobFormListViewModel
            {
                JobForms = jobforms,
                CustomIdentityUser = user
            };
            return View(model);
        }

        public ActionResult AddJobForm()
        {
            var model = new JobFormAddViewModel
            {
                JobForm = new JobForm(),
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddJobForm(JobForm jobform)
        {
            if (ModelState.IsValid)
            {
                _jobformService.Add(jobform);

                TempData["applicationMessage"] = "Your application has been sent sucessfully";
            }
            return RedirectToAction("JobFormIndex", new { area = "User" });
        }
       

    }
}