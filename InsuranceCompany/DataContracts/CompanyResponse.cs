using InsuranceCompany.Models;

namespace InsuranceCompany.DataContracts
{
    public class CompanyResponse
    {
        public Company Company { get; set; }
        public bool HasActiveInsurancePolicy
        {
            get
            {
                return Company != null && Company.InsuranceEndDate != DateTime.MinValue && Company.InsuranceEndDate > DateTime.Now ? true : false;
            }
        }
    }
}
