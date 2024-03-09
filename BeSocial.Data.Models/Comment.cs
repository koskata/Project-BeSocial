using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static BeSocial.Common.EntityValidationConstants.Comment;

namespace BeSocial.Data.Models
{
    public class Comment
    {
        [Key]
        [Comment("Comment identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength)]
        [Comment("Comment description")]
        public string Description { get; set; } = string.Empty;
    }
}
