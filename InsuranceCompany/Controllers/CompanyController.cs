using Microsoft.AspNetCore.Mvc;
using InsuranceCompany.Models;
using InsuranceCompany.Interfaces;

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
        public ActionResult GetCompany(int id)
        {
            try
            {
                return Ok(_companyTask.GetCompany(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}