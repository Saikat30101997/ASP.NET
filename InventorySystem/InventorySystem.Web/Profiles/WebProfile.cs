using AutoMapper;
using InventorySystem.Inventory.BusinessObjects;
using InventorySystem.Web.Areas.Admin.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Web.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<CreateProductModel, Product>().ReverseMap();
            CreateMap<EditProductModel, Product>().ReverseMap();
        }
    }
}
