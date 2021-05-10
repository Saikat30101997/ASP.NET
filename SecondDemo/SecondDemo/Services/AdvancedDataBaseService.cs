using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondDemo.Services
{
    public class AdvancedDataBaseService : IDatabaseService
    {
        public string GetName()
        {
            return "AdvancedDataBaseService";
        }
    }
}
