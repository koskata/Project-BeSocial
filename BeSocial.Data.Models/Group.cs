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
        }

        [Key]
        [Comment("Group identifier")]
        public Guid Id { get; set; }

        [Required]
        [Comment("Group name")]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Default user identifier who created the group")]
        public Guid CreatorId { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public virtual ApplicationUser Creator { get; set; } = null!;

        [Required]
        [Comment("Category identifier")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; } = null!;

        [Required]
        [Comment("Premium user identifier who is creator of group")]
        public Guid PremiumUserId { get; set; }
        [ForeignKey(nameof(PremiumUserId))]
        public PremiumUser PremiumUser { get; set; } = null!;

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<GroupParticipant> GroupParticipants { get; set; }
    }
}
