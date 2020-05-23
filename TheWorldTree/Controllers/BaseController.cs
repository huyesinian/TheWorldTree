using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheWorldTree.Data;
using TheWorldTree.Models;
using System.Reflection;

namespace TheWorldTree.Controllers
{
    /// <summary>
    /// 最基本
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// 成功
        /// </summary>
        public  const int  Suc= 1;

        /// <summary>
        /// 失败
        /// </summary>
        public const int Def = 0;

        /// <summary>
        /// redis相关操作
        /// </summary>
        public static readonly RedisAction Redis = new RedisAction();

        /// <summary>
        /// 日志记录
        /// </summary>
        public static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 获取当前用户
        /// </summary>
        /// <returns></returns>
        public string GetCurrentU()
        {
            var user = HttpContext.Connection.RemoteIpAddress.ToString();
            return user;
        }

    }
}