using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using YouChat.YouChat;
using YouChat.YouChat.Dto;

namespace YouChat.Web.Controllers
{
    public class HomeController : AbpZeroTemplateControllerBase
    {
        private readonly IArticleAppService _articelService;
       
        public HomeController(IArticleAppService articelService)
        {
            _articelService = articelService;
        }

        public ActionResult Index()
        {
            var articleList = _articelService.GetArticlAll();
            return View(articleList);
        }

        public ActionResult Article(int id)
        {
            var article = _articelService.GetArticleById(id);
            return View(article);
        }
	}
}