﻿using FirstDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FirstDemo.Controllers
{
    public class DashboardController : Controller
    {
        public string s = null;
        public IActionResult Summary()
        {
            var model = new SummaryModel();
            return View(model);
        }

        public IActionResult StudentInfo()
        {
            var std = new Student();
            return View(std.StudenInfo());
        }
        public IActionResult StudentBranch(string name)
        {

            var std = new Student();
            var std1 = std.GetStudents(name);
            return View(std1);

        }
    }
}
