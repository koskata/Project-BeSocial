namespace BeSocial.Services.Interfaces
{
    public interface IPremiumUserService
    {
        Task<bool> ExistByIdAsync(string userId);

        Task<int> GetPremiumUserId(string userId);
    }
}
