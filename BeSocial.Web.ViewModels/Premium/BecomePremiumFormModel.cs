using System.ComponentModel.DataAnnotations;

using static BeSocial.Common.EntityValidationConstants.PremiumUser;
using static BeSocial.Common.ErrorMessages;

namespace BeSocial.Web.ViewModels.Premium
{
    public class BecomePremiumFormModel
    {
        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength, ErrorMessage = LengthErrorMessage)]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength, ErrorMessage = LengthErrorMessage)]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = null!;
    }
}
