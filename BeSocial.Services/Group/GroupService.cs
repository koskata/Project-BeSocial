using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BeSocial.Data;
using BeSocial.Data.Models;
using BeSocial.Services.Interfaces;
using BeSocial.Web.ViewModels.Enums;
using BeSocial.Web.ViewModels.Group;
using BeSocial.Web.ViewModels.Post;
using BeSocial.Web.ViewModels.Premium;

using Microsoft.EntityFrameworkCore;

namespace BeSocial.Services.Group
{
    public class GroupService : IGroupService
    {
        private readonly BeSocialDbContext context;

        public GroupService(BeSocialDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<GroupCategoryServiceModel>> AllCategoriesAsync()
            => await context.Categories.Select(x => new GroupCategoryServiceModel() { Id = x.Id, Name = x.Name }).ToListAsync();

        public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        {
            return await context.Categories.Select(c => c.Name).Distinct().ToListAsync();
        }

        public async Task<bool> CategoryExistAsync(int categoryId)
            => await context.Categories.AnyAsync(x => x.Id == categoryId);

        public async Task CreateGroupAsync(GroupFormModel model, string userId)
        {
            var premiumUser = await context.PremiumUsers.FirstOrDefaultAsync(x => x.ApplicationUserId.ToString() == userId);
            int premiumId = premiumUser.Id;

            var group = new BeSocial.Data.Models.Group()
            {
                Name = model.Name,
                CreatorId = premiumId,
                CategoryId = model.CategoryId
            };

            await context.Groups.AddAsync(group);
            await context.SaveChangesAsync();
        }

        public async Task EditGroupAsync(GroupFormModel model, string groupId)
        {
            var group = await context.Groups.FirstOrDefaultAsync(x => x.Id.ToString() == groupId);

            if (group != null)
            {
                group.Name = model.Name;
                group.CategoryId = model.CategoryId;
            }

            await context.SaveChangesAsync();
        }

        public async Task<GroupQueryServiceModel> GetAllGroupsAsync(string category = null,
                                                                    string searchTerm = null,
                                                                    GroupSorting sorting = GroupSorting.MostJoined,
                                                                    int currentPage = 1,
                                                                    int groupsPerPage = 1)
        {
            var groupsQuery = context.Groups.AsQueryable();

            if (!string.IsNullOrWhiteSpace(category))
            {
                groupsQuery = context.Groups.Where(x => x.Category.Name == category);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                groupsQuery = groupsQuery.Where(x =>
                                                x.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            groupsQuery = sorting switch
            {
                GroupSorting.WithMostPosts => groupsQuery
                                                .OrderByDescending(x => x.Posts.Count),
                _ => groupsQuery.OrderByDescending(x => x.GroupParticipants.Count)
            };

            var groups = groupsQuery
                .Skip((currentPage - 1) * groupsPerPage)
                .Take(groupsPerPage)
                .Select(x => new GroupAllViewModel(
                    x.Id.ToString(),
                    x.Name,
                    x.CreatorId,
                    x.Category.Name,
                    $"{x.Creator.FirstName} {x.Creator.LastName}",
                    x.GroupParticipants.Where(y => y.GroupId == x.Id).Count()
                )).ToList();

            foreach (var group in groups)
            {
                var posts = await GetAllPostsForGroupByIdAsync(group.Id);
                group.Posts = posts;
            }

            var totalGroups = groupsQuery.Count();

            return new GroupQueryServiceModel()
            {
                TotalGroupsCount = totalGroups,
                Groups = groups
            };
        }

        public async Task<IEnumerable<GroupAllViewModel>> GetAllJoinedGroups(string userId)
        {
            var groups = await context.GroupParticipants
                .Where(x => x.ParticipantId.ToString() == userId)
                .Select(x => new GroupAllViewModel(
                    x.Group.Id.ToString(),
                    x.Group.Name,
                    x.Group.CreatorId,
                    x.Group.Category.Name,
                    $"{x.Group.Creator.FirstName} {x.Group.Creator.LastName}",
                    x.Group.GroupParticipants.Where(y => y.GroupId == x.Group.Id).Count()
                    )).ToListAsync();

            return groups;
        }

        public async Task<IEnumerable<PostAllViewModel>> GetAllPostsForGroupByIdAsync(string groupId)
        {
            var posts = await context.Posts
                .Where(x => x.GroupId.ToString() == groupId)
                .Select(x => new PostAllViewModel(
                    x.Id.ToString(),
                    x.Title,
                    x.Description,
                    x.Likes,
                    x.CreatedOn,
                    x.Category.Name,
                    $"{x.Creator.FirstName} {x.Creator.LastName}"
                    )).ToListAsync();

            return posts;
        }

        public async Task<GroupFormModel> GetGroupFormModelByIdAsync(string groupId)
        {
            var group = await context.Groups
                .Where(x => x.Id.ToString() == groupId)
                .Select(x => new GroupFormModel()
                {
                    Name = x.Name,
                    CategoryId = x.CategoryId
                }).FirstOrDefaultAsync();

            if (group != null)
            {
                group.Categories = await AllCategoriesAsync();
            }

            return group;
        }

        public async Task<PremiumUserAccountViewModel> GetPremiumUserByPremiumIdAsync(int creatorId)
        {
            var model = await context.PremiumUsers
            .Where(x => x.Id == creatorId)
            .Select(x => new PremiumUserAccountViewModel()
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Description = x.Description
            }).FirstOrDefaultAsync();

            return model;
        }

        //public async Task<PremiumUserAccountViewModel> GetPremiumUserByUserIdAsync(string userId)
        //{
        //    var model = await context.PremiumUsers
        //        .Where(x => x.ApplicationUserId.ToString() == userId)
        //        .Select(x => new PremiumUserAccountViewModel()
        //        {
        //            FirstName = x.FirstName,
        //            LastName = x.LastName,
        //            Description = x.Description
        //        }).FirstOrDefaultAsync();

        //    return model;
        //}

        public async Task<bool> GroupExistAsync(string groupId)
            => await context.Groups.AnyAsync(x => x.Id.ToString() == groupId);

        public async Task<bool> HasUserWithIdAsync(string groupId, string userId)
        {
            var premiumUser = await context.PremiumUsers.FirstOrDefaultAsync(x => x.ApplicationUserId.ToString() == userId);

            if (premiumUser == null)
            {
                return false;
            }

            int premiumUserId = premiumUser.Id;

            return await context.Groups.AnyAsync(x => x.Id.ToString() == groupId && x.CreatorId == premiumUserId);
        }

        public async Task<bool> IsUserInGroupAsync(string groupId, string userId)
            => await context.GroupParticipants.AnyAsync(x => x.ParticipantId.ToString() == userId && x.GroupId.ToString() == groupId);

        public async Task<bool> IsUserPremiumAsync(string userId)
            => await context.PremiumUsers.AnyAsync(x => x.ApplicationUserId.ToString() == userId);

        public async Task JoinGroupAsync(string groupId, string userId)
        {
            var group = await context.Groups.FirstOrDefaultAsync(x => x.Id.ToString() == groupId);

            var entry = new GroupParticipant()
            {
                GroupId = Guid.Parse(groupId),
                ParticipantId = Guid.Parse(userId)
            };

            await context.GroupParticipants.AddAsync(entry);
            await context.SaveChangesAsync();
        }

        public async Task LeaveGroupAsync(string groupId, string userId)
        {
            var group = await context.Groups.FirstOrDefaultAsync(x => x.Id.ToString() == groupId);

            var entry = new GroupParticipant()
            {
                GroupId = Guid.Parse(groupId),
                ParticipantId = Guid.Parse(userId)
            };

            context.GroupParticipants.Remove(entry);

            await context.SaveChangesAsync();
        }
    }
}
