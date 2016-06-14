using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Xml;
using Abp.Application.Services.Dto;
using Newtonsoft.Json.Linq;
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






        #region 微信测试

        //[HttpGet]
        //public void WeiXinInit()
        //{
        //    //Valid();
        //    StreamReader str = new StreamReader(Request.InputStream, Encoding.UTF8);
        //    XmlDocument xml = new XmlDocument();
        //    xml.Load(str);
        //    string toUserName = xml.SelectSingleNode("xml").SelectSingleNode("ToUserName").InnerText;
        //    string fromUserName = xml.SelectSingleNode("xml").SelectSingleNode("FromUserName").InnerText;
        //    string content = xml.SelectSingleNode("xml").SelectSingleNode("Content").InnerText;
        //    Logger.Info("这里是微信的信息哦:" + fromUserName + " 发给 " + toUserName + " " + content);
        //}

        //public string GetAccessToken()
        //{
        //    string url =
        //        "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=wx7fb5a3fe66bddf8f&secret=8997422e56eb028067d4a3847336832c";

        //    HttpClient http = new HttpClient();
        //    string result = http.GetStringAsync(url).Result;
        //    JObject resutlJsonr = JObject.Parse(result);
        //    return resutlJsonr["access_token"].ToString();
        //}


        //const string Token = "seejoy";

        ///// <summary>  
        ///// 验证微信签名  
        ///// </summary>  
        ///// * 将token、timestamp、nonce三个参数进行字典序排序  
        ///// * 将三个参数字符串拼接成一个字符串进行sha1加密  
        ///// * 开发者获得加密后的字符串可与signature对比，标识该请求来源于微信。  
        ///// <returns></returns>  
        //private bool CheckSignature()
        //{
        //    string signature = Request.QueryString["signature"].ToString();
        //    string timestamp = Request.QueryString["timestamp"].ToString();
        //    string nonce = Request.QueryString["nonce"].ToString();
        //    string[] ArrTmp = {Token, timestamp, nonce};
        //    Array.Sort(ArrTmp); //字典排序  
        //    string tmpStr = string.Join("", ArrTmp);
        //    var data = SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(tmpStr));
        //    var sb = new StringBuilder();
        //    foreach (var t in data)
        //    {
        //        sb.Append(t.ToString("X2"));
        //    }
        //    tmpStr = sb.ToString();
        //    tmpStr = tmpStr.ToLower();
        //    if (tmpStr == signature)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //private void Valid()
        //{
        //    string echoStr = Request.QueryString["echoStr"].ToString();
        //    if (CheckSignature())
        //    {
        //        if (!string.IsNullOrEmpty(echoStr))
        //        {
        //            Response.Write(echoStr);
        //            Response.End();
        //        }
        //    }
        //}

        #endregion

    }
}