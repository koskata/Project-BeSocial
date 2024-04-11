namespace BeSocial.Web.ViewModels.Post
{
    public class PostCommentServiceModel
    {
        public int Id { get; set; }

        public string UserFullName { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string PostTitle { get; set; } = null!;

        public string PostId { get; set; } = null!;
    }
}
