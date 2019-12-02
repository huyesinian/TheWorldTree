using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheWorldTree.Data;
using TheWorldTree.Models;

namespace TheWorldTree.Controllers
{
    /// <summary>
    /// 最基本
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// redis相关操作
        /// </summary>
        public static readonly RedisAction Redis = new RedisAction();

        /// <summary>
        /// 日志记录
        /// </summary>
        public static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 数据操作
        /// </summary>
        public readonly TheWorldTreeDBContext _context;

    }
}