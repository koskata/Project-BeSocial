using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BeSocial.Web.ViewModels.Enums;
using BeSocial.Web.ViewModels.Group;
using BeSocial.Web.ViewModels.Post;
using BeSocial.Web.ViewModels.Premium;

namespace BeSocial.Services.Interfaces
{
    public interface IGroupService
    {
        Task<GroupQueryServiceModel> GetAllGroupsAsync(string category = null,
                                                                            string searchTerm = null,
                                                                            GroupSorting sorting = GroupSorting.MostJoined,
                                                                            int currentPage = 1,
                                                                            int groupsPerPage = 1);

        Task<IEnumerable<GroupCategoryServiceModel>> AllCategoriesAsync();

        Task<IEnumerable<string>> AllCategoriesNamesAsync();

        //Task<IEnumerable<PostAllViewModel>> GetAllPostsForGroupByIdAsync(string groupId);

        Task<bool> IsUserInGroupAsync(string groupId, string userId);

        Task<bool> GroupExistAsync(string groupId);

        Task JoinGroupAsync(string groupId, string userId);

        Task LeaveGroupAsync(string groupId, string userId);

        Task<bool> HasUserWithIdAsync(string groupId, string userId);

        Task<GroupFormModel> GetGroupFormModelByIdAsync(string groupId);

        Task<bool> CategoryExistAsync(int categoryId);

        Task EditGroupAsync(GroupFormModel model, string groupId);

        Task<bool> IsUserPremiumAsync(string userId);

        //Task<PremiumUserAccountViewModel> GetPremiumUserByUserIdAsync(string userId);

        Task<PremiumUserAccountViewModel> GetPremiumUserByPremiumIdAsync(int creatorId);

        Task CreateGroupAsync(GroupFormModel model, string userId);

        Task<IEnumerable<GroupAllViewModel>> GetAllJoinedGroupsAsync(string userId);

        Task DeleteGroupAsync(string groupId);

        Task<GroupDeleteViewModel> GetGroupDeleteModelByIdAsync(string groupId);

        Task<IEnumerable<PostAllViewModel>> GetAllPostsForGroupByGroupIdAsync(string groupId);

        Task AddPostToGroupAsync(PostFormServiceModel model, string groupId, string userId);

        Task<IEnumerable<GroupAllViewModel>> GetAllMyGroupsAsync(string userId);
    }
}
