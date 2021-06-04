using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SerilogDemo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SerilogDemo.Services;
namespace SerilogDemo.Controllers
{
    public class HomeController : Controller
    {
        private IDataBaseService _databaseService;
         public HomeController(IDataBaseService dataBaseService)
        {
            _databaseService = dataBaseService;
        }
        
        public IActionResult Index()
        {
            var databaseservice = _databaseService.Getname();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
