using PromactManagement.DomainModel.Models.OrganizationListDto;
using PromactManagement.DomainModel.Models.OrganizationModuleDetail;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PromactManagement.Repository.OrganizationModuleRegistration
{
    public interface IOrganizationRegistration
    {
        /// <summary>
        /// Add New organization Details.
        /// </summary>
        /// <param name="organization">Add New organization or registration in Database</param>
        /// <returns> return object</returns>
        Task<OrganizationModelDto> CreateOrganizationAsync(OrganizationModelDto organization);

        /// <summary>
        /// Fetch the All Organization details.
        /// </summary>
        /// <returns>Fetch the details from the database</returns>
        Task<List<OrganizationListDto>> GetAllOrganizationDetailAsync();

        /// <summary>
        /// Fetch the organization details with  Id.
        /// </summary>
        /// <param name="Id">Get perticlar organization deatails by Id</param>
        /// <returns> Fetch the details from the database</returns>
        Task<OrganizationListDto> GetOrganizationDetailByIdAsync(int Id);

        /// <summary>
        /// Updating the organization details.
        /// </summary>
        /// <param name="organizationDetail">Organization detail to update.</param>
        /// <returns>Updated organization detail.</returns>
        Task<OrganizationModelDto> UpdateOrganizationDetailAsync(OrganizationModelDto organizationDetail);

        /// <summary>
        /// Updating the organization status.
        /// </summary>
        /// <param name="Id">Id Is used for selected company detail to update.</param>
        /// <param name="Status">Status is used for change company status</param>
        /// <returns>Organization status updat.</returns>
        Task<OrganizationModelDto> UpdateOrganizationStatusAsync(int Id, bool Status);
    }
}
