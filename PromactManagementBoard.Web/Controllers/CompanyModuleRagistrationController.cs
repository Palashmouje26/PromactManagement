using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromactManagement.DomainModel.Models.CompanyRagistrationDto;
using PromactManagement.DomainModel.Models.OrganizationModuleDetail;
using PromactManagement.Repository.CompanyModuleRagistration;
using PromactManagement.Repository.OrganizationModuleRagistration;
using System.Threading.Tasks;

namespace PromactManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyModuleRagistrationController : ControllerBase
    {
        #region private Member
        
        private readonly ICompanyModuleRagistration _companyModuleRagistration;
        #endregion

        #region Constructor
        public CompanyModuleRagistrationController(ICompanyModuleRagistration companyModuleRagistration)
        {
            _companyModuleRagistration = companyModuleRagistration;
        }
        #endregion

        #region public Methods

        [HttpGet("getOrganization")]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _companyModuleRagistration.GetAllUserAsync());
        }

        [HttpPost("company")]
        public async Task<IActionResult> AddUserAsync([FromForm] CompanyModelDto company)
        {

            var result = await _companyModuleRagistration.CreateRagistrationAsync(company);

            if (result.OrganizationId == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Created Successfully");
        }

        #endregion
    }
}
