using EcommerceSystem.Data;
using ECommerceSystem.ECommerce.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.ECommerce.UnitOfWorks
{
    public interface IECommerceUnitOfWork : IUnitOfWork
    {
        IProductRepository Products { get; set; }
    }
}
