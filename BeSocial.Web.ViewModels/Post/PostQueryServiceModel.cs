namespace BeSocial.Web.ViewModels.Post
{
    public class PostQueryServiceModel
    {
        public int TotalPostsCount { get; set; }

        public IEnumerable<PostAllViewModel> Posts { get; set; } = new List<PostAllViewModel>();
    }
}
