using AutoMapper;
using ECommerceSystem.ECommerce.BusinessObjects;
using ECommerceSystem.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceSystem.Web.Profiles
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
