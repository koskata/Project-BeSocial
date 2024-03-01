using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSocial.Data.Models
{
    public class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            PostLikers = new HashSet<PostLiker>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int Likes { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string OrganiserId { get; set; } = string.Empty;

        [ForeignKey(nameof(OrganiserId))]
        public User Organiser { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public PostCategory PostCategory { get; set; } = null!;


        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<PostLiker> PostLikers { get; set; }
    }
}
