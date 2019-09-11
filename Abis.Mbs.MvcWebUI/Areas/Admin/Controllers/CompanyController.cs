using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abis.Mbs.Business.Abstract;
using Abis.Mbs.Entities.Concrete;
using Abis.Mbs.MvcWebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Abis.Mbs.MvcWebUI.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private ICompanyService _companyService;

        public CompanyController( ICompanyService companyService)
        {
            _companyService = companyService;

        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {

            var model = new CompanyAddViewModel
            {
                Company = new Company(),
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Company company)
        {
            if (ModelState.IsValid)
            {

                _companyService.Add(company);


                TempData["addjobmessage"] = "Job has been added sucessfully";
                return RedirectToAction("Add" , new { area = "Admin" });

            }
            CompanyAddViewModel model = new CompanyAddViewModel()
            {
                Company = company,

            };

            return View(model);
        }


        public ActionResult Update(int CompanyId)
        {


            var model = new CompanyUpdateViewModel
            {
                Company = _companyService.GetById(CompanyId),

            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(Company company)
        {
            if (ModelState.IsValid)
            {
                _companyService.Update(company);

                TempData["updatejobmessage"] = "Job has been updated sucessfully";
            }
            return RedirectToAction("Add","Job", new { area = "Admin" });
        }


        public ActionResult Delete(int CompanyId)
        {
            _companyService.Delete(CompanyId);

            TempData["deletejobmessage"] = "Job has been deleted sucessfully";
            return RedirectToAction("Index", new { area = "Admin" });
        }
    }
}