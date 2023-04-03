using InsuranceCompany.Helpers;
using InsuranceCompany.Models;
using InsuranceCompany.Repositories.IRepository;
using System.Linq;

namespace InsuranceCompany.Repositories.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataHelpers _dataHelpers;

        public CompanyRepository(DataHelpers dataHelpers)
        {
            _dataHelpers = dataHelpers;
        }

        public async Task<Company> GetById(int id)
        {
            return _dataHelpers.listOfCompnaies.FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<Company>> List()
        {
            return _dataHelpers.listOfCompnaies;
        }
    }
}
