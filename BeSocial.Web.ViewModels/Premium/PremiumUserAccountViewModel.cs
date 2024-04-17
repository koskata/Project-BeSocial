using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSocial.Web.ViewModels.Premium
{
    public class PremiumUserAccountViewModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
