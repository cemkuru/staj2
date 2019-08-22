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

    public class JobFormController : Controller
    {
        private IJobFormService _jobformService;

        public JobFormController(IJobFormService jobformService)
        {
            _jobformService = jobformService;
        }

        public ActionResult Index()
        {
            var jobFormListViewModel = new JobFormListViewModel
            {
                JobForms = _jobformService.GetAll()
            };
            return View(jobFormListViewModel);
        }
    }
}