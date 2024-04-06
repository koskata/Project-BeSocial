using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSocial.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> UserFullName(string userId);
    }
}
