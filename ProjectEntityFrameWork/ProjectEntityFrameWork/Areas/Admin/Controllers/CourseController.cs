using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectEntityFrameWork.Areas.Admin.Models;
using ProjectEntityFrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProjectEntityFrameWork.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy  = "AdminandTeacherAccess") ] //Authorize Roll and policy egular name add kora jaay 
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;
        public CourseController(ILogger<CourseController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            ViewBag.SomeData = "All availabe Courses";
            var model = new CourseListModel();
            return View(model);
        }

        public JsonResult GetCourseData()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = new CourseListModel();
            var data = model.GetCourses(dataTableModel);
            return Json(data);
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

        public IActionResult Edit(int id)
        {
            var model = new EditCourseModel();
            model.LoadModelData(id);
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditCourseModel model)
        {
           if(ModelState.IsValid)
            {
                try
                {
                    model.Update();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Cann't Edit Course");
                    _logger.LogError(ex, "Course Edition Failed");
                }
            }
            //  return RedirectToAction(nameof(Index));
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int Id)
        {
            var model = new CourseListModel();
            model.Delete(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
