using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static BeSocial.Common.EntityValidationConstants.ApplicationUser;

namespace BeSocial.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Posts = new HashSet<Post>();
            Groups = new HashSet<Group>();
        }

        [Required]
        [Comment("User's first name")]
        [StringLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Comment("User's last name")]
        [StringLength(LastNameMaxLength)]
        public string LastName { get; set; } = string.Empty;

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
