using System.Web.Mvc;

namespace YouChat.Web.Controllers
{
    public class HomeController : AbpZeroTemplateControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}