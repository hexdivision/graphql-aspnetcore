namespace PathWays.Tests.Unit
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using NUnit.Framework;
    using PathWays.Data.Model;
    using PathWays.Data.Repositories.Domain;
    using PathWays.Data.Repositories.ExcludeWord;
    using PathWays.Data.Repositories.Organization;
    using PathWays.Data.Repositories.UnitOfWork;
    using PathWays.Data.Repositories.UserExploration;
    using PathWays.Resolvers;
    using PathWays.Services.UserExplorationService;

    [TestFixture]
    public class UserExplorationTest
    {
        private PathWaysContext pathwaysContext;

        public PathWaysContext Context
        {
            get
            {
                if (this.pathwaysContext == null)
                {
                    var builder = new DbContextOptionsBuilder<PathWaysContext>().UseInMemoryDatabase("testDb");

                    var context = new PathWaysContext(builder.Options);

                    context.Organizations.AddRange(DataInitializer.Organizations);

                    context.Domains.AddRange(DataInitializer.Domains);

                    context.UserExplorations.AddRange(DataInitializer.UserExplorations);

                    context.AccessCodeExcludeWords.AddRange(DataInitializer.BadWords);

                    int res = context.SaveChanges();

                    this.pathwaysContext = context;
                }

                return this.pathwaysContext;
            }
        }

        public IUnitOfWork UnitOfWork { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {

            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork.SetupGet(s => s.DomainRepository).Returns(new DomainRepository(this.Context));
            mockUnitOfWork.SetupGet(s => s.OrganizationRepository).Returns(new OrganizationRepository(this.Context));
            mockUnitOfWork.SetupGet(s => s.UserExplorationRepository).Returns(new UserExplorationRepository(this.Context));
            mockUnitOfWork.SetupGet(s => s.ExcludeWordRepository).Returns(new ExcludeWordRepository(this.Context));

            this.UnitOfWork = mockUnitOfWork.Object;
        }

        [Test]
        [TestCase(22, 2, 7, "accessCode-345", 1)]
        [TestCase(23, 6, 4, "qwerty!@#123", 3)]
        public async Task TestAddUserExplorationAsync(int id, int domainId, int organizationId, string accessCode, int createdBy)
        {
            var userExplorationService = new UserExplorationService(this.UnitOfWork);
            var result = await userExplorationService.CreateUserExploration(
                new UserExploration
                {
                    UserExplorationId = id,
                    DomainId = domainId,
                    OrganizationId = organizationId,
                    AccessCode = accessCode,
                    CreatedBy = createdBy,
                    CreatedDate = DateTime.UtcNow.AddMonths(2),
                    ExplorationCompletionDate = DateTime.UtcNow.AddMonths(5)
                });

            Assert.True(result != null);
        }

        [Test]
        [TestCase(1)]
        [TestCase(9)]
        public async Task TestGetUserExplorationByIdAsync(int value)
        {
            var userExplorationService = new UserExplorationService(this.UnitOfWork);
            var result = await userExplorationService.GetUserExploration(value);

            Assert.True(result != null);
            Assert.True(result.UserExplorationId == value);
        }
    }
}
