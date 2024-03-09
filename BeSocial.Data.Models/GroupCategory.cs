using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static BeSocial.Common.EntityValidationConstants.GroupCategory;

namespace BeSocial.Data.Models
{
    public class GroupCategory
    {
        public GroupCategory()
        {
            Groups = new HashSet<Group>();
        }

        [Key]
        [Comment("Category identifier for group")]
        public int Id { get; set; }

        [Required]
        [Comment("Category name for group")]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Group> Groups { get; set; }
    }
}
