using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PromactManagement.DomainModel.Models.CompanyRagistrationDto;
using PromactManagement.DomainModel.Models.OrganizationListDto;
using PromactManagement.DomainModel.Models.OrganizationModuleRagistration;
using PromactManagement.Repository.Data;
using PromactManagement.Repository.OrganizationModuleRagistration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PromactManagement.Repository.CompanyModuleRagistration
{
    public  class CompanyModuleRagistration : ICompanyModuleRagistration
    {
        #region PrivetMember
        private readonly IOrganizationModuleRagistration _organizationModule;
        private readonly IDataRepository _dataRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public CompanyModuleRagistration(IDataRepository dataRepository, IMapper mapper)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
        }
        #endregion

        #region Public Methods

        public async Task<CompanyModelDto> CreateRagistrationAsync(CompanyModelDto company)
        {
            var newUser = _mapper.Map<CompanyModelDto, CompanyModuleRagistration>(company);
            var response = GetAllUserAsync();
            {
               
            }

            await _dataRepository.AddAsync(newUser);
            return _mapper.Map<CompanyModuleRagistration, CompanyModelDto>(newUser);
        }
        public async Task<List<OrganizationListDto>> GetAllUserAsync()
        {
            var userDetail = await _dataRepository.Where<OrganizationModel>(x => x.ActiveCompany == 0).AsNoTracking().ToListAsync();
            return _mapper.Map<List<OrganizationModel>, List<OrganizationListDto>>(userDetail);
        }

        #endregion
    }
}
