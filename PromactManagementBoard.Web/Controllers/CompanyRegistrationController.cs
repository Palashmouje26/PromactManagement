using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromactManagement.DomainModel.Models.CompanyRagistrationDto;
using PromactManagement.DomainModel.Models.OrganizationModuleDetail;
using PromactManagement.Repository.CompanyRagistration;
using System.Threading.Tasks;

namespace PromactManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyRegistrationController : ControllerBase
    {
        #region private Member
        
        private readonly ICompanyRegistration _companyRagistration;
        #endregion

        #region Constructor
        public CompanyRegistrationController(ICompanyRegistration companyModuleRagistration)
        {
            _companyRagistration = companyModuleRagistration;
        }
        #endregion

        #region public Methods

        /**
        * @api {get} /api/CompanyRegistrationController /:get all company information
        * @apiName GetCompanyDetailAsync
        * @apiGroup CompanyModelRegistration
        * 
        * @apiSuccess : List Of registerd company details.
        * 
        * @apiSuccessExample Success-Response:{object[]}   
        * @apiError ComanyNotFound The information of the company was not found.
        */
        [HttpGet("company")]
        public async Task<IActionResult> GetCompanyDetailAsync()
        {
            return Ok(await _companyRagistration.GetAllCompanyDetailAsync());
        }

        /**
        * @api {get} /api/CompanyRegistrationController /:id get one particuler company information
        * @apiName GetComanyByIDAsync
        * @apiGroup CompanyModelRegistration
        *    
        * @apiParam {Number}  Id of the company.
        */
        [HttpGet("comanybyId/{Id}")]
        public async Task<IActionResult> GetComanyByIDAsync([FromRoute] int Id)
        {
            return Ok(await _companyRagistration.GetCompanyDetailByIdAsync(Id));
        }

        /**
        * @api {post} /CompanyModelRegistration/
        * @apiBody {String} companyName           Mandatory Firstname of the company.
        * @apiBody {String} CompanyOwnerEmailId   Mandatory  input with small letter"Xyz@xxx.com".
        * @apiBody {String} CompanyStatus         Mandatory nested status object.
        * 
        * @apiSuccessExample Success-Response:
        *  { 
        *      organizationName = "John",
        *      OrganizationOwnerEmailId =  "Xyz@abc.com"
        *  }
        * @apiError return StatusCode.
        */
        [HttpPost("company")]
        public async Task<IActionResult> AddCompanyDetailAsync([FromBody] CompanyModelDto company)
        {

            var result = await _companyRagistration.CreateRagistrationAsync(company);

            if (result.ComapnyId == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Company Created Successfully");
        }
        /**
        * @api {put} /CompanyRegistrationController/ Modify company information
        * @apiName UpdateCompanyAsync
        * @apiGroup CompanyModelRegistration
        *
        * @apiParam :{object[]} 
        * 
        * @apiError return BadRequest.
        */

        [HttpPut("updatecompany")]
        public async Task<ActionResult> UpdateCompanyAsync([FromBody] CompanyModelDto companyDetail)
        {
            if (companyDetail.ComapnyId != companyDetail.ComapnyId)
            {
                return BadRequest();
            }
            await _companyRagistration.UpdateCompanyDetailAsync(companyDetail);
            return Ok("Update Successfully");
        }

        #endregion
    }
}
