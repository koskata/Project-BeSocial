using System.Security.Claims;

namespace BeSocial.Web.Infrastructure
{
    public static class ClaimsPrincipalExtension
    {
        public static string GetById(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
