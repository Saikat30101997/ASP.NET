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

        public void Create(Product product)
        {
            if (product == null)
                throw new InvalidOperationException("Product is not provided");
            _inventoryUnitOfWork.Products.Add(
                _mapper.Map<Entities.Product>(product));
            _inventoryUnitOfWork.Save();
        }

        public void Delete(int id)
        {
            _inventoryUnitOfWork.Products.Remove(id);
            _inventoryUnitOfWork.Save();
        }

        public Product GetProduct(int id)
        {
            var product = _inventoryUnitOfWork.Products.GetById(id);
            return _mapper.Map<Product>(product);
        }

        public (IList<Product> records, int total, int totalDisplay) GetProducts(int pageIndex, 
            int pageSize, string searchText, string sortText)
        {
            var productData = _inventoryUnitOfWork.Products.GetDynamic(string.IsNullOrWhiteSpace(searchText) ? 
                null : x => x.Name.Contains(searchText) || x.Price.ToString().Contains(searchText), sortText, string.Empty, pageIndex, pageSize);
            var resultData = (from product in productData.data
                              select _mapper.Map<Product>(product)).ToList();

            return (resultData, productData.total, productData.totalDisplay);
        }

        public void Update(Product product)
        {
            if (product == null)
                throw new InvalidOperationException("Product is not provided");
            var productEntity = _inventoryUnitOfWork.Products.GetById(product.Id);
            if (productEntity != null)
            {
                _mapper.Map(product, productEntity);
                _inventoryUnitOfWork.Save();
            }
            else
                throw new InvalidOperationException("Product is not found");
        }
    }
}
