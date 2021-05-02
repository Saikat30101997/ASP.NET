using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDemo.Models
{
    public class SmtpConfiguration
    {
        public string Host { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }
        //Etate ami SmtpConfiguration er property gula nilam ja amra start up e configure korbo and appsettings.json e settings set korbo smtp r
    }
}
