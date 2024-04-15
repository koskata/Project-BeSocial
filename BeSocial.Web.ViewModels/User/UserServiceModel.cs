using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSocial.Web.ViewModels.User
{
    public class UserServiceModel
    {
        public string Id { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public bool IsPremium { get; set; }
    }
}
