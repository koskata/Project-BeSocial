using System.ComponentModel.DataAnnotations;

using static BeSocial.Common.ErrorMessages;
using static BeSocial.Common.EntityValidationConstants.Comment;

namespace BeSocial.Web.ViewModels.Post
{
    public class PostCommentServiceModel
    {
        public int Id { get; set; }

        public string UserFullName { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = null!;

        public string PostTitle { get; set; } = null!;

        public string PostId { get; set; } = null!;
    }
}
