using InsuranceCompany.Models;

namespace InsuranceCompany.Helpers
{
    public class DataHelpers
    {
        public List<Claim> claims { get; set; }

        public List<Company> listOfCompnaies { get; set; }

        public DataHelpers()
        {
            LoadAllClaims();
            LoadAllCompanies();
        }

        public void LoadAllCompanies() 
        {
            listOfCompnaies = new List<Company>();

            listOfCompnaies.Add(new Company() { Id = 1, Name = "Aviva", Active = true, Address = new Address { Address1 = "135", Address2 = "Beresford Road", Address3 = "Manchester", Country = "United Kingdom", PostCode = "M130TA" }, InsuranceEndDate = DateTime.Now.AddMonths(2) });
            listOfCompnaies.Add(new Company() { Id = 2, Name = "AXA", Active = true, Address = new Address { Address1 = "10", Address2 = "Reynell Road", Address3 = "Manchester", Country = "United Kingdom", PostCode = "M130PT" }, InsuranceEndDate = DateTime.Now.AddMonths(8) });
            listOfCompnaies.Add(new Company() { Id = 3, Name = "Churchill", Active = true, Address = new Address { Address1 = "16", Address2 = "Stamford Road", Address3 = "Manchester", Country = "United Kingdom", PostCode = "M130SR" }, InsuranceEndDate = DateTime.Now.AddMonths(-5) });
            listOfCompnaies.Add(new Company() { Id = 4, Name = "Hastings Direct", Active = true, Address = new Address { Address1 = "800", Address2 = "Kingsway", Address3 = "Manchester", Country = "United Kingdom", PostCode = "M205NR" }, InsuranceEndDate = DateTime.Now.AddMonths(5) });
        }

        public void LoadAllClaims()
        {
            claims = new List<Claim>();

            claims.Add(new Claim()
            {
                Id = 1,
                ClaimReference = "ABC123",
                CompanyId = 1,
                ClaimDate = DateTime.Parse("20/01/2019").Date,
                LossDate = DateTime.Parse("20/01/2019"),
                IncurredLoss = 500,
                AssuredName = "Test",
                Closed = false,
                ClaimType = new ClaimType() { Id = 1, Name = "FAULT" }
            });

            claims.Add(new Claim()
            {
                Id = 2,
                ClaimReference = "ABC456",
                CompanyId = 1,
                ClaimDate = DateTime.Parse("20/01/2021").Date,
                LossDate = DateTime.Parse("20/01/2021"),
                IncurredLoss = 1000,
                AssuredName = "Test",
                Closed = false,
                ClaimType = new ClaimType() { Id = 1, Name = "FAULT" }
            });

            claims.Add(new Claim()
            {
                Id = 3,
                ClaimReference = "ABC789",
                CompanyId = 1,
                ClaimDate = DateTime.Parse("20/01/2022").Date,
                LossDate = DateTime.Parse("20/01/2022").Date,
                IncurredLoss = 350,
                AssuredName = "Test",
                Closed = false,
                ClaimType = new ClaimType() { Id = 1, Name = "NON-FAULT" }
            });

            claims.Add(new Claim()
            {
                Id = 4,
                ClaimReference = "ABC101",
                CompanyId = 2,
                ClaimDate = DateTime.Parse("20/01/2023").Date,
                LossDate = DateTime.Parse("20/01/2023").Date,
                IncurredLoss = 250,
                AssuredName = "Test2",
                Closed = false,
                ClaimType = new ClaimType() { Id = 1, Name = "FAULT" }
            });

            claims.Add(new Claim()
            {
                Id = 5,
                ClaimReference = "ABC102",
                CompanyId = 2,
                ClaimDate = DateTime.Parse("20/05/2021").Date,
                LossDate = DateTime.Parse("20/01/2023").Date,
                IncurredLoss = 1500,
                AssuredName = "Test2",
                Closed = false,
                ClaimType = new ClaimType() { Id = 1, Name = "NON-FAULT" }
            });

            claims.Add(new Claim()
            {
                Id = 6,
                ClaimReference = "ABC103",
                CompanyId = 3,
                ClaimDate = DateTime.Parse("20/06/2022").Date,
                LossDate = DateTime.Parse("20/01/2023").Date,
                IncurredLoss = 1640,
                AssuredName = "Test3",
                Closed = false,
                ClaimType = new ClaimType() { Id = 1, Name = "FAULT" }
            });

            claims.Add(new Claim()
            {
                Id = 7,
                ClaimReference = "ABC104",
                CompanyId = 4,
                ClaimDate = DateTime.Parse("20/09/2020").Date,
                LossDate = DateTime.Parse("20/01/2023").Date,
                IncurredLoss = 120,
                AssuredName = "Test4",
                Closed = false,
                ClaimType = new ClaimType() { Id = 1, Name = "FAULT" }
            });
        }
    }
}
