using System;
using System.Collections.Generic;
using System.Text;

namespace FareHarborService.Models
{
    public class CustomerTypeRate
    {
        public int pk { get; set; }
        public int total { get; set; }
        public int capacity { get; set; }
        public CustomerPrototype customer_prototype { get; set; }
        public CustomerType customer_type { get; set; }
    }
}
