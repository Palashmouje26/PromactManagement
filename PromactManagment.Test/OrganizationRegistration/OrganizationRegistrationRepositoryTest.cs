using Microsoft.AspNetCore.Mvc;
using Moq;
using PromactManagement.DomainModel.ApplicationClass.DTO.OrganizationListDTO;
using PromactManagement.DomainModel.ApplicationClass.DTO.OrganizationModuleDTO;
using PromactManagement.Repository.Data;
using PromactManagement.Repository.OrganizationModuleRegistration;
using PromactManagement.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PromactManagment.Test.OrganizationRegistration
{
    public class OrganizationRegistrationRepositoryTest
    {
        #region Private Variables
        #region Dependencies
        private readonly Mock<IOrganizationRegistration> _organizationModule;
        private readonly OrganizatioRegistrationController _organizationController;
        private readonly Mock<IDataRepository> _dataRepository;
        #endregion
        #endregion

        #region Constructor

        public OrganizationRegistrationRepositoryTest()
        {
            _organizationModule = new Mock<IOrganizationRegistration>();
            _dataRepository = new Mock<IDataRepository>();
            _organizationController = new OrganizatioRegistrationController(_organizationModule.Object);
        }
        #endregion

        #region Testing Methods
        /// <summary>
        /// This test case used to show all organization detail in list view.
        /// </summary>
        [Fact]
        public async Task GetAllOrganizationDetailTest()
        {
            //Arrange
            _organizationModule.Setup(x => x.GetAllOrganizationDetailAsync()).ReturnsAsync(new List<OrganizationListDto>() { new OrganizationListDto(), new OrganizationListDto() });
            //Art
            var result = await _organizationController.GetOrganizationAsync();
            //Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var organization = Assert.IsType<List<OrganizationListDto>>(viewResult.Value);
            Assert.Equal(2, organization.Count);
        }

        /// <summary>
        ///  This test case used to  show selected organization information  is created.
        /// </summary>
        [Fact]
        public async Task GetOrganizationByIDTest()
        {
            var organizationList = GetOrganizationData();

            _organizationModule.Setup(x => x.GetOrganizationDetailByIdAsync(It.IsAny<int>())).ReturnsAsync(organizationList);

            var organizationData = await _organizationController.GetOrganizationByIDAsync(3);

            //Assert
            Assert.NotNull(organizationData);
        }
        /// <summary>
        /// This test case used to check organization is created.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateOrganizationTest()
        {
            OrganizationDTO organizations = new OrganizationDTO()
            {
                OrganizationId = 4,
                OrganizationName = "Test",
                OrganizationOwnerEmailId = "RRR@gmail.com",
                PartnerLevel = "Silver",
                OrganizationStatus = false,
                OrganizationType = "Partner",
                PartnerSince = 1986,
                UseOverrides = true,
                AUAOverride = "239M",
                VCOverride = "239M",
                CostsLastQuarter = "298M",
                ActiveSince = System.DateTime.Now,
                Notes = "dsfs"
            };

            _organizationModule.Setup(x => x.CreateOrganizationAsync(It.IsAny<OrganizationDTO>())).ReturnsAsync(organizations);

            var organizationData = await _organizationController.AddOrganizationAsync(organizations);
           
            var viewResult = Assert.IsType<OkObjectResult>(organizationData);

            Assert.Equal("Created Successfully", viewResult.Value);
        }

        /// <summary>
        /// This test case used to update organization information.
        /// </summary>
        [Fact]
        public async Task UpdateOrganizationTest ()
        {
            OrganizationDTO organizations = new OrganizationDTO()
            {
                OrganizationId = 3,
                OrganizationName = "Palash",
                OrganizationOwnerEmailId = "Palash@gmail.com",
                PartnerLevel = "Gold",
                OrganizationStatus = false,
                OrganizationType = "Partner",
                PartnerSince = 1986,
                UseOverrides = true,
                AUAOverride = "240M",
                VCOverride = "249M",
                CostsLastQuarter = "398M",
                ActiveSince = System.DateTime.Now,
                Notes = "Hello World"
            };

            _organizationModule.Setup(x => x.UpdateOrganizationDetailAsync(It.IsAny<OrganizationDTO>())).ReturnsAsync(organizations);

            var organizationData = await _organizationController.UpdateOrganizationAsync(organizations);

            var viewResult = Assert.IsType<OkObjectResult>(organizationData);

            Assert.Equal("Update Successfully", viewResult.Value);
        }

        #region Private Method
        /// <summary>
        /// Create organization detail. 
        /// </summary>
        /// <returns>Return organizationDetail object </returns>
        private OrganizationListDto GetOrganizationData()
        {
            var organizationDetail = new OrganizationListDto();

            organizationDetail.OrganizationId = 3;
            organizationDetail.OrganizationName = "RRRR";
            organizationDetail.OrganizationOwnerEmailId = "RRR@gmail.com";
            organizationDetail.PartnerLevel = "Partner";
            organizationDetail.ActiveCompany = 1;
            organizationDetail.OrganizationStatus = false;
            organizationDetail.OrganizationType = "Partner";
            organizationDetail.PartnerSince = 1986;
            organizationDetail.UseOverrides = true;
            organizationDetail.AUAOverride = "239M";
            organizationDetail.VCOverride = "239M";
            organizationDetail.CostsLastQuarter = "298M";
            organizationDetail.ActiveSince = System.DateTime.Now;
            organizationDetail.Notes = "dsfs";
            return organizationDetail;

        }
        #endregion
        #endregion
    }
}
