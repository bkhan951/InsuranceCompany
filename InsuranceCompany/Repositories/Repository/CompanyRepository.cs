using InsuranceCompany.Models;
using InsuranceCompany.Repositories.IRepository;
using System.Linq;

namespace InsuranceCompany.Repositories.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private List<Company> listOfCompnaies = null;

        public CompanyRepository()
        {
            listOfCompnaies = new List<Company>();
            listOfCompnaies.Add(new Company() { Id = 1, Name = "Aviva", Active = true, Address = new Address { Address1 = "135", Address2 = "Beresford Road", Address3 = "Manchester", Country = "United Kingdom", PostCode = "M130TA" }, InsuranceEndDate = DateTime.Now.AddMonths(2) });
            listOfCompnaies.Add(new Company() { Id = 2, Name = "AXA", Active = true, Address = new Address { Address1 = "10", Address2 = "Reynell Road", Address3 = "Manchester", Country = "United Kingdom", PostCode = "M130PT" }, InsuranceEndDate = DateTime.Now.AddMonths(8) });
            listOfCompnaies.Add(new Company() { Id = 3, Name = "Churchill", Active = true, Address = new Address { Address1 = "16", Address2 = "Stamford Road", Address3 = "Manchester", Country = "United Kingdom", PostCode = "M130SR" }, InsuranceEndDate = DateTime.Now.AddMonths(-5) });
            listOfCompnaies.Add(new Company() { Id = 4, Name = "Hastings Direct", Active = true, Address = new Address { Address1 = "800", Address2 = "Kingsway", Address3 = "Manchester", Country = "United Kingdom", PostCode = "M205NR" }, InsuranceEndDate = DateTime.Now.AddMonths(5) });
        }

        public Company GetById(int id)
        {
            return listOfCompnaies.FirstOrDefault(x => x.Id == id);
        }

        public List<Company> List()
        {
            return listOfCompnaies;
        }

        //private List<Company> AllCompanies()
        //{
        //    var listOfCompnaies = new List<Company>();

        //    listOfCompnaies.Add(new Company() { Id = 1, Name = "Aviva", Active = true, Address = new Address { Address1 = "135", Address2 = "Beresford Road", Address3 = "Manchester", Country = "United Kingdom", PostCode = "M130TA" }, InsuranceEndDate = DateTime.Now.AddMonths(2) });
        //    listOfCompnaies.Add(new Company() { Id = 2, Name = "AXA", Active = true, Address = new Address { Address1 = "10", Address2 = "Reynell Road", Address3 = "Manchester", Country = "United Kingdom", PostCode = "M130PT" }, InsuranceEndDate = DateTime.Now.AddMonths(8) });
        //    listOfCompnaies.Add(new Company() { Id = 3, Name = "Churchill", Active = true, Address = new Address { Address1 = "16", Address2 = "Stamford Road", Address3 = "Manchester", Country = "United Kingdom", PostCode = "M130SR" }, InsuranceEndDate = DateTime.Now.AddMonths(-5) });
        //    listOfCompnaies.Add(new Company() { Id = 4, Name = "Hastings Direct", Active = true, Address = new Address { Address1 = "800", Address2 = "Kingsway", Address3 = "Manchester", Country = "United Kingdom", PostCode = "M205NR" }, InsuranceEndDate = DateTime.Now.AddMonths(5) });

        //    return listOfCompnaies;
        //}
    }
}
