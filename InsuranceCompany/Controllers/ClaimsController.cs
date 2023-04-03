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
        public async Task<ActionResult> GetAllClaimsByCompanyId(int companyId)
        {
            try
            {
                if (companyId <= 0)
                {
                    return BadRequest("Request is invalid");
                }

                return Ok(await _claimTask.GetAllClaimsByCompanyId(companyId));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Route("GetClaimByClaimReference")]
        [HttpGet()]
        public async Task<ActionResult> GetClaimByClaimReference(string claimReference)
        {
            try
            {
                if (string.IsNullOrEmpty(claimReference))
                {
                    return BadRequest("Request is invalid");
                }

                var response = _claimTask.GetClaimByClaimReference(claimReference);

                if (response == null || response.Result.Claims == null)
                {
                    return BadRequest("Claim not found!");
                }

                return Ok(await response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Route("UpdateClaim")]
        [HttpPut]
        public async Task<ActionResult> UpdateClaim(UpdateClaimsRequest request)
        {
            try
            {
                if (request == null || !request.ClaimReference.Equals(request.Claims.ClaimReference, StringComparison.InvariantCultureIgnoreCase))
                {
                    return BadRequest("claims reference mismatch");
                }

                return Ok(await _claimTask.UpdateClaim(request));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}