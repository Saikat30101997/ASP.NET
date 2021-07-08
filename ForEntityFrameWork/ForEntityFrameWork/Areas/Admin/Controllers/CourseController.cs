using ForEntityFrameWork.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForEntityFrameWork.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;
        public CourseController(ILogger<CourseController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            var model =new CoureListModel();
            model.LoadModelData();
            return View(model);
        }
        public IActionResult Create()
        {
        
            return View();

        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(CreateCourseModel courseModel)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    courseModel.Create();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("","Failed To Create Course");
                    _logger.LogError(ex, "Course Creation Failed");
                }
            }
            return View();
        }

       
    }
}
