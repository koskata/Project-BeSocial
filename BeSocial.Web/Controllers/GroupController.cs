﻿using BeSocial.Services.Interfaces;
using BeSocial.Services.Post;
using BeSocial.Web.Infrastructure;
using BeSocial.Web.ViewModels.Group;
using BeSocial.Web.ViewModels.Post;

using static BeSocial.Common.MessageConstants;
using static BeSocial.Common.ErrorMessages;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BeSocial.Web.ViewModels.Premium;

namespace BeSocial.Web.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupService groupService;

        public GroupController(IGroupService _groupService)
        {
            groupService = _groupService;
        }

        public async Task<IActionResult> All([FromQuery] AllGroupsQueryModel query)
        {
            var queryResult = await groupService.GetAllGroupsAsync(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllGroupsQueryModel.GroupsPerPage);

            query.TotalGroupsCount = queryResult.TotalGroupsCount;
            query.Groups = queryResult.Groups;

            var groupCategories = await groupService.AllCategoriesNamesAsync();
            query.Categories = groupCategories;

            return View(query);
        }

        public async Task<IActionResult> Join(string groupId)
        {
            string userId = User.GetById();


            if (!await groupService.GroupExistAsync(groupId))
            {
                return BadRequest();
            }

            if (await groupService.IsUserInGroupAsync(groupId, userId))
            {
                TempData[UserMessageWarning] = "You are already in this group!";

                return RedirectToAction(nameof(All));
            }

            await groupService.JoinGroupAsync(groupId, userId);

            TempData[UserMessageSuccess] = "Joined group successfully";

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Leave(string groupId)
        {
            string userId = User.GetById();

            if (!await groupService.GroupExistAsync(groupId))
            {
                return BadRequest();
            }

            if (!await groupService.IsUserInGroupAsync(groupId, userId))
            {
                TempData[UserMessageWarning] = "You are not in this group already!";

                return RedirectToAction(nameof(All));
            }

            await groupService.LeaveGroupAsync(groupId, userId);

            TempData[UserMessageSuccess] = "Left group successfully";

            return RedirectToAction(nameof(All));
        }



        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(string groupId)
        {
            if (!await groupService.GroupExistAsync(groupId))
            {
                return BadRequest();
            }

            var userId = User.GetById();

            if (!await groupService.HasUserWithIdAsync(groupId, userId))
            {
                return Unauthorized();
            }

            var model = await groupService.GetGroupFormModelByIdAsync(groupId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GroupFormModel model, string groupId)
        {
            if (!await groupService.GroupExistAsync(groupId))
            {
                return BadRequest();
            }

            var userId = User.GetById();

            if (!await groupService.HasUserWithIdAsync(groupId, userId))
            {
                return Unauthorized();
            }

            if (!await groupService.CategoryExistAsync(model.CategoryId))
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), CategoryDoesNotExist);
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await groupService.AllCategoriesAsync();

                return View(model);
            }

            await groupService.EditGroupAsync(model, groupId);

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            string userId = User.GetById();

            if (!await groupService.IsUserPremiumAsync(userId))
            {
                TempData[UserMessageError] = "You have to be a premium user!";

                return RedirectToAction(nameof(All));
            }

            var model = new GroupFormModel();

            model.Categories = await groupService.AllCategoriesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GroupFormModel model)
        {
            if (await groupService.CategoryExistAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), CategoryDoesNotExist);
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await groupService.AllCategoriesAsync();

                return View(model);
            }

            string userId = User.GetById();

            await groupService.CreateGroupAsync(model, userId);

            TempData[UserMessageSuccess] = "Successfully created group";

            return RedirectToAction(nameof(All));
        }


        public async Task<IActionResult> Account(int creatorId)
        {
            var model = await groupService.GetPremiumUserByPremiumIdAsync(creatorId);

            return View(model);
        }


        public async Task<IActionResult> JoinedGroups()
        {
            string userId = User.GetById();

            var likedPosts = await groupService.GetAllJoinedGroups(userId);

            return View(likedPosts);
        }
    }
}