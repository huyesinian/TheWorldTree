using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TheWorldTree.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string UserName, string Password)
        {
            //这里获取用户名和密码之后，到redis里面去匹配，并且生成相应的SessionID，添加到redis中

            //这里设置相关的IP限制登陆节点，防止被攻击


            return View();
        }
    }
}