using Microsoft.AspNetCore.Mvc;
using InsuranceCompany.Models;
using InsuranceCompany.Interfaces;
using InsuranceCompany.Clients;
using System.ComponentModel.Design;

namespace InsuranceCompany.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;

        private readonly ICompanyTask _companyTask;

        public CompanyController(ILogger<CompanyController> logger, ICompanyTask companyTask)
        {
            _logger = logger;
            _companyTask = companyTask;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetCompany(int id)
        {
            try
            {
                var response = await _companyTask.GetCompany(id);

                if (response == null || response.Company == null)
                {
                    return BadRequest("Company does not exist!");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}