using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSocial.Data.Models
{
    public class PostLiker
    {
        [Required]
        public string LikerId { get; set; } = string.Empty;

        public User Liker { get; set; } = null!;

        [Required]
        public int PostId { get; set; }

        public Post Post { get; set; } = null!;
    }
}
