using System.ComponentModel.DataAnnotations;

using BeSocial.Web.ViewModels.Enums;

namespace BeSocial.Web.ViewModels.Group
{
    public class AllGroupsQueryModel
    {
        public const int GroupsPerPage = 3;

        public string Category { get; set; } = null!;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; } = null!;

        public GroupSorting Sorting { get; set; }

        [Display(Name = "Current Page")]
        public int CurrentPage { get; set; } = 1;

        [Display(Name = "Total Groups Count")]
        public int TotalGroupsCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<GroupAllViewModel> Groups { get; set; } = new List<GroupAllViewModel>();
    }
}
