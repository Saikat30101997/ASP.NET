using InventorySystem.Web.Areas.Admin.Models.Products;
using InventorySystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace InventorySystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        public ProductController(ILogger<ProductController>  logger)
        {
            _logger = logger;
        }
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
        [HttpPost]
        public JsonResult GetProductData(ProductListModel model)
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var data = model.GetProducts(tableModel);
            var contactName = Request.Form["ddCountry"].FirstOrDefault();
            var country = Request.Form["txtEmployeeName"].FirstOrDefault();
            return Json(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(CreateProductModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateProduct();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed To Create Product");
                    _logger.LogError(ex, "Product Creation Failed");
                }
            }
            return View();
        }
        
        public IActionResult Edit(int id)
        {
            var model = new EditProductModel();
            model.GetProduct(id);
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditProductModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    model.Update();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed To edit Product");
                    _logger.LogError(ex, "Product edition Failed");
                }
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var model = new ProductListModel();
            model.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
