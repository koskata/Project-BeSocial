using System.Security.Claims;

namespace BeSocial.Web.Infrastructure
{
    public static class ClaimsPrincipalExtension
    {
        public static string GetById(this ClaimsPrincipal user)
            => user.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
