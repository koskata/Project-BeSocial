namespace BeSocial.Web.ViewModels.Post
{
    public class PostServiceModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string CreatorFullName { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string? Group { get; set; }
    }
}
