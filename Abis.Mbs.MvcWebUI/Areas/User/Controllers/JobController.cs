using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abis.Core.DataAccess.EntityFramework;
using Abis.Mbs.Business.Abstract;
using Abis.Mbs.MvcWebUI.Areas.User.Models;
using Abis.Mbs.MvcWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Abis.Mbs.MvcWebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User,Admin")]
    [Area("User")]

    public class JobController : Controller
    {
        private IJobService _jobService;
        private ICompanyService _companyService;
        public JobController(IJobService jobService, ICompanyService companyService)
        {
            _jobService = jobService;
            _companyService = companyService;
        }

        public ActionResult Index( string searchString)
        {
            var jobs =  _jobService.GetAll();
            var companies = _companyService.GetAll();


            if (!string.IsNullOrEmpty(searchString))
            {
                jobs = jobs.Where(w => w.Position.ToLower().Contains(searchString.ToLower())).ToList(); 
            }

            var jobList = new JobListViewModel()
            { 
                 Jobs = jobs,

            };
            
            return View(jobList);
        }



        public ActionResult Details(int id)
        {
            var jobs = _jobService.GetById(id);
            var companies = _companyService.GetById(jobs.CompanyID);
            JobViewModel model = new JobViewModel
            {
                Job = jobs,
                Company = companies
                
            };
            return View(model);
        }
       

    }
}