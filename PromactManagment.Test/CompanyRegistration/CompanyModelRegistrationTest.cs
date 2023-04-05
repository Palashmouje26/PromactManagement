using Microsoft.AspNetCore.Mvc;
using Moq;
using PromactManagement.DomainModel.ApplicationClass.DTO.CompanyRegistrationDTO;
using PromactManagement.Repository.CompanyRegistration;
using PromactManagement.Repository.Data;
using PromactManagement.Web.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PromactManagment.Test.CompanyRegistration
{
    public class CompanyModelRegistrationTest
    {
        #region Private Variables
        #region Dependencies
        private readonly Mock<ICompanyRegistrationRepository> _companyRegistration;
        private readonly CompanyRegistrationController _companyRegistrationController;
        private readonly Mock<IDataRepository> _dataRepository;
        #endregion
        #endregion

        #region Constructor
        public CompanyModelRegistrationTest()
        {
            _companyRegistration = new Mock<ICompanyRegistrationRepository>();
            _dataRepository = new Mock<IDataRepository>();
            _companyRegistrationController = new CompanyRegistrationController(_companyRegistration.Object);
        }
        #endregion

        #region Testing Methods

        /// <summary>
        ///  This test case used to show all company detail in list view.
        /// </summary>
        [Fact]
        public async Task GetAllCompanyDetailTest()
        {
            //Arrange
            _companyRegistration.Setup(x => x.GetAllCompanyDetailAsync()).ReturnsAsync(new List<CompanyModelDTO>() { new CompanyModelDTO(), new CompanyModelDTO() });
            //Art
            var result = await _companyRegistrationController.GetCompanyDetailAsync();
            //Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var company = Assert.IsType<List<CompanyModelDTO>>(viewResult.Value);
            Assert.Equal(2, company.Count);
        }

        /// <summary>
        /// This test case used to  show selected company information  is created.
        /// </summary>
        [Fact]
        public async Task GetCompanyByIDTest()
        {
            //Arrange
            var companyList = GetCompanyData();
            //Art
            _companyRegistration.Setup(x => x.GetCompanyDetailByIdAsync(It.IsAny<int>())).ReturnsAsync(companyList);
            var CompanyData = await _companyRegistrationController.GetComanyByIDAsync(3);
            //Assert
            Assert.NotNull(CompanyData);
        }
        /// <summary>
        /// This test case used to check company is created.
        /// </summary>
        [Fact]
        public async Task CreateCompanyTest()
        {
            //Arrange
            CompanyModelDTO company = new CompanyModelDTO()
            {
                ComapnyId = 1,
                CompanyName = "Bhushan",
                CompanyOwner = "Bhushan@gmail.com",
                OrganizationId = 3,
                PartnerLevel = "Silver",
                CompanyStatus = true,
                CompanyCreateDate = System.DateTime.UtcNow,
                Notes = "Hello World",
                website = "www.bhusan.com",
                URLLinke = "htttp://www.google.com",
            };
            //Art
            _companyRegistration.Setup(x => x.CreateCompanyAsync(It.IsAny<CompanyModelDTO>())).ReturnsAsync(company);
            var companyData = await _companyRegistrationController.AddCompanyDetailAsync(company);
            //Assert
            var viewResult = Assert.IsType<OkObjectResult>(companyData);
            Assert.Equal("Company Created Successfully", viewResult.Value);
        }
        /// <summary>
        /// This test case used to update company information.
        /// </summary>
        [Fact]
        public async Task UpdateCompanyTest()
        {
            //Arrange
            CompanyModelDTO company = new CompanyModelDTO()
            {
                ComapnyId = 1,
                CompanyName = "Jio",
                CompanyOwner = "Jio@gmail.com",
                OrganizationId = 3,
                PartnerLevel = "Silver",
                CompanyStatus = true,
                CompanyCreateDate = System.DateTime.UtcNow,
                Notes = "Hello World",
                website = "www.bhusan.com",
                URLLinke = "htttp://www.google.com",
            };
            //Art
            _companyRegistration.Setup(x => x.UpdateCompanyDetailAsync(It.IsAny<CompanyModelDTO>())).ReturnsAsync(company);
             
            var result = await _companyRegistrationController.UpdateCompanyAsync(company);
            //Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Update Successfully", viewResult.Value);
        }



        #region Private Method
        /// <summary>
        /// Create company detail. 
        /// </summary>
        /// <returns>Return CompanyDetail object </returns>
        private CompanyModelDTO GetCompanyData()
        {
            var CompanyDetail = new CompanyModelDTO();

            CompanyDetail.ComapnyId = 1;
            CompanyDetail.CompanyName = "Bhushan";
            CompanyDetail.CompanyOwner = "Bhushan@gmail.com";
            CompanyDetail.OrganizationId = 3;
            CompanyDetail.PartnerLevel = "Silver";
            CompanyDetail.CompanyStatus = true;
            CompanyDetail.CompanyCreateDate = System.DateTime.UtcNow;
            CompanyDetail.Notes = "Hello World";
            CompanyDetail.website = "www.bhusan.com";
            CompanyDetail.URLLinke = "htttp://www.google.com";
            return CompanyDetail;
        }
        #endregion

        #endregion
    }
}
