using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PromactManagement.DomainModel.Models.CompanyRegistration;
using PromactManagement.Repository.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using PromactManagement.DomainModel.ApplicationClass.DTO.CompanyRegistrationDTO;

namespace PromactManagement.Repository.CompanyRegistration
{
    public class CompanyRegistrationRepository : ICompanyRegistrationRepository
    {
        #region PrivetMember
        private readonly IDataRepository _dataRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public CompanyRegistrationRepository(IDataRepository dataRepository, IMapper mapper)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Add company details,Company  belong to only one organization.
        /// </summary>
        /// <param name="company">Company registration.</param>
        /// <returns> return object</returns>
        public async Task<CompanyModelDTO> CreateCompanyAsync(CompanyModelDTO company)
        {
            var response = await _dataRepository.Where<CompanyModelRegistration>(x => x.CompanyName == company.CompanyName).AsNoTracking().ToListAsync();
            foreach (var i in response)
            {
                bool areEqual = string.Equals(i.CompanyName, company.CompanyName, System.StringComparison.OrdinalIgnoreCase); //checking company name Upper or lower case.
                if (areEqual)
                {
                    throw new Exception("User already exists");
                }
            }
            var companyData = _mapper.Map<CompanyModelDTO, CompanyModelRegistration>(company);
            companyData.ComapnyId = 0;
            await _dataRepository.AddAsync(companyData);
            return company;

        }
        /// <summary>
        /// Show all registerd company list.
        /// </summary>
        /// <returns> List all company registerd with details.</returns>
        public async Task<List<CompanyModelDTO>> GetAllCompanyDetailAsync()
        {
            var companyDetail = await _dataRepository.Where<CompanyModelRegistration>(x => x.CompanyStatus).AsNoTracking().ToListAsync();
            return _mapper.Map<List<CompanyModelRegistration>, List<CompanyModelDTO>>(companyDetail);
        }

        /// <summary>
        /// This Method is used for showing list of company  details.
        /// </summary>
        /// <param name="Id">Id is used for particuller company detail find.</param>
        /// <returns>Show partucular company regiterd  with details.</returns>
        public async Task<CompanyModelDTO> GetCompanyDetailByIdAsync(int Id)
        {
            var companyDetail = await _dataRepository.FirstAsync<CompanyModelRegistration>(a => a.ComapnyId == Id);

            return _mapper.Map<CompanyModelDTO>(companyDetail);
        }


        /// <summary>
        /// Updating all company details .
        /// </summary>
        /// <param name="companyDetail">Company detail to update.</param>
        /// <returns>Updated company detail.</returns>
        public async Task<CompanyModelDTO> UpdateCompanyDetailAsync(CompanyModelDTO companyDetail)
        {
            if (companyDetail.ComapnyId == 1)
            {
                var companyData = await _dataRepository.FirstAsync<CompanyModelRegistration>(a => a.ComapnyId == companyDetail.ComapnyId);
                var data = _mapper.Map<CompanyModelDTO, CompanyModelRegistration>(companyDetail, companyData);
                await _dataRepository.UpdateAsync(data);
                return _mapper.Map<CompanyModelDTO>(companyDetail);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Updating company status.If organization satus changes inactive company status also get inactive.
        /// </summary>
        /// <param name="Id">Id Is used for selected company detail to update.</param>
        /// <param name="Status">Status is used for change company status</param>
        /// <returns></returns>
        public async Task UpdateCompanyStatusByIdAsync(int Id, bool Status)
        {
            var companyList = await _dataRepository.Where<CompanyModelRegistration>(x => x.OrganizationId == Id).AsNoTracking().ToListAsync();
            if (companyList.Count != 0)
            {
                foreach (var company in companyList)
                {
                    company.CompanyStatus = Status;
                }
                await _dataRepository.UpdateAsync(companyList);
            }
        }
        #endregion
    }
}
