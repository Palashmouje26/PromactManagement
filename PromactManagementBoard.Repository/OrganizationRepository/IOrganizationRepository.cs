﻿using PromactManagement.DomainModel.ApplicationClass.DTO.OrganizationListDTO;
using PromactManagement.DomainModel.ApplicationClass.DTO.OrganizationModuleDTO;
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
        Task<OrganizationDTO> CreateOrganizationAsync(OrganizationDTO organization);

        /// <summary>
        /// Fetch the All Organization details.
        /// </summary>
        /// <returns>Fetch the details from the database</returns>
        Task<List<OrganizationListDTO>> GetAllOrganizationDetailAsync();

        /// <summary>
        /// Fetch the organization details with  Id.
        /// </summary>
        /// <param name="Id">Get perticlar organization deatails by Id</param>
        /// <returns> Fetch the details from the database</returns>
        Task<OrganizationListDTO> GetOrganizationDetailByIdAsync(int Id);

        /// <summary>
        /// Updating the organization details.
        /// </summary>
        /// <param name="organizationDetail">Organization detail to update.</param>
        /// <returns>Updated organization detail.</returns>
        Task<OrganizationDTO> UpdateOrganizationDetailAsync(OrganizationDTO organizationDetail);

        /// <summary>
        /// Updating the organization status.
        /// </summary>
        /// <param name="Id">Id Is used for selected organization detail to update.</param>
        /// <param name="Status">Status is used for change organization status</param>
        /// <returns>Organization status update.</returns>
        Task<OrganizationDTO> UpdateOrganizationStatusAsync(int Id, bool Status);
    }
}
