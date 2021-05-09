using FirstDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using FirstDemo.Services;
namespace FirstDemo.Controllers
{
    public class DashboardController : Controller
    {
        private IDataBaseService _dataBaseService;
        public DashboardController(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }
        public IActionResult Summary()
        {
            var databaseservice = _dataBaseService.Getname(); // eta amdr addtransient diye add korar karone amdr DI er fole jodi knu ekta debug rekhe dei dekha jbe jeta diye amra startup e bind korechi shei class er instance ta ekhane cholee asbee...
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
