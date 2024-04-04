using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeSocial.Data.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("656592c0-e20c-4a11-900a-eb6c9cd94b20"), 0, "c9c430d2-565d-4c0c-b509-bd85da090ff7", "dimitarpavlov@gmail.com", false, "Dimitar", "Pavlov", true, null, "DIMITARPAVLOV@GMAIL.COM", "DIMITARPAVLOV@GMAIL.COM", "AQAAAAEAACcQAAAAEKnNQRBxWjhQ1jhR6aqzV2cA6GlVk1Xpk0BzTzBLrC1/fz+SvzLSyPDTz1MhqGV3Tw==", null, false, "OAD62GJU3G2YF7PWPMEZCF3GHPWQ7HMB", false, "dimitarpavlov@gmail.com" },
                    { new Guid("b744c1d2-71a0-42a9-af63-836846a0fa40"), 0, "7eb380da-3373-4d72-bda1-373fc72570ae", "georgiivanov@gmail.com", false, "Georgi", "Ivanov", true, null, "GEORGIIVANOV@GMAIL.COM", "GEORGIIVANOV@GMAIL.COM", "AQAAAAEAACcQAAAAEHtgf9NoaG+oNtbYh0u0dX399hkZP+4zfe0dki/Z1h91TrRuG8y+bToQ99eB7fmxZQ==", null, false, "5KP4PV6DCRMT6GIQXH5UTIY3E35QGPU5", false, "georgiivanov@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Funny" },
                    { 2, "Lifestyle" },
                    { 3, "Sport" },
                    { 4, "Music" },
                    { 5, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "CreatorId", "Description", "GroupId", "Likes", "Title" },
                values: new object[,]
                {
                    { new Guid("7b38ce67-125a-44b7-b13a-666e3167b20a"), 2, new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("656592c0-e20c-4a11-900a-eb6c9cd94b20"), "Today I woke up and went to the gym. Then I went home and worked from home a bit. At the end of the day, we sat down to dinner with my family.", null, 0, "One day in my life" },
                    { new Guid("b32c53b2-bed3-49cb-a43f-189de2dcc6c6"), 3, new DateTime(2024, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("656592c0-e20c-4a11-900a-eb6c9cd94b20"), "The semi-final in champions league will be: Real Madrid vs Manchester City. The match is going to be very interesting!", null, 0, "Semi-Final Champions League" },
                    { new Guid("c0a48ee8-f260-4d8e-9f47-bd1d553b23f7"), 1, new DateTime(2024, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b744c1d2-71a0-42a9-af63-836846a0fa40"), "Why did the tomato turn red? Because it saw the salad dressing!", null, 0, "Joke that I heard from my friend" }
                });

            migrationBuilder.InsertData(
                table: "PremiumUsers",
                columns: new[] { "Id", "ApplicationUserId", "Description", "FirstName", "LastName" },
                values: new object[] { new Guid("2094f5c9-a588-4e76-8b7f-ad4a0866189b"), new Guid("656592c0-e20c-4a11-900a-eb6c9cd94b20"), "Hello, my name is Dimitar. I am 25 years old from Sofia. I would love it if you follow me for more content from me.", "Dimitar", "Pavlov" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CategoryId", "CreatorId", "Name", "PremiumUserId" },
                values: new object[] { new Guid("e4d30dd1-31f7-4a05-9f45-9b40f8bad5eb"), 3, new Guid("656592c0-e20c-4a11-900a-eb6c9cd94b20"), "Champions League Matches", new Guid("2094f5c9-a588-4e76-8b7f-ad4a0866189b") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("e4d30dd1-31f7-4a05-9f45-9b40f8bad5eb"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("7b38ce67-125a-44b7-b13a-666e3167b20a"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("b32c53b2-bed3-49cb-a43f-189de2dcc6c6"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("c0a48ee8-f260-4d8e-9f47-bd1d553b23f7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b744c1d2-71a0-42a9-af63-836846a0fa40"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PremiumUsers",
                keyColumn: "Id",
                keyValue: new Guid("2094f5c9-a588-4e76-8b7f-ad4a0866189b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("656592c0-e20c-4a11-900a-eb6c9cd94b20"));
        }
    }
}
