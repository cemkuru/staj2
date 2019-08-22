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
    public class JobController : Controller
    {
        
        private IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        public ActionResult Index()
        {
            var jobListViewModel = new JobListViewModel
            {
                Jobs = _jobService.GetAll()
            };
            return View(jobListViewModel);
        }
     


        public ActionResult Add()
        {
            var model = new JobAddViewModel
            {
                Job = new Job(),
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Job(Job job)
        {
            if (ModelState.IsValid)
            {
                _jobService.Add(job);

                TempData["addjobmessage"] = "Job has been added sucessfully";
            }
            return RedirectToAction("Index", new { area = "Admin" });
        }


        public ActionResult Update(int JobId)
        {
            var model = new JobUpdateViewModel
            {
                Job = _jobService.GetById(JobId),
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(Job job)
        {
            if (ModelState.IsValid)
            {
                _jobService.Update(job);

                TempData["updatejobmessage"] = "Job has been updated sucessfully";
            }
            return RedirectToAction("Index", new { area = "Admin" });
        }


        public ActionResult Delete(int JobId)
        {
            _jobService.Delete(JobId);

            TempData["deletejobmessage"] = "Job has been deleted sucessfully";
            return RedirectToAction("Index", new { area = "Admin" });
        }

    }
}