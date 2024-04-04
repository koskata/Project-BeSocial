using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static BeSocial.Common.EntityValidationConstants.Post;

namespace BeSocial.Data.Models
{
    public class Post
    {
        public Post()
        {
            Id = Guid.NewGuid();
            Comments = new HashSet<Comment>();
            PostLikers = new HashSet<PostLiker>();
        }

        [Key]
        [Comment("Post identifier")]
        public Guid Id { get; set; }

        [Required]
        [Comment("Post title")]
        [StringLength(TitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Comment("Post description")]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Post likes counter")]
        public int Likes { get; set; } // Not decideddddd!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        [Required]
        [Comment("Post date of creation")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Comment("Creator identifier")]
        public Guid CreatorId { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public virtual ApplicationUser Creator { get; set; } = null!;

        [Required]
        [Comment("Category identifier")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; } = null!;

        [Comment("Group identifier")]
        public Guid? GroupId { get; set; }
        [ForeignKey(nameof(GroupId))]
        public virtual Group? Group { get; set; }


        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<PostLiker> PostLikers { get; set; }
    }
}
