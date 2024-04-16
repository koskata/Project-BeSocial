using BeSocial.Services.Interfaces;
using BeSocial.Services.PremiumUser;
using BeSocial.Tests.UnitTests;

namespace BeSocial.Tests
{
    [TestFixture]
    public class PremiumUserServiceTests : UnitTestsBase
    {
        private IPremiumUserService premiumService;

        [OneTimeSetUp]
        public void SetUp()
            => premiumService = new PremiumUserService(context);

        [Test]
        public async Task GetPremiumUserId_ShouldReturnCorrectUserId()
        {
            var resultPremiumUserId = await premiumService.GetPremiumUserIdAsync(PremiumUser.ApplicationUserId.ToString());

            Assert.That(resultPremiumUserId, Is.EqualTo(PremiumUser.Id));
        }

        [Test]
        public async Task ExistsById_ShouldReturnTrue_WithValidAsync()
        {
            var result = await premiumService.ExistByIdAsync(PremiumUser.ApplicationUserId.ToString());

            Assert.IsTrue(result);
        }

        [Test]
        public async Task CreateAgent_ShouldWorkCorrectly()
        {
            var premiumUsersCountBefore = context.PremiumUsers.Count();

            await premiumService.CreatePremiumUserAsync(PremiumUser.ApplicationUserId.ToString(),
                PremiumUser.FirstName, PremiumUser.LastName, PremiumUser.Description);

            var premiumUsersCountAfter = context.PremiumUsers.Count();
            Assert.That(premiumUsersCountAfter, Is.EqualTo(premiumUsersCountBefore + 1));

            var newPremiumUserId = await premiumService.GetPremiumUserIdAsync(PremiumUser.ApplicationUserId.ToString());
            var newPremiumUserInDb = await context.PremiumUsers.FindAsync(newPremiumUserId);

            Assert.IsNotNull(newPremiumUserInDb);
            Assert.That(newPremiumUserInDb.ApplicationUserId.ToString(), Is.EqualTo(PremiumUser.ApplicationUserId.ToString()));
            Assert.That(newPremiumUserInDb.FirstName, Is.EqualTo(PremiumUser.FirstName));
            Assert.That(newPremiumUserInDb.LastName, Is.EqualTo(PremiumUser.LastName));
            Assert.That(newPremiumUserInDb.Description, Is.EqualTo(PremiumUser.Description));
        }
    }
}
