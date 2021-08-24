using Autofac;
using AutoMapper;
using ECommerceSystem.ECommerce.BusinessObjects;
using ECommerceSystem.ECommerce.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceSystem.Web.Areas.Admin.Models
{
    public class EditProductModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
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
            Product product = _productService.GetProduct(id);
            _mapper.Map(product, this);
        }

        internal void Update()
        {
            var product = _mapper.Map<Product>(this);
            _productService.Update(product);
        }
    }
}
