using ECommerceSystem.Web.Areas.Admin.Models;
using ECommerceSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        public ProductController(ILogger<ProductController> logger)
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

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Create(CreateProductModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.Create();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Failed to create Product");
                    _logger.LogError(ex, "Product Creation Failed");
                }
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = new EditProductModel();
            model.GetProduct(id);
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(EditProductModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Update();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Failed to edit Product");
                    _logger.LogError(ex, "Product Edition Failed");
                }
            }
            return View(model);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var model = new ProductListModel();
            model.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    
    }
}
