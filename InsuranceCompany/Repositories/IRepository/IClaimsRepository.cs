using InsuranceCompany.Models;

namespace InsuranceCompany.Repositories.IRepository
{
    public interface IClaimsRepository : IRepository<Claim>
    {
        IEnumerable<Claim> GetAllClaimsByCompanyId(int companyId);

        Claim GetbyUniqueClaimReference(string ClaimReference);

        bool UpdateClaim(string claimReference, Claim claim);
    }
}
