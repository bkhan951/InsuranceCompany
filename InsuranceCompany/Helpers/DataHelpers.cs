using InsuranceCompany.Models;

namespace InsuranceCompany.Helpers
{
    public class DataHelpers
    {
        public List<Claim> claims { get; set; }

        public DataHelpers()
        {
            LoadAllClaims();
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
