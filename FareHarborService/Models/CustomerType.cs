using System;
using System.Collections.Generic;
using System.Text;

namespace FareHarborService.Models
{
    public class CustomerType
    {
        public int pk { get; set; }
        public string singular { get; set; }
        public string plural { get; set; }
        public string note { get; set; }
    }
}
