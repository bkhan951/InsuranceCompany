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
        public void Test1()
        {
            // _companyRepositoryMock.Setup(x => x.GetById(1)).Returns;

            // _companyRepositoryMock.Setup(x => x.List());


            _companyRepositoryMock.Setup(repo => repo.GetById(1))
             .Returns(
                new Company() { Id = 1, Name = "Aviva", Active = true, Address = new Address { Address1 = "135", Address2 = "Beresford Road", Address3 = "Manchester", Country = "United Kingdom", PostCode = "M130TA" }, InsuranceEndDate = DateTime.Now.AddMonths(2) }
                 );

            var companyTask = new CompanyTask(_logger.Object, _companyRepositoryMock.Object);

            var result = companyTask.GetCompany(1);

            Assert.NotNull(result);
            Assert.True(result.Company.Id == 1 );
        }
    }
}