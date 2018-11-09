namespace FareHarborService.Models
{
    public class Lodging
    {
        public int pk { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string url { get; set; }
        bool is_self_lodging { get; set; }
        bool is_pickup_available { get; set; }
    }
}