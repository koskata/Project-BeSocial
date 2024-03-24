using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BeSocial.Web.ViewModels.Post;

namespace BeSocial.Services.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostAllViewModel>> GetAllPostsAsync();
    }
}
