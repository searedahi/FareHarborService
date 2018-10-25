using FareHarborService.Configuration;
using FareHarborService.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace FareHarborService
{
    public class FareHarborRestService
    {
        private IFareHarborConfig fareHarborConfig;

        public FareHarborRestService( IFareHarborConfig fareHarborConfiguration)
        {
            fareHarborConfig = fareHarborConfiguration;
        }

        public List<Company> GetCompanies()
        {
            var rawResp = CallFareHarbor("companies/", "GET");
            
            var jsonCompanies = JsonConvert.DeserializeObject<Companies>(rawResp);

            return jsonCompanies.companies;
        }

        public CompanyDetail GetCompany(string companyShortName)
        {
            var route = $"companies/{companyShortName}/";

            var rawResp = CallFareHarbor(route, "GET");

            var jsonCompany = JsonConvert.DeserializeObject<CompanyDetail>(JObject.Parse(rawResp)["company"].ToString());

            return jsonCompany;
        }
        
        public List<Item> GetComanyItems(string companyShortName)
        {
            var route = $"companies/{companyShortName}/items/";

            var rawResp = CallFareHarbor(route, "GET");

            var jsonItems = JsonConvert.DeserializeObject<Items>(rawResp);

            return jsonItems.items;
        }






        /// <summary>
        /// Generic caller to the FareHarbor REST service.
        /// </summary>
        /// <param name="route">
        /// The route to the desired action without a leading slash.  
        /// For example: companies   or   companies/items   or   </param>
        /// <returns>A raw response string.</returns>
        private string CallFareHarbor(string route, string method)
        {
            var response = "";

            //Build the url
            var serviceUrl = $"{fareHarborConfig.FareHarborServiceUrl}{route}";

            var webRequest = System.Net.WebRequest.Create(serviceUrl);
            if (webRequest != null)
            {
                webRequest.Method = method;
                webRequest.ContentType = "application/json";
                webRequest.Headers.Add("X-FareHarbor-API-App", fareHarborConfig.FareHarborAppId);
                webRequest.Headers.Add("X-FareHarbor-API-User", fareHarborConfig.FareHarborUserId);

                using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                    {
                        var jsonResponse = sr.ReadToEnd();

                        response = jsonResponse;
                    }
                }
            }
            return response;
        }

    }
}
