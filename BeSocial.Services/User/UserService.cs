using BeSocial.Data;
using BeSocial.Services.Interfaces;
using BeSocial.Web.ViewModels.User;

using Microsoft.EntityFrameworkCore;

namespace BeSocial.Services.User
{
    public class UserService : IUserService
    {
        private readonly BeSocialDbContext context;

        public UserService(BeSocialDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<UserServiceModel>> AllAsync()
        {
            var allUsers = new List<UserServiceModel>();

            var premiumUsers = await context.PremiumUsers
                .Select(x => new UserServiceModel()
                {
                    Id = x.Id.ToString(),
                    FullName = $"{x.FirstName} {x.LastName}",
                    IsPremium = true
                }).ToListAsync();

            allUsers.AddRange(premiumUsers);

            var users = await context.Users
                .Where(x => !context.PremiumUsers.Any(y => y.ApplicationUserId == x.Id))
                .Select(x => new UserServiceModel()
                {
                    Id = x.Id.ToString(),
                    FullName = $"{x.FirstName} {x.LastName}",
                    IsPremium = false
                }).ToListAsync();

            allUsers.AddRange(users);

            return allUsers;
        }

        public async Task<string> UserFullName(string userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id.ToString() == userId);

            return user.FirstName + " " + user.LastName;
        }
    }
}
