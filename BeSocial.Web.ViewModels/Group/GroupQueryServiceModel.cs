using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BeSocial.Web.ViewModels.Group
{
    public class GroupQueryServiceModel
    {
        public int TotalGroupsCount { get; set; }

        public IEnumerable<GroupAllViewModel> Groups { get; set; } = new List<GroupAllViewModel>();
    }
}
