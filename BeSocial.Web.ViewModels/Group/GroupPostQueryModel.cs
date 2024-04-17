using BeSocial.Web.ViewModels.Post;

namespace BeSocial.Web.ViewModels.Group
{
    public class GroupPostQueryModel
    {
        public string GroupId { get; set; } = null!;

        public IEnumerable<PostAllViewModel> Posts { get; set; } = new List<PostAllViewModel>();
    }
}
