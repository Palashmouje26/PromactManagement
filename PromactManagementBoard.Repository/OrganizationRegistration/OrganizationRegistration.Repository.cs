using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PromactManagement.DomainModel.Enum;
using PromactManagement.DomainModel.Models.CompanyRegistration;
using PromactManagement.DomainModel.Models.OrganizationListDto;
using PromactManagement.DomainModel.Models.OrganizationModuleDetail;
using PromactManagement.DomainModel.Models.OrganizationModuleRegistration;
using PromactManagement.Repository.CompanyRegistration;
using PromactManagement.Repository.Data;
using PromactManagement.Repository.OrganizationModuleRegistration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PromactManagement.Repository.OrganizationRegistration
{
    public class OrganizationRegistration : IOrganizationRegistration
    {
        #region PrivetMember
        private readonly ICompanyRegistration _companyRegistration;
        private readonly IDataRepository _dataRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public OrganizationRegistration(IDataRepository dataRepository, IMapper mapper, ICompanyRegistration companyRegistration)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
            _companyRegistration = companyRegistration;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Add Organization details.
        /// </summary>
        /// <param name="organization"> organization registertion.</param>
        /// <returns> return object</returns>
        public async Task<OrganizationModelDto> CreateOrganizationAsync(OrganizationModelDto organization)
        {
            var newOrganization = _mapper.Map<OrganizationModelDto, OrganizationModel>(organization);
            newOrganization.OrganizationId = 0;
            if (organization.OrganizationType == OrganizationType.Partner)
            {
                newOrganization.PartnerSince = organization.Partnersince;
            }
            else
            {
                newOrganization.PartnerSince = 0;
            }
            if (organization.UseOverrides)
            {
                newOrganization.AUAOverride = $"{organization.CostsLastQuarter}M";
                newOrganization.VCOverride = $"{organization.CostsLastQuarter}M";
            }
            else
            {
                newOrganization.AUAOverride = null;
                newOrganization.VCOverride = null;
            }
            newOrganization.CostsLastQuarter = $"{organization.CostsLastQuarter}M";
            await _dataRepository.AddAsync(newOrganization);
            return _mapper.Map<OrganizationModel, OrganizationModelDto>(newOrganization);
        }

        /// <summary>
        /// Show all registerd Organization list.
        /// </summary>
        /// <returns> List of all organization registerd with details.</returns>
        public async Task<List<OrganizationListDto>> GetAllOrganizationDetailAsync()
        {
            var organizationDetail = await _dataRepository.Where<OrganizationModel>(x => x.ActiveCompany == 0).AsNoTracking().ToListAsync();

            return _mapper.Map<List<OrganizationModel>, List<OrganizationListDto>>(organizationDetail);
        }

        /// <summary>
        /// This Method is used for showing List of organization  details.
        /// </summary>
        /// <param name="Id">Id is used for particuller Organization detail find.</param>
        /// <returns>Showing of partucular organization regiterd  with details.</returns>
        public async Task<OrganizationListDto> GetOrganizationDetailByIdAsync(int Id)
        {
            var organizationDetail = await _dataRepository.FirstAsync<OrganizationModel>(a => a.OrganizationId == Id);
            var data = _mapper.Map<OrganizationListDto>(organizationDetail);
            var totalActiveCompany = await _dataRepository.CountAsync<OrganizationModel>(x => x.OrganizationId == Id && x.ActiveCompany == 0);
            data.ActiveCompany = totalActiveCompany;
            return data;
        }


        /// <summary>
        /// Updating all the organization information.
        /// </summary>
        /// <param name="organizationDetail">Organization detail to update.</param>
        /// <returns>Updated organization detail.</returns>
        public async Task<OrganizationModelDto> UpdateOrganizationDetailAsync(OrganizationModelDto organizationDetail)
        {
            var organizationData = await _dataRepository.FirstAsync<OrganizationModel>(a => a.OrganizationId == organizationDetail.OrganizationId);

            var res = _mapper.Map<OrganizationModelDto, OrganizationModel>(organizationDetail, organizationData);
            await _dataRepository.UpdateAsync(res);
            return _mapper.Map<OrganizationModelDto>(organizationData);
        }

        /// <summary>
        /// Updating Organization Stauts.
        /// </summary>
        /// <param name="Id">Id Is used for selected organization detail to update.</param>
        /// <param name="Status">Status is used for change organization status.</param>
        /// <returns>Updating Organization status.</returns>
        public async Task<OrganizationModelDto> UpdateOrganizationStatusAsync(int Id, bool Status)
        {
            var organizationData = await _dataRepository.FirstOrDefaultAsync<OrganizationModel>(a => a.OrganizationId == Id);
            if (organizationData != null)
            {
                organizationData.OrganizationStatus = Status;
                var companyListData = new List<CompanyModelRegistration>();
                await _dataRepository.UpdateAsync(organizationData);
                var companyList = await _dataRepository.Where<CompanyModelRegistration>(a => a.OrganizationId == Id).ToListAsync();
                foreach (var company in companyList) 
                {
                    company.CompanyStatus = Status;
                    await _dataRepository.UpdateAsync(company);
                }
            }
            return _mapper.Map<OrganizationModelDto>(organizationData);
        }
        #endregion
    }
}
