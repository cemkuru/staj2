using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abis.Mbs.Business.Abstract;
using Abis.Mbs.Entities.Concrete;
using Abis.Mbs.MvcWebUI.Areas.User.Models;
using Abis.Mbs.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Abis.Mbs.MvcWebUI.Controllers
{
    public class JobFormController : Controller
    {
        private IJobFormService _jobformService;

        public JobFormController(IJobFormService jobformService)
        {
            _jobformService = jobformService;
        }

        

        public ActionResult Index()
        {

            var jobforms = _jobformService.GetAll();
            JobFormListViewModel model = new JobFormListViewModel
            {
                JobForms = jobforms
            };
            return View(model);
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