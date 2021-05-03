using FirstDemo.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult StudentBranch(string name)
        {

            s = name;


            //return View("~/Views/Dashboard/StudentBranch.cshtml");
            ////StudentInfo model = new StudentInfo();
            ////return View(model.GetStudents());
            ////StudentInfo studentInfo = new StudentInfo();



            var std = new StudentInfo();

            
            return View(std.GetStudentsRes());



        }
    }
}
