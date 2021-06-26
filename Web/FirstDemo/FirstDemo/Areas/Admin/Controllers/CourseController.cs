using FirstDemo.Areas.Admin.Models;
using FristDemo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;

namespace FirstDemo.Areas.Admin.Controllers
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
    }
}
