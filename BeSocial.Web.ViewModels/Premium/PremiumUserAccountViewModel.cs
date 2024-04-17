using System.ComponentModel.DataAnnotations;

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
