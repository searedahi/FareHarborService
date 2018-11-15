using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Travel.Models;

namespace FareHarborService.Test
{
    [TestClass]
    public class FareHarborServiceTests
    {
        [TestMethod]
        public void GetCompanies_ListOfCompaniesReturned()
        {
            //Assemble
            var fareHarborService = FareHarborRestServiceFactory.CreateFareHarborRestService();

            //Act 
            var companies = fareHarborService.GetCompanies();

            //Assert
            Assert.IsNotNull(companies);
            Assert.IsTrue(companies.Any());
        }

        [TestMethod]
        public void GetCompany_DetailsReturned()
        {
            //Assemble
            var fareHarborService = FareHarborRestServiceFactory.CreateFareHarborRestService();

            //Act 
            var companyDetails = fareHarborService.GetCompany("bodyglove");

            //Assert
            Assert.IsNotNull(companyDetails);
            Assert.IsFalse(string.IsNullOrEmpty(companyDetails.About));
            Assert.IsNotNull(companyDetails.Address);
        }

        [TestMethod]
        public void GetCompanyItems_ListOfCompanyItemsReturned()
        {
            //Assemble
            var fareHarborService = FareHarborRestServiceFactory.CreateFareHarborRestService();

            //Act 
            var items = fareHarborService.GetComanyItems("bodyglove");

            //Assert
            Assert.IsNotNull(items);
            Assert.IsTrue(items.Any());
            Assert.AreNotEqual(0, items.Select(i => i.Locations).ToList());
        }

        [TestMethod]
        public void GetCompanyAgents_ListOfAgentsReturned()
        {
            //Assemble
            var fareHarborService = FareHarborRestServiceFactory.CreateFareHarborRestService();

            //Act 
            var items = fareHarborService.GetComanyAgents("bodyglove");

            //Assert
            Assert.IsNotNull(items);
            Assert.IsTrue(items.Any());
            Assert.AreNotEqual(0, items.ToList());
        }

        [TestMethod]
        public void GetCompanyDesks_ListOfDesksReturned()
        {
            //Assemble
            var fareHarborService = FareHarborRestServiceFactory.CreateFareHarborRestService();

            //Act 
            var items = fareHarborService.GetComanyDesks("bodyglove");

            //Assert
            Assert.IsNotNull(items);
            Assert.IsTrue(items.Any());
            Assert.AreNotEqual(0, items.ToList());
        }

        [TestMethod]
        public void GetCompanyLodgings_ListOfLodgingsReturned()
        {
            //Assemble
            var fareHarborService = FareHarborRestServiceFactory.CreateFareHarborRestService();

            //Act 
            var items = fareHarborService.GetComanyLodgings("bodyglove");

            //Assert
            Assert.IsNotNull(items);
            Assert.IsTrue(items.Any());
            Assert.AreNotEqual(0, items.ToList());
        }

        [TestMethod]
        public void GetCompanyLodgingAvailabilities_ListOfAvailabilitiesReturned()
        {
            //Assemble
            var fareHarborService = FareHarborRestServiceFactory.CreateFareHarborRestService();

            //Act 
            var items = fareHarborService.GetComanyLodgings("bodyglove");

            //Assert
            Assert.IsNotNull(items);
            Assert.IsTrue(items.Any());
            Assert.AreNotEqual(0, items.ToList());
        }

        [TestMethod]
        public void GetCompanyExperienceAvailabilities_ListOfAvailabilitiesReturned()
        {
            //Assemble
            var fareHarborService = FareHarborRestServiceFactory.CreateFareHarborRestService();
                                 
            var experiencesinDb = new List<int> { 183, 1186, 1187, 1188, 1355, 12252 };

            //Act 
            var items = new List<IAvailability>();

            foreach (var id in experiencesinDb)
            {
                var foundOne = false;
                DateTime targetDt = DateTime.Now;

                while (!foundOne && targetDt < DateTime.Now.AddDays(30))
                {
                    var rres = fareHarborService.GetExperienceAvailabilities("bodyglove", id, targetDt);
                    if (rres.Any())
                    {
                        foundOne = true;
                        items.AddRange(rres);
                    }

                    targetDt = targetDt.AddDays(1);
                }
            }

            //Assert
            Assert.IsNotNull(items);
            Assert.IsTrue(items.Any());
            Assert.AreNotEqual(0, items.ToList());
        }





    }
}
