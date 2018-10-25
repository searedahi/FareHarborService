using Microsoft.VisualStudio.TestTools.UnitTesting;
using FareHarborService;
using System.Linq;

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
    }
}
