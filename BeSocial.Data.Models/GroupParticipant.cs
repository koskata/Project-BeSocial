using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BeSocial.Data.Models
{
    public class GroupParticipant
    {
        [Required]
        [Comment("Group identifier")]
        public int GroupId { get; set; }

        public Group Group { get; set; } = null!;

        [Required]
        [Comment("Participant identifier")]
        public string ParticipantId { get; set; } = string.Empty;

        public ApplicationUser Participant { get; set; } = null!;
    }
}
