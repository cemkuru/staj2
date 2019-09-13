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
using System.Linq;

namespace Abis.Mbs.MvcWebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class JobController : Controller
    {
        
        private IJobService _jobService;
        private ICompanyService _companyService;

        public JobController(IJobService jobService, ICompanyService companyService)
        {
            _jobService = jobService;
            _companyService = companyService;

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
            var jobs = _jobService.GetAll();
            var companies = _companyService.GetAll();
            var model = new JobAddViewModel
            {
                Companies = companies, 
                Job = new Job(),

            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Job job)
        {
            if (ModelState.IsValid)
            {

                _jobService.Add(job);
                

                TempData["addjobmessage"] = "Job has been added sucessfully";
                return RedirectToAction("Index", new { area = "Admin" });

            }
            JobAddViewModel model = new JobAddViewModel()
            {
                Job = job,
                Companies = _companyService.GetAll()

            };

            return View(model);
        }


        public ActionResult Update(int JobId)
        {
            Job job = _jobService.GetById(JobId);
            JobUpdateViewModel model = new JobUpdateViewModel();
            model.Job = job;
            model.CompanyID = job.CompanyID;
           
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(Job job)
        {
            if (ModelState.IsValid)
            {
                //Job iş = _jobService.GetAll().FirstOrDefault(x=> x.CompanyID.Equals())  
                //_jobService.Update(job);

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