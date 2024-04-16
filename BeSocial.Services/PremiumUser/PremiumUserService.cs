using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BeSocial.Data;
using BeSocial.Services.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace BeSocial.Services.PremiumUser
{
    public class PremiumUserService : IPremiumUserService
    {
        private readonly BeSocialDbContext context;

        public PremiumUserService(BeSocialDbContext _context)
        {
            context = _context;
        }

        public async Task CreatePremiumUserAsync(string userId, string firstName, string lastName, string description)
        {
            var premium = new BeSocial.Data.Models.PremiumUser()
            { 
                ApplicationUserId = Guid.Parse(userId),
                FirstName = firstName,
                LastName = lastName,
                Description = description
            };

            await context.PremiumUsers.AddAsync(premium);
            await context.SaveChangesAsync();
        }

        public async Task<bool> ExistByIdAsync(string userId)
            => await context.PremiumUsers.AnyAsync(x => x.ApplicationUserId.ToString() == userId);

        public async Task<int> GetPremiumUserIdAsync(string userId)
            => (await context.PremiumUsers.FirstOrDefaultAsync(x => x.ApplicationUserId.ToString() == userId)).Id;



    }
}
