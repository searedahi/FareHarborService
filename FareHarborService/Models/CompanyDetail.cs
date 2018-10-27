namespace FareHarborService.Models
{
    public class CompanyDetail
    {
        public string currency { get; set; }
        public string shortname { get; set; }
        public string name { get; set; }
        public string summary { get; set; }
        public string about { get; set; }
        public string about_safe_html { get; set; }
        public string booking_notes { get; set; }
        public string booking_notes_safe_html { get; set; }
        public string faq { get; set; }
        public string faq_safe_html { get; set; }
        public string intro { get; set; }
        public string intro_safe_html { get; set; }
        public AddressInfo address { get; set; }
        public AddressInfo billing_address { get; set; }
    }
}
