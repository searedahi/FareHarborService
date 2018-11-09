using System.Collections.Generic;

namespace FareHarborService.Models
{
    public class ExperienceAvailability
    {
        public int pk { get; set; }
        public string start_at { get; set; }
        public string end_at { get; set; }
        public int capactiy { get; set; }
        public Item item { get; set; }
        public List<CustomerTypeRate> customer_type_rates { get; set; }
    }
}