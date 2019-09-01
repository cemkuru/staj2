using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abis.Mbs.Business.Abstract;
using Abis.Mbs.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Abis.Mbs.MvcWebUI.Controllers
{
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

        private DepartmentModel PopulateSaleCategory()
        {
            var departments1 = _departmentService.GetAll();
            DepartmentModel model = new DepartmentModel
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
    }
}