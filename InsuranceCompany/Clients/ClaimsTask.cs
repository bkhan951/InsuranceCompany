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
        public List<Claim> GetAllClaimsByCompanyId(int id)
        {
            return _claimsRepository.GetAllClaimsByCompanyId(id).ToList();
        }

        public ClaimsResponse GetClaimByClaimReference(string claimReference)
        {
            var response = new ClaimsResponse()
            {
                Claims = _claimsRepository.GetbyUniqueClaimReference(claimReference)
            };

            response.TotalNumberOfDays = response.Claims != null ? Math.Round((DateTime.Now.Date - response.Claims.ClaimDate).TotalDays, MidpointRounding.ToZero) : 0;
            return response;
        }

        public UpdateClaimsResponse UpdateClaim(UpdateClaimsRequest request)
        {
            return new UpdateClaimsResponse() { Success = _claimsRepository.UpdateClaim(request.ClaimReference, request.Claims) };
        }
    }
}
