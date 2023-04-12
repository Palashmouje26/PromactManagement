using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromactManagement.DomainModel.ApplicationClass.DTO.CompanyRegistrationDTO;
using PromactManagement.Repository.CompanyRegistration;
using System.Threading.Tasks;

namespace PromactManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyRegistrationController : ControllerBase
    {
        #region private Member
        
        private readonly ICompanyRepository _companyRegistration;
        #endregion

        #region Constructor
        public CompanyRegistrationController(ICompanyRepository company)
        {
            _companyRegistration = company;
        }
        #endregion

        #region public Methods

        /**
        * @api {get} /api/Company /:get all company information
        * @apiName GetCompanyDetailAsync
        * @apiGroup Company
        * 
        * @apiSuccess : List Of registerd company details.
        * 
        * @apiSuccessExample Success-Response:{object[]}   
        */
        [HttpGet("company")]
        public async Task<IActionResult> GetCompanyDetailAsync()
        {
            return Ok(await _companyRegistration.GetAllCompanyDetailAsync());
        }

        /**
        * @api {get} /api/Company/:id get one particuler company information
        * @apiName GetComanyByIDAsync
        * @apiGroup Company
        *    
        * @apiParam {Number}  Id of the company.
        * 
        *  @apiSuccess : Showing particuler Of registerd company details.
        */
        [HttpGet("comanybyId/{Id}")]
        public async Task<IActionResult> GetComanyByIDAsync([FromRoute] int Id)
        {
            return Ok(await _companyRegistration.GetCompanyDetailByIdAsync(Id));
        }
        /**
        *   @api {post} api/company/add company Method to add company detail.
        *   
        *   @apiBody {object} company detail.
        */
        [HttpPost("companycreate")]
        public async Task<IActionResult> AddCompanyDetailAsync([FromBody] CompanyDTO company)
        {

            var result = await _companyRegistration.CreateCompanyAsync(company);

            if (result.ComapnyId == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Company Created Successfully");
        }
        /**
        * @api {put} /Company/ Modify company information
        * @apiName UpdateCompanyAsync
        * @apiGroup Company
        *
        * @apiParam :{object[]} 
        * 
        * @apiError return BadRequest.
        */
        [HttpPut("updatecompany")]
        public async Task<ActionResult> UpdateCompanyAsync([FromBody] CompanyDTO companyDetail)
        {
            if (companyDetail.ComapnyId != companyDetail.ComapnyId)
            {
                return BadRequest();
            }
            await _companyRegistration.UpdateCompanyDetailAsync(companyDetail);
            return Ok("Update Successfully");
        }

        #endregion
    }
}
