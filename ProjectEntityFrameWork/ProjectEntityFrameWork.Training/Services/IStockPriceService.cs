using ProjectEntityFrameWork.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEntityFrameWork.Training.Services
{
    public interface IStockPriceService
    {
        void Create(StockPrice stockPrice);
    }
}
