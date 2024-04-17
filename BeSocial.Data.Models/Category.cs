using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

using static BeSocial.Common.EntityValidationConstants.Category;

namespace BeSocial.Data.Models
{
    public class Category
    {
        public Category()
        {
            Groups = new HashSet<Group>();
            Posts = new HashSet<Post>();
        }

        [Key]
        [Comment("Category identifier for group")]
        public int Id { get; set; }

        [Required]
        [Comment("Category name for group")]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Group> Groups { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
