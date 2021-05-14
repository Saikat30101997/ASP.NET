using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecondDemo.Services;

namespace SecondDemo.Controllers
{
    public class DashBoardController : Controller
    {
        private IDatabaseService _dataBaseService;
        public DashBoardController(IDatabaseService databaseService)
        {
            _dataBaseService = databaseService;
        }
        public IActionResult Summery()
        {
            var data = _dataBaseService.GetName();
            return View();
        }
    }
}
