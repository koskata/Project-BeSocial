using BeSocial.Data;
using BeSocial.Data.Models;
using BeSocial.Tests.Mocks;

namespace BeSocial.Tests.UnitTests
{
    public class UnitTestsBase
    {
        protected BeSocialDbContext context;


        [OneTimeSetUp]
        public void SetUpBase()
        {
            context = DatabaseMock.Instance;

            SeedDatabase();
        }

        public ApplicationUser NormalUser { get; set; } = null!;

        public PremiumUser PremiumUser { get; set; } = null!;

        public Post Post { get; set; } = null!;

        public Group Group { get; set; } = null!;

        public List<Category> Categories { get; set; } = null!;

        private void SeedDatabase()
        {
            NormalUser = new ApplicationUser()
            {
                Id = Guid.Parse("b744c1d2-71a0-42a9-af63-836846a0fa40"),
                Email = "georgiivanov@gmail.com",
                NormalizedEmail = "GEORGIIVANOV@GMAIL.COM",
                UserName = "georgiivanov@gmail.com",
                NormalizedUserName = "GEORGIIVANOV@GMAIL.COM",
                FirstName = "Georgi",
                LastName = "Ivanov",
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };

            PremiumUser = new PremiumUser()
            {
                Id = 1,
                FirstName = "Dimitar",
                LastName = "Pavlov",
                Description = "Hello, my name is Dimitar. I am 25 years old from Sofia. I would love it if you follow me for more content from me.",
                ApplicationUserId = Guid.Parse("656592c0-e20c-4a11-900a-eb6c9cd94b20"),
                ApplicationUser = new ApplicationUser()
                {
                    Id = Guid.Parse("656592c0-e20c-4a11-900a-eb6c9cd94b20"),
                    Email = "dimitarpavlov@gmail.com",
                    NormalizedEmail = "DIMITARPAVLOV@GMAIL.COM",
                    UserName = "dimitarpavlov@gmail.com",
                    NormalizedUserName = "DIMITARPAVLOV@GMAIL.COM",
                    FirstName = "Dimitar",
                    LastName = "Pavlov",
                    SecurityStamp = Guid.NewGuid().ToString("D")
                }
            };

            Post = new Post()
            {
                Id = Guid.Parse("b32c53b2-bed3-49cb-a43f-189de2dcc6c6"),
                Title = "Semi-Final Champions League",
                Description = "The semi-final in champions league will be: Real Madrid vs Manchester City. The match is going to be very interesting!",
                Likes = 0,
                CreatedOn = new DateTime(2024, 4, 7, 12, 37, 12),
                CreatorId = Guid.Parse("656592c0-e20c-4a11-900a-eb6c9cd94b20"),
                CategoryId = 3
            };

            Group = new Group()
            {
                Id = Guid.Parse("e4d30dd1-31f7-4a05-9f45-9b40f8bad5eb"),
                Name = "Champions League Matches",
                CreatorId = 1,
                CategoryId = 3
            };

            Categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Funny"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Lifestyle"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Sport"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Music"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Other"
                },
            };

            context.Users.Add(NormalUser);
            context.PremiumUsers.Add(PremiumUser);
            context.Posts.Add(Post);
            context.Groups.Add(Group);
            context.Categories.AddRange(Categories);
            context.SaveChanges();

        }

        [OneTimeTearDown]
        public void TearDownBase()
        {
            context.Dispose();
        }
    }
}
