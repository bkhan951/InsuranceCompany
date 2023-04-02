using Microsoft.AspNetCore.Mvc;
using InsuranceCompany.Interfaces;
using System.Diagnostics.CodeAnalysis;
using InsuranceCompany.DataContracts;

namespace InsuranceCompany.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClaimsController : ControllerBase
    {
        private readonly ILogger<ClaimsController> _logger;
        private readonly IClaimsTask _claimTask;

        public ClaimsController(ILogger<ClaimsController> logger, IClaimsTask claimsTask)
        {
            _logger = logger;
            _claimTask = claimsTask;
        }

        [HttpGet("{companyId:int}")]
        public ActionResult GetAllClaimsByCompanyId(int companyId)
        {
            try
            {
                if (companyId <= 0)
                {
                    return BadRequest("Request is invalid");
                }

                return Ok(_claimTask.GetAllClaimsByCompanyId(companyId));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Route("GetClaimByClaimReference")]
        [HttpGet()]
        public ActionResult GetClaimByClaimReference(string claimReference)
        {
            try
            {
                if (string.IsNullOrEmpty(claimReference))
                {
                    return BadRequest("Request is invalid");
                }

                var response = _claimTask.GetClaimByClaimReference(claimReference);

                if (response == null || response.Claims == null)
                {
                    return BadRequest("Claim not found!");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Route("UpdateClaim")]
        [HttpPut]
        public ActionResult UpdateClaim(UpdateClaimsRequest request)
        {
            try
            {
                if (request == null || request.ClaimReference != request.Claims.ClaimReference)
                {
                    return BadRequest("claims reference mismatch");
                }

                return Ok(_claimTask.UpdateClaim(request).Success);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}