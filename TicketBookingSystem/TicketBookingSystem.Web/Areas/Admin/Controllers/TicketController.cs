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
            var model = new TicketListModel();
            return View(model);
        }

        public JsonResult GetTicketData()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new TicketListModel();
            var data = model.GetTickets(tableModel);
            return Json(data);
        }
    }
}
