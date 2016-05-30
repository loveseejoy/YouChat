using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using YouChat.Authorization;
using YouChat.Web.Controllers;

namespace YouChat.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Tenant_Dashboard)]
    public class DashboardController : AbpZeroTemplateControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}