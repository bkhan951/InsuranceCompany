using InsuranceCompany.DataContracts;
using InsuranceCompany.Models;

namespace InsuranceCompany.Interfaces
{
    public interface ICompanyTask
    {
        public CompanyResponse GetCompany(int id);
    }
}
