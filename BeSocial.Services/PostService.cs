using BeSocial.Data;
using BeSocial.Services.Interfaces;
using BeSocial.Web.ViewModels.Enums;
using BeSocial.Web.ViewModels.Post;

using Microsoft.EntityFrameworkCore;

using static BeSocial.Web.Infrastructure.ClaimsPrincipalExtension;
using static BeSocial.Common.EntityValidationConstants.Post;
using System.Linq;

namespace BeSocial.Services
{
    public class PostService : IPostService
    {
        private readonly BeSocialDbContext context;

        public PostService(BeSocialDbContext _context)
        {
            context = _context;
        }


        public async Task<IEnumerable<string>> AllPostsCategoriesNames()
        {
            return await context.PostCategories.Select(c => c.Name).Distinct().ToListAsync();
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
                postsQuery = context.Posts.Where(x => x.PostCategory.Name == category);
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
                    x.Id,
                    x.Title,
                    x.Description,
                    x.Likes,
                    x.CreatedOn,
                    x.PostCategory.Name
                )).ToList();


            var totalPosts = postsQuery.Count();

            return new PostQueryServiceModel()
            {
                TotalPostsCount = totalPosts,
                Posts = posts
            };
        }
    }
}
