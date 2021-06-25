using ForEntityFrameWork.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForEntityFrameWork.Areas.Admin.Controllers
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
