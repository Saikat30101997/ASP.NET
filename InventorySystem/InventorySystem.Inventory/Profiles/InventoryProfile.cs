using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EO = InventorySystem.Inventory.Entities;
using BO = InventorySystem.Inventory.BusinessObjects;

namespace InventorySystem.Inventory.Profiles
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<EO.Product, BO.Product>().ReverseMap();
        }
    }
}
