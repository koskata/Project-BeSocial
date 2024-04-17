using BeSocial.Web.ViewModels.User;

namespace BeSocial.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> UserFullName(string userId);

        Task<IEnumerable<UserServiceModel>> AllAsync();
    }
}
