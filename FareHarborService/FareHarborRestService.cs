using AutoMapper;
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
        private IMapper mapper;

        public MapperConfiguration ObjectMapper
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.IgnoreUnmapped();
                    cfg.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
                    cfg.DestinationMemberNamingConvention = new PascalCaseNamingConvention();

                    cfg.CreateMap<CompanyDetail, Travel.Models.Company>();
                    cfg.CreateMap<Company, Travel.Models.Company>();
                    cfg.CreateMap<Company[], List<Travel.Models.Company>>();
                    cfg.CreateMap<Item, Travel.Models.Experience>();
                    cfg.CreateMap<Item[], List<Travel.Models.Experience>>();
                    cfg.CreateMap<ImageInfo, Travel.Models.ImageInfo>();
                    cfg.CreateMap<LocationInfo, Travel.Models.LocationInfo>();
                    cfg.CreateMap<CustomerPrototype, Travel.Models.CustomerPrototype>();
                });
            }
        }

        public FareHarborRestService(IFareHarborConfig fareHarborConfiguration)
        {
            fareHarborConfig = fareHarborConfiguration;
            mapper = ObjectMapper.CreateMapper();
        }

        public List<Travel.Models.ICompany> GetCompanies()
        {
            var rawResp = CallFareHarbor("companies/", "GET");

            var domainCompanies = new List<Travel.Models.Company>();
            var jsonCompanies = JsonConvert.DeserializeObject<Companies>(rawResp);

            if (jsonCompanies != null && jsonCompanies.companies != null)
            {
                domainCompanies = mapper.Map<List<Travel.Models.Company>>(jsonCompanies.companies);
            }

            return new List<Travel.Models.ICompany>(domainCompanies);
        }

        public Travel.Models.ICompany GetCompany(string companyShortName)
        {
            var route = $"companies/{companyShortName}/";

            var rawResp = CallFareHarbor(route, "GET");

            var domainCompany = new Travel.Models.Company();
            var jsonCompany = JsonConvert.DeserializeObject<CompanyDetail>(JObject.Parse(rawResp)["company"].ToString());

            if (jsonCompany != null)
            {
                domainCompany = mapper.Map<Travel.Models.Company>(jsonCompany);
            }

            return domainCompany;
        }

        public List<Travel.Models.IExperience> GetComanyItems(string companyShortName)
        {
            var route = $"companies/{companyShortName}/items/";

            var rawResp = CallFareHarbor(route, "GET");

            var domainExperiences = new List<Travel.Models.Experience>();
            var jsonItems = JsonConvert.DeserializeObject<Items>(rawResp);

            if (jsonItems != null)
            {
                domainExperiences = mapper.Map<List<Travel.Models.Experience>>(jsonItems.items);
            }

            return new List<Travel.Models.IExperience>(domainExperiences);
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
