using ForEntityFrameWork.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForEntityFrameWork.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            var model = new TeacherListModel();
            model.GetAll();
            return View(model);
        }
    }
}
