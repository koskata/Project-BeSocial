using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static BeSocial.Common.EntityValidationConstants.Group;

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
        [Comment("Group identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Group name")]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Creator of group identifier")]
        public string OrganiserId { get; set; } = string.Empty;

        [ForeignKey(nameof(OrganiserId))]
        public ApplicationUser Organiser { get; set; } = null!;

        [Required]
        [Comment("Category identifier")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public GroupCategory GroupCategory { get; set; } = null!;

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<GroupParticipant> GroupParticipants { get; set; }
    }
}
