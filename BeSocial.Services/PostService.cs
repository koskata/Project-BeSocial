using BeSocial.Data;
using BeSocial.Services.Interfaces;
using BeSocial.Web.ViewModels.Post;

using Microsoft.EntityFrameworkCore;

using static BeSocial.Web.Infrastructure.ClaimsPrincipalExtension;

namespace BeSocial.Services
{
    public class PostService : IPostService
    {
        private readonly BeSocialDbContext context;

        public PostService(BeSocialDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<PostAllViewModel>> GetAllPostsAsync()
        {
            var posts = await context.Posts.Select(x => new PostAllViewModel
            (x.Title, x.Description, x.Likes, x.CreatedOn, x.PostCategory.Name)).ToListAsync();

            return posts;
        }
    }
}
