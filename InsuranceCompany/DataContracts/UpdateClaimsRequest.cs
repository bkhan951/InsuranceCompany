using InsuranceCompany.Models;

namespace InsuranceCompany.DataContracts
{
    public class UpdateClaimsRequest
    {
        public string ClaimReference { get; set; }
        public Claim Claims { get; set; }
    }
}
