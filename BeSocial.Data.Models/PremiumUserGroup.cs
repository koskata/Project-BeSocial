using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace BeSocial.Data.Models
{
    public class PremiumUserGroup
    {
        [Required]
        [Comment("Premium User identifier")]
        public Guid PremiumUserId { get; set; }

        public PremiumUser PremiumUser { get; set; } = null!;

        [Required]
        [Comment("Group identifier")]
        public Guid GroupId { get; set; }

        public Group Group { get; set; } = null!;
    }
}
