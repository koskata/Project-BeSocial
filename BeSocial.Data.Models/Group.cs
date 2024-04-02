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
            Id = Guid.NewGuid();
            GroupParticipants = new HashSet<GroupParticipant>();
            Posts = new HashSet<Post>();
            PremiumUsersGroups = new HashSet<PremiumUserGroup>();
        }

        [Key]
        [Comment("Group identifier")]
        public Guid Id { get; set; }

        [Required]
        [Comment("Group name")]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Creator of group identifier")]
        public Guid OrganiserId { get; set; }

        [ForeignKey(nameof(OrganiserId))]
        public virtual ApplicationUser Organiser { get; set; } = null!;

        [Required]
        [Comment("Category identifier")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; } = null!;

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<GroupParticipant> GroupParticipants { get; set; }

        public virtual ICollection<PremiumUserGroup> PremiumUsersGroups { get; set; }
    }
}
