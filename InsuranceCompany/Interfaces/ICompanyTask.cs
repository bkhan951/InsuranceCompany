using InsuranceCompany.DataContracts;
using InsuranceCompany.Models;

namespace InsuranceCompany.Interfaces
{
    public interface ICompanyTask
    {
        Task<CompanyResponse> GetCompany(int id);
    }
}
