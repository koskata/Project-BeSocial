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
                    GroupId = Guid.Parse("dedd5df2-ae16-4c81-8989-ab4b04a2c7da"),
                    ParticipantId = Guid.Parse("")
                },
            };
        }
    }
}
