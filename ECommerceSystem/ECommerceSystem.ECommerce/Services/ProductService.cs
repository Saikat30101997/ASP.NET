using AutoMapper;
using ECommerceSystem.ECommerce.BusinessObjects;
using ECommerceSystem.ECommerce.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.ECommerce.Services
{
    public class ProductService : IProductService
    {
        private readonly IECommerceUnitOfWork _eCommerceUnitOfWork;
        public readonly IMapper _mapper;
        public ProductService(IECommerceUnitOfWork eCommerceUnitOfWork, IMapper mapper)
        {
            _eCommerceUnitOfWork = eCommerceUnitOfWork;
            _mapper = mapper;
        }

        public (IList<Product> records, int total, int totalDisplay) GetProducts(int pageIndex, 
            int pageSize, string searchText, string sortText)
        {
            var productData = _eCommerceUnitOfWork.Products.GetDynamic(string.IsNullOrWhiteSpace(searchText) ?
                null : x => x.Name.Contains(searchText), sortText, string.Empty, pageIndex, pageSize);

            var resultData = (from product in productData.data
                              select _mapper.Map<Product>(product)).ToList();

            return (resultData, productData.total, productData.totalDisplay);
        }
    }
}
