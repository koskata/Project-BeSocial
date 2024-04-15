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

        public async Task<IEnumerable<PostCategoryServiceModel>> AllCategoriesAsync()
            => await context.Categories.Select(x => new PostCategoryServiceModel() { Id = x.Id, Name = x.Name }).ToListAsync();

        public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        {
            return await context.Categories.Select(c => c.Name).Distinct().ToListAsync();
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
            => await context.Categories.AnyAsync(x => x.Id == categoryId);

        public async Task DeleteAsync(string postId)
        {
            var post = await context.Posts.FirstOrDefaultAsync(x => x.Id.ToString() == postId);

            var entryPostLikers = await context.PostLikers.Where(x => x.PostId.ToString() == postId)
                .ToListAsync();

            foreach (var item in entryPostLikers)
            {
                context.PostLikers.Remove(item);
            }

            var entryPostComments = await context.Comments.Where(x => x.PostId.ToString() == postId).ToListAsync();

            foreach (var comment in entryPostComments)
            {
                context.Comments.Remove(comment);
            }

            context.Posts.Remove(post);
            await context.SaveChangesAsync();
        }

        public async Task EditAsync(PostFormServiceModel model, string postId)
        {
            var post = await context.Posts.FirstOrDefaultAsync(x => x.Id.ToString() == postId);

            if (post != null)
            {
                post.Title = model.Title;
                post.Description = model.Description;
                post.CategoryId = model.CategoryId;

                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(string id)
            => await context.Posts.AnyAsync(x => x.Id.ToString() == id);

        public async Task<IEnumerable<PostCommentServiceModel>> GetAllCommentsFromPostAsync(string postId)
        {
            var comments = await context.Comments
                .Where(x => x.PostId.ToString() == postId)
                .Select(x => new PostCommentServiceModel()
                {
                    Id = x.Id,
                    UserFullName = $"{x.User.FirstName} {x.User.LastName}",
                    Description = x.Description,
                    PostTitle = x.Post.Title,
                    PostId = x.PostId.ToString()
                })
                .ToListAsync();

            return comments;
        }

        public async Task<PostQueryServiceModel> GetAllPostsAsync(string category = null,
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
                    x.Category.Name,
                    $"{x.Creator.FirstName} {x.Creator.LastName}",
                    x.Group.Name,
                    x.GroupId.ToString(),
                    x.CreatorId.ToString()
                    )).ToList();

            foreach (var post in posts)
            {
                var comments = await GetAllCommentsFromPostAsync(post.Id);
                post.Comments = comments;
            }


            var totalPosts = postsQuery.Count();

            return new PostQueryServiceModel()
            {
                TotalPostsCount = totalPosts,
                Posts = posts
            };
        }

        public async Task<PostFormServiceModel> GetPostFormModelByIdAsync(string postId)
        {
            var model = await context.Posts
                .Where(x => x.Id.ToString() == postId)
                .Select(x => new PostFormServiceModel()
                {
                    Title = x.Title,
                    Description = x.Description,
                    CategoryId = x.CategoryId,
                    GroupName = x.Group.Name
                }).FirstOrDefaultAsync();

            if (model != null)
            {
                model.Categories = await AllCategoriesAsync();
            }

            return model;
        }

        public async Task<bool> HasUserWithIdAsync(string postId, string currentUserId)
            => await context.Posts.AnyAsync(x => x.Id.ToString() == postId && x.CreatorId.ToString() == currentUserId);

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

        public async Task<bool> LikerExistsOnPostAsync(string userId, string postId)
            => await context.PostLikers.AnyAsync(x => x.LikerId.ToString() == userId && x.PostId.ToString() == postId);

        public async Task<PostServiceModel> PostByIdAsync(string postId)
        {
            var postToFind = await context.Posts.FirstOrDefaultAsync(x => x.Id.ToString() == postId);

            var model = await context.Posts
                .Where(x => x.Id.ToString() == postId)
                .Select(x => new PostServiceModel()
                {
                    Id = x.Id.ToString(),
                    Title = x.Title,
                    Description = x.Description,
                    CreatorFullName = $"{x.Creator.FirstName} {x.Creator.LastName}",
                    Category = x.Category.Name
                }).FirstAsync();

            if (postToFind.Group != null)
            {
                model.Group = postToFind.Group.Name;
            }

            return model;
        }

        public async Task CreateCommentAsync(PostCommentServiceModel model, string userId, string postId)
        {

            var post = new BeSocial.Data.Models.Comment()
            {
                Description = model.Description,
                UserId = Guid.Parse(userId),
                PostId = Guid.Parse(postId)
            };

            await context.Comments.AddAsync(post);
            await context.SaveChangesAsync();
        }

        public async Task<PostCommentServiceModel> SetPostTitleToCommentAsync(string postId)
        {
            var postToFind = await context.Posts.FirstOrDefaultAsync(x => x.Id.ToString() == postId);

            var model = new PostCommentServiceModel();

            model.PostTitle = postToFind.Title;

            return model;
        }

        public async Task CreatePostAsync(PostFormServiceModel model, string userId)
        {
            var postToCreate = new BeSocial.Data.Models.Post()
            {
                Title = model.Title,
                Description = model.Description,
                Likes = 0,
                CreatedOn = DateTime.Now,
                CreatorId = Guid.Parse(userId),
                CategoryId = model.CategoryId
            };

            await context.Posts.AddAsync(postToCreate);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostAllViewModel>> GetAllLikedPostsAsync(string userId)
        {

            var posts = await context.PostLikers
                .Where(x => x.LikerId.ToString() == userId)
                .Select(x => new PostAllViewModel(
                    x.Post.Id.ToString(),
                    x.Post.Title,
                    x.Post.Description,
                    x.Post.Likes,
                    x.Post.CreatedOn,
                    x.Post.Category.Name,
                    $"{x.Post.Creator.FirstName} {x.Post.Creator.LastName}",
                    x.Post.Group.Name,
                    x.Post.GroupId.ToString(),
                    x.Post.CreatorId.ToString()))
                .ToListAsync();

            return posts;
        }

        public async Task<IEnumerable<PostAllViewModel>> GetAllMyPostsAsync(string userId)
        {
            var posts = await context.Posts
                .Where(x => x.CreatorId.ToString() == userId)
                .Select(x => new PostAllViewModel(
                    x.Id.ToString(),
                    x.Title,
                    x.Description,
                    x.Likes,
                    x.CreatedOn,
                    x.Category.Name,
                    $"{x.Creator.FirstName} {x.Creator.LastName}",
                    x.Group.Name,
                    x.GroupId.ToString(),
                    x.CreatorId.ToString()
                    ))
                .ToListAsync();

            return posts;
        }
    }
}
