using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromactManagement.DomainModel.ApplicationClass.DTO.OrganizationModuleDTO;
using PromactManagement.Repository.CompanyRegistration;
using PromactManagement.Repository.OrganizationModuleRegistration;
using System.Threading.Tasks;

namespace PromactManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizatioRegistrationController : ControllerBase
    {
        #region private Member
        private readonly IOrganizationRegistration _organizationModule;

        #endregion

        #region Constructor
        public OrganizatioRegistrationController(IOrganizationRegistration organizationModule)
        {
            _organizationModule = organizationModule;

        }
        #endregion

        #region public Methods
        /**
       * @api {get} /api/Organization/:get all organization information.
       * @apiName GetOrganizationAsync.
       * @apiGroup Organization.
       * 
       * @apiSuccess : List Of registerd organization details.
       * 
       * @apiSuccessExample Success-Response:{object[]}   
       */
        [HttpGet("organization")]
        public async Task<IActionResult> GetOrganizationAsync()
        {
            return Ok(await _organizationModule.GetAllOrganizationDetailAsync());
        }

        /**
       * @api {get} /api/Organization/:Id get one particuler organization information.
       * @apiName GetorganizationByIDAsync.
       * @apiGroup Organization.
       *    
       * @apiParam {Number}  Id of the organization.
       */
        [HttpGet("organizationbyId/{Id}")]
        public async Task<IActionResult> GetOrganizationByIDAsync([FromRoute] int Id)
        {
            return Ok(await _organizationModule.GetOrganizationDetailByIdAsync(Id));
        }

        /**
        *   @api {post} api/Organization/add organization Method to add organization detail.
        *   
        *   @apiBody {object} organization detail.
        */
        [HttpPost("createorganization")]
        public async Task<IActionResult> AddOrganizationAsync([FromForm] OrganizationDTO organization)
        {

            var result = await _organizationModule.CreateOrganizationAsync(organization);

            if (result.OrganizationId == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Created Successfully");
        }

        /**
      * @api {put} /Organization/ Modify Organization information.
      * @apiName UpdateOrganizationAsync.
      * @apiGroup Organization.
      *
      * @apiParam :{object[]} 
      * 
      * @apiError return BadRequest.
      */
        [HttpPut("updateorganization")]
        public async Task<ActionResult> UpdateOrganizationAsync([FromForm] OrganizationDTO organizationDetail)
        {
            if (organizationDetail.OrganizationId != organizationDetail.OrganizationId)
            {
                return BadRequest();
            }
            await _organizationModule.UpdateOrganizationDetailAsync(organizationDetail);
            return Ok("Update Successfully");
        }
        /**
        * @api {put} /Organization/ Modify Organization status.
        * @apiName UpdateOrganizationStatusAsync.
        * @apiGroup Organization.
        *
        * @apiParam :{object[]} 
        * 
        */
        [HttpPut("updateorganizationstatus")]
        public async Task<ActionResult> UpdateOrganizationStatusAsync(int Id, bool Status)
        {

            await _organizationModule.UpdateOrganizationStatusAsync(Id, Status);

            return Ok("Status Update Successfully");
        }
        #endregion
    }
}
