using System.Diagnostics;

using BeSocial.Data;
using BeSocial.Services.Interfaces;
using BeSocial.Web.ViewModels.Post;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeSocial.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService postService;

        public HomeController(IPostService _postService)
        {
            postService = _postService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ModalContent(string postId)
        {
            //var model = context.Posts.FirstOrDefault(x => x.Id.ToString() == postId);
            if (postId == null)
            {
                return RedirectToAction(nameof(Index));
            }


            var comments = await postService.GetAllCommentsFromPostAsync(postId);

            return PartialView("~/Views/Shared/_ModalContent.cshtml", comments);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return null;
        }
    }
}