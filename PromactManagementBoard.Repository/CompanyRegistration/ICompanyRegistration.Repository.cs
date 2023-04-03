using PromactManagement.DomainModel.ApplicationClass.DTO.CompanyRegistrationDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PromactManagement.Repository.CompanyRegistration
{
    public interface ICompanyRegistration
    {
        /// <summary>
        /// Add New company Details.
        /// </summary>
        /// <param name="company"> Add New Company or registration in Database.</param>
        /// <returns> return object</returns>
        Task<CompanyModelDTO> CreateCompanyAsync(CompanyModelDTO company);
        /// <summary>
        /// Fetch the All Comapny  details.
        /// </summary>
        /// <returns> Fetch the details from the datebase and show in List.</returns>
        Task<List<CompanyModelDTO>> GetAllCompanyDetailAsync();
        /// <summary>
        ///  Updating the comapny details.
        /// </summary>
        /// <param name="companyDetail">Company detail to update.</param>
        /// <returns> Updated comapny detail.</returns>
        Task<CompanyModelDTO> UpdateCompanyDetailAsync(CompanyModelDTO companyDetail);
        /// <summary>
        /// Fetch the comany details with  Id.
        /// </summary>
        /// <param name="Id">Get particlar comapny deatails by Id.</param>
        /// <returns>List the details from the database.</returns>
        Task<CompanyModelDTO> GetCompanyDetailByIdAsync(int Id);
        /// <summary>
        ///  Updating the company status.
        /// </summary>
        /// <param name="Id">Id Is used for selected company detail to update.</param>
        /// <param name="Status">Status is used for change company status.</param>
        /// <returns>company status update.</returns>
        Task UpdateCompanyStatusByIdAsync(int Id, bool Status);

    }
}
