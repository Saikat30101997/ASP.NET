using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstDemo.Models;

namespace FirstDemo.Controllers
{
    public class DashboardController : Controller
    {
        public string s;
        public IActionResult Summary()
        {
            var model = new SummaryModel();
            return View(model);
        }
        public ViewResult StudentBranch(string name)    
        {
            //s = name;
            //StudentInfo studentinfo = new StudentInfo();
            //var x = studentinfo.GetStudents();
            //Student student = new Student();
            //var res = (from std in studentinfo.GetStudents() where std.Name == name select std).ToList();
            //var ans = new
            //{
            //    Reg = res.Select(x=>x.RegNo),
            //    Nam = res.Select(std=>std.Name),

            //};
            //return View(ans);
            StudentInfo model = new StudentInfo();
            return View(model.GetStudents());
            //StudentInfo studentInfo = new StudentInfo();





            //var x = studentInfo.GetStudents();

            //var res = (from std in studentInfo.GetStudents() where std.Name == name select std).ToList();

            //ViewData["Student"] = res;
            //return View();



        }
    }
}
