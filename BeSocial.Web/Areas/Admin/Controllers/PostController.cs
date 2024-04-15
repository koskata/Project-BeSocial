using BeSocial.Services.Interfaces;
using BeSocial.Web.Infrastructure;

using Microsoft.AspNetCore.Mvc;

namespace BeSocial.Web.Areas.Admin.Controllers
{
    public class PostController : AdminBaseController
    {
        private readonly IPostService postService;

        public PostController(IPostService _postService)
        {
            postService = _postService;
        }

        public async Task<IActionResult> My()
        {

            string userId = User.GetById();

            var myPosts = await postService.GetAllMyPostsAsync(userId);

            return View(myPosts);
        }
    }
}
