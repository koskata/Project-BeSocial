using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BeSocial.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeSocial.Data.Configuration
{
    public class PremiumUserEntityConfiguration : IEntityTypeConfiguration<PremiumUser>
    {
        public void Configure(EntityTypeBuilder<PremiumUser> builder)
        {
            builder.HasData(GeneratePremiumUsers());
        }

        private PremiumUser[] GeneratePremiumUsers()
        {
            List<PremiumUser> users = new List<PremiumUser>()
            {
                new PremiumUser() 
                {
                    Id = 1,
                    FirstName = "Dimitar",
                    LastName = "Pavlov",
                    Description = "Hello, my name is Dimitar. I am 25 years old from Sofia. I would love it if you follow me for more content from me.",
                    ApplicationUserId = Guid.Parse("656592c0-e20c-4a11-900a-eb6c9cd94b20")
                }
            };

            return users.ToArray();
        }
    }
}
