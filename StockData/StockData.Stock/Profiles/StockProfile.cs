using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EO = StockData.Stock.Entities;
using BO = StockData.Stock.BusinessObjects;

namespace StockData.Stock.Profiles
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<EO.StockPrice, BO.StockPrice>().ReverseMap();
        }
    }
}
