using InventorySystem.Web.Areas.Admin.Models.Products;
using InventorySystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var model = new ProductListModel();
            return View(model);
        }
        public JsonResult GetProductData()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ProductListModel();
            var data = model.GetProducts(tableModel);
            return Json(data);
        }
    }
}
