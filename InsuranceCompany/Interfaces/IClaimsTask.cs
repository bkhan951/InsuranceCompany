using InsuranceCompany.DataContracts;
using InsuranceCompany.Models;

namespace InsuranceCompany.Interfaces
{
    public interface IClaimsTask
    {
        Task<List<Claim>> GetAllClaimsByCompanyId(int id);

        Task<ClaimsResponse> GetClaimByClaimReference(string claimReference);

        Task<UpdateClaimsResponse> UpdateClaim(UpdateClaimsRequest request);

    }
}
