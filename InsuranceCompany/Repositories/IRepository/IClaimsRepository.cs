using InsuranceCompany.Models;

namespace InsuranceCompany.Repositories.IRepository
{
    public interface IClaimsRepository : IRepository<Claim>
    {
        Task<IEnumerable<Claim>> GetAllClaimsByCompanyId(int companyId);

        Task<Claim> GetbyClaimReference(string ClaimReference);

        Task<bool> UpdateClaim(string claimReference, Claim claim);
    }
}
