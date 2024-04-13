using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BeSocial.Data;
using BeSocial.Services.Interfaces;

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

        public async Task<string> UserFullName(string userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id.ToString() == userId);

            return user.FirstName + " " + user.LastName;
        }
    }
}
