
using AttendanceSystem.Web.Areas.Admin.Models.Attendances;
using AttendanceSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AttendanceController : Controller
    {
        private readonly ILogger<AttendanceController> _logger;
        public AttendanceController(ILogger<AttendanceController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetAttendanceData()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = new AttendanceListModel();
            var data = model.GetAttendances(dataTableModel);
            return Json(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(CreateAttendanceModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.CreateAttendance();

                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create Attendance");
                    _logger.LogError(ex, "Attendance Creation Failed");
                }
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var model =new  EditAttendanceModel();
            model.LoadModelData(id);
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditAttendanceModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.Update();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Failed to edit attendance");
                    _logger.LogError(ex, "Attendance is not edited");
                }
            }
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new AttendanceListModel();
            model.DeleteAttendance(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
