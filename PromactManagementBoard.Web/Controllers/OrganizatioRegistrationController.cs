using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromactManagement.DomainModel.Models.OrganizationModuleDetail;
using PromactManagement.DomainModel.Models.OrganizationModuleRagistration;
using PromactManagement.Repository.OrganizationModuleRagistration;
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
       * @api {get} /api/OrganizatioRegistrationController /:get all organization information
       * @apiName GetOrganizationAsync
       * @apiGroup OrganizationModelRagistration
       * 
       * @apiSuccess : List Of registerd organization details.
       * 
       * @apiSuccessExample Success-Response:{object[]}   
       * @apiError OrganizationNotFound The information of the User was not found.
       */
        [HttpGet("organization")]
        public async Task<IActionResult> GetOrganizationAsync()
        {
            return Ok(await _organizationModule.GetAllOrganizationDetailAsync());
        }

        /**
       * @api {get} /api/OrganizatioRegistrationController /:id get one particuler organization information
       * @apiName GetorganizationByIDAsync
       * @apiGroup OrganizationModelRagistration
       *    
       * @apiParam {Number}  Id of the organization.
       */
        [HttpGet("organizationbyId/{Id}")]
        public async Task<IActionResult> GetorganizationByIDAsync([FromRoute] int Id)
        {
            return Ok(await _organizationModule.GetOrganizationDetailByIdAsync (Id));
        }

        /**
        * @api {post} /OrganizationModelRagistration/
        * @apiBody {String} organizationName           Mandatory Firstname of the user.
        * @apiBody {String} OrganizationOwnerEmailId   Mandatory  input with small letter"Xyz@xxx.com".
        * @apiBody {String} OrganizationStatus         Mandatory nested status object.
        * 
        * @apiSuccessExample Success-Response:
        *  { 
        *      organizationName = "John",
        *      OrganizationOwnerEmailId =  "Xyz@abc.com"
        *  }
        * @apiError return StatusCode.
        */
        [HttpPost("createorganization")]
        public async Task<IActionResult> AddOrganizationAsync([FromForm] OrganizationModelDto organization)
        {
           
            var result = await _organizationModule.CreateRagistrationAsync(organization);

            if (result.OrganizationId == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Created Successfully");
        }

        /**
      * @api {put} /OrganizatioRegistrationController/ Modify Organization information
      * @apiName UpdateOrganizationAsync
      * @apiGroup OrganizationModelRagistration
      *
      * @apiParam :{object[]} 
      * 
      * @apiError return BadRequest.
      */
        [HttpPut("updateorganization")]
        public async Task<ActionResult> UpdateOrganizationAsync([FromForm] OrganizationModelDto organizationDetail)
        {
            if (organizationDetail.OrganizationId != organizationDetail.OrganizationId)
            {
                return BadRequest();
            }
            await _organizationModule.UpdateOrganizationDetailAsync(organizationDetail);
            return Ok("Update Successfully");
        }
        #endregion
    }
}
