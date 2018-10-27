using FareHarborService.Configuration;

namespace FareHarborService
{
    public static class FareHarborRestServiceFactory
    {
        public static FareHarborRestService CreateFareHarborRestService()
        {
            var fareHarborConfiguration = new FareHarborConfig {
                FareHarborServiceUrl = "https://demo.fareharbor.com/api/external/v1/",
                FareHarborAppId = "db88c55c-5721-4bcb-bf7b-5fc9a76806ee",
                FareHarborUserId = "d5db215b-e85b-4a3a-9a16-e29219400e5a"
            };

            var fareHarborService = new FareHarborRestService(fareHarborConfiguration);

            return fareHarborService;


        }
    }
}
