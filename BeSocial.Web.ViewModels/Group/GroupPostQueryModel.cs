using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BeSocial.Web.ViewModels.Post;

namespace BeSocial.Web.ViewModels.Group
{
    public class GroupPostQueryModel
    {
        public string GroupId { get; set; } = null!;

        public IEnumerable<PostAllViewModel> Posts { get; set; } = new List<PostAllViewModel>();
    }
}
