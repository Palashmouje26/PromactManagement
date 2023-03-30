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
    public interface IOrganizationModuleRagistration
    {
        /// <summary>
        /// Add New organization Details
        /// </summary>
        /// <param name="organization">Add New organization or ragesterd in Stors</param>
        /// <returns> return object</returns>
        Task<OrganizationModelDto> CreateRagistrationAsync(OrganizationModelDto organization);

        /// <summary>
        /// Fetch the AllUser details 
        /// </summary>
        /// <returns>Fetch the details from the database</returns>
        Task<List<OrganizationListDto>> GetAllUserAsync();

        /// <summary>
        /// Fetch the organization details with  Id
        /// </summary>
        /// <param name="UserId">Get perticlar organization deatails in the stores</param>
        /// <returns> Fetch the details from the database</returns>
        Task<OrganizationListDto> GetUserByIdAsync(int UserId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        Task<OrganizationModelDto> UpdateUserAsync(OrganizationModelDto User);

    }
}
