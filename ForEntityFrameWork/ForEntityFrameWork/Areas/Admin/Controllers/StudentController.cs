using ForEntityFrameWork.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForEntityFrameWork.Areas.Admin.Controllers
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
            model.GetAll();
            return View(model);
        }
        public IActionResult Create()
        {
            var model = new CreateStudentList();
            return View(model);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(CreateStudentList createstudentModel)
        {
          if(ModelState.IsValid)
            {
                try
                {
                    createstudentModel.CreateStudent();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create Student");
                    _logger.LogError(ex, "Student Creation Failed");

                }
            }
            return View();
        }
    }
}
