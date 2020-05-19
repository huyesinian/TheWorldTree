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
            ///将用户IP信息记录到数据库中
            string uIP = HttpContext.Session.GetString("CurrentUser");
            //判断这个用户是不是当天登陆过
            var uCount = _context.TreeIPInfo.Where(x => x.IPAdd == uIP &&x.IPAccessTime.Date==DateTime.Now.Date).Count();
            try
            {
                //
                if (uCount<1)
                {
                    var treeIPInfo = new TreeIPInfo
                    {
                        ID = Guid.NewGuid().ToString(),
                        IPAccessTime = DateTime.Now,
                        IPAdd = uIP
                    };

                    _context.Add(treeIPInfo);
                    _context.SaveChangesAsync();
                }
                ViewBag.IPInfo = JsonConvert.SerializeObject(TreeBaseEX.GetIPinfo());//获取当前年份的每月访问人数
            }
            catch (Exception ex)
            {
                Logger.Info(ex.ToString());
            }

           
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
