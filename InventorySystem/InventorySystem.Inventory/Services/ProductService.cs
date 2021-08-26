using AutoMapper;
using InventorySystem.Inventory.BusinessObjects;
using InventorySystem.Inventory.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Inventory.Services
{
    public class ProductService : IProductService
    {
        private readonly IInventoryUnitOfWork _inventoryUnitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IInventoryUnitOfWork inventoryUnitOfWork, IMapper mapper)
        {
            _inventoryUnitOfWork = inventoryUnitOfWork;
            _mapper = mapper;
        }

        public (IList<Product> records, int total, int totalDisplay) GetProducts(int pageIndex, 
            int pageSize, string searchText, string sortText)
        {
            var productData = _inventoryUnitOfWork.Products.GetDynamic(string.IsNullOrWhiteSpace(searchText) ? 
                null : x => x.Name.Contains(searchText), sortText, string.Empty, pageIndex, pageSize);
            var resultData = (from product in productData.data
                              select _mapper.Map<Product>(product)).ToList();

            return (resultData, productData.total, productData.totalDisplay);
        }
    }
}
