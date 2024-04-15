using System.Security.Claims;

using static BeSocial.Common.GeneralApplicationConstants;

namespace BeSocial.Web.Infrastructure
{
    public static class ClaimsPrincipalExtension
    {
        public static string GetById(this ClaimsPrincipal user)
            => user.FindFirstValue(ClaimTypes.NameIdentifier);

        public static bool IsAdmin(this ClaimsPrincipal user)
            => user.IsInRole(AdminRoleName);
    }
}
