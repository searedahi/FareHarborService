using FareHarborService.Configuration;

namespace FareHarborService
{
    public static class FareHarborRestServiceFactory
    {
        public static FareHarborRestService CreateFareHarborRestService()
        {
            var fareHarborConfiguration = new FareHarborConfig {

            };

            var fareHarborService = new FareHarborRestService(fareHarborConfiguration);

            return fareHarborService;
        }
    }
}
