using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeSocial.Web.ViewModels.Post;

namespace BeSocial.Web.ViewModels.Group
{
    public class GroupAllViewModel
    {
        public GroupAllViewModel(string id, string name, int creatorId, string category, string creator, int participants)
        {
            Id = id;
            Name = name;
            CreatorId = creatorId;
            Category = category;
            Creator = creator;
            Participants = participants;
            Posts = new List<PostAllViewModel>();
        }

        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public int CreatorId { get; set; }

        public string Category { get; set; }

        public string Creator { get; set; }

        public int Participants { get; set; }

        public IEnumerable<PostAllViewModel> Posts { get; set; }

    }
}
