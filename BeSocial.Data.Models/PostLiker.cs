using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BeSocial.Data.Models
{
    public class PostLiker
    {
        [Required]
        [Comment("Post liker identifier")]
        public string LikerId { get; set; } = string.Empty;

        public ApplicationUser Liker { get; set; } = null!;

        [Required]
        [Comment("Post identifier")]
        public int PostId { get; set; }

        public Post Post { get; set; } = null!;
    }
}
