using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBookingSystem.Web.Areas.Admin.Models.Customers;
using TicketBookingSystem.Web.Models;

namespace TicketBookingSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            ViewBag.SomeData = "All Avaialble Customers";
            var model = new CustomerListModel();
            return View(model);
        }

        public JsonResult GetCustomerData()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new CustomerListModel();
            var data = model.GetCustomers(tableModel);
            return Json(data);
        }
    }
}
