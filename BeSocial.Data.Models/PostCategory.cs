using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static BeSocial.Common.EntityValidationConstants.PostCategory;

namespace BeSocial.Data.Models
{
    public class PostCategory
    {

        public PostCategory()
        {
            Posts = new HashSet<Post>();
        }

        [Key]
        [Comment("Category identifier of post")]
        public int Id { get; set; }

        [Required]
        [Comment("Category name of post")]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Post> Posts { get; set; }
    }
}
