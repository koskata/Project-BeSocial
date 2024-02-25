using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeSocial.Data
{
    public class BeSocialDbContext : IdentityDbContext
    {
        public BeSocialDbContext(DbContextOptions<BeSocialDbContext> options)
            : base(options)
        {
        }
    }
}