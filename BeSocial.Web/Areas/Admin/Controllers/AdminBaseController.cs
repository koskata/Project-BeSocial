using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static BeSocial.Common.GeneralApplicationConstants;

namespace BeSocial.Web.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class AdminBaseController : Controller
    {

    }
}
