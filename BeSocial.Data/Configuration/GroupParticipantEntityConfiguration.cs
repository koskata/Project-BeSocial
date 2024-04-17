using BeSocial.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeSocial.Data.Configuration
{
    public class GroupParticipantEntityConfiguration : IEntityTypeConfiguration<GroupParticipant>
    {
        public void Configure(EntityTypeBuilder<GroupParticipant> builder)
        {
            builder.HasData(GenerateGroupParticipants());
        }

        private GroupParticipant[] GenerateGroupParticipants()
        {
            List<GroupParticipant> groupParticipants = new List<GroupParticipant>()
            {
                new GroupParticipant()
                {
                    GroupId = Guid.Parse("e4d30dd1-31f7-4a05-9f45-9b40f8bad5eb"),
                    ParticipantId = Guid.Parse("656592c0-e20c-4a11-900a-eb6c9cd94b20"),
                }

            };

            return groupParticipants.ToArray();
        }
    }
}
