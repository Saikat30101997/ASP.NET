﻿using ECommerceSystem.ECommerce.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.ECommerce.Services
{
    public interface IProductService
    {
        (IList<Product>records,int total,int totalDisplay) GetProducts(int pageIndex, 
            int pageSize, string searchText, string sortText,string Name);
        void CreateProduct(Product product);
        Product GetProduct(int id);
        void Update(Product product);
        void Delete(int id);
    }
}
