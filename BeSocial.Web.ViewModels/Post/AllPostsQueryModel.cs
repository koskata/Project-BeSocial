using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BeSocial.Web.ViewModels.Enums;

namespace BeSocial.Web.ViewModels.Post
{
    public class AllPostsQueryModel
    {
        public const int PostsPerPage = 3;

        public string Category { get; set; } = null!;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; } = null!;

        public PostSorting Sorting { get; set; }

        [Display(Name = "Current Page")]
        public int CurrentPage { get; set; } = 1;

        [Display(Name = "Total Posts Count")]
        public int TotalPostsCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<PostAllViewModel> Posts { get; set; } = new List<PostAllViewModel>();
    }
}
