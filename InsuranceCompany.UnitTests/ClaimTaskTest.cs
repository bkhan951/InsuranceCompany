using Castle.Core.Logging;
using InsuranceCompany.Clients;
using InsuranceCompany.DataContracts;
using InsuranceCompany.Models;
using InsuranceCompany.Repositories.IRepository;
using Microsoft.Extensions.Logging;
using Moq;

namespace InsuranceCompany.UnitTests
{
    public class ClaimTaskTest
    {
        private readonly Mock<IClaimsRepository> _claimRepositoryMock;
        private readonly Mock<ILogger<ClaimsTask>> _logger;

        public ClaimTaskTest()
        {
            _claimRepositoryMock = new Mock<IClaimsRepository>();
            _logger = new Mock<ILogger<ClaimsTask>>();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetClaimByClaimReferenceTest()
        {
            _claimRepositoryMock.Setup(repo => repo.GetbyClaimReference("ABC123"))
             .Returns(
              Task.FromResult(
                                new Claim()
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
                                }));

            var claimsTask = new ClaimsTask(_logger.Object, _claimRepositoryMock.Object);

            var result = claimsTask.GetClaimByClaimReference("ABC123");

            Assert.NotNull(result);
            Assert.True(result.Result.Claims.AssuredName == "Test");
            Assert.True(result.Result.Claims.Closed == false);
            Assert.True(result.Result.Claims.CompanyId == 1);
            Assert.True(result.Result.Claims.ClaimType.Name == "FAULT");
        }

        [Test]
        public void GetAllClaimsByCompanyIdTest()
        {
            var mockClaimsList = new List<Claim>();

            mockClaimsList.Add(new Claim()
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

            mockClaimsList.Add(new Claim()
            {
                Id = 2,
                ClaimReference = "ABC456",
                CompanyId = 1,
                ClaimDate = DateTime.Parse("20/01/2021").Date,
                LossDate = DateTime.Parse("20/01/2021"),
                IncurredLoss = 1000,
                AssuredName = "Testing",
                Closed = false,
                ClaimType = new ClaimType() { Id = 1, Name = "FAULT" }
            });


            _claimRepositoryMock.Setup(repo => repo.GetAllClaimsByCompanyId(1))
             .Returns(
              Task.FromResult<IEnumerable<Claim>>(mockClaimsList));

            var claimsTask = new ClaimsTask(_logger.Object, _claimRepositoryMock.Object);

            var result = claimsTask.GetAllClaimsByCompanyId(1);

            Assert.NotNull(result);
            Assert.True(result.Result.Count() == 2);
            Assert.That(result.Result.FirstOrDefault().Closed, Is.EqualTo(false));
            Assert.That(result.Result.LastOrDefault().AssuredName, Is.EqualTo("Testing"));
            Assert.That(result.Result.LastOrDefault().ClaimType.Name, Is.EqualTo("FAULT"));
        }

        [Test]
        public void UpdateClaimTest()
        {
            _claimRepositoryMock.Setup(repo => repo.GetbyClaimReference("ABC123"))
             .Returns(
              Task.FromResult(
                                new Claim()
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
                                }));


            var claimsTask = new ClaimsTask(_logger.Object, _claimRepositoryMock.Object);
            var result = claimsTask.GetClaimByClaimReference("ABC123");


            var request = new UpdateClaimsRequest() { ClaimReference = "ABC123", Claims = result.Result.Claims };
            request.Claims.AssuredName = "Testing";

            var updateResult = claimsTask.UpdateClaim(request);
            var updatedResult = claimsTask.GetClaimByClaimReference("ABC123");

            Assert.NotNull(updateResult);
            Assert.That(updatedResult.Result.Claims.AssuredName, Is.EqualTo("Testing"));
            Assert.IsTrue(updateResult.Result.Success);
        }
    }
}