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
                    { new Guid("42409a8e-62ad-41ce-82be-533c18943886"), 0, "11011c0b-d5a9-4ed1-80f5-67f81947af91", "admin@gmail.com", false, "Admin", "Adminov", false, null, "admin@gmail.com", "admin@gmail.com", "AQAAAAEAACcQAAAAEBc9bfgA8ilkZTapegAbsIjNkFCPsNM2bFsbUcyEt1muPSWuC6cPtz8+eunrgUnFcA==", null, false, "2d464a10-b5a9-4663-b891-ee51c577feb8", false, "admin@gmail.com" },
                    { new Guid("656592c0-e20c-4a11-900a-eb6c9cd94b20"), 0, "50b90bc9-0a2c-4318-89ac-d3e65f3f04e1", "dimitarpavlov@gmail.com", false, "Dimitar", "Pavlov", false, null, "DIMITARPAVLOV@GMAIL.COM", "DIMITARPAVLOV@GMAIL.COM", "AQAAAAEAACcQAAAAEIGqOuBDAzCmyN06ZHHcJ1OnkGWVE/U/6v/GavQrN+KOuJq1u9qKs+lqEJthbmzJYA==", null, false, "f87e6ae4-949e-4f08-bb73-1111cb89d2ba", false, "dimitarpavlov@gmail.com" },
                    { new Guid("b744c1d2-71a0-42a9-af63-836846a0fa40"), 0, "2fae81d0-26cc-4a15-a8de-026fd5b3689c", "georgiivanov@gmail.com", false, "Georgi", "Ivanov", false, null, "GEORGIIVANOV@GMAIL.COM", "GEORGIIVANOV@GMAIL.COM", "AQAAAAEAACcQAAAAEGfPfRz7C91/b/oxT9fDLMi/IyXBiwszmiHKZyANzJqvANNXSlco1I40vPDzMvf1Cg==", null, false, "92ec64dc-deed-4c10-b96e-b7dcd02ea143", false, "georgiivanov@gmail.com" }
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
                values: new object[,]
                {
                    { 1, new Guid("656592c0-e20c-4a11-900a-eb6c9cd94b20"), "Hello, my name is Dimitar. I am 25 years old from Sofia. I would love it if you follow me for more content from me.", "Dimitar", "Pavlov" },
                    { 2, new Guid("42409a8e-62ad-41ce-82be-533c18943886"), "The best admin. You can't touch me!", "Admin", "Adminov" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CategoryId", "CreatorId", "Name" },
                values: new object[] { new Guid("e4d30dd1-31f7-4a05-9f45-9b40f8bad5eb"), 3, 1, "Champions League Matches" });
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
                table: "PremiumUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("42409a8e-62ad-41ce-82be-533c18943886"));

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
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("656592c0-e20c-4a11-900a-eb6c9cd94b20"));
        }
    }
}
