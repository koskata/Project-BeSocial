using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSocial.Data.Models
{
    public class Group
    {
        public Group()
        {
            GroupParticipants = new HashSet<GroupParticipant>();
            Posts = new HashSet<Post>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string OrganiserId { get; set; } = string.Empty;

        [ForeignKey(nameof(OrganiserId))]
        public User Organiser { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public GroupCategory GroupCategory { get; set; } = null!;

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<GroupParticipant> GroupParticipants { get; set; }
    }
}
