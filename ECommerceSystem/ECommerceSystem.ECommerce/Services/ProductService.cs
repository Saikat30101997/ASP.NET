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
            int pageSize, string searchText, string sortText,string Name)
        {
            var productData = _eCommerceUnitOfWork.Products.GetDynamic(x=>x.Name==Name, sortText, string.Empty, pageIndex, pageSize);

            var resultData = (from product in productData.data
                              select _mapper.Map<Product>(product)).ToList();

            return (resultData, productData.total, productData.totalDisplay);
        }

        public void CreateProduct(Product product)
        {
            if (product == null)
                throw new InvalidOperationException("product is not Provided");
            _eCommerceUnitOfWork.Products.Add(
                _mapper.Map<Entities.Product>(product));

            _eCommerceUnitOfWork.Save();
        }

        public Product GetProduct(int id)
        {
            var product = _eCommerceUnitOfWork.Products.GetById(id);
            return _mapper.Map<Product>(product);
        }

        public void Update(Product product)
        {
            if (product == null)
                throw new InvalidOperationException("Product is not provided");

            var productEntity = _eCommerceUnitOfWork.Products.GetById(product.Id);
            if (productEntity != null)
            {
                _mapper.Map(product, productEntity);
                _eCommerceUnitOfWork.Save();
            }
            else
                throw new InvalidOperationException("Product was not found");
        }

        public void Delete(int id)
        {
            _eCommerceUnitOfWork.Products.Remove(id);
            _eCommerceUnitOfWork.Save();
        }
    }
}
