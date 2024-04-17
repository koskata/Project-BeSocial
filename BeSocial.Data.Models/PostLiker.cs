using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

namespace BeSocial.Data.Models
{
    public class PostLiker
    {
        [Required]
        [Comment("Post liker identifier")]
        public Guid LikerId { get; set; }

        public ApplicationUser Liker { get; set; } = null!;

        [Required]
        [Comment("Post identifier")]
        public Guid PostId { get; set; }

        public Post Post { get; set; } = null!;
    }
}
