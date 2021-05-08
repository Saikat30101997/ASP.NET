using FirstDemo.Models;
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

        public IActionResult StudentData()
        {
            var std = new Student()
            {
                StudentId = 110,
                Name = "Shweta",
                 Branch="Anthropology",
                 Section="C",
                 Gender="Female"
            };
            
            ViewBag.Student = std;
            return View();
        }

        public IActionResult StudentInfo1(int id)
        {
            var std = new Student();
            var st = std.StudenInfo();
            var res = (from s in st where s.StudentId == id select s).ToList();
            TempData["Student"] = res;

            return View();
        }
    }
}
