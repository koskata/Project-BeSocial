namespace BeSocial.Services.Interfaces
{
    public interface IPremiumUserService
    {
        Task<bool> ExistByIdAsync(string userId);

        Task<int> GetPremiumUserIdAsync(string userId);

        Task CreatePremiumUserAsync(string userId, string firstName, string lastName, string description);
    }
}
