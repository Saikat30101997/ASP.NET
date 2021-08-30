using AutoMapper;
using ProjectEntityFrameWork.Training.BusinessObjects;
using ProjectEntityFrameWork.Training.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEntityFrameWork.Training.Services
{
    public class StockPriceService : IStockPriceService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        private readonly IMapper _mapper;
        public StockPriceService(ITrainingUnitOfWork trainingUnitOfWork, IMapper mapper)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
            _mapper = mapper;
        }

        public void Create(StockPrice stockPrice)
        {
            if (stockPrice == null)
                throw new InvalidOperationException("not provided");
            _trainingUnitOfWork.StockPrices.Add(
                _mapper.Map<Entities.StockPrice>(stockPrice));
            _trainingUnitOfWork.Save();
        }
    }
}
