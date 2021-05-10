using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondDemo.Services
{
    public class SimpleDataBaseServcice : IDatabaseService
    {
        private IDataDriver _dataDriver;
        public SimpleDataBaseServcice(IDataDriver dataDriver)
        {
            _dataDriver = dataDriver;
        }
        public string GetName()
        {
            return "SimpleDataBaseServcice";
        }
    }
}
