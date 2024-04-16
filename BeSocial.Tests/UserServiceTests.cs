using BeSocial.Services.Interfaces;
using BeSocial.Services.User;
using BeSocial.Tests.UnitTests;

namespace BeSocial.Tests
{
    [TestFixture]
    public class UserServiceTests : UnitTestsBase
    {
        private IUserService userService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
            => userService = new UserService(context);


        [Test]
        public async Task UserFullName_ShouldReturnCorrectResult()
        {
            var resultFullName = await userService.UserFullName(NormalUser.Id.ToString());

            var fullNameOfUser = $"{NormalUser.FirstName} {NormalUser.LastName}";

            Assert.That(resultFullName, Is.EqualTo(fullNameOfUser));
        }

        [Test]
        public async Task All_ShouldReturnCorrectUsersAndPremiumUsers()
        {
            var result = await userService.AllAsync();

            var usersCount = context.Users.Count();
            var resultUsers = result.ToList();
            Assert.That(resultUsers.Count, Is.EqualTo(usersCount));

            var premiumUsersCount = context.PremiumUsers.Count();
            var resultPremiumUsers = resultUsers.Where(x => x.IsPremium).ToList();
            Assert.That(resultPremiumUsers.Count, Is.EqualTo(premiumUsersCount));

            var premiumUser = resultPremiumUsers
                .FirstOrDefault(x => x.Id == PremiumUser.Id.ToString());
            Assert.IsNotNull(premiumUser);
            var fullNameOfUser = $"{PremiumUser.FirstName} {PremiumUser.LastName}";
            Assert.That(premiumUser.FullName, Is.EqualTo(fullNameOfUser));
        }
    }
}
