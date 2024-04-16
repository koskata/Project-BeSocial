using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BeSocial.Services.Interfaces;
using BeSocial.Services.Post;
using BeSocial.Tests.UnitTests;
using BeSocial.Web.ViewModels.Enums;
using BeSocial.Web.ViewModels.Post;

using Microsoft.EntityFrameworkCore;

namespace BeSocial.Tests
{
    [TestFixture]
    public class PostServiceTests : UnitTestsBase
    {
        private IPostService postService;

        [OneTimeSetUp]
        public void SetUp()
            => postService = new PostService(context);

        [Test]
        public async Task AllCategoriesNamesAsync_ShouldReturnCorrectResult()
        {
            var result = await postService.AllCategoriesNamesAsync();

            var dbCategories = context.Categories.ToList();
            Assert.That(result.Count(), Is.EqualTo(dbCategories.Count()));

            var categoryNames = dbCategories.Select(c => c.Name);
            Assert.That(categoryNames.Contains(result.FirstOrDefault()));
        }

        [Test]
        public async Task CategoryExistsAsync_ShouldReturnTrueIfCategoryExists()
        {
            // Act
            var exists = await postService.CategoryExistsAsync(1);

            // Assert
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task EditAsync_ShouldEditPost()
        {
            // Arrange
            var postId = Post.Id.ToString();
            var model = new PostFormServiceModel
            {
                Title = Post.Title,
                Description = Post.Description,
                CategoryId = Post.CategoryId
            };

            // Act
            await postService.EditAsync(model, postId);
            var editedPost = await context.Posts.FirstOrDefaultAsync(p => p.Id.ToString() == postId);

            // Assert
            Assert.IsNotNull(editedPost);
            Assert.That(model.Title, Is.EqualTo(editedPost.Title));
            Assert.That(model.Description, Is.EqualTo(editedPost.Description));
            Assert.That(model.CategoryId, Is.EqualTo(editedPost.CategoryId));
        }

        [Test]
        public async Task ExistsAsync_ShouldReturnTrueIfPostExists()
        {
            // Arrange
            var postId = Post.Id.ToString();

            // Act
            var exists = await postService.ExistsAsync(postId);

            // Assert
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task GetAllCommentsFromPostAsync_ShouldReturnCorrectComments()
        {
            // Arrange
            string postId = Post.Id.ToString(); 
            int expectedCommentsCount = context.Comments.Where(x => x.PostId.ToString() == postId).Count();

            // Act
            var comments = await postService.GetAllCommentsFromPostAsync(postId);

            // Assert
            Assert.That(expectedCommentsCount, Is.EqualTo(comments.Count()));
        }

        [Test]
        public async Task GetPostFormModelByIdAsync_ShouldReturnCorrectPostFormModel()
        {
            // Arrange
            string postId = Post.Id.ToString();

            // Act
            var result = await postService.GetPostFormModelByIdAsync(postId);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task HasUserWithIdAsync_ShouldReturnCorrectResult()
        {
            // Arrange
            string postId = Post.Id.ToString();
            string currentUserId = PremiumUser.ApplicationUserId.ToString();

            // Act
            var result = await postService.HasUserWithIdAsync(postId, currentUserId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task LikePostAsync_ShouldIncrementPostLikes()
        {
            // Arrange
            string postId = Post.Id.ToString();
            string userId = NormalUser.Id.ToString();

            // Act
            await postService.LikePostAsync(postId, userId);

            // Assert
            var post = context.Posts.FirstOrDefault(p => p.Id == Guid.Parse(postId));
            Assert.NotNull(post);
            Assert.That(1, Is.EqualTo(post.Likes));
        }

        [Test]
        public async Task PostByIdAsync_ShouldReturnCorrectPost()
        {
            // Arrange
            string postId = Post.Id.ToString();

            // Act
            var result = await postService.PostByIdAsync(postId);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task CreateCommentAsync_ShouldCreateNewComment()
        {
            // Arrange
            var model = new PostCommentServiceModel
            {
                Description = "Test Comment Description"
            };
            string userId = NormalUser.Id.ToString();
            string postId = Post.Id.ToString();
            int expectedCommentsCountBefore = context.Comments.Count();

            // Act
            await postService.CreateCommentAsync(model, userId, postId);

            // Assert
            int expectedCommentsCountAfter = context.Comments.Count();
            Assert.That(expectedCommentsCountAfter, Is.EqualTo(expectedCommentsCountBefore + 1));

            var comment = context.Comments.FirstOrDefault(x => x.PostId.ToString() == postId);
            Assert.That(model.Description, Is.EqualTo(comment.Description));
        }


        [Test]
        public async Task CreatePostAsync_ShouldCreateNewPost()
        {
            // Arrange
            string userId = NormalUser.Id.ToString();
            int expectedPostsCountBefore = context.Posts.Count();

            // Act
            await postService.CreatePostAsync(new PostFormServiceModel()
            {
                Title = Post.Title,
                Description = Post.Description,
                CategoryId = Post.CategoryId
            }, userId);

            int expectedPostsCountAfter = context.Posts.Count();
            // Assert
            var post = context.Posts.FirstOrDefault(x => x.Id == Post.Id);
            Assert.IsNotNull(post);
            Assert.That(Post.Title, Is.EqualTo(post.Title));
            Assert.That(Post.Description, Is.EqualTo(post.Description));
            Assert.That(Post.CategoryId, Is.EqualTo(post.CategoryId));
            Assert.That(expectedPostsCountAfter, Is.EqualTo(expectedPostsCountBefore + 1));
        }

        [Test]
        public async Task GetAllMyPostsAsync_ShouldReturnCorrectPosts()
        {
            // Arrange
            string userId = NormalUser.Id.ToString();
            int expectedMyPostsCount = context.Posts.Where(x => x.CreatorId.ToString() == userId).Count();

            // Act
            var result = await postService.GetAllMyPostsAsync(userId);

            // Assert
            Assert.That(expectedMyPostsCount, Is.EqualTo(result.Count()));
        }

        [Test]
        public async Task GetAllLikedPostsAsync_ShouldReturnCorrectLikedPosts()
        {
            // Arrange
            string userId = PremiumUser.ApplicationUserId.ToString();
            int expectedLikedPostsCount = await context.PostLikers.Where(x => x.LikerId.ToString() == userId).CountAsync();

            // Act
            var result = await postService.GetAllLikedPostsAsync(userId);

            // Assert
            Assert.That(expectedLikedPostsCount, Is.EqualTo(result.Count()));
        }

        [Test]
        public async Task GetAllPostsAsync_ShouldReturnCorrectPosts()
        {
            // Arrange
            string category = "Sport";
            string searchTerm = "semi-final";
            int currentPage = 1;
            int postsPerPage = 3;
            int expectedTotalPostsCount = await context.Posts
                .Where(x => x.Title.ToLower().Contains(searchTerm.ToLower())
                || x.Description.ToLower().Contains(searchTerm)).CountAsync();

            // Act
            var result = await postService.GetAllPostsAsync(category, searchTerm, PostSorting.Newest, currentPage, postsPerPage);

            // Assert
            Assert.That(expectedTotalPostsCount, Is.EqualTo(result.TotalPostsCount));
        }
    }
}
