using InsuranceCompany.Models;

namespace InsuranceCompany.DataContracts
{
    public class ClaimsResponse
    {
        public Claim Claims { get; set; }

        public double TotalNumberOfDays { get; set; }
    }
}
