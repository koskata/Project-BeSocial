using System.ComponentModel.DataAnnotations;
using static BeSocial.Common.EntityValidationConstants.Post;

namespace BeSocial.Web.ViewModels.Post
{
    public class PostAllViewModel
    {
        public PostAllViewModel(string id, string title, string description, 
            int likes, DateTime createdOn, string category, string organiser)
        {
            Id = id;
            Title = title;
            Description = description;
            Likes = likes;
            CreatedOn = createdOn.ToString(DateFormat);
            Category = category;
            OrganiserFullName = organiser;
            Comments = new List<PostCommentServiceModel>();
        }

        public string Id { get; set; } = null!;

        [Required]
        [StringLength(TitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int Likes { get; set; }

        [Required]
        public string CreatedOn { get; set; } = string.Empty;

        [Required]
        public string OrganiserId { get; set; } = string.Empty;

        [Required]
        public string OrganiserFullName { get; set; } = null!;

        [Required]
        public string Category { get; set; } = string.Empty;

        public IEnumerable<PostCommentServiceModel> Comments { get; set; }
    }
}
