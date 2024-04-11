using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BeSocial.Web.ViewModels.Enums;
using BeSocial.Web.ViewModels.Post;

namespace BeSocial.Services.Interfaces
{
    public interface IPostService
    {
        Task<PostQueryServiceModel> GetAllPostsAsync(string category = null,
                                                         string searchTerm = null,
                                                         PostSorting sorting = PostSorting.Newest,
                                                         int currentPage = 1,
                                                         int postsPerPage = 1);
        Task<IEnumerable<string>> AllCategoriesNamesAsync();

        Task LikePostAsync(string postId, string userId);

        Task<bool> LikerExistsOnPostAsync(string userId, string postId);

        Task<bool> HasUserWithIdAsync(string postId, string currentUserId);

        Task EditAsync(PostFormServiceModel model, string postId);

        Task<bool> ExistsAsync(string id);

        Task<PostFormServiceModel> GetPostFormModelByIdAsync(string postId);

        Task<IEnumerable<PostCategoryServiceModel>> AllCategoriesAsync();

        Task<bool> CategoryExistsAsync(int categoryId);

        Task<PostServiceModel> PostByIdAsync(string postId);

        Task DeleteAsync(string postId);

        Task<IEnumerable<PostCommentServiceModel>> GetAllCommentsFromPostAsync(string postId);

        Task CreateComment(PostCommentServiceModel model, string userId, string postId);

        Task<PostCommentServiceModel> SetPostTitleToComment(string postId);

    }
}
