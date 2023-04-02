using Microsoft.AspNetCore.Mvc;
using PromactManagement.DomainModel.Models.OrganizationListDto;
using PromactManagement.DomainModel.Models.OrganizationModuleDetail;
using PromactManagement.DomainModel.Models.OrganizationModuleRagistration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PromactManagement.Repository.OrganizationModuleRagistration
{
    public interface IOrganizationRegistration
    {
        /// <summary>
        /// Add New organization Details.
        /// </summary>
        /// <param name="organization">Add New organization or registration in Database</param>
        /// <returns> return object</returns>
        Task<OrganizationModelDto> CreateRagistrationAsync(OrganizationModelDto organization);

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

    }
}
