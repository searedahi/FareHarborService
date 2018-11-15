using AutoMapper;
using FareHarborService.Configuration;
using FareHarborService.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace FareHarborService
{
    public class FareHarborRestService
    {
        private IFareHarborConfig fareHarborConfig;
        private IMapper mapper;

        public MapperConfiguration FareHarborMapper
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
                    cfg.CreateMap<AddressInfo, Travel.Models.AddressInfo>();
                    cfg.CreateMap<CustomerPrototype, Travel.Models.CustomerPrototype>();
                });
            }
        }

        public FareHarborRestService(IFareHarborConfig fareHarborConfiguration)
        {
            fareHarborConfig = fareHarborConfiguration;
            mapper = FareHarborMapper.CreateMapper();
        }

        public IList<Travel.Models.ICompany> GetCompanies()
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

        public IList<Travel.Models.IExperience> GetComanyItems(string companyShortName)
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
        
        public IList<Travel.Models.IAgent> GetComanyAgents(string companyShortName)
        {
            var route = $"companies/{companyShortName}/agents/";

            var rawResp = CallFareHarbor(route, "GET");

            var domainAgents = new List<Travel.Models.Agent>();
            var jsonItems = JsonConvert.DeserializeObject<Agents>(rawResp);

            if (jsonItems != null)
            {
                domainAgents = mapper.Map<List<Travel.Models.Agent>>(jsonItems.agents);
            }

            return new List<Travel.Models.IAgent>(domainAgents);
        }

        public IList<Travel.Models.IDesk> GetComanyDesks(string companyShortName)
        {
            var route = $"companies/{companyShortName}/agents/";

            var rawResp = CallFareHarbor(route, "GET");

            var domainDesks = new List<Travel.Models.Desk>();
            var jsonItems = JsonConvert.DeserializeObject<Desks>(rawResp);

            if (jsonItems != null)
            {
                domainDesks = mapper.Map<List<Travel.Models.Desk>>(jsonItems.desks);
            }

            return new List<Travel.Models.IDesk>(domainDesks);
        }

        public IList<Travel.Models.ILodging> GetComanyLodgings(string companyShortName)
        {
            var route = $"companies/{companyShortName}/lodgings/";

            var rawResp = CallFareHarbor(route, "GET");

            var domainLodgings = new List<Travel.Models.Lodging>();
            var jsonItems = JsonConvert.DeserializeObject<Lodgings>(rawResp);

            if (jsonItems != null)
            {
                domainLodgings = mapper.Map<List<Travel.Models.Lodging>>(jsonItems.lodgings);
            }

            return new List<Travel.Models.ILodging>(domainLodgings);
        }

        public IList<Travel.Models.ILodging> GetLodgingAvailabilities(string companyShortName, int lodgingPk)
        {
            var route = $"companies/{companyShortName}/availabilities/{lodgingPk}/lodgings/";

            var rawResp = CallFareHarbor(route, "GET");

            var domainLodgings = new List<Travel.Models.Lodging>();
            var jsonItems = JsonConvert.DeserializeObject<Lodgings>(rawResp);

            if (jsonItems != null)
            {
                domainLodgings = mapper.Map<List<Travel.Models.Lodging>>(jsonItems.lodgings);
            }

            return new List<Travel.Models.ILodging>(domainLodgings);
        }
        
        public IList<Travel.Models.IAvailability> GetExperienceAvailabilities(string companyShortName, int experiencePk, DateTime targetDate)
        {
            var formattedDate = targetDate.ToString("yyyy-MM-dd");

            var route = $"companies/{companyShortName}/items/{experiencePk}/minimal/availabilities/date/{formattedDate}/";

            var rawResp = CallFareHarbor(route, "GET");

            var domainAvailabilities = new List<Travel.Models.Availability>();
            var jsonItems = JsonConvert.DeserializeObject<Availabilities>(rawResp);

            if (jsonItems != null)
            {
                domainAvailabilities = mapper.Map<List<Travel.Models.Availability>>(jsonItems.availabilities);
            }

            return new List<Travel.Models.IAvailability>(domainAvailabilities);
        }

        public IList<Travel.Models.IAvailability> GetExperienceAvailabilities(string companyShortName, int experiencePk, DateTime startDate, DateTime endDate)
        {
            var formattedStartDate = startDate.ToString("yyyy-MM-dd");
            var formattedEndDate = endDate.ToString("yyyy-MM-dd");

            var route = $"companies/{companyShortName}/items/{experiencePk}/minimal/availabilities/date-range/{formattedStartDate}/{formattedEndDate}/";

            var rawResp = CallFareHarbor(route, "GET");

            var domainAvailabilities = new List<Travel.Models.Availability>();
            var jsonItems = JsonConvert.DeserializeObject<Availabilities>(rawResp);

            if (jsonItems != null)
            {
                domainAvailabilities = mapper.Map<List<Travel.Models.Availability>>(jsonItems.availabilities);
            }

            return new List<Travel.Models.IAvailability>(domainAvailabilities);
        }

        public Travel.Models.IAvailability GetAvailability(string companyShortName, int availabilityPk)
        {
            var route = $"companies/{companyShortName}/availabilities/{availabilityPk}/";

            var rawResp = CallFareHarbor(route, "GET");

            var domainAvailability = new Travel.Models.Availability();
            var jsonAvailability = JsonConvert.DeserializeObject<ExperienceAvailability>(JObject.Parse(rawResp)["availability"].ToString());

            if (jsonAvailability != null)
            {
                domainAvailability = mapper.Map<Travel.Models.Availability>(jsonAvailability);
            }

            return domainAvailability;
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
