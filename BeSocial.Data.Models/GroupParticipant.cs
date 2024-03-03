using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSocial.Data.Models
{
    public class GroupParticipant
    {
        [Required]
        public int GroupId { get; set; }

        public Group Group { get; set; } = null!;

        [Required]
        public string ParticipantId { get; set; } = string.Empty;

        public User Participant { get; set; } = null!;
    }
}
