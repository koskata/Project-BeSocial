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
        PostQueryServiceModel GetAllPostsAsync(string category = null,
                                                         string searchTerm = null,
                                                         PostSorting sorting = PostSorting.Newest,
                                                         int currentPage = 1,
                                                         int postsPerPage = 1);
        Task<IEnumerable<string>> AllCategoriesNamesAsync();

        Task LikePostAsync(string postId, string userId);

        Task<bool> LikerExistsOnPostAsync(string userId);
    }
}
