using BeSocial.Services.Interfaces;
using BeSocial.Web.Infrastructure;
using BeSocial.Web.ViewModels.Post;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static BeSocial.Common.ErrorMessages;

namespace BeSocial.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService _postService)
        {
            postService = _postService;
        }

        public async Task<IActionResult> All([FromQuery] AllPostsQueryModel query)
        {

            var queryResult = await postService.GetAllPostsAsync(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllPostsQueryModel.PostsPerPage);

            query.TotalPostsCount = queryResult.TotalPostsCount;
            query.Posts = queryResult.Posts;

            var postCategories = await postService.AllCategoriesNamesAsync();
            query.Categories = postCategories;

            return View(query);
        }

        [Authorize]
        public async Task<IActionResult> Like(string postId)
        {
            string userId = User.GetById();

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Register", "Identity", "Account");
            }

            if (await postService.LikerExistsOnPostAsync(userId, postId))
            {
                return RedirectToAction(nameof(All));
            }

            await postService.LikePostAsync(postId, userId);

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (!await postService.ExistsAsync(id))
            {
                return BadRequest();
            }

            if (await postService.HasUserWithIdAsync(id, this.User.GetById()) == false)
            {
                return Unauthorized();
            }

            var model = await postService.GetPostFormModelByIdAsync(id);

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(PostFormServiceModel model, string id)
        {
            if (!await postService.ExistsAsync(id))
            {
                return this.View();
            }

            if (await postService.HasUserWithIdAsync(id, this.User.GetById()) == false)
            {
                return Unauthorized();
            }

            if (await postService.CategoryExistsAsync(model.CategoryId) == false)
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), CategoryDoesNotExist);
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await postService.AllCategoriesAsync();

                return View(model);
            }

            await postService.EditAsync(model, id);

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (!await postService.ExistsAsync(id))
            {
                return BadRequest();
            }

            if (!await postService.HasUserWithIdAsync(id, User.GetById()))
            {
                return Unauthorized();
            }

            var post = await postService.PostByIdAsync(id);

            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(PostServiceModel model, string id)
        {
            if (!await postService.ExistsAsync(id))
            {
                return BadRequest();
            }

            if (!await postService.HasUserWithIdAsync(id, User.GetById()))
            {
                return Unauthorized();
            }

            await postService.DeleteAsync(id);

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AddComment(string id)
        {
            if (!await postService.ExistsAsync(id))
            {
                return BadRequest();
            }

            var model = await postService.SetPostTitleToCommentAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(PostCommentServiceModel model, string id)
        {
            if (!await postService.ExistsAsync(id))
            {
                return BadRequest();
            }

            string userId = User.GetById();

            await postService.CreateCommentAsync(model, userId, id);

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> CreatePost()
        {
            var model = new PostFormServiceModel();

            model.Categories = await postService.AllCategoriesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostFormServiceModel model)
        {
            if (await postService.CategoryExistsAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), CategoryDoesNotExist);
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await postService.AllCategoriesAsync();

                return View(model);
            }

            string userId = User.GetById();

            await postService.CreatePostAsync(model, userId);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> LikedPosts()
        {
            string userId = User.GetById();

            var likedPosts = await postService.GetAllLikedPosts(userId);

            return View(likedPosts);
        }
    }
}
