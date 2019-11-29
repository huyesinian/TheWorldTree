﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheWorldTree.Models;

namespace TheWorldTree.Controllers
{
    public class AccountController : Controller
    {
        private readonly RedisAction Redis = new RedisAction();
        private readonly IHttpContextAccessor httpContextAccessor;

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Login(string userName, string passWord)
        {
            var userIP = new IPAddressController(httpContextAccessor).Get().ToString();
            var selResult = Redis.GetClientIPNum(userIP);
            if (selResult.Length > 0)
            {
                return Json(selResult);
            }
            if (Redis.GetLoginResult(userName) == passWord)
            {
                HttpContext.Session.SetString(userName, Guid.NewGuid().ToString());
                return Json(1);
            }
            else
            {
                Redis.UpdateClientIPErrorNum(userIP);
                Redis.SetClientIPDeadLine(userIP);
                return Json("指令配对失败");
            }
        }
    }
}