using PromactManagement.DomainModel.Models.CompanyRagistrationDto;
using PromactManagement.DomainModel.Models.OrganizationListDto;
using PromactManagement.DomainModel.Models.OrganizationModuleDetail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PromactManagement.Repository.CompanyRagistration
{
    public interface ICompanyRegistration
    {
        /// <summary>
        /// Add New company Details.
        /// </summary>
        /// <param name="company"> Add New Company or registration in Database.</param>
        /// <returns> return object</returns>
        Task<CompanyModelDto> CreateRagistrationAsync(CompanyModelDto company);
        /// <summary>
        /// Fetch the All Comapny  details.
        /// </summary>
        /// <returns> Fetch the details from the datebase and show in List</returns>
        Task<List<CompanyModelDto>> GetAllCompanyDetailAsync();
        /// <summary>
        ///  Updating the comapny details.
        /// </summary>
        /// <param name="companyDetail">Company detail to update.</param>
        /// <returns> Updated comapny detail.</returns>
        Task<CompanyModelDto> UpdateCompanyDetailAsync(CompanyModelDto companyDetail);
        /// <summary>
        /// Fetch the comany details with  Id.
        /// </summary>
        /// <param name="Id">Get particlar comapny deatails by Id</param>
        /// <returns>List the details from the database</returns>
        Task<CompanyModelDto> GetCompanyDetailByIdAsync(int Id);
    }
}
