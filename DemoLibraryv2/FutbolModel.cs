using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibraryv2
{
    public class FutbolModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Short_Code { get; set;}
        public int CountryId { get; set; }
        public int Founded { get; set; }
        public string Logo_Path { get; set; }
    }
}