namespace FareHarborService.Configuration
{
    public interface IFareHarborConfig
    {
        string FareHarborAppId { get; set; }
        string FareHarborServiceUrl { get; set; }
        string FareHarborUserId { get; set; }
    }
}