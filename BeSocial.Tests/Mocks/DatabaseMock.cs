using BeSocial.Data;

using Microsoft.EntityFrameworkCore;

namespace BeSocial.Tests.Mocks
{
    public static class DatabaseMock
    {
        public static BeSocialDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<BeSocialDbContext>()
                    .UseInMemoryDatabase("BeSocialInMemoryDb"
                        + Guid.NewGuid().ToString()).Options;

                return new BeSocialDbContext(dbContextOptions, false);
            }
        }
    }
}
