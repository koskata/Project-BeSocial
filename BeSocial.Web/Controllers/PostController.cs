using BeSocial.Services.Interfaces;
using BeSocial.Web.Infrastructure;
using BeSocial.Web.ViewModels.Post;

using Microsoft.AspNetCore.Mvc;

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
            //if (User?.Identity?.IsAuthenticated == false && User?.Identity == null)
            //{
            //    return RedirectToAction();
            //}


            //User.GetById();

            var queryResult = postService.GetAllPostsAsync(
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
    }
}
