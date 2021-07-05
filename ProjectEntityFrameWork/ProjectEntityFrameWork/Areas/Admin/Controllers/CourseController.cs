using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectEntityFrameWork.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEntityFrameWork.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;
        public CourseController(ILogger<CourseController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            var model = new CourseListModel();
            model.LoadModelData();
            return View(model);
        }

        public IActionResult Enroll()
        {
            var model = new EnrollStudentModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Enroll(EnrollStudentModel enrollStudentModel)
        {
            if(ModelState.IsValid)
            {
                enrollStudentModel.EnrollStudent();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(CreateCourseModel courseModel)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    courseModel.CreateCourse();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Failed To Create Course");
                    _logger.LogError(ex, "Course Creation Failed");
                }
            }
            return View();
        }

    }
}
