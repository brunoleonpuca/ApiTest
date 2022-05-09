using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibraryv2
{
    public class Configuration
    {
        public string DefaultToken = ConfigurationManager.AppSettings["apiToken"];


    }
}
