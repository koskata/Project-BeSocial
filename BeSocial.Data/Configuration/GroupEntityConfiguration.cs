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
                //new Group()
                //{
                //    Id = Guid.Parse("dedd5df2-ae16-4c81-8989-ab4b04a2c7da"),
                //    Name = "The best jokes ever",
                //    OrganiserId = Guid.Parse("42409a8e-62ad-41ce-82be-533c18943886"),
                //    CategoryId = 1
                //},
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
