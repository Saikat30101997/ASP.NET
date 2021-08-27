using AutoMapper;
using InventorySystem.Inventory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using InventorySystem.Inventory.BusinessObjects;

namespace InventorySystem.Web.Areas.Admin.Models.Products
{
    public class CreateProductModel
    {
        public string Name { get; set; }
        public int Price { get; set; }

        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public CreateProductModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();

        }

        public CreateProductModel(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        internal void CreateProduct()
        {
            var product = _mapper.Map<Product>(this);
            _productService.Create(product);
        }
    }
}
