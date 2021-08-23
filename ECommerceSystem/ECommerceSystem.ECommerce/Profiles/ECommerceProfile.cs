using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EO = ECommerceSystem.ECommerce.Entities;
using BO = ECommerceSystem.ECommerce.BusinessObjects;

namespace ECommerceSystem.ECommerce.Profiles
{
    public class ECommerceProfile : Profile
    {
        public ECommerceProfile()
        {
            CreateMap<EO.Product, BO.Product>().ReverseMap();
        }
    }
}
