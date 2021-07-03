using Microsoft.AspNetCore.Mvc;
using ProjectEntityFrameWork.Areas.Admin.Models;
using ProjectEntityFrameWork.Training.Services;
using ProjectEntityFrameWork.Training.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEntityFrameWork.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        public IActionResult Course()
        {
            var model = new CourseListModel();
            model.LoadModelData();
            return View(model);
        }
    }
}
