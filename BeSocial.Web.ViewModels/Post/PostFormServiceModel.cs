using System.ComponentModel.DataAnnotations;

using static BeSocial.Common.EntityValidationConstants.Post;
using static BeSocial.Common.ErrorMessages;

namespace BeSocial.Web.ViewModels.Post
{
    public class PostFormServiceModel
    {
        public PostFormServiceModel()
        {
            Categories = new HashSet<PostCategoryServiceModel>();
        }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = LengthErrorMessage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Category")]
        [Required(ErrorMessage = RequiredMessage)]
        public int CategoryId { get; set; }

        [Display(Name = "Group")]
        public string? GroupName { get; set; }

        public IEnumerable<PostCategoryServiceModel> Categories { get; set; }
    }
}
