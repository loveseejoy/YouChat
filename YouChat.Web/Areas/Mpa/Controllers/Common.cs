using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using YouChat.Web.Areas.Mpa.Models.Common.Modals;
using YouChat.Web.Controllers;

namespace YouChat.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize]
    public class CommonController : AbpZeroTemplateControllerBase
    {
        public PartialViewResult LookupModal(LookupModalViewModel model)
        {
            return PartialView("Modals/_LookupModal", model);
        }
    }
}