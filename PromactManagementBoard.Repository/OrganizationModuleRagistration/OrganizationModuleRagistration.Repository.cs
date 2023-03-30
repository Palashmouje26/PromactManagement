using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PromactManagement.DomainModel.Enum;
using PromactManagement.DomainModel.Models.OrganizationListDto;
using PromactManagement.DomainModel.Models.OrganizationModuleDetail;
using PromactManagement.DomainModel.Models.OrganizationModuleRagistration;
using PromactManagement.Repository.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PromactManagement.Repository.OrganizationModuleRagistration
{
    public class OrganizationModuleRagistration : IOrganizationModuleRagistration
    {
        #region PrivetMember
        private readonly IDataRepository _dataRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public OrganizationModuleRagistration(IDataRepository dataRepository, IMapper mapper)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Add Organization details 
        /// </summary>
        /// <param name="organization"></param>
        /// <returns> return object</returns>
        public async Task<OrganizationModelDto> CreateRagistrationAsync(OrganizationModelDto organization)
        {
            var newUser = _mapper.Map<OrganizationModelDto, OrganizationModel>(organization);
           // PartnerLevelType par = new PartnerLevelType(); 
            newUser.OrganizationId = 0;
            if (organization.OrganizationType == OrganizationType.Partner) 
            {
                newUser.Partnersince = organization.Partnersince;
            }
            else
            {
                newUser.Partnersince= 0;
            }
            if (organization.UseOverrides)
            {
                newUser.AUAOverride = $"{organization.CostsLastQuarter}M";
                newUser.VCOverride = $"{organization.CostsLastQuarter}M";
            }
            else
            {
                newUser.AUAOverride = null;
                newUser.VCOverride = null;
            }
            newUser.CostsLastQuarter = $"{organization.CostsLastQuarter}M";
            // $"{organization.CostsLastQuarter}M";
            //$@string.Format("{0:#,0.00}", item.TotalAmount)
            await _dataRepository.AddAsync(newUser);
            return _mapper.Map<OrganizationModel, OrganizationModelDto>(newUser);
        }

        /// <summary>
        /// Show all Organization list 
        /// </summary>
        /// <returns> List of partucular organizationName with details </returns>
        public async Task<List<OrganizationListDto>> GetAllUserAsync()
        {
            var userDetail = await _dataRepository.Where<OrganizationModel>(x => x.ActiveCompany == 0).AsNoTracking().ToListAsync();
            return _mapper.Map<List<OrganizationModel>, List<OrganizationListDto>>(userDetail);
        }

        /// <summary>
        /// This Method is used for showing List of user with registerd details
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<OrganizationListDto> GetUserByIdAsync(int Id)
        {
            var userDetail = await _dataRepository.FirstAsync<OrganizationModel>(a => a.OrganizationId == Id);

            return _mapper.Map<OrganizationListDto>(userDetail);
        }

        /// <summary>
        /// Updating OrganizationName, OrganizationOwnerEmailId, & OrganizationStatus
        /// </summary>
        /// <param name="User"> Current organizationId Is used</param>
        /// <returns>updating organization information</returns>
        public async Task<OrganizationModelDto> UpdateUserAsync(OrganizationModelDto User)
        {
            var userDetail = await _dataRepository.FirstAsync<OrganizationModel>(a => a.OrganizationId ==User.OrganizationId);

            userDetail.OrganizationName = User.OrganizationName;
            userDetail.OrganizationOwnerEmailId = User.OrganizationOwnerEmailId;
            userDetail.OrganizationStatus = User.OrganizationStatus;

            await _dataRepository.UpdateAsync(userDetail);
            return _mapper.Map<OrganizationModelDto>(userDetail);
        }
        #endregion
    }
}
