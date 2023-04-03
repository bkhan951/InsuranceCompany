using InsuranceCompany.DataContracts;
using InsuranceCompany.Interfaces;
using InsuranceCompany.Models;
using InsuranceCompany.Repositories.IRepository;

namespace InsuranceCompany.Clients
{
    public class ClaimsTask : IClaimsTask
    {
        private readonly ILogger<ClaimsTask> _logger;

        private readonly IClaimsRepository _claimsRepository;

        public ClaimsTask(ILogger<ClaimsTask> logger, IClaimsRepository claimsRepository)
        {
            _logger = logger;
            _claimsRepository = claimsRepository;
        }
        public async Task<List<Claim>> GetAllClaimsByCompanyId(int id)
        {
            return  _claimsRepository.GetAllClaimsByCompanyId(id).Result.ToList();
        }

        public async Task<ClaimsResponse> GetClaimByClaimReference(string claimReference)
        {
            var response = new ClaimsResponse()
            {
                Claims = await _claimsRepository.GetbyClaimReference(claimReference)
            };

            response.TotalNumberOfDays = response.Claims != null ? Math.Round((DateTime.Now.Date - response.Claims.ClaimDate).TotalDays, MidpointRounding.ToZero) : 0;
            return  response;
        }

        public async Task<UpdateClaimsResponse> UpdateClaim(UpdateClaimsRequest request)
        {
            return new UpdateClaimsResponse() { Success = await _claimsRepository.UpdateClaim(request.ClaimReference, request.Claims) };
        }
    }
}
