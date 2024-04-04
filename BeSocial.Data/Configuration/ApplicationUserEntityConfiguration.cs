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
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(GenerateUsers());
        }

        private ApplicationUser[] GenerateUsers()
        {
            List<ApplicationUser> applicationUsers = new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    Id = Guid.Parse("b744c1d2-71a0-42a9-af63-836846a0fa40"),
                    Email = "georgiivanov@gmail.com",
                    NormalizedEmail = "GEORGIIVANOV@GMAIL.COM",
                    UserName = "georgiivanov@gmail.com",
                    NormalizedUserName = "GEORGIIVANOV@GMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAEHtgf9NoaG+oNtbYh0u0dX399hkZP+4zfe0dki/Z1h91TrRuG8y+bToQ99eB7fmxZQ==",
                    SecurityStamp = "5KP4PV6DCRMT6GIQXH5UTIY3E35QGPU5",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    FirstName = "Georgi",
                    LastName = "Ivanov"
                },

                //new ApplicationUser()
                //{
                //    Id = Guid.Parse("42409a8e-62ad-41ce-82be-533c18943886"),
                //    Email = "petardimitrov@gmail.com",
                //    NormalizedEmail = "PETARDIMITROV@GMAIL.COM",
                //    UserName = "petardimitrov@gmail.com",
                //    NormalizedUserName = "PETARDIMITROV@GMAIL.COM",
                //    EmailConfirmed = false,
                //    PasswordHash = "AQAAAAEAACcQAAAAEJ6e5b6IILTATdwrhIgcL44vS7V0QoXgsN/JewZM/bvogfLK8HB3GuIJcV9SMB0HJg==",
                //    SecurityStamp = "WNQJVQUUHUHBW4I5M5B5CC4322JZ267D",
                //    PhoneNumberConfirmed = false,
                //    TwoFactorEnabled = false,
                //    LockoutEnabled = true,
                //    AccessFailedCount = 0,
                //    FirstName = "Petar",
                //    LastName = "Dimitrov"
                //},

                new ApplicationUser()
                {
                    Id = Guid.Parse("656592c0-e20c-4a11-900a-eb6c9cd94b20"),
                    Email = "dimitarpavlov@gmail.com",
                    NormalizedEmail = "DIMITARPAVLOV@GMAIL.COM",
                    UserName = "dimitarpavlov@gmail.com",
                    NormalizedUserName = "DIMITARPAVLOV@GMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAEKnNQRBxWjhQ1jhR6aqzV2cA6GlVk1Xpk0BzTzBLrC1/fz+SvzLSyPDTz1MhqGV3Tw==",
                    SecurityStamp = "OAD62GJU3G2YF7PWPMEZCF3GHPWQ7HMB",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    FirstName = "Dimitar",
                    LastName = "Pavlov"
                },
            };

            return applicationUsers.ToArray();
        }
    }
}
