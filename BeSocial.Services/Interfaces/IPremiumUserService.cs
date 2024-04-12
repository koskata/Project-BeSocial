namespace BeSocial.Services.Interfaces
{
    public interface IPremiumUserService
    {
        Task<bool> ExistByIdAsync(string userId);

        Task<int> GetPremiumUserId(string userId);

        Task<bool> PremiumUserWithUserIdExistsAsync(string email);

        Task CreatePremiumUserAsync(string userId, string firstName, string lastName, string description);
    }
}
