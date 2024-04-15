using BeSocial.Services.Interfaces;
using BeSocial.Web.Infrastructure;

using Microsoft.AspNetCore.Mvc;

namespace BeSocial.Web.Areas.Admin.Controllers
{
    public class GroupController : AdminBaseController
    {
        private readonly IGroupService groupService;

        public GroupController(IGroupService _groupService)
        {
            groupService = _groupService;
        }

        public async Task<IActionResult> My()
        {
            string userId = User.GetById();

            var model = await groupService.GetAllMyGroupsAsync(userId);

            return View(model);
        }
    }
}
