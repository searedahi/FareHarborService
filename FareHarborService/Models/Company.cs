using System.Collections.Generic;

namespace FareHarborService.Models
{
    public class Company
    {
        public string currency { get; set; }
        public string shortname { get; set; }
        public string name { get; set; }
    }


    public class Companies
    {
        public List<Company> companies{ get; set; }
    }
}
