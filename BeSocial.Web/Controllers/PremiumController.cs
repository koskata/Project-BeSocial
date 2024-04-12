using BeSocial.Data;
using BeSocial.Services.Interfaces;
using BeSocial.Web.Infrastructure;
using BeSocial.Web.ViewModels.Premium;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using static BeSocial.Common.ErrorMessages;
using static BeSocial.Common.MessageConstants;

namespace BeSocial.Web.Controllers
{
    public class PremiumController : Controller
    {
        private readonly IPremiumUserService premiumService;
        private readonly BeSocialDbContext context;

        public PremiumController(IPremiumUserService _premiumService, BeSocialDbContext _context)
        {
            premiumService = _premiumService;
            context = _context;
        }

        [Authorize]
        public async Task<IActionResult> Become()
        {
            string userId = User.GetById();


            if (await premiumService.PremiumUserWithUserIdExistsAsync(userId))
            {
                TempData[UserMessageSuccess] = "You are already a premium user!";

                return RedirectToAction("Index", "Home");
            }

            var user = await context.Users.FirstOrDefaultAsync(x => x.Id.ToString() == userId);

            var model = new BecomePremiumFormModel();

            model.Email = user.Email;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomePremiumFormModel model)
        {
            string userId = User.GetById();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await premiumService.CreatePremiumUserAsync(userId, model.FirstName, model.LastName, model.Description);

            return RedirectToAction("Index", "Home");
        }
    }
}
