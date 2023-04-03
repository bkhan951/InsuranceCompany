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
        public async Task GetClaimByClaimReferenceTest()
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

            var result = await claimsTask.GetClaimByClaimReference("ABC123");

            Assert.NotNull(result);
            Assert.Multiple(() =>
            {
                Assert.True(result.Claims.AssuredName == "Test");
                Assert.True(result.Claims.Closed == false);
                Assert.True(result.Claims.CompanyId == 1);
                Assert.True(result.Claims.ClaimType.Name == "FAULT");
            });
        }

        [Test]
        public async Task GetAllClaimsByCompanyIdTest()
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

            var result = await claimsTask.GetAllClaimsByCompanyId(1);

            Assert.NotNull(result);
            Assert.True(result.Count() == 2);
            Assert.Multiple(() =>
            {
                Assert.That(result.FirstOrDefault().Closed, Is.EqualTo(false));
                Assert.That(result.LastOrDefault().AssuredName, Is.EqualTo("Testing"));
                Assert.That(result.LastOrDefault().ClaimType.Name, Is.EqualTo("FAULT"));
            });
        }

        [Test]
        public async Task UpdateClaimTest()
        {
            var claim = new Claim()
            {
                Id = 1,
                ClaimReference = "ABC123",
                CompanyId = 1,
                ClaimDate = DateTime.Parse("20/01/2019").Date,
                LossDate = DateTime.Parse("20/01/2019").Date,
                IncurredLoss = 500,
                AssuredName = "Test",
                Closed = false,
                ClaimType = new ClaimType() { Id = 1, Name = "FAULT" }
            };

            _claimRepositoryMock.Setup(repo => repo.GetbyClaimReference("ABC123"))
             .Returns(
              Task.FromResult(claim));


            var claimsTask = new ClaimsTask(_logger.Object, _claimRepositoryMock.Object);

            var request = new UpdateClaimsRequest() { ClaimReference = "ABC123", Claims = claim };
            request.Claims.AssuredName = "Testing";
            request.Claims.IncurredLoss = 3000;

            var updateResult = await claimsTask.UpdateClaim(request);
            var updatedResult = await claimsTask.GetClaimByClaimReference("ABC123");

            Assert.NotNull(updateResult);
            Assert.That(updatedResult.Claims.AssuredName, Is.EqualTo("Testing"));
            Assert.That(updatedResult.Claims.IncurredLoss, Is.EqualTo(3000));
        }
    }
}