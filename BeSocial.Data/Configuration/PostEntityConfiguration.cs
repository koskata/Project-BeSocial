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
    public class PostEntityConfiguration : IEntityTypeConfiguration<GroupParticipant>
    {
        public void Configure(EntityTypeBuilder<GroupParticipant> builder)
        {
            builder.HasData(GeneratePosts());
        }

        private Post[] GeneratePosts()
        {
            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    Id = Guid.Parse("c0a48ee8-f260-4d8e-9f47-bd1d553b23f7"),
                    Title = "Joke that I heard from my friend",
                    Description = "Why did the tomato turn red? Because it saw the salad dressing!",
                    Likes = 0,
                    CreatedOn = new DateTime(2024, 3, 23),
                    OrganiserId = Guid.Parse("b744c1d2-71a0-42a9-af63-836846a0fa40"),
                    CategoryId = 1,
                    GroupId = Guid.Parse("dedd5df2-ae16-4c81-8989-ab4b04a2c7da")
                },
                new Post()
                {
                    Id = Guid.Parse("b32c53b2-bed3-49cb-a43f-189de2dcc6c6"),
                    Title = "Semi-Final Champions League",
                    Description = "The semi-final in champions league will be: Real Madrid vs Manchester City. The match is going to be very interesting!",
                    Likes = 0,
                    CreatedOn = new DateTime(2024, 4, 7),
                    OrganiserId = Guid.Parse("42409a8e-62ad-41ce-82be-533c18943886"),
                    CategoryId = 3,
                    GroupId = Guid.Parse("e4d30dd1-31f7-4a05-9f45-9b40f8bad5eb")
                },
                new Post()
                {
                    Id = Guid.Parse("7b38ce67-125a-44b7-b13a-666e3167b20a"),
                    Title = "One day in my life",
                    Description = "Today I woke up and went to the gym. Then I went home and worked from home a bit. At the end of the day, we sat down to dinner with my family.",
                    Likes = 0,
                    CreatedOn = new DateTime(2024, 4, 3),
                    OrganiserId = Guid.Parse("42409a8e-62ad-41ce-82be-533c18943886"),
                    CategoryId = 2
                },
                new Post()
                {
                    Id = Guid.Parse("87ff2998-0940-4717-9545-dbc7e42fc7f2"),
                    Title = "Toni Storaro's new song",
                    Description = "Toni Storaro's new song is great. I can't stop listening to her!",
                    Likes = 0,
                    CreatedOn = new DateTime(2024, 3, 30),
                    OrganiserId = Guid.Parse("b744c1d2-71a0-42a9-af63-836846a0fa40"),
                    CategoryId = 4,
                }
            };

            return posts.ToArray();
        }
    }
}
