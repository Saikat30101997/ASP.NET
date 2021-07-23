using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBookingSystem.Web.Areas.Admin.Models.Tickets;
using TicketBookingSystem.Web.Models;

namespace TicketBookingSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TicketController : Controller
    {
        private readonly ILogger<TicketController> _logger;
        public TicketController(ILogger<TicketController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            var model =new TicketListModel();
            return View();
        }
        public JsonResult GetTicketData()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = new TicketListModel();
            var data = model.GetTicketInfo(dataTableModel);
            return Json(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(CreateTicketModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.CreateTicket();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create a Ticket");
                    _logger.LogError(ex, "cannot create a ticket");
                }
            }
            return View();
        }

        public IActionResult Edit(int Id)
        {
            var model = new EditTicketModel();
            model.LoadModelData(Id);
            return View(model);

        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Edit(EditTicketModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.Update();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create a Ticket");
                    _logger.LogError(ex, "cannot create a ticket");
                }
            }
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Delete(int Id)
        {
            var model = new TicketListModel();
            model.Delete(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
