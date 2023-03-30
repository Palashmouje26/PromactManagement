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
    public class OrganizationModuleRagistrationController : ControllerBase
    {
        #region private Member
        private readonly IOrganizationModuleRagistration _organizationModule;
        #endregion

        #region Constructor
        public OrganizationModuleRagistrationController(IOrganizationModuleRagistration organizationModule)
        {
            _organizationModule = organizationModule;
        }
        #endregion

        #region public Methods
        /**
       * @api {get} /api/organizationModule /:get all organization information
       * @apiName GetOrganizationAsync
       * @apiGroup OrganizationModelRagistration
       * 
       * @apiSuccess {String} UserName Username of the User.
       * 
       * @apiSuccessExample Success-Response:{object[]}   
       * @apiError OrganizationNotFound The information of the User was not found.
       */
        [HttpGet("getorganization")]
        public async Task<IActionResult> GetOrganizationAsync()
        {
            return Ok(await _organizationModule.GetAllUserAsync());
        }

        /**
       * @api {get} /api/organizationModule /:id get one particuler organization information
       * @apiName GetorganizationByIDAsync
       * @apiGroup OrganizationModelRagistration
       *    
       * @apiParam {Number}  Id of the User.
       */
        [HttpGet("getuserbyId/{Id}")]
        public async Task<IActionResult> GetorganizationByIDAsync([FromRoute] int Id)
        {
            return Ok(await _organizationModule.GetUserByIdAsync(Id));
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
        [HttpPost("organization")]
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
      * @api {put} /organization/ Modify Organization information
      * @apiName UpdateOrganizationAsync
      * @apiGroup OrganizationModelRagistration
      *
      * @apiParam {Number} organizationId               organization unique ID.
      * @apiParam {String} organizationName             organizationName of the organization.
      * @apiParam {String} OrganizationOwnerEmailId     EMailId of the organization.
      * @apiParam {bool}   OrganizationStatus           Status of the organization.
      *       *
      * @apiError return BadRequest.
      */
        [HttpPut("userupdate")]
        public async Task<ActionResult> UpdateOrganizationAsync([FromForm] OrganizationModelDto user)
        {
            if (user.OrganizationId != user.OrganizationId)
            {
                return BadRequest();
            }
            await _organizationModule.UpdateUserAsync(user);
            return Ok("Update Successfully");
        }
        #endregion
    }
}
