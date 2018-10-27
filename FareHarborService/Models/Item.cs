using System.Collections.Generic;

namespace FareHarborService.Models
{
    public class Item
    {
        public int pk { get; set; }
        public string name { get; set; }
        public string headline { get; set; }
        public string description { get; set; }
        public IList<string> description_bullets { get; set; }
        public string description_safe_html { get; set; }
        public string description_text { get; set; }
        public string cancellation_policy { get; set; }
        public string cancellation_policy_safe_html { get; set; }
        public string location { get; set; }
        public IList<LocationInfo> locations { get; set; }
        public string image_cdn_url { get; set; }
        public bool is_pickup_ever_available { get; set; }
        public IList<ImageInfo> images { get; set; }
        public IList<CustomerPrototype> customer_prototypes { get; set; }
    }
}
