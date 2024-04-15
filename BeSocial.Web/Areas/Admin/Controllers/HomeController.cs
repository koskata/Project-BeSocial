using BeSocial.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace BeSocial.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
