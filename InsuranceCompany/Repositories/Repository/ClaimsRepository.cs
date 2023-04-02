using InsuranceCompany.DataContracts;
using InsuranceCompany.Helpers;
using InsuranceCompany.Models;
using InsuranceCompany.Repositories.IRepository;

namespace InsuranceCompany.Repositories.Repository
{
    public class ClaimsRepository : IClaimsRepository
    {
        private readonly DataHelpers _dataHelpers;
        public ClaimsRepository(DataHelpers dataHelpers)
        {
            _dataHelpers = dataHelpers;
        }
        public Claim GetById(int id)
        {
            return _dataHelpers.claims.FirstOrDefault(x => x.Id == id);
        }

        public Claim GetbyUniqueClaimReference(string claimReference)
        {
            return _dataHelpers.claims.FirstOrDefault(x => x.ClaimReference.Equals(claimReference.Trim(), StringComparison.InvariantCultureIgnoreCase));
        }

        public List<Claim> List()
        {
            return _dataHelpers.claims;
        }

        public IEnumerable<Claim> GetAllClaimsByCompanyId(int companyId)
        {
            return _dataHelpers.claims.Where(x => x.CompanyId.Equals(companyId));
        }

        public bool UpdateClaim(string claimReference, Claim claim)
        {
            var existingClaim = _dataHelpers.claims.FirstOrDefault(x => x.ClaimReference.Equals(claim.ClaimReference));
            bool Success = false;

            if (existingClaim != null)
            {
                existingClaim.AssuredName = claim.AssuredName;
                existingClaim.ClaimDate = claim.ClaimDate;
                existingClaim.LossDate = claim.LossDate;
                existingClaim.CompanyId = claim.CompanyId;
                existingClaim.Closed = claim.Closed;
                existingClaim.IncurredLoss = claim.IncurredLoss;
                Success = true;
            }

            return Success;
        }
    }
}
