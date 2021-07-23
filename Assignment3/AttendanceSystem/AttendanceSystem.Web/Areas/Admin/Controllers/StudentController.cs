using AttendanceSystem.Web.Areas.Admin.Models.Students;
using AttendanceSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            var model = new StudentListModel();
            return View(model);
        }
        public JsonResult GetStudentData()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = new StudentListModel();
            var data = model.GetStudents(dataTableModel);
            return Json(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(CreateListModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.Create();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create student in list");
                    _logger.LogError(ex, "Student is not created");
                }
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var model = new EditListModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Edit(EditListModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.Update();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Failed to Edit Student");
                    _logger.LogError(ex, "Student edition Failed");
                }
            }
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new StudentListModel();
            model.DeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
