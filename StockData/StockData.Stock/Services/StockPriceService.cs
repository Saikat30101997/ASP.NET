using AutoMapper;
using StockData.Stock.BusinessObjects;
using StockData.Stock.UnitOFWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Stock.Services
{
    public class StockPriceService : IStockPriceService
    {
        private readonly IStockDataUnitOfWork _stockDataUnitOfWork;
        private readonly IMapper _mapper;
        public StockPriceService(IStockDataUnitOfWork stockDataUnitOfWork,IMapper mapper)
        {
            _stockDataUnitOfWork = stockDataUnitOfWork;
            _mapper = mapper;
        }

        public void Create(StockPrice stockPrice)
        {
            if (stockPrice == null)
                throw new InvalidOperationException("");
            _stockDataUnitOfWork.StockPrices.Add(
                _mapper.Map<Entities.StockPrice>(stockPrice));
            _stockDataUnitOfWork.Save();
        }
    }
}
