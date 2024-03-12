using Microsoft.AspNetCore.Mvc;

namespace BeSocial.Web.Controllers
{
    public class PostController : Controller
    {
        public IActionResult All()
        {
            //if (User?.Identity?.IsAuthenticated == false || User?.Identity == null)
            //{
            //    return RedirectToAction();
            //}
            return View();
        }
    }
}
