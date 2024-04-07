using BeSocial.Data;
using BeSocial.Services.Interfaces;
using BeSocial.Web.ViewModels.Enums;
using BeSocial.Web.ViewModels.Post;

using Microsoft.EntityFrameworkCore;

using static BeSocial.Web.Infrastructure.ClaimsPrincipalExtension;
using static BeSocial.Common.EntityValidationConstants.Post;
using System.Linq;
using BeSocial.Data.Models;

namespace BeSocial.Services.Post
{
    public class PostService : IPostService
    {
        private readonly BeSocialDbContext context;

        public PostService(BeSocialDbContext _context)
        {
            context = _context;
        }


        public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        {
            return await context.Categories.Select(c => c.Name).Distinct().ToListAsync();
        }


        public PostQueryServiceModel GetAllPostsAsync(string category = null,
                                                                            string searchTerm = null,
                                                                            PostSorting sorting = PostSorting.Newest,
                                                                            int currentPage = 1,
                                                                            int postsPerPage = 1)
        {
            var postsQuery = context.Posts.AsQueryable();

            if (!string.IsNullOrWhiteSpace(category))
            {
                postsQuery = context.Posts.Where(x => x.Category.Name == category);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                postsQuery = postsQuery.Where(x =>
                                                x.Title.ToLower().Contains(searchTerm.ToLower()) ||
                                                x.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            postsQuery = sorting switch
            {
                PostSorting.MostLiked => postsQuery
                                                .OrderByDescending(x => x.Likes),
                _ => postsQuery.OrderByDescending(x => x.CreatedOn)
            };

            var posts = postsQuery
                .Skip((currentPage - 1) * postsPerPage)
                .Take(postsPerPage)
                .Select(x => new PostAllViewModel(
                    x.Id.ToString(),
                    x.Title,
                    x.Description,
                    x.Likes,
                    x.CreatedOn,
                    x.Category.Name
                )).ToList();


            var totalPosts = postsQuery.Count();

            return new PostQueryServiceModel()
            {
                TotalPostsCount = totalPosts,
                Posts = posts
            };
        }

        public async Task LikePostAsync(string postId, string userId)
        {
            var post = await context.Posts.FirstOrDefaultAsync(x => x.Id.ToString() == postId);

            if (post != null)
            {
                post.Likes++;
                post.PostLikers.Add(new PostLiker
                {
                    PostId = Guid.Parse(postId),
                    LikerId = Guid.Parse(userId)
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> LikerExistsOnPostAsync(string userId)
            => await context.PostLikers.AnyAsync(x => x.LikerId.ToString() == userId);
    }
}
