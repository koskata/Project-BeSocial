using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using static BeSocial.Common.EntityValidationConstants.PremiumUser;

namespace BeSocial.Data.Models
{
    public class PremiumUser
    {
        public PremiumUser()
        {
            CreatedGroups = new HashSet<Group>();
        }

        [Key]
        [Comment("Premium user identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Premium user first name")]
        [StringLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [Comment("Premium user last name")]
        [StringLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [Comment("Premium user description")]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Comment("Normal user identifier")]
        public Guid ApplicationUserId { get; set; }

        [ForeignKey(nameof(ApplicationUserId))]

        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

        public virtual ICollection<Group> CreatedGroups { get; set; }

    }
}
