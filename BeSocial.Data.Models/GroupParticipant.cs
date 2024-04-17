using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

namespace BeSocial.Data.Models
{
    public class GroupParticipant
    {

        [Required]
        [Comment("Group identifier")]
        public Guid GroupId { get; set; }

        public virtual Group Group { get; set; } = null!;

        [Required]
        [Comment("Participant identifier")]
        public Guid ParticipantId { get; set; }

        public virtual ApplicationUser Participant { get; set; } = null!;
    }
}
