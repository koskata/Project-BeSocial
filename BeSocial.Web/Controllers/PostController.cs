using BeSocial.Services.Interfaces;
using BeSocial.Web.Infrastructure;

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

        public async Task<IActionResult> All()
        {
            //if (User?.Identity?.IsAuthenticated == false && User?.Identity == null)
            //{
            //    return RedirectToAction();
            //}


            //User.GetById();

            var posts = await postService.GetAllPostsAsync();

            return View(posts);
        }
    }
}
