using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheWorldTree.Data;
using TheWorldTree.Models;

namespace TheWorldTree.Controllers
{
    /// <summary>
    /// 主页
    /// </summary>
    public class HomeController : BaseVerifyController
    {

        public TheWorldTreeDBContext _context;
        public HomeController(TheWorldTreeDBContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            ///将用户IP信息记录到数据库中
            try
            {
                var treeIPInfo = new TreeIPInfo
                {
                    ID = Guid.NewGuid().ToString(),
                    IPAccessTime = DateTime.Now,
                    IPAdd = HttpContext.Session.GetString("CurrentUser")
                };
                
                _context.Add(treeIPInfo);
                _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Logger.Info(ex.ToString());
            }
            ///

            ///查询需要在首页显示的图表数据
            
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
