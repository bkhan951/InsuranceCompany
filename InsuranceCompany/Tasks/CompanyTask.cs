using InsuranceCompany.DataContracts;
using InsuranceCompany.Interfaces;
using InsuranceCompany.Models;
using InsuranceCompany.Repositories.IRepository;

namespace InsuranceCompany.Clients
{
    public class CompanyTask : ICompanyTask
    {
        private readonly ILogger<CompanyTask> _logger;
        private readonly ICompanyRepository _companyRepository;

        public CompanyTask(ILogger<CompanyTask> logger, ICompanyRepository companyRepository)
        {
            _logger = logger;
            _companyRepository = companyRepository;
        }

        public async Task<CompanyResponse> GetCompany(int id)
        {
            return  new CompanyResponse()
            {
                Company = await _companyRepository.GetById(id)
            };
        }
    }
}
