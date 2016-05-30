using System.Web.Mvc;
using Abp.Auditing;
using Abp.Web.Mvc.Authorization;
using YouChat.Authorization;
using YouChat.Web.Controllers;

namespace YouChat.Web.Areas.Mpa.Controllers
{
    [DisableAuditing]
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_AuditLogs)]
    public class AuditLogsController : AbpZeroTemplateControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}