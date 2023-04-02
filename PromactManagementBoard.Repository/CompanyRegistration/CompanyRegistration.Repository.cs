using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PromactManagement.DomainModel.Models.CompanyModuleRagistration;
using PromactManagement.DomainModel.Models.CompanyRagistrationDto;
using PromactManagement.Repository.CompanyRagistration;
using PromactManagement.Repository.Data;
using PromactManagement.Repository.OrganizationModuleRagistration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromactManagement.Repository.CompanyRegistration
{
    public  class CompanyRegistration : ICompanyRegistration
    {
        #region PrivetMember
        private readonly IOrganizationRegistration _organizationModule;
        private readonly IDataRepository _dataRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public CompanyRegistration(IDataRepository dataRepository, IMapper mapper)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Add company details.
        /// </summary>
        /// <param name="company">Company registertion.</param>
        /// <returns> return object</returns>
        public async Task<CompanyModelDto> CreateRagistrationAsync(CompanyModelDto company)
        {
            var organization = await _dataRepository.Where<CompanyModelRegistration>(x => x.CompanyName ==company.CompanyName && x.OrganizationId == company.OrganizationId ).AsNoTracking().ToListAsync();
            if (organization.Select(a=>a.OrganizationId).Contains(company.OrganizationId))
            {
                return company;
            }
            var companyData = _mapper.Map<CompanyModelDto, CompanyModelRegistration>(company);
            companyData.ComapnyId = 0;

            await _dataRepository.AddAsync(companyData);
            return _mapper.Map<CompanyModelRegistration, CompanyModelDto>(companyData);
        }
        /// <summary>
        /// Show all registerd company list.
        /// </summary>
        /// <returns> List of all company registerd with details.</returns>
        public async Task<List<CompanyModelDto>> GetAllCompanyDetailAsync()
        {
            var companyDetail = await _dataRepository.Where<CompanyModelRegistration>(x => x.CompanyStatus == true).AsNoTracking().ToListAsync();
            return _mapper.Map<List<CompanyModelRegistration>, List<CompanyModelDto>>(companyDetail);
        }

        /// <summary>
        /// This Method is used for showing list of comoany  details.
        /// </summary>
        /// <param name="Id">Id is used for particuller company detail find.</param>
        /// <returns>List of partucular company regiterd  with details.</returns>
        public async Task<CompanyModelDto> GetCompanyDetailByIdAsync(int Id)
        {
            var companyDetail = await _dataRepository.FirstAsync<CompanyModelRegistration>(a => a.ComapnyId == Id);

            return _mapper.Map<CompanyModelDto>(companyDetail);
        }


        /// <summary>
        /// Updating companyName,companyownerEmailId.
        /// </summary>
        /// <param name="companyDetail">Organization detail to update.</param>
        /// <returns>Updated company detail.</returns>
        public async Task<CompanyModelDto> UpdateCompanyDetailAsync(CompanyModelDto companyDetail)
        {
            var companyData = await _dataRepository.FirstAsync<CompanyModelRegistration>(a => a.ComapnyId == companyDetail.ComapnyId);

            companyData.CompanyName = companyDetail.CompanyName;
            companyData.CompanyOwner = companyDetail.CompanyOwner;
          

            await _dataRepository.UpdateAsync(companyData);
            return _mapper.Map<CompanyModelDto>(companyDetail);
        }


        #endregion
    }
}
