using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestMethod]
        public void GetCompany_CompanyDetailsReturned()
        {
            //Assemble
            var fareHarborService = FareHarborRestServiceFactory.CreateFareHarborRestService();

            //Act 
            var companyDetails = fareHarborService.GetCompany("bodyglove");

            //Assert
            Assert.IsNotNull(companyDetails);
            Assert.IsFalse(string.IsNullOrEmpty(companyDetails.Description));
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
        }
    }
}
