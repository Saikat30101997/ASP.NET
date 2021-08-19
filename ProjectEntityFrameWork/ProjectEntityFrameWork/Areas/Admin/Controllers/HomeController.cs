using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEntityFrameWork.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize(Policy = "ViewPermission")]   //Authorize Roll and policy egular name add kora jaay 
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
