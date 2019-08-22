using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abis.Mbs.Business.Abstract;
using Abis.Mbs.Entities.Concrete;
using Abis.Mbs.MvcWebUI.Areas.Admin.Models;
using Abis.Mbs.MvcWebUI.Areas.User.Models;
using Abis.Mbs.MvcWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Abis.Mbs.MvcWebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]

    public class JobFormController : Controller
    {
        private IJobFormService _jobformService;

        public JobFormController(IJobFormService jobformService)
        {
            _jobformService = jobformService;
        }


        public ActionResult JobFormIndex()
        {

            var jobforms = _jobformService.GetAll();
            JobFormListViewModel model = new JobFormListViewModel
            {
                JobForms = jobforms
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
        //public ActionResult Detail(int id)
        //{

        //    var jobforms = _jobformService.GetById(id);
        //    JobFormViewModel model = new JobFormViewModel
        //    {
        //        JobForm = jobforms
        //    };
        //    return View(model);
        //}

    }
}