﻿using ECommerceSystem.ECommerce.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using ECommerceSystem.Web.Models;

namespace ECommerceSystem.Web.Areas.Admin.Models
{
    public class ProductListModel
    {
        private readonly IProductService _productService;
        public string Name { get; set; }
        public ProductListModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
        }

        public ProductListModel(IProductService productService)
        {
            _productService = productService;
        }

        internal object GetProducts(DataTablesAjaxRequestModel tableModel)
        {

            var data = _productService.GetProducts(
               tableModel.PageIndex,
               tableModel.PageSize,
               tableModel.SearchText,
               Name,
               tableModel.GetSortText(new string[] { "Name", "Price"}));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Name,
                                record.Price.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        internal void Delete(int id)
        {
            _productService.Delete(id);
        }
    }
}
