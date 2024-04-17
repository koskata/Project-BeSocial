using BeSocial.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeSocial.Data.Configuration
{
    public class GroupEntityConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasData(GenerateGroups());
        }

        private Group[] GenerateGroups()
        {
            List<Group> groups = new List<Group>()
            {
                new Group()
                {
                    Id = Guid.Parse("e4d30dd1-31f7-4a05-9f45-9b40f8bad5eb"),
                    Name = "Champions League Matches",
                    CreatorId = 1,
                    CategoryId = 3
                },
            };

            return groups.ToArray();
        }
    }
}
