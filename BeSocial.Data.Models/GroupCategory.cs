using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSocial.Data.Models
{
    public class GroupCategory
    {
        public GroupCategory()
        {
            Groups = new HashSet<Group>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Group> Groups { get; set; }
    }
}
