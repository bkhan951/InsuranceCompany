using InsuranceCompany.DataContracts;
using InsuranceCompany.Models;

namespace InsuranceCompany.Interfaces
{
    public interface IClaimsTask
    {
        List<Claim> GetAllClaimsByCompanyId(int id);

        ClaimsResponse GetClaimByClaimReference(string claimReference);

        UpdateClaimsResponse UpdateClaim(UpdateClaimsRequest request);

    }
}
