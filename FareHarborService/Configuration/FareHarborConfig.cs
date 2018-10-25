namespace FareHarborService.Configuration
{
    public class FareHarborConfig : IFareHarborConfig
    {
        public string FareHarborServiceUrl { get; set; }
        public string FareHarborAppId { get; set; }
        public string FareHarborUserId { get; set; }
    }
}
