using AutoMapper;
using ECommerceSystem.ECommerce.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using Autofac;
using ECommerceSystem.ECommerce.BusinessObjects;

namespace ECommerceSystem.Web.Areas.Admin.Models
{
    public class CreateProductModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
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

        internal void Create()
        {
            var product = _mapper.Map<Product>(this);
            _productService.CreateProduct(product);
        }
    }
}
