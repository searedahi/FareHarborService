namespace FareHarborService.Models
{
    public class LocationInfo
    {
        public int pk { get; set; }
        public string type { get; set; }
        public string note { get; set; }
        public string note_safe_html { get; set; }
        public AddressInfo address { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public string google_place_id { get; set; }
        public string tripadvisor_url { get; set; }
    }
}
