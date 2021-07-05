using Microsoft.AspNetCore.Mvc;
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


    }
}
