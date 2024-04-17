using BeSocial.Data.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static BeSocial.Common.GeneralApplicationConstants;

namespace BeSocial.Data.Configuration
{
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(GenerateUsers());
        }

        private ApplicationUser[] GenerateUsers()
        {
            ApplicationUser normalUser = new();
            ApplicationUser premiumUser = new();
            ApplicationUser adminUser = new();

            List<ApplicationUser> applicationUsers = new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    Id = Guid.Parse("b744c1d2-71a0-42a9-af63-836846a0fa40"),
                    Email = "georgiivanov@gmail.com",
                    NormalizedEmail = "GEORGIIVANOV@GMAIL.COM",
                    UserName = "georgiivanov@gmail.com",
                    NormalizedUserName = "GEORGIIVANOV@GMAIL.COM",
                    FirstName = "Georgi",
                    LastName = "Ivanov",
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                },

                new ApplicationUser()
                {
                    Id = Guid.Parse("656592c0-e20c-4a11-900a-eb6c9cd94b20"),
                    Email = "dimitarpavlov@gmail.com",
                    NormalizedEmail = "DIMITARPAVLOV@GMAIL.COM",
                    UserName = "dimitarpavlov@gmail.com",
                    NormalizedUserName = "DIMITARPAVLOV@GMAIL.COM",
                    FirstName = "Dimitar",
                    LastName = "Pavlov",
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                },

                new ApplicationUser()
                {
                    Id = Guid.Parse("42409a8e-62ad-41ce-82be-533c18943886"),
                    Email = AdminEmail,
                    NormalizedEmail = AdminEmail,
                    UserName = AdminEmail,
                    NormalizedUserName = AdminEmail,
                    FirstName = "Admin",
                    LastName = "Adminov",
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                },
            };

            foreach (var user in applicationUsers)
            {
                if (user.FirstName == "Georgi")
                {
                    normalUser = user;
                }
                else if (user.FirstName == "Dimitar")
                {
                    premiumUser = user;
                }
                else if (user.FirstName == "Admin")
                {
                    adminUser = user;
                }
            }

            var hasher = new PasswordHasher<ApplicationUser>();

            normalUser.PasswordHash = hasher.HashPassword(normalUser, "Normal123");
            premiumUser.PasswordHash = hasher.HashPassword(premiumUser, "Premium123");
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin123");

            return applicationUsers.ToArray();
        }
    }
}
