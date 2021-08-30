﻿using ProjectEntityFrameWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEntityFrameWork.Training.Entities
{
    public class Company : IEntity<int>
    {
        public int Id { get; set; }
        public string TradeCode { get; set; }

        public StockPrice StockPrice { get; set; }

    }
}
