using Castle.Core.Logging;
using InsuranceCompany.Clients;
using InsuranceCompany.Models;
using InsuranceCompany.Repositories.IRepository;
using Microsoft.Extensions.Logging;
using Moq;

namespace InsuranceCompany.UnitTests
{
    public class CompanyTaskTest
    {
        private readonly Mock<ICompanyRepository> _companyRepositoryMock;
        private readonly Mock<ILogger<CompanyTask>> _logger;


        public CompanyTaskTest()
        {
            _companyRepositoryMock = new Mock<ICompanyRepository>();
            _logger = new Mock<ILogger<CompanyTask>>();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetCompanyByIdTest()
        {
            _companyRepositoryMock.Setup(repo => repo.GetById(1))
             .Returns(
              Task.FromResult(
                  new Company() { Id = 1, Name = "Aviva", Active = true, Address = new Address { Address1 = "135", Address2 = "Beresford Road", Address3 = "Manchester", Country = "United Kingdom", PostCode = "M130TA" }, InsuranceEndDate = DateTime.Parse("20/11/2023").Date }
                  ));

            var companyTask = new CompanyTask(_logger.Object, _companyRepositoryMock.Object);

            var result = await companyTask.GetCompany(1);

            Assert.NotNull(result);
            Assert.Multiple(() =>
            {
                Assert.True(result.Company.Id == 1);
                Assert.True(result.Company.Active == true);
                Assert.True(result.Company.InsuranceEndDate == DateTime.Parse("20/11/2023").Date);
                Assert.True(result.Company.Address.Country == "United Kingdom");
                Assert.True(result.Company.Address.Address3 == "Manchester");
            });
        }
    }
}