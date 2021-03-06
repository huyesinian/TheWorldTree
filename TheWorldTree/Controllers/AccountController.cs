﻿using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TheWorldTree.Controllers
{
    public class AccountController : BaseController
    {
       

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(string userName, string passWord)
        {
            
            var userIP = GetCurrentU();//获取用户IP
            var selResult = Redis.GetClientIPNum(userIP);
            if (selResult.Length > 0)
            {
                return Json(selResult);
            }
            if (Redis.GetLoginResult(userName) == passWord)
            {
                HttpContext.Session.SetString("CurrentUser", userIP);
                return Json(Suc);
            }
            else
            {
                Redis.UpdateClientIPErrorNum(userIP);
                return Json("指令配对失败");
            }
        }
    }
}