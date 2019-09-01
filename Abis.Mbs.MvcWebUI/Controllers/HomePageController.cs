using Abis.Mbs.Business.Abstract;
using Abis.Mbs.MvcWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Abis.Mbs.MvcWebUI.Controllers
{
    [AllowAnonymous]

    public class HomePageController : Controller
    {


        private IAnnouncementService _announcementService;
        private IDepartmentService _departmentService;

        public HomePageController(IAnnouncementService announcementService,IDepartmentService departmentService)
        {
            _announcementService = announcementService;
            _departmentService = departmentService;
        }


        [AllowAnonymous]
        public ActionResult Index(int page = 1)
        {
            int pageSize = 3;
            var announcements = _announcementService.GetAll();
            //var salecategories = PopulateSaleCategory();
            //return View(salecategories);
            AnnouncementListViewModel model = new AnnouncementListViewModel
            {
                 
                Announcements = announcements.Skip((page - 1) * pageSize).Take(pageSize).ToList()


            };
            return View(model);


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

        public ActionResult Details(int id)
        {

            var announcements = _announcementService.GetById(id);
            AnnouncementViewModel model = new AnnouncementViewModel
            {
                Announcement = announcements
            };

            return View(model);
        }

        public IActionResult Announcements()
        {
            return View();
        }
    }
}