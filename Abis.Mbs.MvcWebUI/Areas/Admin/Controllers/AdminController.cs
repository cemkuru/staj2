using Abis.Mbs.Business.Abstract;
using Abis.Mbs.Entities.Concrete;
using Abis.Mbs.MvcWebUI.Areas.Admin.Models;
using Abis.Mbs.MvcWebUI.Areas.User.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Abis.Mbs.MvcWebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    //[Route("admin")]
    public class AdminController : Controller
    {
        private IAnnouncementService _announcementService;
        // Add Job Announcement Service
        private IJobService _jobService;
        // Addd job application form
        private IJobFormService _jobformService;
        

        public AdminController(IAnnouncementService announcementService,
                            ICategoryService categoryService,
                            IJobService jobService,
                            IJobFormService jobformService)
        {
            _announcementService = announcementService;
            _jobService = jobService;
            _jobformService = jobformService;
        }

        //Job Index
        public ActionResult JobIndex()
        {
            var jobListViewModel = new JobListViewModel
            {
                Jobs = _jobService.GetAll()
            };
            return View(jobListViewModel);
        }
      //End Job Index  


        //Add Job
        public ActionResult AddJob()
        {
            var model = new JobAddViewModel
            {
                Job = new Job(),
            };
            return View(model);
        }
        // POST/Add Job
        [HttpPost]
        public ActionResult AddJob(Job job)
        {
            if (ModelState.IsValid)
            {
                _jobService.Add(job);

                TempData["addjobmessage"] = "Job has been added sucessfully";
            }
            return RedirectToAction("JobIndex", new { area = "Admin" });
        }
        //End Add Job


        // Update Job
        public ActionResult UpdateJob(int JobId)
        {
            var model = new JobUpdateViewModel
            {
                Job = _jobService.GetById(JobId),
            };
            return View(model);
        }
        // POST/Update Job
        [HttpPost]
        public ActionResult UpdateJob(Job job)
        {
            if (ModelState.IsValid)
            {
                _jobService.Update(job);

                TempData["updatejobmessage"] = "Job has been updated sucessfully";
            }
            return RedirectToAction("JobIndex", new { area = "Admin" });
        }
        //End Update Job


        //Delete Job
        public ActionResult DeleteJob(int JobId)
        {
            _jobService.Delete(JobId);

            TempData["deletejobmessage"] = "Job has been deleted sucessfully";
            return RedirectToAction("JobIndex", new { area = "Admin" });
        }
        //End Delete Job


        // Announcement Index
        public ActionResult Index()
        {

            var model = new ReportViewModel
            {
                JobCount = _jobformService.GetAll().Count(),
                AnnouncementCount = _announcementService.GetAll().Count()

            };
            return View(model);


          
        }

        // Add Announcement
        //[Route("[action]/Add")]
        public ActionResult Add()
        {
            var model = new AnnouncementAddViewModel
            {
                Announcement = new Announcement(),
                
            }; 
            return View(model);
        }
        //,IFormFile image1
        [HttpPost]
        public ActionResult Add(Announcement announcement)
        {
           
            if (ModelState.IsValid)
            {
                _announcementService.Add(announcement);

                TempData.Add("message", "Announcement was successfully added");
            }

            return RedirectToAction("Index", new { area = "Admin" });


           
        }

        public ActionResult Update(int announcementId)
            {
            var model = new AnnouncementUpdateViewModel
            {
                Announcement = _announcementService.GetById(announcementId),
                
            };

            return View(model);

        }

        [HttpPost]
        public ActionResult Update(Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                _announcementService.Update(announcement);
                TempData.Add("message", "Announcement was successfully updated");
            }

            return RedirectToAction("Index", new { area = "Admin"});
        }
        // Delete Announcement
        public ActionResult Delete(int announcementId)
        {
            _announcementService.Delete(announcementId);
            TempData.Add("message", "Announcement was successfully deleted");
            return RedirectToAction("Index", new { area = "Admin" });
        }




        // Job Form Index

        public ActionResult JobFormIndex()
        {
            var jobFormListViewModel = new JobFormListViewModel
            {
                JobForms = _jobformService.GetAll()
            };
            return View(jobFormListViewModel);
        }

        




    }
}
