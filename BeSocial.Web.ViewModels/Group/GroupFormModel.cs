using System.ComponentModel.DataAnnotations;

using static BeSocial.Common.EntityValidationConstants.Group;
using static BeSocial.Common.ErrorMessages;

namespace BeSocial.Web.ViewModels.Group
{
    public class GroupFormModel
    {
        public GroupFormModel()
        {
            Categories = new HashSet<GroupCategoryServiceModel>();
        }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = LengthErrorMessage)]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Category")]
        [Required(ErrorMessage = RequiredMessage)]
        public int CategoryId { get; set; }

        public IEnumerable<GroupCategoryServiceModel> Categories { get; set; }
    }
}
