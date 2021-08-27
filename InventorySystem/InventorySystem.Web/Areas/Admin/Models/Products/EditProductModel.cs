using Autofac;
using AutoMapper;
using InventorySystem.Inventory.BusinessObjects;
using InventorySystem.Inventory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Web.Areas.Admin.Models.Products
{
    public class EditProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public EditProductModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();

        }

        public EditProductModel(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        internal void GetProduct(int id)
        {
            var product = _productService.GetProduct(id);
            _mapper.Map(product, this);
        }

        internal void Update()
        {
            var product = _mapper.Map<Product>(this);
            _productService.Update(product);
        }
    }
}
