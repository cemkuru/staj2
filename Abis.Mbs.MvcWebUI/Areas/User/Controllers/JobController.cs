using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abis.Mbs.Business.Abstract;
using Abis.Mbs.MvcWebUI.Areas.User.Models;
using Abis.Mbs.MvcWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Abis.Mbs.MvcWebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User,Admin")]
    [Area("User")]

    public class JobController : Controller
    {
        private IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        public ActionResult Index( string searchString)
        {
            // Use LINQ to get list of genres.


            var jobList = new JobListViewModel();

            if (!string.IsNullOrEmpty(searchString))
            {

                jobList.Jobs.AddRange(_jobService.GetAll().Where(w => w.Area.ToLower().Contains(searchString.ToLower())));
            }
            else
            {
                jobList.Jobs.AddRange(_jobService.GetAll());
            }

            return View(jobList);
        }



        public ActionResult Details(int id)
        {
            var jobs = _jobService.GetById(id);
            JobViewModel model = new JobViewModel
            {
                Job = jobs
            };
            return View(model);
        }
       

    }
}