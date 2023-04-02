using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PromactManagement.DomainModel.Enum;
using PromactManagement.DomainModel.Models.OrganizationListDto;
using PromactManagement.DomainModel.Models.OrganizationModuleDetail;
using PromactManagement.DomainModel.Models.OrganizationModuleRagistration;
using PromactManagement.Repository.Data;
using PromactManagement.Repository.OrganizationModuleRagistration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PromactManagement.Repository.OrganizationRegistration
{
    public class OrganizationRegistration : IOrganizationRegistration
    {
        #region PrivetMember
        private readonly IDataRepository _dataRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public OrganizationRegistration(IDataRepository dataRepository, IMapper mapper)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Add Organization details.
        /// </summary>
        /// <param name="organization"> organization registertion.</param>
        /// <returns> return object</returns>
        public async Task<OrganizationModelDto> CreateRagistrationAsync(OrganizationModelDto organization)
        {
            var newOrganization = _mapper.Map<OrganizationModelDto, OrganizationModel>(organization);
             newOrganization.OrganizationId = 0;
            if (organization.OrganizationType == OrganizationType.Partner) 
            {
                newOrganization.Partnersince = organization.Partnersince;
            }
            else
            {
                newOrganization.Partnersince= 0;
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
            // $"{organization.CostsLastQuarter}M";
            //$@string.Format("{0:#,0.00}", item.TotalAmount)
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
            OrganizationListDto newOrganization = new OrganizationListDto();

            return _mapper.Map<List<OrganizationModel>, List<OrganizationListDto>>(organizationDetail);
        }

        /// <summary>
        /// This Method is used for showing List of organization  details.
        /// </summary>
        /// <param name="Id">Id is used for particuller Organization detail find.</param>
        /// <returns>List of partucular organization regiterd  with details.</returns>
        public async Task<OrganizationListDto> GetOrganizationDetailByIdAsync (int Id)
        {
            var organizationDetail = await _dataRepository.FirstAsync<OrganizationModel>(a => a.OrganizationId == Id);

            OrganizationListDto newOrganization = new OrganizationListDto();
            newOrganization.OrganizationId = Id;
            newOrganization.OrganizationName = organizationDetail.OrganizationName;
            newOrganization.OrganizationOwnerEmailId = organizationDetail.OrganizationOwnerEmailId;
           // newOrganization.PartnerLevel = organizationDetail.PartnerLevel;
            newOrganization .ActiveCompany= await _dataRepository.CountAsync<OrganizationModel>(authUser => authUser.OrganizationId == Id && authUser.ActiveCompany==0);
            newOrganization.OrganizationStatus = organizationDetail.OrganizationStatus;
            //newOrganization.OrganizationType    = organizationDetail.OrganizationType;
            newOrganization.Partnersince = organizationDetail.Partnersince;
            newOrganization.UseOverrides = organizationDetail.UseOverrides;
            newOrganization.AUAOverride = organizationDetail.AUAOverride;
            newOrganization.VCOverride = organizationDetail.VCOverride;
            newOrganization.CostsLastQuarter = organizationDetail.CostsLastQuarter;
            newOrganization.ActiveSince = organizationDetail.ActiveSince;
            newOrganization.Notes = organizationDetail.Notes;
            return _mapper.Map<OrganizationListDto>(newOrganization);
        }
        

        /// <summary>
        /// Updating OrganizationName, OrganizationOwnerEmailId, & OrganizationStatus.
        /// </summary>
        /// <param name="organizationDetail">Organization detail to update.</param>
        /// <returns>Updated organization detail.</returns>
        public async Task<OrganizationModelDto> UpdateOrganizationDetailAsync (OrganizationModelDto organizationDetail)
        {
            var organizationData = await _dataRepository.FirstAsync<OrganizationModel>(a => a.OrganizationId == organizationDetail.OrganizationId);

            organizationData.OrganizationName = organizationDetail.OrganizationName;
            organizationData.OrganizationOwnerEmailId = organizationDetail.OrganizationOwnerEmailId;
            organizationData.OrganizationStatus = organizationDetail.OrganizationStatus;

            await _dataRepository.UpdateAsync(organizationData);
            return _mapper.Map<OrganizationModelDto>(organizationDetail);
        }
        #endregion
    }
}
