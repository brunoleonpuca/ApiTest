using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibraryv2
{
    public class FutbolModel
    {
        public int LegacyId { get; set; }
        public string Name { get; set; }
        public string ShortCode { get; set;}
        public int CountryId { get; set; }
        public bool NationalTeam { get; set; }
        public int Founded { get; set; }
        public string LogoPath { get; set; }
        public int VenueId { get; set; }
        public int CurrentSeasonId { get; set; }
        public bool IsPlaceholder { get; set; }
    }
}