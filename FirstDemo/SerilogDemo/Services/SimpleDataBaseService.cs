using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerilogDemo.Services
{
    public class SimpleDataBaseService : IDataBaseService
    {
        private IDataDriver _dataDriver;
        public SimpleDataBaseService(IDataDriver dataDriver)
        {
            _dataDriver = dataDriver;
        }
        public string Getname()
        {
            return "SimpleDataBaseService";
        }
    }
}
