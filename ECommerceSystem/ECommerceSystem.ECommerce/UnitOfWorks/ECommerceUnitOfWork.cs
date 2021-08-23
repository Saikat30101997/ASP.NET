using EcommerceSystem.Data;
using ECommerceSystem.ECommerce.Contexts;
using ECommerceSystem.ECommerce.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.ECommerce.UnitOfWorks
{
    public class ECommerceUnitOfWork : UnitOfWork,IECommerceUnitOfWork
    { 
        public IProductRepository Products { get; set; }

        public ECommerceUnitOfWork(IECommerceDbContext context,IProductRepository products):base((DbContext)context)
        {
            Products = products;
        }
    }
}
