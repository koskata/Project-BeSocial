using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSocial.Data.Models
{
    public class PostCategory
    {

        public PostCategory()
        {
            Posts = new HashSet<Post>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Post> Posts { get; set; }
    }
}
