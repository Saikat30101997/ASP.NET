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
        public CustomerController(ILogger<CustomerController>logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            var model = new CustomerListModel();
            return View(model);
        }
        public JsonResult GetCustomerData()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = new CustomerListModel();
            var data = model.GetCustomers(dataTableModel);
            return Json(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(CreateCustomerModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.CreateCustomer();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Failed To Create Customer");
                    _logger.LogError(ex, "Cannot create Customer");
                }
            }
            return View();
        }
        public IActionResult Edit(int Id)
        {
            var model = new EditCustomerModel();
            model.LoadModelData(Id);
            return View(model);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Edit(EditCustomerModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.Update();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Failed to edit Customer");
                    _logger.LogError(ex, "Cannot edit Customer");
                }
            }
            return View();
        }

        public IActionResult Delete(int Id)
        {
            var model = new CustomerListModel();
            model.DeleteCustomer(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
