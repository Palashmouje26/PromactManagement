using PromactManagement.DomainModel.Models.CompanyRagistrationDto;
using PromactManagement.DomainModel.Models.OrganizationListDto;
using PromactManagement.DomainModel.Models.OrganizationModuleDetail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PromactManagement.Repository.CompanyModuleRagistration
{
    public interface ICompanyModuleRagistration
    {

        Task<CompanyModelDto> CreateRagistrationAsync(CompanyModelDto company);
        Task<List<OrganizationListDto>> GetAllUserAsync();
    }
}
