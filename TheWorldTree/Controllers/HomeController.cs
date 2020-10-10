using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TheWorldTree.Data;
using TheWorldTree.EXMethod;
using TheWorldTree.Models;

namespace TheWorldTree.Controllers
{
    /// <summary>
    /// 主页
    /// </summary>
    public class HomeController : BaseVerifyController
    {
        public TreeBaseEX TreeBaseEX;
        public TheWorldTreeDBContext _context;
        public HomeController(TheWorldTreeDBContext context)
        {
            TreeBaseEX = new TreeBaseEX(context);
            _context = context;
        }


        public IActionResult Index()
        {
           
            try
            {
               
                var Article = _context.TreePress.ToList();//获取文章
                ViewBag.Articles = Article.Count();//文章数
                ViewBag.PubArticle = Article.Where(x => x.Issue == "1").ToList();//已发表文章
                ViewBag.NoPubArticle = Article.Where(x => x.Issue == "0").ToList();//草稿
                ViewBag.Subs = _context.TreeSubscription.Count();//订阅数
                ViewBag.IPInfo = JsonConvert.SerializeObject(TreeBaseEX.GetIPinfo());//获取当前年份的每月访问人数
            }
            catch (Exception ex)
            {
                Logger.Info(ex.ToString());
            }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
