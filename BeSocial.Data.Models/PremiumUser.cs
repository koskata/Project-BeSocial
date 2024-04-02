using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using static BeSocial.Common.EntityValidationConstants.PremiumUser;

namespace BeSocial.Data.Models
{
    public class PremiumUser
    {
        public PremiumUser()
        {
            Id = Guid.NewGuid();
            PremiumUsersGroups = new HashSet<PremiumUserGroup>();
            Posts = new HashSet<Post>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [Comment("Premium user first name")]
        [StringLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Comment("Premium user last name")]
        [StringLength(LastNameMaxLength)]
        public string LastName { get; set; } = string.Empty;

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<PremiumUserGroup> PremiumUsersGroups { get; set; }

    }
}
