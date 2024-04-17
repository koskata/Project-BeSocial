using BeSocial.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace BeSocial.Web.Controllers
{
    public class CommentController : Controller
    {

        private readonly IPostService postService;

        public CommentController(IPostService _postService)
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
    }
}
