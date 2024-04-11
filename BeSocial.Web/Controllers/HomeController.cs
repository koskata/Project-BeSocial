using System.Diagnostics;

using BeSocial.Data;
using BeSocial.Web.ViewModels.Post;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeSocial.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly BeSocialDbContext context;

        public HomeController(BeSocialDbContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ModalContent(string postId)
        {
            //var model = context.Posts.FirstOrDefault(x => x.Id.ToString() == postId);

            var comments = context.Comments
                .Where(x => x.PostId.ToString() == postId)
                .Select(x => new PostCommentServiceModel()
                {
                    Id = x.Id,
                    UserFullName = $"{x.User.FirstName} {x.User.LastName}",
                    Description = x.Description,
                    PostTitle = x.Post.Title,
                    PostId = x.PostId.ToString()
                }).ToList();

            return PartialView("~/Views/Shared/_ModalContent.cshtml", comments);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return null;
        }
    }
}