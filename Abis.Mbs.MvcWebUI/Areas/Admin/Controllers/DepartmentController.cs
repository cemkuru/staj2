using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abis.Mbs.Business.Abstract;
using Abis.Mbs.Entities.Concrete;
using Abis.Mbs.MvcWebUI.Areas.Admin.Models;
using Abis.Mbs.MvcWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Abis.Mbs.MvcWebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    [Area("Admin")]
    public class DepartmentController : Controller
    {
        private IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var salecategories = PopulateSaleCategory();
            return View(salecategories);

        }

        private DepartmentListModel PopulateSaleCategory()
        {
            var departments1 = _departmentService.GetAll();
            DepartmentListModel model = new DepartmentListModel
            {
                Departments = departments1
            };
            return model;
        }

        public JsonResult GetChartData()
        {
            var sales = PopulateSaleCategory();
            var chartData = new object[sales.Departments.Count + 1];
            chartData[0] = new object[]{
            "Category",
            "Amount"
             };
            int j = 0;
            foreach (var i in sales.Departments)
            {
                j++;
                chartData[j] = new object[] { i.DepartmentName, i.Amount };
            }
            return new JsonResult(chartData);
        }

        public ActionResult Add()
        {
            var model = new DepartmentAddModel
            {
                Department = new Department(),

            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Department department)
        {

            if (ModelState.IsValid)
            {
                _departmentService.Add(department);

                //TempData.Add("message", "Announcement was successfully added");
            }

            return RedirectToAction("Index", new { area = "Admin" });



        }

        public ActionResult Update(int depId)
        {
            var model = new DepartmentAddModel
            {
                Department = _departmentService.GetById(depId),

            };

            return View(model);

        }

        [HttpPost]
        public ActionResult Update(Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentService.Update(department);
                //TempData.Add("message", "Announcement was successfully updated");
            }

            return RedirectToAction("Index", new { area = "Admin" });
        }

        public ActionResult Delete(int depId)
        {
            _departmentService.Delete(depId);
            //TempData.Add("message", "Announcement was successfully deleted");
            return RedirectToAction("Index", new { area = "Admin" });
        }
    }
}