using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSocial.Web.ViewModels.Post
{
    public class PostQueryServiceModel
    {
        public int TotalPostsCount { get; set; }

        public IEnumerable<PostAllViewModel> Posts { get; set; } = new List<PostAllViewModel>();
    }
}
