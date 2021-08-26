﻿using InventorySystem.Inventory.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Inventory.Services
{
    public interface IProductService
    {
        (IList<Product>records,int total,int totalDisplay) GetProducts(int pageIndex, 
            int pageSize, string searchText, string sortText);
    }
}
