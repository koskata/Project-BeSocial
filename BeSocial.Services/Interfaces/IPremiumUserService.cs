using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSocial.Services.Interfaces
{
    public interface IPremiumUserService
    {
        Task<bool> ExistByIdAsync(string userId);

        Task<int> GetPremiumUserId(string userId);
    }
}
