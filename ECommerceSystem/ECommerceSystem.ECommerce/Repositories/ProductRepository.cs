using EcommerceSystem.Data;
using ECommerceSystem.ECommerce.Contexts;
using ECommerceSystem.ECommerce.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.ECommerce.Repositories
{
    public class ProductRepository : Repository<Product,int> ,IProductRepository
    {
        public ProductRepository(IECommerceDbContext context) : base((DbContext)context)
        {

        }
    }
}
